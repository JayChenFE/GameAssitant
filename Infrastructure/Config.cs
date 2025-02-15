using GameAssitant.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GameAssistant.Configs
{
    public class Config
    {
        public bool IsForce { get; set; }
        public Dictionary<string, Point> Coordinates { get; private set; }
        public Dictionary<string, Rectangle> Areas { get; private set; } = new Dictionary<string, Rectangle>();
        public ScaleConfig Scale { get; private set; }
        public string ImageFolderPath { get; private set; }
        public List<Account> Accounts { get; set; }
        public List<Account> SelectedAccounts { get; set; }
        public List<string> SelectedTaskNames { get; set; }

        public string AccountFilePath { get; private set; }
        public string CoordinateFilePath { get; private set; }
        public string AreaFilePath { get; private set; }
        public string ScaleFilePath { get; private set; }
        public string CommonFilePath { get; private set; }

        // 线程安全处理
        private static readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        private Account _currentAccount;

        public Account CurrentAccount
        {
            get
            {
                rwLock.EnterReadLock();
                try
                {
                    return _currentAccount;
                }
                finally
                {
                    rwLock.ExitReadLock();
                }
            }
            set
            {
                rwLock.EnterWriteLock();
                try
                {
                    _currentAccount = value;
                }
                finally
                {
                    rwLock.ExitWriteLock();
                }
            }
        }

        // 配置文件路径
        private const string ResourcePath = "C:\\resource";


        private static Config _instance;
        private static readonly object LockObject = new object();

        /// <summary>
        /// 获取 Config 实例（单例模式）
        /// </summary>
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

        /// <summary>
        /// 获取要执行的账户列表
        /// </summary>
        public List<Account> GetAccountsToExecute()
        {
            return SelectedAccounts != null && SelectedAccounts.Count > 0 ? SelectedAccounts : Accounts;
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        private static Config LoadConfig()
        {
            ValidateResourcePath();

            Config config = new Config
            {
                CoordinateFilePath = Path.Combine(ResourcePath, "coordinate.yaml"),
                AreaFilePath = Path.Combine(ResourcePath, "area.yaml"),
                ScaleFilePath = Path.Combine(ResourcePath, "scale.yaml"),
                AccountFilePath = Path.Combine(ResourcePath, "account.yaml"),
                CommonFilePath = Path.Combine(ResourcePath, "common.yaml")
            };

            config.Scale = LoadYaml<ScaleConfig>(config.ScaleFilePath);
            config.Coordinates = LoadYamlCoordinates(config.CoordinateFilePath);
            config.Areas = LoadYamlAreas(config.AreaFilePath, config.Scale);
            config.Accounts = LoadAccounts(config.AccountFilePath);
            config.ImageFolderPath = Path.Combine(ResourcePath, "images");


            return config;
        }

        private static List<Account> LoadAccounts(string accountFilePath)
        {
            var accounts = LoadYaml<List<Account>>(accountFilePath);

            foreach (var account in accounts)
            {
                account.TaskNames = SplitAndClean(account.Task);
                account.RewardNames = SplitAndClean(account.Reward);
            }

            return accounts;
        }

        // 通用方法：按逗号分割字符串并清理空值
        private static List<string> SplitAndClean(string input)
        {
            return input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .ToList();
        }

        /// <summary>
        /// 校验资源路径是否存在
        /// </summary>
        private static void ValidateResourcePath()
        {
            if (!Directory.Exists(ResourcePath))
            {
                throw new DirectoryNotFoundException($"资源目录未找到: {ResourcePath}");
            }
        }

        /// <summary>
        /// 解析 YAML 文件为 Dictionary<string, Point>
        /// </summary>
        private static Dictionary<string, Point> LoadYamlCoordinates(string filePath)
        {
            ValidateFileExists(filePath);

            var rawCoordinates = LoadYaml<Dictionary<string, string>>(filePath);
            var coordinates = new Dictionary<string, Point>();

            foreach (var entry in rawCoordinates)
            {
                var values = entry.Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length == 2 &&
                    int.TryParse(values[0], out int x) &&
                    int.TryParse(values[1], out int y))
                {
                    coordinates[entry.Key] = new Point(x, y);
                }
                else
                {
                    throw new FormatException($"无效的坐标格式: {entry.Key} -> {entry.Value}");
                }
            }

            return coordinates;
        }

        /// <summary>
        /// 解析 YAML 文件为 Dictionary<string, Rectangle>
        /// </summary>
        private static Dictionary<string, Rectangle> LoadYamlAreas(string filePath, ScaleConfig scale)
        {
            ValidateFileExists(filePath);

            var rawCoordinates = LoadYaml<Dictionary<string, string>>(filePath);
            var areas = new Dictionary<string, Rectangle>();

            foreach (var entry in rawCoordinates)
            {
                var values = entry.Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length == 4 &&
                    int.TryParse(values[0], out int x1) &&
                    int.TryParse(values[1], out int y1) &&
                    int.TryParse(values[2], out int x2) &&
                    int.TryParse(values[3], out int y2))
                {
                    Point originalTopLeft = new Point(x1, y1);
                    Point originalBottomRight = new Point(x2, y2);

                    Point scaledTopLeft = scale.CalculateScaledPoint(originalTopLeft);
                    Point scaledBottomRight = scale.CalculateScaledPoint(originalBottomRight);

                    // 修正坐标
                    int correctedX1 = Math.Min(scaledTopLeft.X, scaledBottomRight.X);
                    int correctedY1 = Math.Min(scaledTopLeft.Y, scaledBottomRight.Y);
                    int correctedX2 = Math.Max(scaledTopLeft.X, scaledBottomRight.X);
                    int correctedY2 = Math.Max(scaledTopLeft.Y, scaledBottomRight.Y);

                    areas[entry.Key] = new Rectangle(correctedX1, correctedY1, correctedX2 - correctedX1, correctedY2 - correctedY1);
                }
                else
                {
                    throw new FormatException($"无效的坐标格式: {entry.Key} -> {entry.Value}，应为 '50 100 200 300'的形式");
                }
            }

            return areas;
        }

        /// <summary>
        /// 通用的 YAML 加载方法
        /// </summary>
        private static T LoadYaml<T>(string filePath)
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
        /// 校验文件是否存在
        /// </summary>
        private static void ValidateFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"配置文件未找到: {filePath}");
            }
        }
    }
}
