using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.ActionItemExecutionAssignment;

namespace Starkov.InternalWorkProcesses
{
  partial class ActionItemExecutionAssignmentClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      base.Showing(e);
       
      var task = InternalWorkProcesses.PublicFunctions.ActionItemExecutionTask.Remote.GetTaskById(_obj.Task.Id);
      var isRoadmapTask = task.IsRoadmapTaskStarkov.GetValueOrDefault();
      _obj.State.Attachments.CompanyGroup.IsVisible = isRoadmapTask;
      _obj.State.Properties.NewEventStatusStarkov.IsVisible = isRoadmapTask;
      _obj.State.Properties.NewEventStatusStarkov.IsRequired = isRoadmapTask; 
    }
  }

}