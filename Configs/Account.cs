using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Configs
{
    public class Account

    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Group { get; set; }

        public string Role { get; set; }

        public List<String> TaskNames { get; set; }


        public override string ToString()
        {
            return $"{Group}-{Name}-{Icon}";
        }
    }
}
