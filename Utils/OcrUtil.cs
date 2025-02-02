using Emgu.CV;
using System;
using System.Drawing;
using Tesseract;

namespace GameAssistant.Utils
{
    public static class OcrUtil
    {


        public static (string text, Rectangle position) RecognizeTextFromScreen(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            // 计算屏幕区域
            Rectangle screenRegion = new Rectangle(
                topLeftX,
                topLeftY,
                bottomRightX - topLeftX,
                bottomRightY - topLeftY
            );

            return RecognizeTextFromScreen(screenRegion);
        }


        public static (string text, Rectangle position) RecognizeTextFromScreen(Rectangle screenRegion)
        {
            // 捕获屏幕区域
            using (Bitmap bitmap = new Bitmap(screenRegion.Width, screenRegion.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(screenRegion.Location, Point.Empty, screenRegion.Size);
                }
                bitmap.Save("test.png");
                //Bitmap bitmap1 = PreprocessImage(bitmap);
                // 初始化 Tesseract OCR 引擎
                using (var engine = new TesseractEngine(@"C:\Program Files\Tesseract-OCR\tessdata", "chi_sim", EngineMode.Default))
                {
                    engine.SetVariable("tessedit_char_whitelist", "0123456789 /");
                    using (var img = PixConverter.ToPix(bitmap))
                    {
                        using (var page = engine.Process(img))
                        {
                            // 获取识别到的文本
                            string text = page.GetText().Trim();
                            return (text, screenRegion);
                        }
                    }
                }
            }
        }



        private static Bitmap CaptureNumberArea(Rectangle captureRect)
        {
            Bitmap bitmap = new Bitmap(captureRect.Width, captureRect.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(captureRect.Location, Point.Empty, captureRect.Size);
            }
            return bitmap;
        }


        private static Bitmap PreprocessImage(Bitmap inputImage)
        {
            using (var mat = ImageRecognition.BitmapToMat(inputImage))
            {
                CvInvoke.CvtColor(mat, mat, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray); // 转灰度
                CvInvoke.Threshold(mat, mat, 128, 255, Emgu.CV.CvEnum.ThresholdType.Binary); // 二值化
                return mat.ToBitmap();
            }
        }

    }
}