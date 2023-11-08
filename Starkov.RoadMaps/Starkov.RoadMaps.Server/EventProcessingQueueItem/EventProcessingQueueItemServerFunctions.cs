using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.RoadMaps.EventProcessingQueueItem;

namespace Starkov.RoadMaps.Server
{
  partial class EventProcessingQueueItemFunctions
  {
    
    /// <summary>
    /// Создать элемент очереди по мероприятию
    /// </summary>
    /// <param name="rmEvent">Мероприятие</param>
    /// <param name="taskId">Id задачи по мероприятию</param>
    /// <param name="eventStatusId">Id статуса мероприятия</param>
    public static void CreateQueueItemByEvent(InternalWorkProcesses.ICompanyRoadmapEventsStarkov rmEvent, long? taskId, long? eventStatusId)
    {
      var item = EventProcessingQueueItems.Create();
      
      item.EventId = rmEvent.Id;
      item.CompanyId = rmEvent.RootEntity.Id;
      item.Type = taskId.HasValue
        ? RoadMaps.EventProcessingQueueItem.Type.TaskStarted
        : RoadMaps.EventProcessingQueueItem.Type.TaskCompleted;
      item.EventStatusId = eventStatusId;
      item.TaskId = taskId;
      
      item.Save();
    }
    
    
    /// <summary>
    /// Получить элемент очереди по задаче
    /// </summary>
    /// <param name="id">Id задачи</param>
    /// <returns>Элемент очереди</returns>
    public static IEventProcessingQueueItem GetStartedQueueItemByTaskId(long id)
    {
      return EventProcessingQueueItems.GetAll()
        .Where(b => b.Type == RoadMaps.EventProcessingQueueItem.Type.TaskStarted)
        .FirstOrDefault(a => a.TaskId == id);
    }
    
    
    /// <summary>
    /// Получить последние элементы очереди по мероприятиям
    /// </summary>
    /// <returns>Коллекция элементов очереди</returns>
    public static System.Collections.Generic.IEnumerable<RoadMaps.IEventProcessingQueueItem> GetLastQueueItemsByEvent()
    {
      var itemGrups = EventProcessingQueueItems.GetAll().GroupBy(a => a.EventId);
      var items = new List<RoadMaps.IEventProcessingQueueItem>();
      
      foreach (var ig in itemGrups)
      {
        var maxDate = ig.Select(a => a.CreateDateTime).Max();
        items.Add(ig.FirstOrDefault(a => a.CreateDateTime == maxDate));
      }
        
      return items;
    }
    
    
    /// <summary>
    /// Удалить элементы очереди по id мероприятия
    /// </summary>
    /// <param name="id">Id мероприятия</param>
    public static void RemoveQueueItemsByEventId(long id)
    {
      var items = EventProcessingQueueItems.GetAll().Where(a => a.EventId == id);
      
      foreach (var i in items)
        EventProcessingQueueItems.Delete(i);
    }

  }
}