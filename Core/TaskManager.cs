using GameAssistant.Utils;
using System;
using System.Collections.Generic;

namespace GameAssistant
{
    public class TaskManager
    {
        private readonly List<TaskBase> _tasks = new List<TaskBase>();

        public void RegisterTask(TaskBase task)
        {
            _tasks.Add(task);
        }

        public void ExecuteAllTasks()
        {
            foreach (var task in _tasks)
            {
                try
                {
                    task.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Log($"任务 {task.GetType().Name} 执行失败：{ex.Message}");
                }
            }
        }
    }
}
