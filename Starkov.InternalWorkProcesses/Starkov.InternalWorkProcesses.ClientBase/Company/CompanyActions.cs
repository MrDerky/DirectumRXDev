using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.Company;

namespace Starkov.InternalWorkProcesses.Client
{
  partial class CompanyActions
  {
    public virtual void ImportRoadmapStarkov(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      
    }

    public virtual bool CanImportRoadmapStarkov(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return true;
    }

    public virtual void AllTasksStarkov(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      var tasks = Sungero.Docflow.ApprovalTasks.GetAll()
        .Where(x => x.ApprovalRule.Name == "Исполнение мероприятий дорожной карты");
      
      if(tasks.Count() == 0)
      {
        Dialogs.ShowMessage("Задачи не формировались");
      }
      else
      {
        tasks.Show();
      }
    }

    public virtual bool CanAllTasksStarkov(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return true;
    }

  }

  partial class CompanyRoadmapEventsStarkovActions
  {

    public virtual bool CanTaskStarkov(Sungero.Domain.Client.CanExecuteChildCollectionActionArgs e)
    {
      return true;
    }

    public virtual void TaskStarkov(Sungero.Domain.Client.ExecuteChildCollectionActionArgs e)
    {
      var tasks = Sungero.Docflow.ApprovalTasks.GetAll()
        .Where(x => x.ApprovalRule.Name == "Исполнение мероприятий дорожной карты")
        .Where(x => x.Addressee.Equals(_obj.Responsible))
        .Where(x => x.Subject == _obj.Name);
      
      if(tasks.Count() == 0)
      {
        Dialogs.ShowMessage("Задачи по данному мероприятию не формировались");
      }
      else
      {
        tasks.Show();
      }
    }
  }

  partial class CompanyAnyChildEntityCollectionActions
  {
    public override void DeleteChildEntity(Sungero.Domain.Client.ExecuteChildCollectionActionArgs e)
    {
      var root = Companies.As(e.RootEntity);
      if (root != null && _all == root.RoadmapEventsStarkov)
        RoadMaps.PublicFunctions.RoadmapEvent.Remote.DeleteRoadMap(_objs.FirstOrDefault().Id);
      base.DeleteChildEntity(e);
    }

    public override bool CanDeleteChildEntity(Sungero.Domain.Client.CanExecuteChildCollectionActionArgs e)
    {
      return base.CanDeleteChildEntity(e);
    }

  }

}