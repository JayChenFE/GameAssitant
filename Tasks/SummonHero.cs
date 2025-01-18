using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    public class SummonHero : TaskBase
    {

        public SummonHero()
        {
            TaskName = "召唤英雄";
        }

        protected override void DoTask()
        {
            MouseAction.Click(2, "召唤", "召唤10次");
            MouseAction.Click(3, 3, "召唤返回");
            MouseAction.Click("回退");
        }
    }
}
