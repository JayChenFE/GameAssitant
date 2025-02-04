using GameAssistant;
using System;
using GameAssitant.Applications.Tasks;

namespace GameAssitant
{
    public partial class MainForm
    {
        private void RegisterAllTasks()
        {
            // 定义所有任务的类型列表
            Type[] taskTypes =
            {
                typeof(Mail),             // 邮件
				typeof(Maid),             // 女仆
				typeof(Beast),            // 帮派圣兽
				typeof(Talk),             // 帮派聊天
				typeof(BonusForRecharge), // 充值免费钻石
				typeof(Arena),            // 本服竞技场
                typeof(DailyRace),        // 每日跨服竞技赛
				typeof(EquipmentCrafting),// 合成装备
				typeof(Shop),             // 日常商店
				typeof(GangChanllenge),    // 帮派试炼
				typeof(ExpeditionBeast),   // 远征兽墟
				typeof(FatefulGame),       // 天命棋局
				typeof(HallOfFate),        // 命运之殿
				typeof(BeastChangllenge),  // 圣兽挑战
				typeof(SummonHero),        // 召唤英雄
				typeof(DailyTask),         // 领取日常任务
				typeof(Pet),               // 灵宠孵化
				typeof(Otherworld)         // 异界远征
			};

            // 遍历所有任务类型并进行注册
            foreach (var taskType in taskTypes)
            {
                RegisterTask(taskType);
            }
        }



        private void RegisterTask(Type taskType)
        {
            // 确保任务类型继承自 TaskBase
            if (typeof(TaskBase).IsAssignableFrom(taskType) && Activator.CreateInstance(taskType) is TaskBase taskInstance)
            {
                _taskManager.RegisterTask(taskInstance);  // 注册任务
                _taskNames.Add(taskInstance.TaskName);
            }

        }

    }
}
