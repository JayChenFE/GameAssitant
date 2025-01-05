using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GameAssistant
{
    public static class MouseAutomation
    {
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        // 鼠标事件常量
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_WHEEL = 0x0800;
        private const uint MOUSEEVENTF_MOVE = 0x0001;

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        }

        /// <summary>
        /// 枚举表示鼠标拖动方向
        /// </summary>
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        /// <summary>
        /// 单击指定位置
        /// </summary>
        public static void ClickAt(Point location)
        {
            MoveTo(location);
            PressAndRelease(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);
        }

        /// <summary>
        /// 双击指定位置
        /// </summary>
        public static void DoubleClickAt(Point location)
        {
            MoveTo(location);
            PressAndRelease(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);
            System.Threading.Thread.Sleep(100); // 模拟双击间隔
            PressAndRelease(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);
        }

        /// <summary>
        /// 滚轮向下滚动
        /// </summary>
        public static void ScrollDown(int amount = 1)
        {
            if (amount < 1) throw new ArgumentException("滚动量必须大于等于 1");
            uint scrollAmount = unchecked((uint)(-120 * amount));
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, scrollAmount, 0);
        }

        /// <summary>
        /// 按住鼠标左键并拖动
        /// </summary>
        public static void DragMouse(int pixels, Direction direction)
        {
            if (pixels <= 0) throw new ArgumentException("移动的像素数必须大于 0");

            if (GetCursorPos(out Point currentPos))
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0); // 按下鼠标左键

                for (int step = 1; step <= pixels; step++)
                {
                    int deltaX = 0, deltaY = 0;

                    switch (direction)
                    {
                        case Direction.Left:
                            deltaX = -1;
                            break;
                        case Direction.Right:
                            deltaX = 1;
                            break;
                        case Direction.Up:
                            deltaY = -1;
                            break;
                        case Direction.Down:
                            deltaY = 1;
                            break;
                    }

                    SimulateMouseMove(deltaX, deltaY); // 使用低级输入模拟鼠标移动

                    System.Threading.Thread.Sleep(1); // 平滑移动
                }

                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0); // 松开鼠标左键
            }
            else
            {
                Console.WriteLine("无法获取当前鼠标位置！");
            }
        }

        /// <summary>
        /// 模拟鼠标移动
        /// </summary>
        private static void SimulateMouseMove(int deltaX, int deltaY)
        {
            INPUT input = new INPUT
            {
                type = 0,
                mi = new MOUSEINPUT
                {
                    dx = deltaX,
                    dy = deltaY,
                    dwFlags = MOUSEEVENTF_MOVE,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            };
            SendInput(1, new INPUT[] { input }, Marshal.SizeOf(typeof(INPUT)));
        }

        /// <summary>
        /// 移动鼠标到指定位置
        /// </summary>
        private static void MoveTo(Point location)
        {
            SetCursorPos(location.X, location.Y);
        }

        /// <summary>
        /// 模拟按下和释放鼠标按键
        /// </summary>
        private static void PressAndRelease(uint downFlag, uint upFlag)
        {
            mouse_event(downFlag, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(50); // 模拟短暂按下
            mouse_event(upFlag, 0, 0, 0, 0);
        }
    }
}
