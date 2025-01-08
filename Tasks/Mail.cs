using GameAssistant.Utils;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GameAssistant
{
    /// <summary>
    /// 邮件任务
    /// </summary>
    public class Mail : TaskBase
    {
        public Mail()
        {
            TaskName = "邮件";
        }

        protected override void DoTask()
        {
            MouseAction.Click(2, "邮件", "删除已读", "邮件确定", "邮件一键领取", "邮件空白", "删除已读", "邮件确定");

            MouseAction.Click("系统邮件", 2);


            MouseAction.Click(2, 3, "邮件01", "邮件领取", "邮件空白2", "系统删除已读", "邮件确定");


            MouseAction.Click("关闭", 2);
        }


    }
}
