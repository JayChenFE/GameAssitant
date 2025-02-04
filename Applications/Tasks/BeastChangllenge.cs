using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Applications.Tasks
{
    public class BeastChangllenge : TaskBase
    {

        /// <summary>
        /// 圣兽挑战
        /// </summary>
        public BeastChangllenge()
        {
            TaskName = "圣兽挑战";
        }


        protected override void DoTask()
        {
            MouseAction.Click(2, "历练", "历练左下");
            MouseAutomation.DragMouse(1000, MouseAutomation.Direction.Up);

            MouseAction.Click(3, "圣兽挑战");
            MouseAction.Click(1, 2, "取消购买");
            MouseAction.Click(3, 5, "圣兽挑战扫荡", "空白");

            MouseAction.Click(2, 3, "主城");
        }
    }
}
