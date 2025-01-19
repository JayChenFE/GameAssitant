using GameAssistant
    ;
using GameAssistant.Configs;
using GameAssistant.Utils;
using GameAssitant.Configs;
using GameAssitant.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAssitant
{
    public partial class MainForm : Form
    {

        private readonly TaskManager _taskManager = new TaskManager();
        private readonly BindingList<string> _taskNames = new BindingList<string>();
        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            RegisterAllTasks();

        }

        private void InitializeCustomComponents()
        {
            clbxAccount.DataSource = Config.Instance.Accounts;
            cbxAllAccounts.CheckedChanged += (sender, e) => SetAllItemsChecked(clbxAccount, cbxAllAccounts.Checked);
            
            clbxTask.DataSource = _taskNames;
            cbxAllTasks.CheckedChanged += (sender, e) => SetAllItemsChecked(clbxTask, cbxAllTasks.Checked);

        }

        private void SetAllItemsChecked(CheckedListBox checkedListBox, bool isChecked)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, isChecked);
            }
        }

       

        private async void btnStart_Click(object sender, EventArgs e)
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

    }
}
