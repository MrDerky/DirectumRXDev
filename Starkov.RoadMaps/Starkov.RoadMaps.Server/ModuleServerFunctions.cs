using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Starkov.RoadMaps.Server
{
  public class ModuleFunctions
  {
    
    /// <summary>
    /// Получить коллекцию мероприятий дорожной карты
    /// </summary>
    /// <returns>Коллекция мероприятий</returns>
    [Public]
    public IQueryable<InternalWorkProcesses.ICompanyRoadmapEventsStarkov> GetRunTodayRmEvents()
    {
      var today = Calendar.Today.Date;
      var query = InternalWorkProcesses.Companies.GetAll()
        .Where(d => d.RoadmapEventsStarkov.Any(e => e.Status.IsExecutable.GetValueOrDefault()))
        .SelectMany(a => a.RoadmapEventsStarkov
                    .Where(b => b.Status.IsExecutable.GetValueOrDefault())
                    .Where(e => !e.CurrentTaskId.HasValue)
                    .Where(c => c.RunDate <=  today))
        .Cast<InternalWorkProcesses.ICompanyRoadmapEventsStarkov>();
      
      return query;
    }
    
    //TODO добавить summary
    [Public]
    public InternalWorkProcesses.ICompanyRoadmapEventsStarkov GetRmEventByCompanyIdAndId(long companyId, long eventId)
    {
      
      
      return InternalWorkProcesses.Companies
        .GetAll(a => a.Id == companyId)
        .FirstOrDefault()?
        .RoadmapEventsStarkov
        .FirstOrDefault(b => b.Id == eventId);
      
    }
    
    
    //TODO добавить summary
    [Public]
    public InternalWorkProcesses.ICompanyRoadmapEventsStarkov GetEventByTask(InternalWorkProcesses.IActionItemExecutionTask task)
    {
      var rmEvent = InternalWorkProcesses.Companies.GetAll()
        .FirstOrDefault(a => a.Id == task.CompanyGroup.Companies.FirstOrDefault().Id)
        ?.RoadmapEventsStarkov
        .FirstOrDefault(b => b.CurrentTaskId == task.Id);
      
      if (rmEvent != null)
        return rmEvent;
      
      var queueItem = RoadMaps.PublicFunctions.EventProcessingQueueItem.GetStartedQueueItemByTaskId(task.Id);
      return GetRmEventByCompanyIdAndId(queueItem.CompanyId.GetValueOrDefault(), queueItem.EventId.GetValueOrDefault());
    }
    
    
    // TODO добавить summary
    [Public]
    public void HandleCompletedRoadMapEvent(InternalWorkProcesses.ICompanyRoadmapEventsStarkov rmEvent, IEventStatus status)
    {
      // Проверить родителя на наличие блокировок
      if (Functions.Module.IsEventRootLocked(rmEvent, this.ToString(), RoadMaps.Resources.LockWarningTaskCompleted))
      {
        Functions.EventProcessingQueueItem.CreateQueueItemByEvent(rmEvent, null, status.Id);
        return;  
      }
      
      rmEvent.Status = status;
      rmEvent.CurrentTaskId = null;
      Functions.EventProcessingQueueItem.RemoveQueueItemsByEventId(rmEvent.Id);
    }
    
  }
}