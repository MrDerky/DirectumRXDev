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
//      var roadmaps = Starkov.RoadMaps.RoadmapEvents.GetAll()
//        .Where(x => x.Date.Value.AddDays(x.DaysComplete).Equals(Calendar.Now.Date));
//      
//      var approvalRule = Sungero.Docflow.ApprovalRuleBases.GetAll(x => x.Name == "Исполнение мероприятий дорожной карты");
//      
//      foreach(var roadmap in roadmaps)
//      {
//        var task = Sungero.Docflow.ApprovalTasks.Create();
//        task.ApprovalRule = approvalRule;
//        task.Subject = string.Format("{0} в срок {1}. {2}", roadmap.EventName, roadmap.Date, roadmap.Note);
//      }
    }

  }
}