using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Starkov.RoadMaps.Shared
{
  public class ModuleFunctions
  {
    /// <summary>
    /// Получить дату запуска работ по мероприятию
    /// </summary>
    /// <param name="date">Дата завершения работ</param>
    /// <param name="daysCount">Количество дней на работы</param>
    /// <returns>Дата запуска работ</returns>
    [Public]
    public DateTime? GetCouldRunDate(DateTime? date, int daysCount)
    {
      if (date == null || daysCount < 0)
        return null;
      
      return date.GetValueOrDefault().Subtract(TimeSpan.FromDays((double)daysCount));
    }
  }
}