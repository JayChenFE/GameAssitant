namespace GameAssitant.Applications.UI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.btnTestImage = new System.Windows.Forms.Button();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.btnTestOther = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.cbxAllAccounts = new System.Windows.Forms.CheckBox();
            this.cbxAllTasks = new System.Windows.Forms.CheckBox();
            this.cbxForce = new System.Windows.Forms.CheckBox();
            this.laAccount = new System.Windows.Forms.Label();
            this.clbxAccount = new System.Windows.Forms.CheckedListBox();
            this.lbTask = new System.Windows.Forms.Label();
            this.clbxTask = new System.Windows.Forms.CheckedListBox();
            this.cbxMultiAccount = new System.Windows.Forms.CheckBox();
            this.tabActivity = new System.Windows.Forms.TabPage();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.btnConfigAccounts = new System.Windows.Forms.Button();
            this.btnConfigRoles = new System.Windows.Forms.Button();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.cbxTestOther = new System.Windows.Forms.ComboBox();
            this.txtTestCoordinate = new System.Windows.Forms.TextBox();
            this.btnTestCoordinate = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.tabTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(119, 980);
            this.btn_start.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(160, 40);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnTestImage
            // 
            this.btnTestImage.Location = new System.Drawing.Point(42, 26);
            this.btnTestImage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnTestImage.Name = "btnTestImage";
            this.btnTestImage.Size = new System.Drawing.Size(138, 40);
            this.btnTestImage.TabIndex = 1;
            this.btnTestImage.Text = "测试图片";
            this.btnTestImage.UseVisualStyleBackColor = true;
            this.btnTestImage.Click += new System.EventHandler(this.test_Click);
            // 
            // txtImageName
            // 
            this.txtImageName.Location = new System.Drawing.Point(191, 26);
            this.txtImageName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(180, 31);
            this.txtImageName.TabIndex = 2;
            // 
            // btnTestOther
            // 
            this.btnTestOther.Location = new System.Drawing.Point(42, 264);
            this.btnTestOther.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnTestOther.Name = "btnTestOther";
            this.btnTestOther.Size = new System.Drawing.Size(138, 40);
            this.btnTestOther.TabIndex = 3;
            this.btnTestOther.Text = "测试其他";
            this.btnTestOther.UseVisualStyleBackColor = true;
            this.btnTestOther.Click += new System.EventHandler(this.btnTestOther_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabTask);
            this.tabs.Controls.Add(this.tabActivity);
            this.tabs.Controls.Add(this.tabConfig);
            this.tabs.Controls.Add(this.tabTest);
            this.tabs.Location = new System.Drawing.Point(-9, -4);
            this.tabs.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(456, 1116);
            this.tabs.TabIndex = 5;
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.cbxAllAccounts);
            this.tabTask.Controls.Add(this.cbxAllTasks);
            this.tabTask.Controls.Add(this.cbxForce);
            this.tabTask.Controls.Add(this.laAccount);
            this.tabTask.Controls.Add(this.clbxAccount);
            this.tabTask.Controls.Add(this.lbTask);
            this.tabTask.Controls.Add(this.clbxTask);
            this.tabTask.Controls.Add(this.cbxMultiAccount);
            this.tabTask.Controls.Add(this.btn_start);
            this.tabTask.Location = new System.Drawing.Point(4, 31);
            this.tabTask.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabTask.Name = "tabTask";
            this.tabTask.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabTask.Size = new System.Drawing.Size(448, 1081);
            this.tabTask.TabIndex = 0;
            this.tabTask.Text = "任务";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // cbxAllAccounts
            // 
            this.cbxAllAccounts.AutoSize = true;
            this.cbxAllAccounts.Location = new System.Drawing.Point(264, 614);
            this.cbxAllAccounts.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbxAllAccounts.Name = "cbxAllAccounts";
            this.cbxAllAccounts.Size = new System.Drawing.Size(145, 25);
            this.cbxAllAccounts.TabIndex = 8;
            this.cbxAllAccounts.Text = "全选/全不选";
            this.cbxAllAccounts.UseVisualStyleBackColor = true;
            // 
            // cbxAllTasks
            // 
            this.cbxAllTasks.AutoSize = true;
            this.cbxAllTasks.Location = new System.Drawing.Point(264, 79);
            this.cbxAllTasks.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbxAllTasks.Name = "cbxAllTasks";
            this.cbxAllTasks.Size = new System.Drawing.Size(145, 25);
            this.cbxAllTasks.TabIndex = 7;
            this.cbxAllTasks.Text = "全选/全不选";
            this.cbxAllTasks.UseVisualStyleBackColor = true;
            // 
            // cbxForce
            // 
            this.cbxForce.AutoSize = true;
            this.cbxForce.Location = new System.Drawing.Point(24, 46);
            this.cbxForce.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbxForce.Name = "cbxForce";
            this.cbxForce.Size = new System.Drawing.Size(113, 25);
            this.cbxForce.TabIndex = 6;
            this.cbxForce.Text = "强制执行";
            this.cbxForce.UseVisualStyleBackColor = true;
            // 
            // laAccount
            // 
            this.laAccount.AutoSize = true;
            this.laAccount.Location = new System.Drawing.Point(6, 616);
            this.laAccount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.laAccount.Name = "laAccount";
            this.laAccount.Size = new System.Drawing.Size(242, 21);
            this.laAccount.TabIndex = 5;
            this.laAccount.Text = "选择账号(不选默认所有)";
            // 
            // clbxAccount
            // 
            this.clbxAccount.FormattingEnabled = true;
            this.clbxAccount.Items.AddRange(new object[] {
            "忘川",
            "蚊子",
            "路人甲"});
            this.clbxAccount.Location = new System.Drawing.Point(24, 646);
            this.clbxAccount.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.clbxAccount.Name = "clbxAccount";
            this.clbxAccount.Size = new System.Drawing.Size(391, 316);
            this.clbxAccount.TabIndex = 4;
            // 
            // lbTask
            // 
            this.lbTask.AutoSize = true;
            this.lbTask.Location = new System.Drawing.Point(6, 79);
            this.lbTask.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTask.Name = "lbTask";
            this.lbTask.Size = new System.Drawing.Size(242, 21);
            this.lbTask.TabIndex = 3;
            this.lbTask.Text = "选择任务(不选默认所有)";
            // 
            // clbxTask
            // 
            this.clbxTask.FormattingEnabled = true;
            this.clbxTask.Items.AddRange(new object[] {
            "帮派圣兽",
            "邮件",
            "女仆"});
            this.clbxTask.Location = new System.Drawing.Point(24, 107);
            this.clbxTask.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.clbxTask.Name = "clbxTask";
            this.clbxTask.Size = new System.Drawing.Size(396, 472);
            this.clbxTask.TabIndex = 2;
            // 
            // cbxMultiAccount
            // 
            this.cbxMultiAccount.AutoSize = true;
            this.cbxMultiAccount.Checked = true;
            this.cbxMultiAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMultiAccount.Location = new System.Drawing.Point(24, 10);
            this.cbxMultiAccount.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbxMultiAccount.Name = "cbxMultiAccount";
            this.cbxMultiAccount.Size = new System.Drawing.Size(176, 25);
            this.cbxMultiAccount.TabIndex = 1;
            this.cbxMultiAccount.Text = "开启多账号模式";
            this.cbxMultiAccount.UseVisualStyleBackColor = true;
            // 
            // tabActivity
            // 
            this.tabActivity.Location = new System.Drawing.Point(4, 31);
            this.tabActivity.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabActivity.Name = "tabActivity";
            this.tabActivity.Size = new System.Drawing.Size(448, 1081);
            this.tabActivity.TabIndex = 3;
            this.tabActivity.Text = "活动";
            this.tabActivity.UseVisualStyleBackColor = true;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.btnConfigAccounts);
            this.tabConfig.Controls.Add(this.btnConfigRoles);
            this.tabConfig.Location = new System.Drawing.Point(4, 31);
            this.tabConfig.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabConfig.Size = new System.Drawing.Size(448, 1081);
            this.tabConfig.TabIndex = 1;
            this.tabConfig.Text = "配置";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // btnConfigAccounts
            // 
            this.btnConfigAccounts.Location = new System.Drawing.Point(103, 360);
            this.btnConfigAccounts.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnConfigAccounts.Name = "btnConfigAccounts";
            this.btnConfigAccounts.Size = new System.Drawing.Size(158, 56);
            this.btnConfigAccounts.TabIndex = 1;
            this.btnConfigAccounts.Text = "配置账号";
            this.btnConfigAccounts.UseVisualStyleBackColor = true;
            this.btnConfigAccounts.Click += new System.EventHandler(this.BtnConfigAccounts_Click);
            // 
            // btnConfigRoles
            // 
            this.btnConfigRoles.Location = new System.Drawing.Point(103, 89);
            this.btnConfigRoles.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnConfigRoles.Name = "btnConfigRoles";
            this.btnConfigRoles.Size = new System.Drawing.Size(158, 68);
            this.btnConfigRoles.TabIndex = 0;
            this.btnConfigRoles.Text = "配置角色";
            this.btnConfigRoles.UseVisualStyleBackColor = true;
            this.btnConfigRoles.Click += new System.EventHandler(this.BtnConfigRoles_Click);
            // 
            // tabTest
            // 
            this.tabTest.Controls.Add(this.cbxTestOther);
            this.tabTest.Controls.Add(this.txtTestCoordinate);
            this.tabTest.Controls.Add(this.btnTestCoordinate);
            this.tabTest.Controls.Add(this.btnTestImage);
            this.tabTest.Controls.Add(this.btnTestOther);
            this.tabTest.Controls.Add(this.txtImageName);
            this.tabTest.Location = new System.Drawing.Point(4, 31);
            this.tabTest.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabTest.Name = "tabTest";
            this.tabTest.Size = new System.Drawing.Size(448, 1081);
            this.tabTest.TabIndex = 2;
            this.tabTest.Text = "测试";
            this.tabTest.UseVisualStyleBackColor = true;
            // 
            // cbxTestOther
            // 
            this.cbxTestOther.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTestOther.FormattingEnabled = true;
            this.cbxTestOther.Location = new System.Drawing.Point(191, 264);
            this.cbxTestOther.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbxTestOther.Name = "cbxTestOther";
            this.cbxTestOther.Size = new System.Drawing.Size(180, 29);
            this.cbxTestOther.TabIndex = 7;
            // 
            // txtTestCoordinate
            // 
            this.txtTestCoordinate.Location = new System.Drawing.Point(191, 142);
            this.txtTestCoordinate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTestCoordinate.Name = "txtTestCoordinate";
            this.txtTestCoordinate.Size = new System.Drawing.Size(180, 31);
            this.txtTestCoordinate.TabIndex = 6;
            // 
            // btnTestCoordinate
            // 
            this.btnTestCoordinate.Location = new System.Drawing.Point(42, 142);
            this.btnTestCoordinate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnTestCoordinate.Name = "btnTestCoordinate";
            this.btnTestCoordinate.Size = new System.Drawing.Size(138, 40);
            this.btnTestCoordinate.TabIndex = 5;
            this.btnTestCoordinate.Text = "测试坐标";
            this.btnTestCoordinate.UseVisualStyleBackColor = true;
            this.btnTestCoordinate.Click += new System.EventHandler(this.btnTestCoordinate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 1061);
            this.Controls.Add(this.tabs);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MainForm";
            this.Text = "星舰助手";
            this.tabs.ResumeLayout(false);
            this.tabTask.ResumeLayout(false);
            this.tabTask.PerformLayout();
            this.tabConfig.ResumeLayout(false);
            this.tabTest.ResumeLayout(false);
            this.tabTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btnTestImage;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.Button btnTestOther;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabTask;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.CheckBox cbxMultiAccount;
        private System.Windows.Forms.CheckedListBox clbxTask;
        private System.Windows.Forms.Label lbTask;
        private System.Windows.Forms.Label laAccount;
        private System.Windows.Forms.CheckedListBox clbxAccount;
        private System.Windows.Forms.CheckBox cbxForce;
        private System.Windows.Forms.CheckBox cbxAllAccounts;
        private System.Windows.Forms.CheckBox cbxAllTasks;
        private System.Windows.Forms.TabPage tabActivity;
        private System.Windows.Forms.Button btnConfigAccounts;
        private System.Windows.Forms.Button btnConfigRoles;
        private System.Windows.Forms.Button btnTestCoordinate;
        private System.Windows.Forms.ComboBox cbxTestOther;
        private System.Windows.Forms.TextBox txtTestCoordinate;
    }
}

