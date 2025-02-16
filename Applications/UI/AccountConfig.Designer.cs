namespace GameAssitant.Applications.UI
{
    partial class AccountConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxAccount = new System.Windows.Forms.ListBox();
            this.lbSwitchAccount = new System.Windows.Forms.Label();
            this.lbTask = new System.Windows.Forms.Label();
            this.clbxTask = new System.Windows.Forms.CheckedListBox();
            this.btnSaveAccountConfig = new System.Windows.Forms.Button();
            this.clbxReward = new System.Windows.Forms.CheckedListBox();
            this.lbReward = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxAccount
            // 
            this.lbxAccount.FormattingEnabled = true;
            this.lbxAccount.ItemHeight = 21;
            this.lbxAccount.Items.AddRange(new object[] {
            "忘川1",
            "忘川2"});
            this.lbxAccount.Location = new System.Drawing.Point(52, 165);
            this.lbxAccount.Name = "lbxAccount";
            this.lbxAccount.Size = new System.Drawing.Size(234, 382);
            this.lbxAccount.TabIndex = 0;
            this.lbxAccount.SelectedIndexChanged += new System.EventHandler(this.lbxAccount_SelectedIndexChanged);
            // 
            // lbSwitchAccount
            // 
            this.lbSwitchAccount.AutoSize = true;
            this.lbSwitchAccount.Location = new System.Drawing.Point(48, 99);
            this.lbSwitchAccount.Name = "lbSwitchAccount";
            this.lbSwitchAccount.Size = new System.Drawing.Size(94, 21);
            this.lbSwitchAccount.TabIndex = 1;
            this.lbSwitchAccount.Text = "切换账号";
            // 
            // lbTask
            // 
            this.lbTask.AutoSize = true;
            this.lbTask.Location = new System.Drawing.Point(1160, 111);
            this.lbTask.Name = "lbTask";
            this.lbTask.Size = new System.Drawing.Size(94, 21);
            this.lbTask.TabIndex = 2;
            this.lbTask.Text = "选择任务";
            // 
            // clbxTask
            // 
            this.clbxTask.FormattingEnabled = true;
            this.clbxTask.Items.AddRange(new object[] {
            "任务1",
            "任务2"});
            this.clbxTask.Location = new System.Drawing.Point(1164, 153);
            this.clbxTask.Name = "clbxTask";
            this.clbxTask.Size = new System.Drawing.Size(390, 648);
            this.clbxTask.TabIndex = 3;
            // 
            // btnSaveAccountConfig
            // 
            this.btnSaveAccountConfig.Location = new System.Drawing.Point(712, 929);
            this.btnSaveAccountConfig.Name = "btnSaveAccountConfig";
            this.btnSaveAccountConfig.Size = new System.Drawing.Size(187, 112);
            this.btnSaveAccountConfig.TabIndex = 4;
            this.btnSaveAccountConfig.Text = "保存";
            this.btnSaveAccountConfig.UseVisualStyleBackColor = true;
            this.btnSaveAccountConfig.Click += new System.EventHandler(this.btnSaveAccountConfig_Click);
            // 
            // clbxReward
            // 
            this.clbxReward.FormattingEnabled = true;
            this.clbxReward.Items.AddRange(new object[] {
            "悬赏1",
            "悬赏2"});
            this.clbxReward.Location = new System.Drawing.Point(735, 153);
            this.clbxReward.Name = "clbxReward";
            this.clbxReward.Size = new System.Drawing.Size(390, 648);
            this.clbxReward.TabIndex = 6;
            
            // lbReward
            // 
            this.lbReward.AutoSize = true;
            this.lbReward.Location = new System.Drawing.Point(731, 111);
            this.lbReward.Name = "lbReward";
            this.lbReward.Size = new System.Drawing.Size(94, 21);
            this.lbReward.TabIndex = 5;
            this.lbReward.Text = "选择悬赏";
            // 
            // AccountConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1593, 1154);
            this.Controls.Add(this.clbxReward);
            this.Controls.Add(this.lbReward);
            this.Controls.Add(this.btnSaveAccountConfig);
            this.Controls.Add(this.clbxTask);
            this.Controls.Add(this.lbTask);
            this.Controls.Add(this.lbSwitchAccount);
            this.Controls.Add(this.lbxAccount);
            this.Name = "AccountConfig";
            this.Text = "AccountConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAccount;
        private System.Windows.Forms.Label lbSwitchAccount;
        private System.Windows.Forms.Label lbTask;
        private System.Windows.Forms.CheckedListBox clbxTask;
        private System.Windows.Forms.Button btnSaveAccountConfig;
        private System.Windows.Forms.CheckedListBox clbxReward;
        private System.Windows.Forms.Label lbReward;
    }
}