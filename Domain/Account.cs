using System.Collections.Generic;

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

        public List<string> TaskNames { get; set; }

        public List<string> RewardNames { get; set; }

        public string Task { get; set; }
        public string Reward { get; set; }
        public override string ToString()
        {
            return $"{Group}-{Name}-{Icon}";
        }
    }
}
