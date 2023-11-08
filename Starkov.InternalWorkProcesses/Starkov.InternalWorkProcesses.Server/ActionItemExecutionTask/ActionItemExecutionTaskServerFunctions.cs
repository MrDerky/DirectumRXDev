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
    
    /// <summary>
    /// Создать задачу по мероприятию
    /// </summary>
    /// <param name="rmEvent">Мероприятие</param>
    /// <returns>Задача</returns>
    [Public]
    public static InternalWorkProcesses.IActionItemExecutionTask CreateTaskByRmEvent(InternalWorkProcesses.ICompanyRoadmapEventsStarkov rmEvent)
    {
      
      
      var task = ActionItemExecutionTasks.Create();
      task.Assignee = rmEvent.Responsible;
      // TODO Решить вопрос с ответсвенным за контрагента
      task.Supervisor = rmEvent.Company.Responsible; // Может быть null?
      task.AssignedBy = task.Supervisor; // Возможно просто изменить обязательность в компании
      task.Deadline = rmEvent.Deadline;
      task.IsRoadmapTaskStarkov = true;
      
      task.CompanyGroup.Companies.Add(InternalWorkProcesses.Companies.As(rmEvent.RootEntity));
      task.ActiveText = string.Format("{0} в срок {1}. {2}", rmEvent.Name, rmEvent.Deadline, rmEvent.Note);
      task.Subject = string.Format("Исполнение мероприятий дорожной карты по «{0}»", rmEvent.Company);
      
      return task;
      //TODO Добавить формирование имени
      
    }
    
    
    /// <summary>
    /// Получить задачу по od
    /// </summary>
    /// <param name="id">Id задачи</param>
    /// <returns>Задача</returns>
    [Remote(IsPure = true), Public]
    public static InternalWorkProcesses.IActionItemExecutionTask GetTaskById(long id)
    {
      return ActionItemExecutionTasks.GetAll().FirstOrDefault(a => a.Id == id);
    }
  }
}