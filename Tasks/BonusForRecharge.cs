using GameAssistant;
using GameAssistant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    public class BonusForRecharge : TaskBase
    {
        protected override bool ShouldExecute()
        {
            SleepHelper.FluctuatingSleep(2);
            return ImageAction.IsImagePresent("充值");
        }


        protected override void DoTask()
        {
            ImageAction.FindAndClickImages(2, "充值", "0元", "确定", "空白", "日礼包", "20钻", "空白", "连购关闭", "连购回退", "连购回退");

        }
    }
}
