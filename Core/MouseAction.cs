using GameAssistant.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GameAssistant
{
    public static class MouseAction
    {


        public static void Click(int delaySeconds = 0, params string[] imageNames)
        {
            Click(delaySeconds, 1, imageNames);
        }

        public static void Click(int delaySeconds = 0, int times = 1, params string[] imageNames)
        {
            if (imageNames == null || imageNames.Length == 0)
            {
                Logger.Log("图片列表为空，未执行任何操作。");
                return;
            }

            for (int i = 0; i < times; i++)
            {
                foreach (var imageName in imageNames)
                {
                    Click(imageName, delaySeconds);
                }
            }


        }
        /// <summary>
        /// 根据图片名称从配置文件中获取坐标并点击。
        /// </summary>
        /// <param name="imageName">图片名称，不包含扩展名。</param>
        public static void Click(string imageName, int delaySeconds = 1, int afterDelaySeconds = 0, bool isDoubleClick = false)
        {


            if (string.IsNullOrEmpty(imageName))
            {
                throw new ArgumentException("图片名称不能为空", nameof(imageName));
            }

            SleepHelper.DelayExecution(delaySeconds);

            // 加载坐标配置
            var coordinates = Config.Instance.Coordinates;
            var scaleConfig = Config.Instance.Scale;

            if (coordinates.ContainsKey(imageName))
            {
                var point = coordinates[imageName];
                var scaledPoint = scaleConfig.CalculateScaledPoint(point);


                if (isDoubleClick)
                {

                    MouseAutomation.DoubleClickAt(scaledPoint);
                }
                else
                {
                    MouseAutomation.ClickAt(scaledPoint);
                }

                SleepHelper.DelayExecution(afterDelaySeconds);

                Logger.Log($"点击了{imageName} 对应的坐标: ({point.X}, {point.Y})");
            }
            else
            {
                Logger.Log($"未找到 {imageName} 的坐标配置");
            }
        }

    }
}
