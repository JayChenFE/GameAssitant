using GameAssistant.Configs;
using GameAssistant.Utils;
using System;
using System.Drawing;
using System.IO;

namespace GameAssistant
{
    public static class ImageAction
    {
        public static void FindAndClickImages(params string[] imageNames)
        {
            FindAndClickImages(0, imageNames);
        }

        /// <summary>
        /// 依次查找并点击图片数组中的每一张图片。
        /// </summary>
        /// <param name="delaySeconds">每次点击后的延迟时间（秒）。</param>
        /// <param name="imageNames">图片名称数组，不包含扩展名。</param>
        public static void FindAndClickImages(int delaySeconds = 0, params string[] imageNames)
        {
            if (imageNames == null || imageNames.Length == 0)
            {
                Logger.Log("图片列表为空，未执行任何操作。");
                return;
            }

            foreach (var imageName in imageNames)
            {
                FindAndClickImage(imageName, delaySeconds);
            }
        }

        /// <summary>
        /// 查找并点击图片，等待屏幕更新。
        /// </summary>
        public static Point FindAndClickImageAndWait(string imageName, Func<bool> isScreenUpdated = null, int timeoutSeconds = 5)
        {
            return FindAndClickImage(imageName, 1, false, isScreenUpdated, timeoutSeconds);
        }

        /// <summary>
        /// 点击指定图片并等待目标图片出现。
        /// </summary>
        public static bool ClickImageAndThenAnother(
            string clickImageName,
            string waitForImageName,
            int delaySeconds = 1,
            int timeoutSeconds = 5)
        {
            Logger.Log($"尝试点击图片：{clickImageName} 并等待图片：{waitForImageName} 出现");

            var clickResult = FindAndClickImage(clickImageName, delaySeconds, false, () => IsImagePresent(waitForImageName), timeoutSeconds);

            if (clickResult == Point.Empty)
            {
                Logger.Log($"未找到需要点击的图片：{clickImageName}");
                return false;
            }

            if (IsImagePresent(waitForImageName))
            {
                FindAndClickImage(waitForImageName);
                return true;
            }

            Logger.Log($"目标图片未出现：{waitForImageName}");
            return false;
        }

        /// <summary>
        /// 查找并点击指定名称的图片。
        /// </summary>
        public static Point FindAndClickImage(
            string imageName,
            int delaySeconds = 1,
            bool isDoubleClick = false,
            Func<bool> isScreenUpdated = null,
            int timeoutSeconds = 5)
        {
            SleepHelper.DelayExecution(delaySeconds);

            string imagePath = GetImagePath(imageName);
            if (string.IsNullOrEmpty(imagePath)) return Point.Empty;

            var location = ImageRecognition.FindImageOnScreen(imageName);
            if (location == Point.Empty)
            {
                Logger.Log($"未找到图片：{imageName}");
                return Point.Empty;
            }

            PerformClick(location, isDoubleClick);
            Logger.Log($"找到并点击了图片：{imageName}, 坐标：({location.X}, {location.Y})");

            if (isScreenUpdated != null)
            {
                WaitHelper.WaitForCondition(isScreenUpdated, timeoutSeconds);
            }

            return location;
        }

        /// <summary>
        /// 检查屏幕上是否存在指定名称的图片。
        /// </summary>
        public static bool IsImagePresent(string imageName)
        {
            return ImageRecognition.FindImageOnScreen(imageName) != Point.Empty;
        }

        /// <summary>
        /// 获取图片的完整路径。
        /// </summary>
        public static string GetImagePath(string imageNameWithoutExtension)
        {
            string imageFolderPath = Config.Instance.ImageFolderPath;
            if (!Directory.Exists(imageFolderPath))
            {
                Logger.Log($"imageFolderPath 文件夹不存在：{imageFolderPath}");
                return null;
            }

            string imageName = $"{imageNameWithoutExtension}.png";
            string imagePath = Path.Combine(imageFolderPath, imageName);

            if (!File.Exists(imagePath))
            {
                Logger.Log($"未找到图片文件：{imageName}");
                return null;
            }

            if (!ImageHelper.IsSupportedImageFormat(imagePath))
            {
                Logger.Log($"不支持的图片格式：{imageName}");
                return null;
            }

            return imagePath;
        }

        /// <summary>
        /// 执行鼠标点击操作（单击或双击）。
        /// </summary>
        private static void PerformClick(Point location, bool isDoubleClick)
        {
            if (isDoubleClick)
            {
                MouseAutomation.DoubleClickAt(location);
            }
            else
            {
                MouseAutomation.ClickAt(location);
            }
        }
    }
}
