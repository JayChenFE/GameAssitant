using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using GameAssistant.Configs;
using System.Windows.Forms;

namespace GameAssistant
{
    public class ImageRecognition
    {

        public static Point FindImageOnScreen(string imageName)
        {

            string imagePath = ImageAction.GetImagePath(imageName);
            if (string.IsNullOrEmpty(imagePath)) { return Point.Empty; }


            // 获取屏幕截图区域
            Rectangle bounds = Config.Instance.Areas.ContainsKey(imageName)
                ? Config.Instance.Areas[imageName]
                : Screen.PrimaryScreen.Bounds;

            using (Bitmap screenBitmap = CaptureScreen(bounds))
            using (Mat screen = BitmapToMat(screenBitmap))
            using (Mat template = CvInvoke.Imread(imagePath, ImreadModes.Color))
            using (Mat result = new Mat())
            {
                ValidateImages(screen, template);

                // 转换为灰度图，增强匹配稳定性
                CvInvoke.CvtColor(screen, screen, ColorConversion.Bgr2Gray);
                CvInvoke.CvtColor(template, template, ColorConversion.Bgr2Gray);

                // 执行模板匹配
                CvInvoke.MatchTemplate(screen, template, result, TemplateMatchingType.CcoeffNormed);

                double minVal = 0, maxVal = 0;
                Point minLoc = new Point(), maxLoc = new Point();
                CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                // 获取最佳匹配结果


                if (maxVal >= 0.8)
                {
                    // 计算屏幕上的绝对坐标
                    int absoluteX = bounds.Left + maxLoc.X + template.Width / 2;
                    int absoluteY = bounds.Top + maxLoc.Y + template.Height / 2;

                    return new Point(absoluteX, absoluteY);
                }

                return Point.Empty;
            }
        }

        /// <summary>
        /// 截取屏幕区域
        /// </summary>
        /// <param name="areaKey">区域名称</param>
        /// <returns>截取的屏幕图像</returns>
        private static Bitmap CaptureScreen(Rectangle bounds)
        {

            bounds.Intersect(Screen.PrimaryScreen.Bounds); // 防止区域超出屏幕范围

            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            }
            return bitmap;
        }

        /// <summary>
        /// 将 Bitmap 转换为 Mat 格式
        /// </summary>
        /// <param name="bitmap">要转换的 Bitmap</param>
        /// <returns>转换后的 Mat 对象</returns>
        public static Mat BitmapToMat(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap), "Bitmap 不能为空！");
            }

            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                bitmap.PixelFormat);

            try
            {
                int channels = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                if (channels != 1 && channels != 3 && channels != 4)
                {
                    throw new NotSupportedException("仅支持 1、3 或 4 通道的 Bitmap！");
                }

                Mat mat = new Mat(bitmap.Height, bitmap.Width, DepthType.Cv8U, channels);

                unsafe
                {
                    Buffer.MemoryCopy(
                        (void*)bitmapData.Scan0,
                        mat.DataPointer.ToPointer(),
                        mat.Step * mat.Rows,
                        bitmapData.Stride * bitmapData.Height);
                }

                return mat;
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }

        /// <summary>
        /// 验证屏幕和模板图像是否有效
        /// </summary>
        private static void ValidateImages(Mat screen, Mat template)
        {
            if (screen.IsEmpty || template.IsEmpty)
            {
                throw new InvalidOperationException("输入图像无效，无法进行匹配！");
            }

            if (template.Rows > screen.Rows || template.Cols > screen.Cols)
            {
                throw new ArgumentException("模板图像的大小不能超过源图像！");
            }
        }
    }
}
