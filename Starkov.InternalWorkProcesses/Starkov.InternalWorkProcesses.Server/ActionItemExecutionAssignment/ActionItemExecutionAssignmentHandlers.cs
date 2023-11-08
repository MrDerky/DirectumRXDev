using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.ActionItemExecutionAssignment;

namespace Starkov.InternalWorkProcesses
{
  partial class ActionItemExecutionAssignmentNewEventStatusStarkovPropertyFilteringServerHandler<T>
  {

    public virtual IQueryable<T> NewEventStatusStarkovFiltering(IQueryable<T> query, Sungero.Domain.PropertyFilteringEventArgs e)
    {
      return query.Where(a => a.Status == RoadMaps.EventStatus.Status.Active);
    }
  }

}