using GameAssistant;
using GameAssistant.Utils;
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
            _taskManager.RegisterTask(new Mail());
            //_taskManager.RegisterTask(new TaskB());
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

    }
}
