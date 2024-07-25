namespace Farm_In_Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.Button btnForceUpload;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCountdown;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnForceUpload = new System.Windows.Forms.Button();
            this.btnReboot = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnForceUpload
            // 
            this.btnForceUpload.Location = new System.Drawing.Point(50, 283);
            this.btnForceUpload.Name = "btnForceUpload";
            this.btnForceUpload.Size = new System.Drawing.Size(242, 40);
            this.btnForceUpload.TabIndex = 0;
            this.btnForceUpload.Text = "강제 전송";
            this.btnForceUpload.Click += new System.EventHandler(this.btnForceUpload_Click);
            // 
            // btnReboot
            // 
            this.btnReboot.Location = new System.Drawing.Point(452, 283);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(242, 40);
            this.btnReboot.TabIndex = 1;
            this.btnReboot.Text = "강제 재시작";
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.lblStatus.Location = new System.Drawing.Point(43, 83);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(704, 63);
            this.lblStatus.Text = "데이터를 보내기 위한 준비 중입니다.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCountdown
            // 
            this.lblCountdown.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular);
            this.lblCountdown.Location = new System.Drawing.Point(257, 173);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(294, 31);
            this.lblCountdown.Text = "다음 전송까지 00:00";
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(801, 431);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnReboot);
            this.Controls.Add(this.btnForceUpload);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Farm In Client";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
