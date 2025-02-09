namespace GameAssitant.Applications.UI
{
    partial class AccountConfigForm
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
            this.flowPanelAccounts = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowPanelAccounts
            // 
            this.flowPanelAccounts.AutoScroll = true;
            this.flowPanelAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelAccounts.Location = new System.Drawing.Point(0, 0);
            this.flowPanelAccounts.Name = "flowPanelAccounts";
            this.flowPanelAccounts.Size = new System.Drawing.Size(800, 450);
            this.flowPanelAccounts.TabIndex = 0;
            // 
            // AccountConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowPanelAccounts);
            this.Name = "AccountConfigForm";
            this.Text = "AccountConfigForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanelAccounts;
    }
}