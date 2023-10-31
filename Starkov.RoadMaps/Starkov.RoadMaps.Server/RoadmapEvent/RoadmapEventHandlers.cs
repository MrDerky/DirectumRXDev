using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.RoadMaps.RoadmapEvent;

namespace Starkov.RoadMaps
{
  partial class RoadmapEventServerHandlers
  {

    public override void BeforeSave(Sungero.Domain.BeforeSaveEventArgs e)
    {
      base.BeforeSave(e);
      _obj.CouldRun = RoadMaps.Functions.Module.GetCouldRunDate(_obj.Deadline, _obj.DaysToComplete.GetValueOrDefault());
    }
  }

}