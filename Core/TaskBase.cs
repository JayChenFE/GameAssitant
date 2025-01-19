using GameAssistant.Configs;
using GameAssistant.Utils;
using System;

namespace GameAssistant
{
    public abstract class TaskBase
    {
        public string TaskName { get; protected set; }

        public void Execute()
        {
            if (ShouldExecute())
            {
                Logger.Log($"开始执行任务：{TaskName}");
                BeforeTask();
                DoTask();
                AfterTask();
                Logger.Log($"完成任务：{TaskName}");
            }
            else
            {
                Logger.Log($"跳过任务：{TaskName}");
            }
        }

        protected virtual bool ShouldExecute()
        {
            if (Config.Instance.IsForce)
            {
                return true;
            }
            return CustomShouldExecute();
        }

        protected virtual bool CustomShouldExecute() => true;


        protected virtual void BeforeTask()
        {
            MouseAction.Click(0.5, "主城");
        }

        protected abstract void DoTask();

        protected virtual void AfterTask()
        {
            MouseAction.Click(0.5, "主城");
        }
    }
}
