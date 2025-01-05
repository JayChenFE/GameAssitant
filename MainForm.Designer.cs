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
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(63, 195);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnTestImage
            // 
            this.btnTestImage.Location = new System.Drawing.Point(12, 42);
            this.btnTestImage.Name = "btnTestImage";
            this.btnTestImage.Size = new System.Drawing.Size(75, 23);
            this.btnTestImage.TabIndex = 1;
            this.btnTestImage.Text = "测试图片";
            this.btnTestImage.UseVisualStyleBackColor = true;
            this.btnTestImage.Click += new System.EventHandler(this.test_Click);
            // 
            // txtImageName
            // 
            this.txtImageName.Location = new System.Drawing.Point(93, 42);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(100, 21);
            this.txtImageName.TabIndex = 2;
            this.txtImageName.TextChanged += new System.EventHandler(this.imageName_TextChanged);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(93, 110);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 21);
            this.txtInput.TabIndex = 4;
            // 
            // btnTestOther
            // 
            this.btnTestOther.Location = new System.Drawing.Point(12, 110);
            this.btnTestOther.Name = "btnTestOther";
            this.btnTestOther.Size = new System.Drawing.Size(75, 23);
            this.btnTestOther.TabIndex = 3;
            this.btnTestOther.Text = "测试其他";
            this.btnTestOther.UseVisualStyleBackColor = true;
            this.btnTestOther.Click += new System.EventHandler(this.btnTestOther_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 516);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnTestOther);
            this.Controls.Add(this.txtImageName);
            this.Controls.Add(this.btnTestImage);
            this.Controls.Add(this.btn_start);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btnTestImage;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnTestOther;
    }
}

