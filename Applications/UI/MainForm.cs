using GameAssistant;
using GameAssistant.Configs;
using GameAssitant.Applications.Tests;
using GameAssitant.Domain;
using GameAssitant.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAssitant.Applications.UI
{
    public partial class MainForm : Form
    {
        private readonly TaskManager _taskManager = new TaskManager();
        private readonly List<string> _taskNames = new List<string>();
        public MainForm()
        {
            RegisterAllTasks();
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            clbxAccount.DataSource = Config.Instance.Accounts;
            cbxAllAccounts.CheckedChanged += (sender, e) => SetAllItemsChecked(clbxAccount, cbxAllAccounts.Checked);

            clbxTask.DataSource = _taskNames;
            cbxAllTasks.CheckedChanged += (sender, e) => SetAllItemsChecked(clbxTask, cbxAllTasks.Checked);

            cbxTestOther.Items.Add(new TestBonus());
            cbxTestOther.Items.Add(new TestChallengeCount());
            cbxTestOther.DisplayMember = "TestName";
        }

        private void SetAllItemsChecked(CheckedListBox checkedListBox, bool isChecked)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, isChecked);
            }
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            Config.Instance.IsForce = cbxForce.Checked;
            Config.Instance.SelectedAccounts = clbxAccount.CheckedItems.Cast<Account>().ToList();
            Config.Instance.SelectedTaskNames = clbxTask.CheckedItems.Cast<string>().ToList();

            var isMultiAccount = this.cbxMultiAccount.Checked;
            Logger.Log("开始调度所有任务...");

            // 在后台线程中执行所有任务，防止 UI 阻塞
            await Task.Run(() =>
            {
                _taskManager.ExecuteAllTasks(isMultiAccount);
            });

            Logger.Log("所有任务调度完成。");
        }

        private void BtnConfigRoles_Click(object sender, EventArgs e)
        {
            MessageBox.Show("配置角色功能暂未实现");
        }

        private void BtnConfigAccounts_Click(object sender, EventArgs e)
        {
            using (var accountConfigForm = new AccountConfig(_taskNames))
            {
                accountConfigForm.ShowDialog();
            }
        }
    }
}
