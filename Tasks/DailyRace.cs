using GameAssistant;
using GameAssitant.Utils;

namespace GameAssitant.Tasks
{
    public class DailyRace : TaskBase
    {
        protected override bool ShouldExecute()
        {
            // 周三到周日执行
            return DateUtil.IsWednesdayToSunday();
        }



        protected override void DoTask()
        {
            ImageAction.FindAndClickImages(2, "竞技", "跨服竞技赛");
            for (int i = 0; i < 10; i++)
            {
                ImageAction.FindAndClickImages("一键战斗", "确定", "空白");
            }
            ImageAction.FindAndClickImages(2, "回退", "回退");
        }
    }
}
