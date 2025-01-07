using GameAssistant;
using GameAssistant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    /// <summary>
    /// 帮派圣兽任务
    /// </summary>
    public class Beast : TaskBase
    {
        protected override bool ShouldExecute()
        {
            SleepHelper.FluctuatingSleep(3);
            return ImageAction.IsImagePresent("帮派圣兽");
        }


        protected override void DoTask()
        {
            ImageAction.FindAndClickImage("帮派圣兽", 3);


            for (int i = 0; i < 5; i++)
            {
                ImageAction.FindAndClickImage("挑战", 3);
                ImageAction.FindAndClickImage("战斗", 3);
                ImageAction.FindAndClickImage("快进", 3);
                ImageAction.FindAndClickImage("保存", 6);
                ImageAction.FindAndClickImage("空白关闭", 3);
                if (i != 4)
                {
                    SleepHelper.RandomSleep();
                }

            }

            ImageAction.FindAndClickImage("参与奖励", 3);
            ImageAction.FindAndClickImages(3, "回退", "回退");
        }
    }
}
