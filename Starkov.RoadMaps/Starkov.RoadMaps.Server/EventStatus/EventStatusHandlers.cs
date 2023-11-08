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

    public override void BeforeSave(Sungero.Domain.BeforeSaveEventArgs e)
    {
      if (_obj.IsDefault.GetValueOrDefault() && _obj.Status == EventStatus.Status.Closed)
        e.AddError(_obj.Info.Properties.IsDefault, "Закрытую запись нельзя установить как статус по умолчанию");
       
      if (!_obj.State.Properties.IsDefault.IsChanged)
        return;
      
      // TODO Возможно будет интереснее, если добавить в сообщение линк на запись справочника либо менять дефолтное значение
      var defaultStatus = Functions.EventStatus.GetDefaultStatus();
      if (defaultStatus != null && _obj.IsDefault.GetValueOrDefault() && !Equals(defaultStatus, _obj))
        e.AddError(_obj.Info.Properties.IsDefault, string.Format("Статус по умолчанию уже установлен: id:{0}, name: {1}.", defaultStatus.Id, defaultStatus.Name));
      
    }

    public override void Created(Sungero.Domain.CreatedEventArgs e)
    {
      _obj.IsExecutable = false;
      _obj.IsDefault = false;
    }
  }

}