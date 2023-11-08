using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Workflow;
using Starkov.InternalWorkProcesses.ActionItemExecutionTask;

namespace Starkov.InternalWorkProcesses.Server.ActionItemExecutionTaskBlocks
{

  partial class HandleEventStarkovHandlers
  {

    public virtual void HandleEventStarkovExecute()
    {
      if (!_obj.IsRoadmapTaskStarkov.GetValueOrDefault())
        return;
      
      var rmEvent = _obj.CompanyGroup.Companies.FirstOrDefault().RoadmapEventsStarkov.FirstOrDefault(a => a.CurrentTaskId == _obj.Id)
        ?? RoadMaps.PublicFunctions.Module.GetStartedEventByTask(_obj);
      
      RoadMaps.PublicFunctions.Module.HandleCompletedRoadMapEvent(rmEvent, _block.NewEventStatusStarkov);
    }
  }
  partial class AcceptWorkBySupervisorBlockHandlers
  {

  }
  partial class SendActionItemToNextCoAssigneeBlockHandlers
  {

  }
  partial class WaitForCreateActionItemToAssigneeBlockHandlers
  {

  }
  partial class WaitForUnblockingLeadingAssignmentBlockHandlers
  {

  }
  partial class SendTaskByNextActionItemPartBlockHandlers
  {

  }
  partial class WaitForCompletionActionItemPartsBlockHandlers
  {

  }
  partial class ProcessResultOfExecutionActionItemBlockHandlers
  {

  }
  partial class GrantAccessRightsToDocumentsAndTaskBlockHandlers
  {

  }
}