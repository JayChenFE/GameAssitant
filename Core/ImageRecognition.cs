using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace GameAssistant
{
    public class ImageRecognition
    {
        public static Point FindImageOnScreen(string templatePath)
        {
            Bitmap screenBitmap = CaptureScreen();
            using (Mat screen = BitmapToMat(screenBitmap))
            using (Mat template = CvInvoke.Imread(templatePath, ImreadModes.Color))
            using (Mat result = new Mat())
            {
                if (screen.IsEmpty || template.IsEmpty)
                {
                    throw new InvalidOperationException("输入图像无效！");
                }

                if (template.Rows > screen.Rows || template.Cols > screen.Cols)
                {
                    throw new ArgumentException("模板图像的大小不能超过源图像！");
                }

                CvInvoke.CvtColor(screen, screen, ColorConversion.Bgr2Gray);
                CvInvoke.CvtColor(template, template, ColorConversion.Bgr2Gray);

                CvInvoke.MatchTemplate(screen, template, result, TemplateMatchingType.CcoeffNormed);

                double minVal = 0, maxVal = 0;
                Point minLoc = new Point(), maxLoc = new Point();
                CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

                if (maxVal >= 0.8)
                {
                    int matchX = maxLoc.X + template.Width / 2;
                    int matchY = maxLoc.Y + template.Height / 2;
                    return new Point(matchX, matchY);
                }

                return Point.Empty;
            }
        }

        private static Bitmap CaptureScreen()
        {
            var bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            }
            return bitmap;
        }

        private static Mat BitmapToMat(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap), "Bitmap 不能为空！");
            }

            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                bitmap.PixelFormat);

            int channels = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            if (channels != 1 && channels != 3 && channels != 4)
            {
                bitmap.UnlockBits(bitmapData);
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

            bitmap.UnlockBits(bitmapData);

            return mat;
        }
    }
}
