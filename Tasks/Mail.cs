using System;

namespace GameAssistant
{
    /// <summary>
    /// 邮件任务
    /// </summary>
    public class Mail : TaskBase
    {
       

        protected override void DoTask()
        {
            ImageAction.FindAndClickImage("邮件.png");
        }

        
    }
}
