using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Starkov.RoadMaps.Server
{
  public class ModuleFunctions
  {
    [Public]
    public IQueryable<InternalWorkProcesses.ICompanyRoadmapEventsStarkov> GetRunTodayRMEvents()
    {
      return null; 
    }
  }
}