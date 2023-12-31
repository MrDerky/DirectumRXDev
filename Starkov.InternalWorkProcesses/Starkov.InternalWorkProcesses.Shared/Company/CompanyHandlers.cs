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
      if (e.NewValue.HasValue && _obj.DaysToComplete.HasValue)
        _obj.RunDate = RoadMaps.PublicFunctions.Module.GetCouldRunDate(e.NewValue.Value, _obj.DaysToComplete.GetValueOrDefault());
    }
  }

  partial class CompanyRoadmapEventsStarkovSharedCollectionHandlers
  {

    public virtual void RoadmapEventsStarkovAdded(Sungero.Domain.Shared.CollectionPropertyAddedEventArgs e)
    {
      _added.Responsible = _obj.Responsible ?? Sungero.Company.Employees.Current;
      _added.Status = RoadMaps.PublicFunctions.EventStatus.Remote.GetDefaultStatus();
    }
  }
}