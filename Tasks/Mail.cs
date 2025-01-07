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


        protected override void DoTask()
        {
            ImageAction.FindAndClickImages(2, "邮件", "一键领取", "空白", "删除已读", "确定");

            ImageAction.FindAndClickImage("系统邮件");
            for (int i = 0; i < 3; i++)
            {
                ImageAction.FindAndClickImages(2, "删除已读", "确定", "时间", "领取", "空白");
            }

            ImageAction.FindAndClickImage("关闭");
        }


    }
}
