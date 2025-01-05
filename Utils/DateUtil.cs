using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Utils
{
    public static class DateUtil
    {
        public static bool IsWednesdayToSunday()
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
            return today >= DayOfWeek.Wednesday && today <= DayOfWeek.Sunday;
        }
    }
}
