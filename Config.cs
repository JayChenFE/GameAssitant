using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace GameAssistant
{
    public class Config
    {

        public Dictionary<string, Point> Coordinates { get; private set; }
        public ScaleConfig Scale { get; private set; }

        public string ImageFolderPath { get; private set; }

        private static readonly string ResourcePath = "C:\\resource";
        private static readonly string CoordinateFilePath = Path.Combine(ResourcePath, "coordinate.yaml");
        private static readonly string ScaleFilePath = Path.Combine(ResourcePath, "scale.yaml");
        private static Config _instance;

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



        /// <summary>
        /// 加载所有配置。
        /// </summary>
        public static Config LoadConfig()
        {
            if (!Directory.Exists(ResourcePath))
            {
                throw new DirectoryNotFoundException($"资源目录未找到: {ResourcePath}");
            }
            Config config = new Config();
            config.Coordinates = LoadYamlCoordinates(CoordinateFilePath);
            config.Scale = LoadYaml<ScaleConfig>(ScaleFilePath);
            config.ImageFolderPath = Path.Combine(ResourcePath, "images");

            return config;
        }

        private static Dictionary<string, Point> LoadYamlCoordinates(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"配置文件未找到: {filePath}");
            }

            var yaml = File.ReadAllText(filePath);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            // 解析为 Dictionary<string, string>
            var rawCoordinates = deserializer.Deserialize<Dictionary<string, string>>(yaml);

            // 转换为 Dictionary<string, Point>
            var coordinates = new Dictionary<string, Point>();
            foreach (var entry in rawCoordinates)
            {
                // 使用正则表达式匹配两个数字，忽略中间多余的空格
                var values = entry.Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length == 2 &&
                    int.TryParse(values[0], out int x) &&
                    int.TryParse(values[1], out int y))
                {
                    coordinates[entry.Key] = new Point(x, y);
                }
                else
                {
                    throw new FormatException($"无效的坐标格式: {entry.Value}");
                }
            }

            return coordinates;
        }


        /// <summary>
        /// 通用的 YAML 加载方法。
        /// </summary>
        /// <typeparam name="T">目标类型。</typeparam>
        /// <param name="filePath">YAML 文件路径。</param>
        /// <returns>解析后的对象。</returns>
        private static T LoadYaml<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"配置文件未找到: {filePath}");
                }

                var yaml = File.ReadAllText(filePath);
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                return deserializer.Deserialize<T>(yaml);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"解析 YAML 文件失败: {filePath}", ex);
            }
        }

        private static readonly object LockObject = new object();

        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (LockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = LoadConfig();
                        }
                    }
                }
                return _instance;
            }
        }


    }
}
