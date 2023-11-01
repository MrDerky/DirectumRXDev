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
        var task = InternalWorkProcesses.PublicFunctions.ActionItemExecutionTask.CreateTaskByRmEvent(e);
        task.Start();
      }
    }

  }
}