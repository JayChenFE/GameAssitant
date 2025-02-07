using GameAssistant;
using GameAssitant.Infrastructure.Utils;
using System;
using System.Text.RegularExpressions;

namespace GameAssitant.Applications.Tasks
{
    public class Arena : TaskBase
    {
        // 常量配置
        private const int MinimumChallengeCount = 3;
        private const int MaxRetryAttempts = 3;
        private const int DefaultWaitSeconds = 2;
        private const int BattleAttempts = 4;
        private const int OcrErrorCode = -1;
        private const double ConfidenceThreshold = 0.95;

        public Arena()
        {
            TaskName = "本服竞技场";
        }

        protected override void DoTask()
        {
            try
            {
                NavigateToArena();
                ExecuteChallengeProcess();
                ReturnToMainCity();
            }
            catch (Exception ex)
            {
                Logger.Log($"竞技场任务执行失败: {ex.Message}");
                throw;
            }
        }

        private void NavigateToArena()
        {
            MouseAction.Click(1.5, "竞技", "竞技场");
        }

        private void ReturnToMainCity()
        {
            MouseAction.Click(3, "回退", "回退", "主城");
        }

        private void ExecuteChallengeProcess()
        {
            HandleChallengeLoop();
            ExecuteMultipleChallenges();
        }

        private void HandleChallengeLoop()
        {
            int attemptCount = 0;
            bool shouldContinue = true;

            while (shouldContinue && attemptCount < MaxRetryAttempts)
            {
                SleepHelper.DelayExecution(DefaultWaitSeconds);

                int currentCount = GetChallengeCount();

                if (currentCount == OcrErrorCode)
                {
                    attemptCount++;
                    Logger.Log("OCR识别失败，正在重试...");
                    continue;
                }

                Logger.Log($"当前挑战次数: {currentCount}，尝试次数: {attemptCount}");

                if (currentCount < MinimumChallengeCount)
                {
                    ExecuteSingleChallenge();
                    attemptCount++;
                }
                else
                {
                    shouldContinue = false;
                }
            }
        }

        private void ExecuteMultipleChallenges()
        {
            if (ImageAction.IsImagePresent("三倍未选"))
            {
                MouseAction.Click("三倍挑战", afterDelaySeconds: 1);
            }

            for (int i = 0; i < BattleAttempts; i++)
            {
                ExecuteBattleSequence();
            }
        }

        private void ExecuteSingleChallenge()
        {
            MouseAction.Click("开始挑战", afterDelaySeconds: 3);
            MouseAction.ClickWithUpdate(
                "圣兽战斗",
                () => ImageAction.IsImagePresent("竞技场录像"),
                100,
                5000
            );
            MouseAction.Click("历练左下", 0);
        }

        private void ExecuteBattleSequence()
        {
            MouseAction.Click("开始挑战", afterDelaySeconds: 8);
            MouseAction.Click("历练左下");
        }

        private int GetChallengeCount()
        {
            try
            {
                var (text, _) = OcrUtil.RecognizeText("挑战次数");

                string numbersOnly = Regex.Replace(text, @"[^\d]", "");

                if (string.IsNullOrWhiteSpace(numbersOnly))
                {
                    Logger.Log("未检测到有效数字");
                    return 0;
                }

                return int.TryParse(numbersOnly, out int result) ? result : OcrErrorCode;
            }
            catch (Exception ex)
            {
                Logger.Log($"挑战次数获取失败: {ex.Message}");
                return OcrErrorCode;
            }
        }
    }
}