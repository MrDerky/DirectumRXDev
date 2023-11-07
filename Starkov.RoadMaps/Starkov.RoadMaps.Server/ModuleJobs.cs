using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Starkov.RoadMaps.Server
{
  public class ModuleJobs
  {

    /// <summary>
    /// Обработать мероприятия дорожной карты
    /// </summary>
    public virtual void RoadmapsTask()
    {
      // TODO Протестировать обработку очереди, какое будет поведение если в очереди будут накапливаться события, 
      // что если события закрытия мероприятия будут обрабатываться раньше чем открытия
      
      // Обработка очереди отложенных задания
      var queue = EventProcessingQueueItems.GetAll();
      foreach (var i in queue)
        HandleQueueItem(i);
      
      // Обработка мероприятий
      var rmEvents = PublicFunctions.Module.GetRunTodayRmEvents();
      foreach(var e in rmEvents)
      {
        if (queue.Any(a => a.EventId == e.Id))
          continue;
        
        var task = InternalWorkProcesses.PublicFunctions.ActionItemExecutionTask.CreateTaskByRmEvent(e);
        //HACK Если запускать обработку мероприятия после запуска задачи, то установка id текущей задачи в мероприятие не происходит
        HandleRunningEvent(e, null, task.Id);
        task.Start();
      }
    }
    
    
    /// <summary>
    /// Обработать элемент очереди
    /// </summary>
    /// <param name="item">Элемент очереди</param>
    private void HandleQueueItem(IEventProcessingQueueItem item)
    {
      var rmEvent = RoadMaps.PublicFunctions.Module.GetRmEventById(item.CompanyId.GetValueOrDefault(), item.EventId.GetValueOrDefault());
      
      if (item.Type == RoadMaps.EventProcessingQueueItem.Type.TaskStarted)
        HandleRunningEvent(rmEvent, item, null);
      else
        HandleCompletedEvent(rmEvent, item);
    }

    
    /// <summary>
    /// Обработать элемент очереди по стартованной
    /// </summary>
    /// <param name="rmEvent">Мероприятие</param>
    /// <param name="item">Элемент очереди</param>
    /// <param name="inputTaskId">Id задачи</param>
    private void HandleRunningEvent(InternalWorkProcesses.ICompanyRoadmapEventsStarkov rmEvent, IEventProcessingQueueItem item, long? inputTaskId)
    {
      if (item == null)
      { 
        if (IsLocked(rmEvent, RoadMaps.Resources.LockWarningTaskStarted))
          RoadMaps.PublicFunctions.EventProcessingQueueItem.CreateQueueItemByEvent(rmEvent, inputTaskId, null);
        else
          rmEvent.CurrentTaskId = inputTaskId;
      }
      else
      {
        if (IsLocked(rmEvent, RoadMaps.Resources.LockWarningTaskStarted))
          return;
        
        rmEvent.CurrentTaskId = item.TaskId;
        RoadMaps.EventProcessingQueueItems.Delete(item);
      }
    }
    
    /// <summary>
    /// Обработать элемент очереди по замершенной задаче
    /// </summary>
    /// <param name="rmEvent">Мероприятие</param>
    /// <param name="item">Элемент очереди</param>
    private void HandleCompletedEvent(InternalWorkProcesses.ICompanyRoadmapEventsStarkov rmEvent, IEventProcessingQueueItem item)
    {
      if (IsLocked(rmEvent, RoadMaps.Resources.LockWarningTaskCompleted))
        return;
      
      rmEvent.CurrentTaskId = null;
      RoadMaps.EventProcessingQueueItems.Delete(item);
    }
    
    
    /// <summary>
    /// Проверить родительскую сущность на наличие блокировки
    /// </summary>
    /// <param name="rmEvent">Сущность мероприятия</param>
    /// <param name="message">Шаблон сообщения для логгера</param>
    /// <returns>Если сущность заблокирована - True, если нет - False</returns>
    private bool IsLocked(InternalWorkProcesses.ICompanyRoadmapEventsStarkov rmEvent, string message)
    {
      var result = Locks.GetLockInfo(rmEvent.RootEntity).IsLocked;
      if (result)
        Logger.DebugFormat(message, this.ToString(), rmEvent.Id, rmEvent.RootEntity.Id);
      
      return result;
    }

  }
}