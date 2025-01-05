using GameAssistant.Utils;
using GameAssitant;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;

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

        public static Point FindAndClickImageAndWait(string imageNameWithoutExtension, Func<bool> isScreenUpdated = null, int timeoutSeconds = 5)
        {
            return FindAndClickImage(imageNameWithoutExtension, 1, false, isScreenUpdated, timeoutSeconds);
        }

        /// <summary>
        /// 点击指定图片并等待目标图片出现。
        /// </summary>
        /// <param name="clickImageName">需要点击的图片名称（不包含扩展名）。</param>
        /// <param name="waitForImageName">等待出现的目标图片名称（不包含扩展名）。</param>
        /// <param name="delaySeconds">点击前的延迟时间（秒）。</param>
        /// <param name="timeoutSeconds">等待目标图片出现的超时时间（秒）。</param>
        /// <returns>目标图片是否在屏幕上出现。</returns>
        public static bool ClickImageAndThenAnother(
            string clickImageName,
            string waitForImageName,
            int delaySeconds = 1,
            int timeoutSeconds = 5)
        {
            Logger.Log($"尝试点击图片：{clickImageName} 并等待图片：{waitForImageName} 出现");

            // 点击图片
            var clickResult = FindAndClickImage(
                clickImageName,
                delaySeconds,
                false,
                isScreenUpdated: () => IsImagePresent(waitForImageName),
                timeoutSeconds
            );

            if (clickResult == Point.Empty)
            {
                Logger.Log($"未找到需要点击的图片：{clickImageName}");
                return false;
            }

            // 判断目标图片是否出现
            bool targetImagePresent = IsImagePresent(waitForImageName);
            if (targetImagePresent)
            {
                FindAndClickImage(waitForImageName);
            }
            else
            {
                Logger.Log($"目标图片未出现：{waitForImageName}");
            }

            return targetImagePresent;
        }

        /// <summary>
        /// 查找指定名称的图片并点击。
        /// </summary>
        /// <param name="imageNameWithoutExtension">图片名称（不包含扩展名）。</param>
        /// <param name="delaySeconds">点击前的延迟时间（秒）。</param>
        /// <param name="isDoubleClick">是否双击。</param>
        /// <param name="isScreenUpdated">屏幕更新条件函数。</param>
        /// <param name="timeoutSeconds">等待屏幕更新的超时时间（秒）。</param>
        /// <returns>点击的位置，如果未找到返回 Point.Empty。</returns>
        public static Point FindAndClickImage(
            string imageNameWithoutExtension,
            int delaySeconds = 1,
            bool isDoubleClick = false,
            Func<bool> isScreenUpdated = null,
            int timeoutSeconds = 5)
        {
            DelayExecution(delaySeconds);

            string imagePath = GetImagePath(imageNameWithoutExtension);
            if (string.IsNullOrEmpty(imagePath)) return Point.Empty;

            var location = ImageRecognition.FindImageOnScreen(imagePath);
            if (location == Point.Empty)
            {
                Logger.Log($"未找到图片：{imageNameWithoutExtension}");
                return Point.Empty;
            }

            // 点击图片
            if (isDoubleClick)
            {
                MouseAutomation.DoubleClickAt(location);
            }
            else
            {
                MouseAutomation.ClickAt(location);
            }
            Logger.Log($"找到并点击了图片：{imageNameWithoutExtension}, 坐标：({location.X}, {location.Y})");

            // 等待屏幕更新
            if (isScreenUpdated != null)
            {
                WaitHelper.WaitForCondition(isScreenUpdated, timeoutSeconds);
            }

            return location;
        }

        /// <summary>
        /// 检查屏幕上是否存在指定名称的图片。
        /// </summary>
        /// <param name="imageNameWithoutExtension">图片名称（不包括扩展名）。</param>
        /// <returns>如果图片存在于屏幕上，返回 true；否则返回 false。</returns>
        public static bool IsImagePresent(string imageNameWithoutExtension)
        {
            string imagePath = GetImagePath(imageNameWithoutExtension);
            if (string.IsNullOrEmpty(imagePath)) return false;

            var location = ImageRecognition.FindImageOnScreen(imagePath);
            return location != Point.Empty;
        }

        /// <summary>
        /// 延迟执行。
        /// </summary>
        /// <param name="seconds">延迟时间（秒）。</param>
        private static void DelayExecution(int seconds)
        {
            if (seconds > 0)
            {
                Thread.Sleep(seconds * 1000);
            }
        }

        /// <summary>
        /// 获取图片的完整路径。
        /// </summary>
        /// <param name="imageNameWithoutExtension">图片名称（不包括扩展名）。</param>
        /// <returns>图片完整路径，如果不存在则返回 null。</returns>
        private static string GetImagePath(string imageNameWithoutExtension)
        {
            string resourcesPath = Config.Instance.ResourcesPath;
            if (!Directory.Exists(resourcesPath))
            {
                Logger.Log($"Resources 文件夹不存在：{resourcesPath}");
                return null;
            }

            string imageName = $"{imageNameWithoutExtension}.png";
            string imagePath = Path.Combine(resourcesPath, imageName);

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
    }
}
