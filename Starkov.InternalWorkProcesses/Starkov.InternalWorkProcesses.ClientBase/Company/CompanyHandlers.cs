using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.Company;

namespace Starkov.InternalWorkProcesses
{
  partial class CompanyRoadmapEventsStarkovClientHandlers
  {

    public virtual void RoadmapEventsStarkovDaysToCompleteValueInput(Sungero.Presentation.IntegerValueInputEventArgs e)
    {
      if(e.NewValue < 0)
      {
        e.AddError("Значение должно быть больше 0.");
      }
    }
  }

  partial class CompanyClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
//      base.Showing(e);
//      var managersRole = Sungero.Docflow.PublicInitializationFunctions.Module.GetProjectManagersRole();
//      var salesGroup = Sungero.CoreEntities.Groups.GetAll(x => x.Name == "Отдел продаж").FirstOrDefault();
//
//      if(!Users.Current.IncludedIn(managersRole) && !Users.Current.IncludedIn(salesGroup))
//        _obj.State.Pages.PageStarkov.IsVisible = false;
//      _obj.State.Pages.PageStarkov.
    }

  }
}