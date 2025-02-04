using GameAssistant;
using GameAssistant.Utils;
using System;
using System.Collections.Generic;
using YamlDotNet.Core;

namespace GameAssitant.Applications.Tasks
{
    /// <summary>
    /// 远征兽墟任务
    /// </summary>
    public class ExpeditionBeast : TaskBase
    {
        private static readonly List<string> completedChallenges = new List<string>
        {
            "已通关-腾蛇",
            "已通关-灾厄",
            "已通关-穷奇"
        };

        public ExpeditionBeast()
        {
            TaskName = "远征兽墟";
        }

        /// <summary>
        /// 执行远征兽墟的主要任务逻辑
        /// </summary>
        protected override void DoTask()
        {
            EnterExpedition();

            // 执行3次远征任务
            for (int attempt = 0; attempt < 3; attempt++)
            {
                ProcessExpedition();
            }

            MouseAction.Click("回退");
        }

        /// <summary>
        /// 进入远征兽墟界面
        /// </summary>
        private static void EnterExpedition()
        {
            MouseAction.Click(2, "历练", "历练左下");
            MouseAutomation.DragMouse(1000, MouseAutomation.Direction.Up);
            MouseAction.Click("远征兽墟", afterDelaySeconds: 2);
        }

        /// <summary>
        /// 执行单次远征兽墟任务
        /// </summary>
        private static void ProcessExpedition()
        {
            var (targetName, requiresBattle) = DetermineExpeditionTarget();
            ExecuteBattle(targetName, requiresBattle);
        }

        /// <summary>
        /// 确定要进行远征的目标
        /// </summary>
        /// <returns>目标名称和是否需要战斗</returns>
        private static (string targetName, bool requiresBattle) DetermineExpeditionTarget()
        {
            SleepHelper.DelayExecution(2);
            
            foreach (var challenge in completedChallenges)
            {
                if (!ImageAction.IsImagePresent(challenge))
                {
                    string targetName = challenge.Replace("已通关-", "");
                    return (targetName, true);
                }
            }
            return ("腾蛇", false);
        }

        /// <summary>
        /// 执行远征战斗或扫荡
        /// </summary>
        /// <param name="targetName">目标名称</param>
        /// <param name="requiresBattle">是否需要战斗</param>
        private static void ExecuteBattle(string targetName, bool requiresBattle)
        {
            MouseAction.Click(targetName, afterDelaySeconds: 1.5);

            if (requiresBattle)
            {
                StartBattleSequence();
            }
            else
            {
                StartSweepSequence();
            }

            ReturnToPreviousScreen();
        }

        /// <summary>
        /// 开始战斗流程
        /// </summary>
        private static void StartBattleSequence()
        {
            MouseAction.Click(1.5, "兽墟挑战", "战斗购买", "空白", "圣兽战斗", "圣兽快进");
            MouseAction.Click(4, "圣兽确定");
            MouseAction.Click(1.5, "空白");
        }

        /// <summary>
        /// 开始扫荡流程
        /// </summary>
        private static void StartSweepSequence()
        {
            MouseAction.Click(1.5, "兽墟挑战", "扫荡购买", "空白");
        }

        /// <summary>
        /// 返回到上一个界面
        /// </summary>
        private static void ReturnToPreviousScreen()
        {
            MouseAction.Click(1, "历练左下", "回退");
        }
    }
}
