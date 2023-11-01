using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.RoadMaps.EventStatus;

namespace Starkov.RoadMaps
{
  partial class EventStatusServerHandlers
  {

    public override void Created(Sungero.Domain.CreatedEventArgs e)
    {
      _obj.IsExecutable = false;
    }
  }

}