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
    
    //TODO добавить summary
    [Public]
    public static void CreateQueueItemByEvent(InternalWorkProcesses.ICompanyRoadmapEventsStarkov rmEvent, long? taskId, long? eventStatusId)
    {
      var item = EventProcessingQueueItems.Create();
      
      item.EventId = rmEvent.Id;
      item.CompanyId = rmEvent.RootEntity.Id;
      item.Type = taskId.HasValue ? RoadMaps.EventProcessingQueueItem.Type.TaskStarted : RoadMaps.EventProcessingQueueItem.Type.TaskCompleted;
      item.EventStatusId = eventStatusId;
      item.TaskId = taskId;
      
      item.Save();
    }
    
    //TODO добавить summary
    [Public]
    public static IEventProcessingQueueItem GetStartedQueueItemByTaskId(long id)
    {
      return EventProcessingQueueItems.GetAll().Where(b => b.Type == RoadMaps.EventProcessingQueueItem.Type.TaskStarted).FirstOrDefault(a => a.TaskId == id);
    }
    
    // TODO добавить summary
    public static bool IsQueueItemByCompletedEventAndNewStatusId(InternalWorkProcesses.ICompanyRoadmapEventsStarkov rmEvent, long statusId)
    {
      return EventProcessingQueueItems.GetAll().Where(a => a.EventId == rmEvent.Id)
        .Where(b => b.EventStatusId == statusId)
        .Any(c => c.Type == RoadMaps.EventProcessingQueueItem.Type.TaskCompleted);
    }
  }
}