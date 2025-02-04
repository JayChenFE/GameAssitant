using GameAssistant;
using GameAssitant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Applications.Tasks
{
    public class Talk : TaskBase
    {
        public Talk()
        {
            TaskName = "帮派聊天";
        }

        protected override void DoTask()
        {
            MouseAction.Click(1.5,"聊天", "聊天-右");
            MouseAutomation.DragMouse(200, MouseAutomation.Direction.Left);
            MouseAction.Click("聊天-帮派",afterDelaySeconds:1);
            MouseAction.Click(1.5, "聊天-表情", "哦");
        }
    }
}
