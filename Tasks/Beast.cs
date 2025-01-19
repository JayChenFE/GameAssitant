using GameAssistant;
using GameAssistant.Utils;
using GameAssitant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YamlDotNet.Core;

namespace GameAssitant.Tasks
{
    /// <summary>
    /// 帮派圣兽任务
    /// </summary>
    public class Beast : TaskBase
    {
        public Beast()
        {
            TaskName = "帮派圣兽";
        }

        protected override bool CustomShouldExecute()
        {
            return ImageAction.IsImagePresent("帮派圣兽") && DateTimeUtil.IsWithinTimeRange("12:00", "20:15");
        }


        protected override void DoTask()
        {
            MouseAction.Click(3, "帮派", "帮派-帮派圣兽");


            for (int i = 0; i < 5; i++)
            {
                MouseAction.Click(4, "挑战", "圣兽战斗", "圣兽快进", "圣兽保存", "圣兽确定");
                if (i != 4)
                {
                    SleepHelper.RandomSleep();
                }

            }

            MouseAction.Click("参与奖励", 3);
            MouseAction.Click(3, "回退", "回退", "主城");
        }
    }

}
