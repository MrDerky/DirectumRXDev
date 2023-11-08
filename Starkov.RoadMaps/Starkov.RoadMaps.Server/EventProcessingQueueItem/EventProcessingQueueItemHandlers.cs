using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.RoadMaps.EventProcessingQueueItem;

namespace Starkov.RoadMaps
{
  partial class EventProcessingQueueItemServerHandlers
  {

    public override void Created(Sungero.Domain.CreatedEventArgs e)
    {
      _obj.CreateDateTime = Calendar.Now;
    }
  }

}