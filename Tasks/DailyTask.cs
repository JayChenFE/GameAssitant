using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    /// <summary>
    /// 领取日常任务
    /// </summary>
    public class DailyTask : TaskBase
    {
        public DailyTask()
        {
            TaskName = "领取日常任务";
        }

        protected override void DoTask()
        {
            MouseAction.Click(2, "任务", "日常领取", "25箱子", "50箱子", "主城");
        }
    }
}
