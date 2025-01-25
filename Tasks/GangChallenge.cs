using GameAssistant;
using GameAssitant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    public class GangChanllenge : TaskBase
    {
        public GangChanllenge()
        {
            TaskName = "帮派试炼";
        }

        protected override void DoTask()
        {
           


            for (int i = 0; i < 3; i++)
            {
                MouseAction.Click("帮派", 3, 2);
                MouseAction.Click(3, "帮派试炼", "帮派试炼挑战");
                MouseAction.Click("帮派试炼购买", 3);

                MouseAction.Click(3, "帮派试炼战斗");
                MouseAction.Click("帮派试炼快进", 1, 6);
                MouseAction.Click(3, "帮派试炼保存", "帮派试炼确定", "帮派试炼回退","主城","主城");
            }

        }
    }
}
