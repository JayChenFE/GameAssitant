using GameAssistant;
using GameAssitant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    public class Talk : TaskBase
    {
        public Talk()
        {
            TaskName = "帮派聊天";
        }

        protected override void DoTask()
        {
            MouseAction.Click("聊天", afterDelaySeconds: 1);
            ImageAction.FindAndClickImage("帮派聊天", delaySeconds: 0);
            MouseAction.Click(1.5, "聊天-表情", "哦");
        }
    }
}
