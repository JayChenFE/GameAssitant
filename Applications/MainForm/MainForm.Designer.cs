namespace GameAssitant
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnTestOther = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.cbxAllAccounts = new System.Windows.Forms.CheckBox();
            this.cbxAllTasks = new System.Windows.Forms.CheckBox();
            this.cbxForce = new System.Windows.Forms.CheckBox();
            this.laAccount = new System.Windows.Forms.Label();
            this.clbxAccount = new System.Windows.Forms.CheckedListBox();
            this.lbTask = new System.Windows.Forms.Label();
            this.clbxTask = new System.Windows.Forms.CheckedListBox();
            this.cbxMultiAccount = new System.Windows.Forms.CheckBox();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.tabActivity = new System.Windows.Forms.TabPage();
            this.tabRole = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.tabAccount.SuspendLayout();
            this.tabTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(65, 579);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(87, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnTestImage
            // 
            this.btnTestImage.Location = new System.Drawing.Point(23, 15);
            this.btnTestImage.Name = "btnTestImage";
            this.btnTestImage.Size = new System.Drawing.Size(75, 23);
            this.btnTestImage.TabIndex = 1;
            this.btnTestImage.Text = "测试图片";
            this.btnTestImage.UseVisualStyleBackColor = true;
            this.btnTestImage.Click += new System.EventHandler(this.test_Click);
            // 
            // txtImageName
            // 
            this.txtImageName.Location = new System.Drawing.Point(104, 15);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(100, 21);
            this.txtImageName.TabIndex = 2;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(104, 65);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 21);
            this.txtInput.TabIndex = 4;
            // 
            // btnTestOther
            // 
            this.btnTestOther.Location = new System.Drawing.Point(23, 65);
            this.btnTestOther.Name = "btnTestOther";
            this.btnTestOther.Size = new System.Drawing.Size(75, 23);
            this.btnTestOther.TabIndex = 3;
            this.btnTestOther.Text = "测试其他";
            this.btnTestOther.UseVisualStyleBackColor = true;
            this.btnTestOther.Click += new System.EventHandler(this.btnTestOther_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTask);
            this.tabControl1.Controls.Add(this.tabActivity);
            this.tabControl1.Controls.Add(this.tabRole);
            this.tabControl1.Controls.Add(this.tabAccount);
            this.tabControl1.Controls.Add(this.tabTest);
            this.tabControl1.Location = new System.Drawing.Point(-5, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(253, 638);
            this.tabControl1.TabIndex = 5;
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
            this.tabTask.Location = new System.Drawing.Point(4, 22);
            this.tabTask.Name = "tabTask";
            this.tabTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabTask.Size = new System.Drawing.Size(245, 612);
            this.tabTask.TabIndex = 0;
            this.tabTask.Text = "任务";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // cbxAllAccounts
            // 
            this.cbxAllAccounts.AutoSize = true;
            this.cbxAllAccounts.Location = new System.Drawing.Point(144, 351);
            this.cbxAllAccounts.Name = "cbxAllAccounts";
            this.cbxAllAccounts.Size = new System.Drawing.Size(90, 16);
            this.cbxAllAccounts.TabIndex = 8;
            this.cbxAllAccounts.Text = "全选/全不选";
            this.cbxAllAccounts.UseVisualStyleBackColor = true;
            // 
            // cbxAllTasks
            // 
            this.cbxAllTasks.AutoSize = true;
            this.cbxAllTasks.Location = new System.Drawing.Point(144, 45);
            this.cbxAllTasks.Name = "cbxAllTasks";
            this.cbxAllTasks.Size = new System.Drawing.Size(90, 16);
            this.cbxAllTasks.TabIndex = 7;
            this.cbxAllTasks.Text = "全选/全不选";
            this.cbxAllTasks.UseVisualStyleBackColor = true;
            // 
            // cbxForce
            // 
            this.cbxForce.AutoSize = true;
            this.cbxForce.Location = new System.Drawing.Point(13, 26);
            this.cbxForce.Name = "cbxForce";
            this.cbxForce.Size = new System.Drawing.Size(72, 16);
            this.cbxForce.TabIndex = 6;
            this.cbxForce.Text = "强制执行";
            this.cbxForce.UseVisualStyleBackColor = true;
            // 
            // laAccount
            // 
            this.laAccount.AutoSize = true;
            this.laAccount.Location = new System.Drawing.Point(3, 352);
            this.laAccount.Name = "laAccount";
            this.laAccount.Size = new System.Drawing.Size(137, 12);
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
            this.clbxAccount.Location = new System.Drawing.Point(13, 369);
            this.clbxAccount.Name = "clbxAccount";
            this.clbxAccount.Size = new System.Drawing.Size(215, 196);
            this.clbxAccount.TabIndex = 4;
            // 
            // lbTask
            // 
            this.lbTask.AutoSize = true;
            this.lbTask.Location = new System.Drawing.Point(3, 45);
            this.lbTask.Name = "lbTask";
            this.lbTask.Size = new System.Drawing.Size(137, 12);
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
            this.clbxTask.Location = new System.Drawing.Point(13, 61);
            this.clbxTask.Name = "clbxTask";
            this.clbxTask.Size = new System.Drawing.Size(218, 276);
            this.clbxTask.TabIndex = 2;
            // 
            // cbxMultiAccount
            // 
            this.cbxMultiAccount.AutoSize = true;
            this.cbxMultiAccount.Checked = true;
            this.cbxMultiAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMultiAccount.Location = new System.Drawing.Point(13, 6);
            this.cbxMultiAccount.Name = "cbxMultiAccount";
            this.cbxMultiAccount.Size = new System.Drawing.Size(108, 16);
            this.cbxMultiAccount.TabIndex = 1;
            this.cbxMultiAccount.Text = "开启多账号模式";
            this.cbxMultiAccount.UseVisualStyleBackColor = true;
            // 
            // tabAccount
            // 
            this.tabAccount.Controls.Add(this.label2);
            this.tabAccount.Location = new System.Drawing.Point(4, 22);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccount.Size = new System.Drawing.Size(228, 612);
            this.tabAccount.TabIndex = 1;
            this.tabAccount.Text = "帐号";
            this.tabAccount.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "这里暂时什么都没有";
            // 
            // tabTest
            // 
            this.tabTest.Controls.Add(this.btnTestImage);
            this.tabTest.Controls.Add(this.txtInput);
            this.tabTest.Controls.Add(this.btnTestOther);
            this.tabTest.Controls.Add(this.txtImageName);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Size = new System.Drawing.Size(245, 612);
            this.tabTest.TabIndex = 2;
            this.tabTest.Text = "测试";
            this.tabTest.UseVisualStyleBackColor = true;
            // 
            // tabActivity
            // 
            this.tabActivity.Location = new System.Drawing.Point(4, 22);
            this.tabActivity.Name = "tabActivity";
            this.tabActivity.Size = new System.Drawing.Size(228, 612);
            this.tabActivity.TabIndex = 3;
            this.tabActivity.Text = "活动";
            this.tabActivity.UseVisualStyleBackColor = true;
            // 
            // tabRole
            // 
            this.tabRole.Location = new System.Drawing.Point(4, 22);
            this.tabRole.Name = "tabRole";
            this.tabRole.Size = new System.Drawing.Size(228, 612);
            this.tabRole.TabIndex = 4;
            this.tabRole.Text = "角色";
            this.tabRole.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 634);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "星舰助手";
            this.tabControl1.ResumeLayout(false);
            this.tabTask.ResumeLayout(false);
            this.tabTask.PerformLayout();
            this.tabAccount.ResumeLayout(false);
            this.tabAccount.PerformLayout();
            this.tabTest.ResumeLayout(false);
            this.tabTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btnTestImage;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnTestOther;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTask;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.CheckBox cbxMultiAccount;
        private System.Windows.Forms.CheckedListBox clbxTask;
        private System.Windows.Forms.Label lbTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label laAccount;
        private System.Windows.Forms.CheckedListBox clbxAccount;
        private System.Windows.Forms.CheckBox cbxForce;
        private System.Windows.Forms.CheckBox cbxAllAccounts;
        private System.Windows.Forms.CheckBox cbxAllTasks;
        private System.Windows.Forms.TabPage tabActivity;
        private System.Windows.Forms.TabPage tabRole;
    }
}

