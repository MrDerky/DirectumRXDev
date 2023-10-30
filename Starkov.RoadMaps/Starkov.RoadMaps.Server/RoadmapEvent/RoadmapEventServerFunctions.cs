using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.RoadMaps.RoadmapEvent;

namespace Starkov.RoadMaps.Server
{
  partial class RoadmapEventFunctions
  {
    [Public, Remote]
    public static void CreateRoadMap(string name,
                                     DateTime date,
                                     int daysComplete,
                                     Sungero.Company.IEmployee responsible,
                                     long eventStatusId,
                                     string note,
                                     Sungero.Parties.ICompany counterparty,
                                     long noteId)
    {
      var roadMap = RoadmapEvents.Create();
      roadMap.EventName = name;
      roadMap.Date = date;
      roadMap.DaysComplete = daysComplete;
      roadMap.Responsible = responsible;
      roadMap.EventStatus = EventStatuses.Get(eventStatusId) ?? EventStatuses.GetAll(x => x.Name == "Новое").FirstOrDefault();
      roadMap.Note = note;
      roadMap.Counterparty = counterparty;
      roadMap.NoteId = noteId;
      roadMap.Save();
    }
    
    [Public, Remote]
    public static void UpdateRoadMap(long noteId,
                                     string name,
                                     DateTime date,
                                     int daysComplete,
                                     Sungero.Company.IEmployee responsible,
                                     long eventStatusId,
                                     string note)
    {
      var roadMap = RoadmapEvents.Get(noteId);
      if(roadMap == null)
      {
        Logger.ErrorFormat("<UpdateRoadMap> - Не удалось найти дорожную карту с ИД: {0}", noteId);
        return;
      }
      
      roadMap.EventName = name;
      roadMap.Date = date;
      roadMap.DaysComplete = daysComplete;
      roadMap.Responsible = responsible;
      roadMap.EventStatus = EventStatuses.Get(eventStatusId) ?? EventStatuses.GetAll(x => x.Name == "Новое").FirstOrDefault();
      roadMap.Note = note;
      roadMap.Save();
    }
    
    [Public, Remote]
    public static void DeleteRoadMap(long noteId)
    {
      var roadMap = RoadmapEvents.GetAll(x => x.NoteId == noteId).FirstOrDefault();
      if(roadMap == null)
      {
        Logger.ErrorFormat("<DeleteRoadMap> - Не удалось найти дорожную карту с ИД: {0}", noteId);
        return;
      }
      
      RoadmapEvents.Delete(roadMap);
    }
    
    /// <summary>
    /// Вернуть список событий дорожных карт, задачи по которым должны быть запущены сегодня
    /// </summary>
    /// <returns></returns>
    [Public]
    public static IQueryable<IRoadmapEvent> GetRunTodayEvent()
    {
      var today = Calendar.Now.Date;
      var roadmaps = Starkov.RoadMaps.RoadmapEvents.GetAll()
        .Where(x => Equals(x.Date.Value.AddDays(x.DaysComplete), today));
    }
    
  }
}