using GameAssistant.Utils;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GameAssistant
{
    public class ClickAutomation
    {
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        // 鼠标点击常量
        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;

        /// <summary>
        /// 单击指定位置
        /// </summary>
        /// <param name="location">点击的位置</param>
        public static void ClickAt(Point location)
        {
            // 设置鼠标位置
            SetCursorPos(location.X, location.Y);
            SleepHelper.RandomSleep();
            // 模拟鼠标点击
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        /// <summary>
        /// 双击指定位置
        /// </summary>
        /// <param name="location">双击的位置</param>
        public static void DoubleClickAt(Point location)
        {
            // 设置鼠标位置
            SetCursorPos(location.X, location.Y);
            SleepHelper.RandomSleep();

            // 模拟第一次点击
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            // 添加短暂延迟，模拟真实的双击行为
            System.Threading.Thread.Sleep(100);

            // 模拟第二次点击
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
}
