using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Infrastructure.Utils
{
    public static class DateTimeUtil
    {
        public static bool IsWednesdayToSunday()
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
            // 将周三到周日的枚举值转为一个数组
            DayOfWeek[] validDays = new[]
            {
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };

            return Array.Exists(validDays, day => day == today);
        }


        // 判断是否符合周期
        public static bool IsTaskDue(string firstRunDateString, int cycleDays)
        {
            // 尝试将字符串转换为日期
            DateTime firstRunDate;
            if (!DateTime.TryParse(firstRunDateString, out firstRunDate))
            {
                throw new ArgumentException("无效的日期格式", nameof(firstRunDateString));
            }

            // 获取当前日期
            DateTime currentDate = DateTime.Today;

            // 计算从第一次执行到现在的天数差
            TimeSpan timeDifference = currentDate - firstRunDate;

            // 如果天数差可以被周期天数整除，则返回true，表示任务可以执行
            return timeDifference.Days % cycleDays == 0;
        }



        public static bool IsAfternoon()
        {
            return DateTime.Now.Hour >= 12;
        }

        /// <summary>
        /// 判断当前时间是否在指定的时间范围内。
        /// </summary>
        /// <param name="startTime">时间范围的起始时间，格式为"HH:mm"，可以为 null。</param>
        /// <param name="endTime">时间范围的结束时间，格式为"HH:mm"，可以为 null。</param>
        /// <returns>如果当前时间在范围内返回 true，否则返回 false。</returns>
        public static bool IsWithinTimeRange(string startTime, string endTime)
        {
            TimeSpan? start = null;
            TimeSpan? end = null;

            if (!string.IsNullOrEmpty(startTime))
            {
                if (!TimeSpan.TryParse(startTime, out TimeSpan parsedStart))
                {
                    throw new ArgumentException("无效的时间格式，应为HH:mm", nameof(startTime));
                }
                start = parsedStart;
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                if (!TimeSpan.TryParse(endTime, out TimeSpan parsedEnd))
                {
                    throw new ArgumentException("无效的时间格式，应为HH:mm", nameof(endTime));
                }
                end = parsedEnd;
            }

            TimeSpan now = DateTime.Now.TimeOfDay;

            bool isAfterStart = start == null || now > start;
            bool isBeforeEnd = end == null || now < end;

            return isAfterStart && isBeforeEnd;
        }

    }
}
