﻿using GameAssitant.Infrastructure.Utils;
using System;


namespace GameAssistant
{
    /// <summary>
    /// 女仆任务
    /// </summary>
    public class Maid : TaskBase
    {
        public Maid()
        {
            TaskName = "女仆";
        }


        protected override void DoTask()
        {
            MouseAction.Click(2, "女仆", "女仆一键完成");

            SleepHelper.DelayExecution(1.5);

            if (ImageAction.IsImagePresent("前往悬赏"))
            {
                MouseAction.Click("悬赏确定", 2);
            }

            MouseAction.Click("女仆确定", 2);
            MouseAction.Click("女仆空白", 5);
            MouseAction.Click(2, "完成事务关闭", "今日商城", "女仆一键完成", "购买", "女仆空白", "女仆关闭");
        }
    }
}
