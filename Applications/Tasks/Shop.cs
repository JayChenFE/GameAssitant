using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Applications.Tasks
{
    public class Shop : TaskBase
    {
        public Shop()
        {
            TaskName = "日常商店";
        }

        protected override void DoTask()
        {
            MouseAction.Click(1.5, "商店", "日常商店", "免费刷新", "中上", "免费刷新", "中上", "回退");
        }
    }
}
