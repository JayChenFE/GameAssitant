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
            MouseAction.Click(3, "聊天", "聊天-帮派", "聊天-表情", "哦", "主城");
        }
    }
}
