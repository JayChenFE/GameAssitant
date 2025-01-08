using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    /// <summary>
    /// 远征兽墟
    /// </summary>
    public class ExpeditionBeast : TaskBase
    {

        private static readonly List<String> beastNames = new List<String>() { "腾蛇", "穷奇", "灾厄" };

        public ExpeditionBeast()
        {
            TaskName = "远征兽墟";
        }

        protected override void DoTask()
        {
            MouseAction.Click(2, "历练", "历练左下");
            MouseAutomation.DragMouse(1000, MouseAutomation.Direction.Up);

            MouseAction.Click(2, "远征兽墟");

            foreach (string beastName in beastNames)
            {
                MouseAction.Click(2, beastName);
                MouseAction.Click(4, "兽墟挑战", "圣兽战斗", "圣兽快进", "圣兽确定", "主城", "主城");
            }


        }
    }
}
