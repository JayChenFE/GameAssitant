using GameAssistant.Configs;
using GameAssitant.Infrastructure.Utils;
using GameAssitant.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameAssistant
{
    public class TaskManager
    {
        private readonly List<TaskBase> _tasks = new List<TaskBase>();
        private bool _isMultiAccount;

        public void RegisterTask(TaskBase task)
        {
            _tasks.Add(task);
        }

        public void ExecuteAllTasks(bool isMultiAccount)
        {
            _isMultiAccount = isMultiAccount; // 设置全局状
            if (_isMultiAccount)
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
                    Logger.Log($"当前不在 {account.Name} 所在的分组 [{account.Group}]");
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
            // 1️⃣ 获取任务名称集合
            var taskNames = GetTaskNamesToExecute();

            // 2️⃣ 根据名称筛选任务
            return GetTasksByNames(taskNames);
        }


        private List<string> GetTaskNamesToExecute()
        {
            // 1️⃣ 全局已选任务
            if (Config.Instance.SelectedTaskNames?.Count > 0)
            {
                return Config.Instance.SelectedTaskNames;
            }

            if (_isMultiAccount)
            {

                // 2️⃣ 角色默认任务
                // TODO


                // 3️⃣ 账号任务
                var accountTaskNames = Config.Instance.CurrentAccount?.TaskNames;
                if (accountTaskNames?.Count > 0)
                {
                    return accountTaskNames;
                }
            }

            // 4️⃣ 默认任务（所有任务）
            return _tasks.Select(t => t.TaskName).ToList();
        }

        /// <summary>
        /// 根据任务名称列表筛选任务
        /// </summary>
        private List<TaskBase> GetTasksByNames(IEnumerable<string> taskNames)
        {
            if (taskNames == null) return new List<TaskBase>();

            // 根据任务名称匹配已注册的任务
            return _tasks.Where(task => taskNames.Contains(task.TaskName)).ToList();
        }
    }
}
