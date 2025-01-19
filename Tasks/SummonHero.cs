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
            MouseAction.Click(2, "召唤");
            MouseAction.Click("召唤10次", afterDelaySeconds: 0.2);
            MouseAction.Click("中上", afterDelaySeconds: 0.2);
            MouseAction.Click("中上", afterDelaySeconds: 0.2);
            MouseAction.Click("召唤返回");
            MouseAction.Click("回退");
        }
    }
}
