using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.ActionItemExecutionTask;

namespace Starkov.InternalWorkProcesses.Server
{
  partial class ActionItemExecutionTaskFunctions
  {
    [Public]
    public static InternalWorkProcesses.IActionItemExecutionTask CreateTaskByRmEvent(InternalWorkProcesses.ICompanyRoadmapEventsStarkov rmEvent)
    {
      var task = ActionItemExecutionTasks.Create();
      task.Assignee = rmEvent.Responsible;
      task.Supervisor = rmEvent.Company.Responsible; // Может быть null?
      task.AssignedBy = task.Supervisor; // Возможно просто изменить обязательность
      task.Deadline = rmEvent.Deadline;
      
      task.OtherGroup.All.Add(rmEvent.RootEntity);
      task.ActiveText = string.Format("{0} в срок {1}. {2}", rmEvent.Name, rmEvent.Deadline, rmEvent.Note);
      task.Subject = string.Format("Исполнение мероприятий дорожной карты по «{0}»", rmEvent.Company);
      
      return task;
      //TODO добавить мероприятия
      //TODO Добавить формирование имени
      
    }
  }
}