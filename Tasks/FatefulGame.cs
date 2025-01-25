using GameAssistant;
using GameAssistant.Utils;
using GameAssitant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Tasks
{
    /// <summary>
    /// 天命棋局任务
    /// </summary>
    public class FatefulGame : TaskBase
    {


        public FatefulGame()
        {
            TaskName = "天命棋局";
        }

        protected override bool CustomShouldExecute()
        {
            return ShouldRunFatefulGame();
        }



        protected override void DoTask()
        {
            MouseAction.Click(2, "历练", "历练左下");
            MouseAutomation.DragMouse(1000, MouseAutomation.Direction.Up);

            MouseAction.Click(3, "天命棋局", "一键布阵", "进入冒险", "快速通关本层");

            MouseAction.Click(6, 5, "快速通关本层", "下一层");

            MouseAction.Click(6, "奖励预览");

            MouseAction.Click(3, 5, "天命领取");

            MouseAction.Click(2, "天命关闭", "回退", "回退", "主城");
        }

        private bool ShouldRunFatefulGame() { return DateTimeUtil.IsTaskDue("2025-01-16", 2); }

    }
}
