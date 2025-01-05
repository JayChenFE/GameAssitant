using GameAssistant.Utils;
using System;


namespace GameAssistant
{
    /// <summary>
    /// 女仆任务
    /// </summary>
    public class Maid : TaskBase
    {
        protected override bool ShouldExecute()
        {
            SleepHelper.FluctuatingSleep(2);
            return ImageAction.IsImagePresent("女仆");
        }


        protected override void DoTask()
        {
            ImageAction.FindAndClickImages("女仆", "一键完成", "确定","空白", "完成事务","今日商城","一键完成","购买", "空白","女仆关闭");

        }
    }
}
