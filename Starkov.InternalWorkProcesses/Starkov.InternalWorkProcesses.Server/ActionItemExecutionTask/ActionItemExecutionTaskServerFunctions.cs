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
    public static IActionItemExecutionTask CreateTaskByRmEvent(RoadMaps.IRoadmapEvent rmEvent)
    {
      var task = ActionItemExecutionTasks.Create();
      task.Assignee = rmEvent.Responsible;
      task.Supervisor = rmEvent.Counterparty.Responsible; // Может быть null?
      task.AssignedBy = task.Supervisor; // Возможно просто изменить обязательность
      task.Deadline = rmEvent.Date;
      
      task.OtherGroup.All.Add(rmEvent);
      task.ActiveText = string.Format("{0} в срок {1}. {2}", rmEvent.EventName, rmEvent.Date, rmEvent.Note);
      task.Subject = string.Format("Исполнение мероприятий дорожной карты по «{0}»", rmEvent.Counterparty);
      
      
      return task;
      //TODO добавить мероприятия
      //TODO Добавить формирование имени
      
    }
  }
}