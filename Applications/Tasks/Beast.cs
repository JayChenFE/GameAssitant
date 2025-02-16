using GameAssistant;
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
            SleepHelper.DelayExecution(3);

            for (int i = 0; i < 5; i++)
            {
                MouseAction.Click("挑战", afterDelaySeconds: 3);
                MouseAction.Click("圣兽战斗", afterDelaySeconds: 1);
                MouseAction.Click(6, "圣兽快进", "圣兽保存", "圣兽确定");
                SleepHelper.DelayExecution(2);
                if (i != 4)
                {
                    SleepHelper.DelayExecution(11);
                }

            }

            MouseAction.Click("参与奖励", 2);
            MouseAction.Click(2, "回退", "回退");
        }
    }

}
