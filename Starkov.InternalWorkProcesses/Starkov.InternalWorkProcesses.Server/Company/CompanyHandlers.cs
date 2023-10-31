using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.Company;

namespace Starkov.InternalWorkProcesses
{
  partial class CompanyServerHandlers
  {

    public override void Saved(Sungero.Domain.SavedEventArgs e)
    {
      base.Saved(e);
      //      var roadMapRows = _obj.RoadmapEventsStarkov;
      //      foreach(var roadMapRow in roadMapRows)
      //      {
      //        var existRoadMap = Starkov.RoadMaps.RoadmapEvents.GetAll(x => x.NoteId == roadMapRow.Id).FirstOrDefault();
      //        if(existRoadMap != null)
      //        {
      //          Starkov.RoadMaps.PublicFunctions.RoadmapEvent.Remote.UpdateRoadMap(existRoadMap.Id,
      //                                                                             roadMapRow.EventName,
      //                                                                             roadMapRow.Date.Value,
      //                                                                             roadMapRow.DaysComplete.Value,
      //                                                                             roadMapRow.Responsible,
      //                                                                             roadMapRow.EventStatus.Id,
      //                                                                             roadMapRow.Note);
      //        }
      //        else
      //        {
      //          Starkov.RoadMaps.PublicFunctions.RoadmapEvent.Remote.CreateRoadMap(roadMapRow.EventName,
      //                                                                             roadMapRow.Date.Value,
      //                                                                             roadMapRow.DaysComplete.Value,
      //                                                                             roadMapRow.Responsible,
      //                                                                             roadMapRow.EventStatus.Id,
      //                                                                             roadMapRow.Note,
      //                                                                             _obj,
      //                                                                             roadMapRow.Id);
      //        }
      //      }
      //    }
    }
  }

}