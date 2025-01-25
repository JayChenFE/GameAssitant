using GameAssistant.Configs;
using GameAssistant.Utils;
using GameAssitant.Configs;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameAssistant
{
    public class TaskManager
    {
        private readonly List<TaskBase> _tasks = new List<TaskBase>();

        public void RegisterTask(TaskBase task)
        {
            _tasks.Add(task);
        }

        public void ExecuteAllTasks(bool isMultiAccount)
        {
            if (isMultiAccount)
            {
                ExecuteForAllAccounts();
            }
            else
            {
                ExecuteTasksForAccount();
            }
        }

        private void ExecuteForAllAccounts()
        {
            var accountsToExecute = Config.Instance.GetAccountsToExecute();

            foreach (var account in accountsToExecute)
            {
                Config.Instance.CurrentAccount = account;
                if (!ImageAction.IsImagePresent(account.Group))
                {
                    Logger.Log($"当前不在{account.Name}所在的分组${account.Group}");
                    continue;
                }


                BeforeExecute(account);

                ExecuteTasksForAccount();

                AfterExecute();
            }
        }

        private static void AfterExecute()
        {
            MouseAction.Click("账号关闭");

            ImageAction.FindAndClickImage("最大化", 5);
        }

        private static void BeforeExecute(Account account)
        {
            MouseAction.ClickPoint(new Point(account.X, account.Y));
            ImageAction.FindAndClickImage("最大化", 5);

            SleepHelper.DelayExecution(30);
            MouseAction.Click("登陆空白");
            MouseAction.Click("开始游戏", afterDelaySeconds: 20);

            MouseAction.Click(1, times: 6, "主城");
        }

        private void ExecuteTasksForAccount()
        {
            List<TaskBase> tasksToExecute = GetTasksToExecute();

            foreach (var task in tasksToExecute)
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

        private List<TaskBase> GetTasksToExecute()
        {
            var selectedTaskNames = Config.Instance.SelectedTaskNames;

            if (selectedTaskNames.Count > 0)
            {
                return _tasks.FindAll(x => selectedTaskNames.Contains(x.TaskName));
            }

            return _tasks;
        }
    }
}
