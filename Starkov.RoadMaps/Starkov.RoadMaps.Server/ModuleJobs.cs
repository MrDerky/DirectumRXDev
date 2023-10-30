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
    /// Отбирает записи мероприятий дорожных карт для которых наступил срок выполнения
    /// </summary>
    public virtual void RoadmapsTask()
    {
      var rmEvents = PublicFunctions.RoadmapEvent.GetRunTodayEvent();
      
      foreach(var e in rmEvents)
      {
        var task = InternalWorkProcesses.PublicFunctions.ActionItemExecutionTask.CreateTaskByRmEvent(e);
        task.Start();
      }
    }

  }
}