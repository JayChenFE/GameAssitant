using GameAssistant;
using GameAssitant.Utils;

namespace GameAssitant.Applications.Tasks
{
    public class DailyRace : TaskBase
    {
        public DailyRace()
        {
            TaskName = "每日跨服竞技赛";
        }

        protected override bool CustomShouldExecute()
        {
            // 周三到周日执行
            return DateTimeUtil.IsWednesdayToSunday();
        }



        protected override void DoTask()
        {
            MouseAction.Click(3, "竞技", "跨服竞技赛");
            MouseAction.Click(2, 10, "竞技一键", "竞技确定", "竞技空白");
            MouseAction.Click(2, "竞技回退", "主城");
        }
    }
}
