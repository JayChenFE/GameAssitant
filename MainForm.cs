using GameAssistant;
using GameAssistant.Utils;
using GameAssitant.Tasks;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GameAssitant
{
    public partial class MainForm : Form
    {

        private readonly TaskManager _taskManager = new TaskManager();
        public MainForm()
        {
            InitializeComponent();
            RegisterAllTasks();
        }

        private void RegisterAllTasks()
        {
            //_taskManager.RegisterTask(new BeastChangllenge()); //圣兽挑战


            _taskManager.RegisterTask(new Mail()); //邮件
            _taskManager.RegisterTask(new Maid()); //女仆
            _taskManager.RegisterTask(new Beast());//帮派圣兽
            _taskManager.RegisterTask(new Talk()); //帮派聊天
            _taskManager.RegisterTask(new BonusForRecharge());//充值免费钻石
            _taskManager.RegisterTask(new DailyRace());// 每日跨服竞技赛
            _taskManager.RegisterTask(new EquipmentCrafting()); //合成装备
            _taskManager.RegisterTask(new Shop()); //日常商店

            _taskManager.RegisterTask(new GangChanllenge()); //帮派试炼

            _taskManager.RegisterTask(new ExpeditionBeast()); //远征兽墟
            _taskManager.RegisterTask(new FatefulGame()); //天命棋局
            _taskManager.RegisterTask(new HallOfFate()); //命运之殿
            _taskManager.RegisterTask(new SummonHero()); //召唤英雄

            _taskManager.RegisterTask(new DailyTask()); // 领取日常任务
            _taskManager.RegisterTask(new Pet()); //灵宠孵化
            _taskManager.RegisterTask(new Otherworld()); //异界远征
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Logger.Log("开始调度所有任务...");
            _taskManager.ExecuteAllTasks();
            Logger.Log("所有任务调度完成。");

        }

        private void imageName_TextChanged(object sender, EventArgs e)
        {

        }

        private void test_Click(object sender, EventArgs e)
        {
            // 获取输入框中的图片名称
            string imageName = txtImageName.Text.Trim() + ".png";
            if (string.IsNullOrEmpty(imageName))
            {
                MessageBox.Show("请输入图片名称！");
                return;
            }

            // 拼接图片路径
            string imageFolderPath = Config.Instance.ImageFolderPath; // 从配置中获取资源路径
            string imagePath = Path.Combine(imageFolderPath, imageName);

            // 检查文件是否存在
            if (!File.Exists(imagePath))
            {
                MessageBox.Show($"图片文件未找到：{imagePath}");
                return;
            }

            // 尝试查找图片
            var location = ImageRecognition.FindImageOnScreen(imagePath);
            if (location != Point.Empty)
            {
                MessageBox.Show($"找到图片！位置：({location.X}, {location.Y})");
            }
            else
            {
                MessageBox.Show("未找到图片！");
            }
        }

        private void btnTestOther_Click(object sender, EventArgs e)
        {
            MouseAction.Click(2, "帮派", "主城","空地");
            MouseAutomation.DragMouse(1000,MouseAutomation.Direction.Left);
        }
    }
}
