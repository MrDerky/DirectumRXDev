using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.Company;

namespace Starkov.InternalWorkProcesses
{
  partial class CompanyRoadmapEventsStarkovStatusPropertyFilteringServerHandler<T>
  {

    public virtual IQueryable<T> RoadmapEventsStarkovStatusFiltering(IQueryable<T> query, Sungero.Domain.PropertyFilteringEventArgs e)
    {
      return query.Where(a => a.Status == RoadMaps.EventStatus.Status.Active);
    }
  }



}