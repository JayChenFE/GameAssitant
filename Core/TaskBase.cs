using GameAssistant.Utils;
using System;

namespace GameAssistant
{
    public abstract class TaskBase
    {
        public void Execute()
        {
            if (ShouldExecute())
            {
                Logger.Log($"开始执行任务：{GetType().Name}");
                BeforeTask();
                DoTask();
                AfterTask();
                Logger.Log($"完成任务：{GetType().Name}");
            }
            else
            {
                Logger.Log($"跳过任务：{GetType().Name}");
            }
        }

        protected virtual bool ShouldExecute() => true;

        protected virtual void BeforeTask() {
            ImageAction.FindAndClickImage("主城");
        }

        protected abstract void DoTask();

        protected virtual void AfterTask()
        {
            SleepHelper.FluctuatingSleep(1);
            ImageAction.FindAndClickImage("主城");
        }
    }
}
