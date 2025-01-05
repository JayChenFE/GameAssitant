using GameAssistant.Utils;
using System;

namespace GameAssistant
{
    public class TaskB : TaskBase
    {
        protected override void DoTask()
        {
            Logger.Log("TaskB: 执行核心逻辑...");
            var location = ImageAction.FindAndClickImage("exampleB.png");
            if (location == System.Drawing.Point.Empty)
            {
                Logger.Log("TaskB: 未找到图片！");
            }
            else
            {
                Logger.Log($"TaskB: 成功点击图片，位置：{location}");
            }
        }
    }
}
