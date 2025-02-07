using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace GameAssitant.Infrastructure.Utils
{
    public static class YamlUtil
    {
        /// <summary>
        /// 读取 YAML 文件并解析为对象
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="filePath">YAML 文件路径</param>
        /// <returns>解析后的对象</returns>
        public static T LoadYaml<T>(string filePath)
        {
            ValidateFileExists(filePath);

            try
            {
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

        /// <summary>
        /// 将对象保存到 YAML 文件
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="filePath">YAML 文件路径</param>
        /// <param name="data">要保存的对象</param>
        public static void SaveYaml<T>(string filePath, T data)
        {
            try
            {
                var serializer = new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                string yamlData = serializer.Serialize(data);
                File.WriteAllText(filePath, yamlData);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"保存 YAML 文件失败: {filePath}", ex);
            }
        }

        /// <summary>
        /// 校验文件是否存在
        /// </summary>
        /// <param name="filePath">文件路径</param>
        private static void ValidateFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"配置文件未找到: {filePath}");
            }
        }
    }
}
