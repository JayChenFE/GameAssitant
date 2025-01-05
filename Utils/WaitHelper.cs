using System;
using System.Drawing;
using System.Threading;

namespace GameAssistant.Utils
{
    public static class WaitHelper
    {
        /// <summary>
        /// 等待画面切换完成（动态等待）
        /// </summary>
        /// <param name="condition">条件检查函数，返回 true 表示条件满足</param>
        /// <param name="timeoutSeconds">最大等待时间</param>
        /// <param name="pollIntervalMilliseconds">轮询间隔（毫秒）</param>
        /// <returns>条件是否满足</returns>
        public static bool WaitForCondition(Func<bool> condition, int timeoutSeconds = 5, int pollIntervalMilliseconds = 100)
        {
            var startTime = Environment.TickCount;

            while (Environment.TickCount - startTime < timeoutSeconds * 1000)
            {
                if (condition())
                {
                    return true;
                }

                Thread.Sleep(pollIntervalMilliseconds); // 间隔检查
            }

            return false; // 超时未满足条件
        }
    }
}
