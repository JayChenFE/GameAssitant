using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Applications.Tasks
{
    public class Fish : TaskBase
    {
        public Fish()
        {
            TaskName = "免费灵鱼";
        }

        protected override void DoTask()
        {
            MouseAction.Click(2, "帮派", "主城", "空地");
            MouseAutomation.DragMouse(1000, MouseAutomation.Direction.Left);
            MouseAction.Click(1, "灵池");
            MouseAction.Click("帮派", 2, 2);

            if (ImageAction.IsImagePresent("免费灵鱼"))
            {
                MouseAction.Click("免费灵鱼", 0, 2);
            }

            MouseAction.Click(1, "主城", "主城");
        }
    }
}
