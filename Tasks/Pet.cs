using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    /// <summary>
    /// 灵宠孵化
    /// </summary>
    public class Pet : TaskBase
    {

        public Pet()
        {
            TaskName = "灵宠孵化";
        }

        protected override void DoTask()
        {
            MouseAction.Click(2, "帮派", "主城", "空地");
            MouseAutomation.DragMouse(1000, MouseAutomation.Direction.Left);
            MouseAction.Click(4, "灵宠家园");
            MouseAction.Click(6, "一键孵化");
            MouseAction.Click(1, 6, "一键孵化");
            MouseAction.Click("主城");
        }
    }
}
