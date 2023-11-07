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
      // Установить статус, указанный исполнителем мероприятию, по которому запущена задача
      
      var company = _obj.CompanyGroup.Companies.FirstOrDefault();
      var rmEvent = company.RoadmapEventsStarkov.FirstOrDefault(a => a.Id == _obj.Id);
      
      // TODO Возможна ошибка при передаче значения в метод получения эвента? потестить
      var evId = RoadMaps.EventProcessingQueueItems.GetAll()
        .Where(a => a.CompanyId == company.Id)
        .Where(a => a.TaskId == _obj.Id)
        .Select(b => b.Id)
        .FirstOrDefault();
      
      
      if (rmEvent == null)
        rmEvent = RoadMaps.PublicFunctions.Module.GetRmEventById(_obj.CompanyGroup.Companies.FirstOrDefault().Id, evId);
      
      
      
    }
  }

  partial class ExecuteActionItemBlockHandlers
  {

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