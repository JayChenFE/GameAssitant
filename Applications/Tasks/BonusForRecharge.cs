using GameAssistant;
using GameAssistant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Applications.Tasks
{
    public class BonusForRecharge : TaskBase
    {

        public BonusForRecharge() {
            TaskName = "充值免费钻石";
        }
        
        protected override void DoTask()
        {
            MouseAction.Click(2, "充值", "0元", "充值空白", "日礼包", "20钻", "充值空白", "连购关闭", "连购回退", "连购回退");
        }
    }
}
