using System;
using System.Threading;

namespace GameAssistant.Utils
{
    public static class SleepHelper
    {
        private static readonly ThreadLocal<Random> RandomGenerator = new ThreadLocal<Random>(() => new Random());


        /// <summary>
        /// 在两个秒数范围内随机延迟。
        /// </summary>
        /// <param name="minSeconds">最小秒数。</param>
        /// <param name="maxSeconds">最大秒数。</param>
        public static void RandomSleep(double minSeconds = 13, double maxSeconds = 16)
        {
            if (minSeconds < 0 || maxSeconds < 0)
            {
                throw new ArgumentException("时间范围不能为负！");
            }

            if (minSeconds > maxSeconds)
            {
                throw new ArgumentException("最小秒数不能大于最大秒数！");
            }
            SleepWithinRange(minSeconds, maxSeconds);
        }

        /// 延迟执行。
        /// </summary>
        /// <param name="seconds">延迟时间（秒）。</param>
        public static void DelayExecution(int seconds)
        {
            if (seconds > 0)
            {
                Thread.Sleep(seconds * 1000);
            }
        }

        /// <summary>
        /// 在给定秒数的正负 0.5 秒范围内延迟，最少为 0 秒。
        /// </summary>
        /// <param name="seconds">基准秒数。</param>
        public static void FluctuatingSleep(double seconds = 0.6)
        {

            // 计算波动范围
            double minSeconds = Math.Max(0, seconds - 0.5);
            double maxSeconds = Math.Max(0, seconds + 0.5);

            SleepWithinRange(minSeconds, maxSeconds);
        }

        private static void SleepWithinRange(double minSeconds, double maxSeconds)
        {
            var seconds = RandomGenerator.Value.NextDouble() * (maxSeconds - minSeconds) + minSeconds;
            int sleepMilliseconds = (int)(seconds * 1000);
            Thread.Sleep(sleepMilliseconds);
        }
    }
}
