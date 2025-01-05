using GameAssistant.Utils;
using GameAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    public class EquipmentCrafting : TaskBase
    {
        protected override void DoTask()
        {
            ImageAction.FindAndClickImages(2, "炼器坊", "一键合成", "炼器确定");
            ImageAction.FindAndClickImages(3,"空白","回退", "回退");
        }


    }
}
