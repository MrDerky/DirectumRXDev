using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.RoadMaps.EventStatus;

namespace Starkov.RoadMaps.Server
{
  partial class EventStatusFunctions
  {
    
    /// <summary>
    /// Получить статус, установленный как статус по умолчанию
    /// </summary>
    /// <returns>Статус по умолчанию</returns>
    [Remote, Public]
    public static IEventStatus GetDefaultStatus()
    {
      return EventStatuses.GetAll().FirstOrDefault(a => a.IsDefault.GetValueOrDefault());
    }
  }
}