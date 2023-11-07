using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Starkov.InternalWorkProcesses.ActionItemExecutionTask;

namespace Starkov.InternalWorkProcesses
{
  partial class ActionItemExecutionTaskClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      base.Showing(e);
      
      // Утсановка видимости вложений компании
      _obj.State.Attachments.CompanyGroup.IsVisible = _obj.CompanyGroup.Companies.Any();
    }

  }
}