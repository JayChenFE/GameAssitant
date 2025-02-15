using System;
using System.IO;

namespace GameAssitant.Infrastructure.Utils
{
    public static class ImageHelper
    {
        private static readonly string[] SupportedFormats = { ".jpg", ".jpeg", ".png", ".bmp" };

        public static bool IsSupportedImageFormat(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return Array.Exists(SupportedFormats, format => format == extension);
        }
    }
}
