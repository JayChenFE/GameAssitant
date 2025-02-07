﻿using GameAssistant;
using GameAssitant.Infrastructure.Utils;

namespace GameAssitant.Applications.Tasks
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

            MouseAction.Click(1.5, "帮派", "主城", "主城", "主城", "主城");
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
