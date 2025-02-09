using GameAssistant.Configs;
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
    public partial class AccountConfigForm : Form
    {

        private List<string> _allTaskNames;

        public AccountConfigForm(List<string> allTaskNames)
        {
            _allTaskNames = allTaskNames;
            InitializeComponent();
            SetFormSizeAndPosition(); // 设置窗口大小和位置
            LoadAccountsUI();
        }

        private void SetFormSizeAndPosition()
        {
            // 获取屏幕尺寸
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // 计算窗口尺寸 (80% 宽高)
            int formWidth = (int)(screenWidth * 0.8);
            int formHeight = (int)(screenHeight * 0.8);

            // 设置窗口大小
            this.Size = new Size(formWidth, formHeight);

            // 计算居中位置
            int posX = (screenWidth - formWidth) / 2;
            int posY = (screenHeight - formHeight) / 2;

            // 设置窗口位置
            this.StartPosition = FormStartPosition.Manual; // 手动定位
            this.Location = new Point(posX, posY);
        }

        private void LoadAccountsUI()
        {
            flowPanelAccounts.Controls.Clear(); // 清空已有控件

            var accounts = Config.Instance.Accounts;

            foreach (var account in accounts)
            {
                Panel accountPanel = new Panel
                {
                    Width = flowPanelAccounts.Width - 20,
                    Height = 200,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblAccount = new Label
                {
                    Text = account.ToString(),
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                accountPanel.Controls.Add(lblAccount);

                // 任务列表
                CheckedListBox clbTaskNames = new CheckedListBox
                {
                    Width = 250,
                    Height = 80,
                    Location = new Point(10, 40)
                };
                clbTaskNames.DataSource = _allTaskNames;
                SetCheckedItems(clbTaskNames, account.TaskNames);
                clbTaskNames.Tag = account;
                accountPanel.Controls.Add(clbTaskNames);

                // 奖励列表
                CheckedListBox clbRewardNames = new CheckedListBox
                {
                    Width = 250,
                    Height = 80,
                    Location = new Point(270, 40)
                };
                clbRewardNames.Items.AddRange(account.RewardNames.ToArray());
                SetCheckedItems(clbRewardNames, account.RewardNames);
                clbRewardNames.Tag = account;
                accountPanel.Controls.Add(clbRewardNames);

                flowPanelAccounts.Controls.Add(accountPanel);
            }
        }

        /// <summary>
        /// 设置 `CheckedListBox` 选中状态
        /// </summary>
        private void SetCheckedItems(CheckedListBox clb, List<string> selectedItems)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                string itemText = clb.Items[i].ToString();
                clb.SetItemChecked(i, selectedItems.Contains(itemText));
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void BtnSaveAccounts_ClickHandler(object sender, EventArgs e)
        {
            foreach (Control control in flowPanelAccounts.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control childControl in panel.Controls)
                    {
                        if (childControl is CheckedListBox clb && clb.Tag is Account account)
                        {
                            List<string> selectedItems = clb.CheckedItems.Cast<string>().ToList();
                            if (clb.Items.Count > 0 && Config.Instance.SelectedTaskNames.Contains(clb.Items[0].ToString()))
                            {
                                account.TaskNames = selectedItems;
                            }
                            else
                            {
                                account.RewardNames = selectedItems;
                            }
                        }
                    }
                }
            }

            try
            {
                SaveAccountsToYaml();
                MessageBox.Show("所有账户的任务已成功保存！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存账号信息到 YAML
        /// </summary>
        private void SaveAccountsToYaml()
        {
            string filePath = Config.Instance.AccountFilePath;
            YamlUtil.SaveYaml(filePath, Config.Instance.Accounts);
        }
    }
}
