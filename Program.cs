using GameAssistant.Configs;
using System;

namespace GameAssitant
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 加载配置
            var config = Config.Instance;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms. Application.Run(new MainForm());
        }
    }
}
