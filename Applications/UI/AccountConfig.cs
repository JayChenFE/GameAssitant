using GameAssistant.Configs;
using GameAssitant.Applications.Tests;
using GameAssitant.Domain;
using GameAssitant.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAssitant.Applications.UI
{
    public partial class AccountConfig : Form
    {
        private List<string> _allTaskNames;

        public AccountConfig(List<string> allTaskNames)
        {
            _allTaskNames = allTaskNames;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            lbxAccount.DataSource = Config.Instance.Accounts;
            if (lbxAccount.Items.Count > 0)
            {
                lbxAccount.SelectedIndex = 0;
            }
            clbxTask.ItemCheck += clbxTask_ItemCheck;
            clbxReward.ItemCheck += clbxReward_ItemCheck;
        }

        private void lbxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxAccount.SelectedItem is Account selectedAccount)
            {
                // 更新任务
                clbxTask.Items.Clear();
                foreach (var task in _allTaskNames)
                {
                    int index = clbxTask.Items.Add(task);
                    clbxTask.SetItemChecked(index, selectedAccount.TaskNames.Contains(task));
                }

                // 更新悬赏
                clbxReward.Items.Clear();
                foreach (var rewardKey in Config.Instance.Common.RewardNames.Keys)
                {
                    int index = clbxReward.Items.Add(rewardKey);
                    clbxReward.SetItemChecked(index, selectedAccount.RewardKeys.Contains(rewardKey));
                }
            }
        }


        private void clbxTask_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (lbxAccount.SelectedItem is Account selectedAccount)
            {
                string taskName = clbxTask.Items[e.Index].ToString();
                if (e.NewValue == CheckState.Checked)
                {
                    if (!selectedAccount.TaskNames.Contains(taskName))
                        selectedAccount.TaskNames.Add(taskName);
                }
                else
                {
                    selectedAccount.TaskNames.Remove(taskName);
                }
            }
        }

        private void clbxReward_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (lbxAccount.SelectedItem is Account selectedAccount)
            {
                string rewardKey = clbxReward.Items[e.Index].ToString();

                // 更新 RewardKeys
                if (e.NewValue == CheckState.Checked)
                {
                    if (!selectedAccount.RewardKeys.Contains(rewardKey))
                    {
                        selectedAccount.RewardKeys.Add(rewardKey);
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    selectedAccount.RewardKeys.Remove(rewardKey);
                }
            }
        }



        private void btnSaveAccountConfig_Click(object sender, EventArgs e)
        {
            string path = Config.Instance.AccountFilePath;

            foreach (var account in Config.Instance.Accounts)
            {
                account.ConvertToTaskAndRewardString();
            }

            YamlUtil.SaveYaml(path, Config.Instance.Accounts);
            MessageBox.Show("账号任务配置已保存！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

       
    }
}
