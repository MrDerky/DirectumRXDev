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
    /// Создать задачи по мероприятиям дорожной карты
    /// </summary>
    public virtual void RoadmapsTask()
    {
      var rmEvents = PublicFunctions.Module.GetRunTodayRMEvents();
      
      foreach(var e in rmEvents)
      {
        if (Locks.GetLockInfo(e.RootEntity).IsLocked)
        {
          Logger.DebugFormat("Source: {0}; Message: Unable create to task by roadmap event (id: {1}); Reason: Company entity (id: {2}) is locked", this.ToString(), e.Id, e.RootEntity.Id);
          continue;
        }
        
        var task = InternalWorkProcesses.PublicFunctions.ActionItemExecutionTask.CreateTaskByRmEvent(e);
        
        task.Start();
      }
    }

  }
}