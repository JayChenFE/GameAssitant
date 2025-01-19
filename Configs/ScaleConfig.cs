using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Configs
{
    public class ScaleConfig
    {
        public int OriginalStartX { get; set; }
        public int OriginalStartY { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }

        /// <summary>
        /// 计算实际坐标。
        /// </summary>
        /// <param name="original">原始坐标。</param>
        /// <returns>按比例调整后的坐标。</returns>
        public Point CalculateScaledPoint(Point original)
        {
            int scaledX = (int)(StartX + (original.X - OriginalStartX) * ScaleX);
            int scaledY = (int)(StartY + (original.Y - OriginalStartY) * ScaleY);
            return new Point(scaledX, scaledY);
        }
    }
}
