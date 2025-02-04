using GameAssistant.Utils;
using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Applications.Tasks
{
    public class EquipmentCrafting : TaskBase
    {
        public EquipmentCrafting() {
            TaskName = "合成装备";
        }

        protected override void DoTask()
        {
            MouseAction.Click(2, "炼器坊", "合成");
            MouseAction.Click(2, 2, "回退");
        }


    }
}
