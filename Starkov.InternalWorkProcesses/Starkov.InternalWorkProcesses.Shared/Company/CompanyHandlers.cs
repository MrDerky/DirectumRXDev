using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.Company;

namespace Starkov.InternalWorkProcesses
{
  partial class CompanyRoadmapEventsStarkovSharedCollectionHandlers
  {

    public virtual void RoadmapEventsStarkovAdded(Sungero.Domain.Shared.CollectionPropertyAddedEventArgs e)
    {
      _added.Responsible = _obj.Responsible != null ? _obj.Responsible : Sungero.Company.Employees.As(Users.Current);
      _added.EventStatus = Starkov.RoadMaps.EventStatuses.GetAll(x => x.Name == "Новое").FirstOrDefault();
    }
  }

  partial class CompanySharedHandlers
  {

  }
}