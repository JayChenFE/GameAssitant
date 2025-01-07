using System;
using System.IO;
using Newtonsoft.Json;

namespace GameAssistant
{
    public class Config
    {

        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"config.json");
        private static Config _instance;

        /// <summary>
        /// 获取全局配置实例
        /// </summary>
        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = LoadConfig();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 资源路径
        /// </summary>
        public string ResourcesPath { get; set; }

        /// <summary>
        /// 从 JSON 文件加载配置
        /// </summary>
        /// <returns>Config 实例</returns>
        private static Config LoadConfig()
        {
            var configPath = Path.GetFullPath(ConfigFilePath);

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"配置文件未找到：{configPath}");
            }

            string json = File.ReadAllText(configPath);
            return JsonConvert.DeserializeObject<Config>(json);
        }
    }
}
