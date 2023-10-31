using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.Company;

namespace Starkov.InternalWorkProcesses
{
  partial class CompanyRoadmapEventsStarkovSharedHandlers
  {

    public virtual void RoadmapEventsStarkovDaysToCompleteChanged(Sungero.Domain.Shared.IntegerPropertyChangedEventArgs e)
    {
      if (e.NewValue.HasValue && _obj.Deadline.HasValue)
        _obj.RunDate = RoadMaps.PublicFunctions.Module.GetCouldRunDate(_obj.Deadline, e.NewValue.Value);
    }

    public virtual void RoadmapEventsStarkovDeadlineChanged(Sungero.Domain.Shared.DateTimePropertyChangedEventArgs e)
    {
      if (e.NewValue.HasValue != null && _obj.DaysToComplete.HasValue)
        _obj.RunDate = RoadMaps.PublicFunctions.Module.GetCouldRunDate(e.NewValue.Value, _obj.DaysToComplete.GetValueOrDefault());
    }
  }

  partial class CompanySharedHandlers
  {

    public virtual void RoadmapEventsStarkovChanged(Sungero.Domain.Shared.CollectionPropertyChangedEventArgs e)
    {
      
    }
  }

  partial class CompanyRoadmapEventsStarkovSharedCollectionHandlers
  {

    public virtual void RoadmapEventsStarkovAdded(Sungero.Domain.Shared.CollectionPropertyAddedEventArgs e)
    {
      _added.Responsible = _obj.Responsible != null ? _obj.Responsible : Sungero.Company.Employees.As(Users.Current);
      _added.Status = Starkov.RoadMaps.EventStatuses.GetAll(x => x.Name == "Новое").FirstOrDefault();
    }
  }
}