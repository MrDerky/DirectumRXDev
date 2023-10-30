using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Initialization;

namespace Starkov.RoadMaps.Server
{
  public partial class ModuleInitializer
  {

    public override void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
    {
      CreateBaseStatusEvent();
      GrantRightsOnDatabooks();
      
    }

    private void CreateBaseStatusEvent()
    {
      if(EventStatuses.GetAll(x => x.Name == "Новое").FirstOrDefault() == null)
      {
        var defaultEventStatus = EventStatuses.Create();
        defaultEventStatus.Name = "Новое";
        defaultEventStatus.Save();
      }
    }
    
    private static void GrantRightsOnDatabooks()
    {
      var managersRole = Sungero.Docflow.PublicInitializationFunctions.Module.GetProjectManagersRole();
      var salesGroup = Sungero.CoreEntities.Groups.GetAll(x => x.Name == "Отдел продаж").FirstOrDefault();
      
      Starkov.RoadMaps.EventStatuses.AccessRights.Grant(managersRole, DefaultAccessRightsTypes.Change);
      Starkov.RoadMaps.EventStatuses.AccessRights.Grant(salesGroup, DefaultAccessRightsTypes.Change);
      Starkov.RoadMaps.EventStatuses.AccessRights.Save();
    }
    
    public override bool IsModuleVisible()
    {
      // На время разработки просто возвращает true;
      return true;
//      var managersRole = Sungero.Docflow.PublicInitializationFunctions.Module.GetProjectManagersRole();
//      var salesGroup = Sungero.CoreEntities.Groups.GetAll(x => x.Name == "Отдел продаж").FirstOrDefault();
//
//      return Users.Current.IncludedIn(managersRole) || Users.Current.IncludedIn(salesGroup);
    }
  }
}
