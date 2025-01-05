using GameAssistant.Utils;
using GameAssitant;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GameAssistant
{
    public static class ImageAction
    {
        /// <summary>
        /// 查找指定名称的图片并点击
        /// </summary>
        /// <param name="imageName">图片名称（包含扩展名）</param>
        /// <returns>点击的位置，如果未找到返回 Point.Empty</returns>
        public static Point FindAndClickImage(string imageName, bool isDoubleClick = false)
        {
            string resourcesPath = Config.Instance.ResourcesPath;
            // 检查资源目录是否存在
            if (!Directory.Exists(resourcesPath))
            {
                Logger.Log($"Resources 文件夹不存在：{resourcesPath}");
                return Point.Empty;
            }

            // 拼接图片完整路径
            string imagePath = Path.Combine(resourcesPath, imageName);

            // 检查图片文件是否存在
            if (!File.Exists(imagePath))
            {
                Logger.Log($"未找到图片文件：{imageName}");
                return Point.Empty;
            }

            // 检查图片格式是否支持
            if (!ImageHelper.IsSupportedImageFormat(imagePath))
            {
                Logger.Log($"不支持的图片格式：{imageName}");
                return Point.Empty;
            }

            // 查找图片位置
            var location = ImageRecognition.FindImageOnScreen(imagePath);
            if (location != Point.Empty)
            {
                // 点击找到的位置
                if (isDoubleClick)
                {
                    ClickAutomation.DoubleClickAt(location);
                }
                else { 
                    ClickAutomation.ClickAt(location);
                }
                Logger.Log($"找到并点击了图片：{imageName}, 坐标：({location.X}, {location.Y})");
            }
            else
            {
                Logger.Log($"未找到图片：{imageName}");
            }

            return location;
        }
    }
}
