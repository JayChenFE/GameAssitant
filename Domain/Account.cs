using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace GameAssitant.Domain
{
    public class Account

    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Group { get; set; }

        public string Role { get; set; }

        [YamlIgnore]
        public List<string> TaskNames { get; set; }

        [YamlIgnore]
        public List<string> RewardKeys { get; set; }

        [YamlIgnore]
        public List<string> RewardNames { get; set; }

        public string Task { get; set; } = string.Empty;
        public string Reward { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Group}-{Name}-{Icon}";
        }

        /// <summary>
        /// 将任务和奖励字符串转换为列表
        /// </summary>
        public void ParseTaskAndReward(CommonConfig common)
        {
            TaskNames = string.IsNullOrWhiteSpace(Task)
                ? new List<string>()
                : Task.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(t => t.Trim())
                      .ToList();

            RewardKeys = string.IsNullOrWhiteSpace(Reward)
                ? new List<string>()
                : Reward.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(r => r.Trim())
                        .ToList();

            RewardNames = common.RewardNames
                .Where(x => RewardKeys.Contains(x.Key))
                .SelectMany(x => x.Value)
                .Distinct()
                .ToList();

        }

        /// <summary>
        /// 将任务和奖励列表转换为字符串，供保存到配置文件
        /// </summary>
        public void ConvertToTaskAndRewardString()
        {
            Task = string.Join(" ", TaskNames);
            Reward = string.Join(" ", RewardKeys);
        }
    }
}
