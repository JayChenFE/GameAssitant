using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace GameAssitant.Domain
{
    public class CommonConfig
    {
        public string Roles { get; set; }
        public Dictionary<string, string> Rewards { get; set; }

        [YamlIgnore]
        public List<string> RoleNames { get; set; } = new List<string>();
        [YamlIgnore]
        public Dictionary<string, List<string>> RewardNames { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// 从 YAML 读取后自动初始化派生属性
        /// </summary>
        public void InitializeDerivedProperties()
        {
            // 解析 Roles
            RoleNames = string.IsNullOrWhiteSpace(Roles)
                ? new List<string>()
                : Roles.Split(' ').Where(r => !string.IsNullOrWhiteSpace(r)).ToList();

            // 解析 Rewards
            RewardNames = Rewards?.ToDictionary(
                kvp => kvp.Key,
                kvp => string.IsNullOrWhiteSpace(kvp.Value)
                    ? new List<string>()
                    : kvp.Value.Split(' ').Where(v => !string.IsNullOrWhiteSpace(v)).ToList()
            ) ?? new Dictionary<string, List<string>>();
        }
    }
}
