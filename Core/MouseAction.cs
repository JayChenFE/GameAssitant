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
        private static readonly string ConfigFilePath = "mouse_coordinates.yaml";

        /// <summary>
        /// 根据图片名称从配置文件中获取坐标并点击。
        /// </summary>
        /// <param name="imageName">图片名称，不包含扩展名。</param>
        public static void Click(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                throw new ArgumentException("图片名称不能为空", nameof(imageName));
            }

            // 加载坐标配置
            var coordinates = LoadCoordinates();

            if (coordinates.ContainsKey(imageName))
            {
                var point = coordinates[imageName];
                MouseAutomation.ClickAt(point);
                Console.WriteLine($"点击了 {imageName} 对应的坐标: ({point.X}, {point.Y})");
            }
            else
            {
                Console.WriteLine($"未找到 {imageName} 的坐标配置: {imageName}");
            }
        }

        /// <summary>
        /// 从 YAML 文件加载坐标配置。
        /// </summary>
        /// <returns>图片名称与坐标的映射。</returns>
        private static Dictionary<string, Point> LoadCoordinates()
        {
            if (!File.Exists(ConfigFilePath))
            {
                throw new FileNotFoundException($"配置文件未找到: {ConfigFilePath}");
            }

            var yaml = File.ReadAllText(ConfigFilePath);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            // 将 YAML 文件解析为字典
            var rawCoordinates = deserializer.Deserialize<Dictionary<string, string>>(yaml);

            // 转换为 Dictionary<string, Point>
            var coordinates = new Dictionary<string, Point>();
            foreach (var entry in rawCoordinates)
            {
                var values = entry.Value.Split(',');
                if (values.Length == 2 &&
                    int.TryParse(values[0].Trim(), out int x) &&
                    int.TryParse(values[1].Trim(), out int y))
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
        /// 将坐标配置保存到 YAML 文件（可选，用于初始化或更新配置）。
        /// </summary>
        /// <param name="coordinates">图片名称与坐标的映射。</param>
        public static void SaveCoordinates(Dictionary<string, Point> coordinates)
        {
            if (coordinates == null)
            {
                throw new ArgumentNullException(nameof(coordinates));
            }

            // 将 Dictionary<string, Point> 转为 Dictionary<string, string>
            var rawCoordinates = new Dictionary<string, string>();
            foreach (var entry in coordinates)
            {
                rawCoordinates[entry.Key] = $"{entry.Value.X},{entry.Value.Y}";
            }

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var yaml = serializer.Serialize(rawCoordinates);
            File.WriteAllText(ConfigFilePath, yaml);
        }
    }
}
