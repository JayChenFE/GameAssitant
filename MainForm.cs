using GameAssistant;
using GameAssistant.Utils;
using GameAssitant.Tasks;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static GameAssistant.MouseAutomation;

namespace GameAssitant
{
    public partial class MainForm : Form
    {

        private readonly TaskManager _taskManager = new TaskManager();
        public MainForm()
        {
            InitializeComponent();
            _taskManager.RegisterTask(new Mail());
            _taskManager.RegisterTask(new Maid());
            _taskManager.RegisterTask(new Beast());
            _taskManager.RegisterTask(new BonusForRecharge());
            _taskManager.RegisterTask(new DailyRace());
            _taskManager.RegisterTask(new EquipmentCrafting());
            _taskManager.RegisterTask(new FatefulGame());

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
            string imageName = txtImageName.Text.Trim()+".png";
            if (string.IsNullOrEmpty(imageName))
            {
                MessageBox.Show("请输入图片名称！");
                return;
            }

            // 拼接图片路径
            string resourcesPath = Config.Instance.ResourcesPath; // 从配置中获取资源路径
            string imagePath = Path.Combine(resourcesPath, imageName);

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
            SleepHelper.RandomSleep(1,2);
            var offset= int.Parse(txtInput.Text.Trim());
            DragMouse(offset, Direction.Up);
        }
    }
}
