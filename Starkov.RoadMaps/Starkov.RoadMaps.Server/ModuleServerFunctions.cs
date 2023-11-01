using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Starkov.RoadMaps.Server
{
  public class ModuleFunctions
  {
    
    /// <summary>
    /// Получить коллекцию мероприятий дорожной карты
    /// </summary>
    /// <returns>Коллекция мероприятий</returns>
    [Public]
    public IQueryable<InternalWorkProcesses.ICompanyRoadmapEventsStarkov> GetRunTodayRMEvents()
    {
      var today = Calendar.Today.Date;
      var query = InternalWorkProcesses.Companies.GetAll()
        .Where(d => d.RoadmapEventsStarkov.Any(e => e.Status.IsExecutable.GetValueOrDefault()))
        .SelectMany(a => a.RoadmapEventsStarkov
                    .Where(b => b.Status.IsExecutable.GetValueOrDefault())
                    .Where(c => c.RunDate <=  today))
        .Cast<InternalWorkProcesses.ICompanyRoadmapEventsStarkov>();
      
      return query;
    }
  }
}