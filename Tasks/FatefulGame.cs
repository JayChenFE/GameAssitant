using GameAssistant;
using GameAssistant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameAssistant.MouseAutomation;

namespace GameAssitant.Tasks
{
    /// <summary>
    /// 天命棋局任务
    /// </summary>
    public class FatefulGame : TaskBase
    {
        protected override void DoTask()
        {

            ImageAction.FindAndClickImage("历练");
            DragMouse(400, Direction.Up);
            DragMouse(500, Direction.Up);

            if (!ImageAction.IsImagePresent("棋局检查"))
            {
                ImageAction.FindAndClickImage("主城");
                return;
            }

            ImageAction.FindAndClickImages(2, "天命棋局", "一键布阵");

            ImageAction.FindAndClickImages(4, "进入冒险", "快速通关本层");

            
            for (int i = 0; i < 5; i++)
            {
                ImageAction.FindAndClickImages(6, "快速通关本层", "下一层");
            }

            ImageAction.FindAndClickImage("奖励预览", 6);


            while (ImageAction.IsImagePresent("天命领取"))
            {
                ImageAction.FindAndClickImage("天命领取");
                SleepHelper.FluctuatingSleep(3);
            }

            DragMouse(400, Direction.Up);

            while (ImageAction.IsImagePresent("天命领取"))
            {
                ImageAction.FindAndClickImage("天命领取");
                SleepHelper.FluctuatingSleep(3);
            }

            ImageAction.FindAndClickImages(2, "天命关闭", "回退", "回退", "主城");
        }

    }
}
