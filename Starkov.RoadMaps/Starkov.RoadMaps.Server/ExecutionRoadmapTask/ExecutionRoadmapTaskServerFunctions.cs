using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.RoadMaps.ExecutionRoadmapTask;

namespace Starkov.RoadMaps.Server
{
  partial class ExecutionRoadmapTaskFunctions
  {
    
    [Public]
    public static IExecutionRoadmapTask CreateTaskByEvent(IRoadmapEvent roadmapEvent)
    {
      var task = ExecutionRoadmapTasks.Create();
      task.
    }
  }
}