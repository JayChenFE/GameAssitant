using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    public class Otherworld : TaskBase
    {
        public Otherworld()
        {
            TaskName = "异界远征";
        }
        protected override void DoTask()
        {
            MouseAction.Click(2, "帮派", "主城", "空地");
            MouseAutomation.DragMouse(1000, MouseAutomation.Direction.Right);
            MouseAction.Click(2, "异界远征", "远征任务");
            MouseAction.Click(2, 3, "远征领取", "远征空白");
            MouseAction.Click(2, "远征200", "远征空白", "远征400", "远征空白", "远征700", "远征空白", "远征1000", "远征空白");
            MouseAction.Click(1, "主城", "主城", "帮派", "主城");
        }
    }
}
