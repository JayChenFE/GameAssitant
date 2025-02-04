using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Applications.Tasks
{
    public class HallOfFate : TaskBase
    {
        public HallOfFate()
        {
            TaskName = "命运之殿";
        }

        protected override void DoTask()
        {
            MouseAction.Click(3, "历练", "命运之殿", "命运之殿挑战", "命运之殿挑战", "命运之殿回退", "命运之殿回退", "主城");
        }
    }
}
