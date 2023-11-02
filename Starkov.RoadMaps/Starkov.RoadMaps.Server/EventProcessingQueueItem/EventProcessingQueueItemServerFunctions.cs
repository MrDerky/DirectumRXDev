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
  }
}