namespace Farm_In_Client
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblPassword;
        private SmartX.SmartKeyboard smartKeyboard1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.smartKeyboard1 = new SmartX.SmartKeyboard();
            this.SuspendLayout();

            // txtUserID
            this.txtUserID.Location = new System.Drawing.Point(189, 45);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(353, 23);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.GotFocus += new System.EventHandler(this.TxtUserID_GotFocus);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(189, 85);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(353, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.GotFocus += new System.EventHandler(this.TxtPassword_GotFocus);

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(585, 45);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(136, 63);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // lblUserID
            this.lblUserID.Location = new System.Drawing.Point(109, 45);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(74, 23);
            this.lblUserID.Text = "User ID:";

            // lblPassword
            this.lblPassword.Location = new System.Drawing.Point(109, 85);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 23);
            this.lblPassword.Text = "Password:";

            // smartKeyboard1
            this.smartKeyboard1.BackGround = null;
            this.smartKeyboard1.BackGroundColor = System.Drawing.Color.LightBlue;
            this.smartKeyboard1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(110)))), ((int)(((byte)(165)))));
            this.smartKeyboard1.BorderStyle = SmartX.SmartKeyboard.BorderStyles.RoundRectFill;
            this.smartKeyboard1.ControlKeyDisable = false;
            this.smartKeyboard1.DesignMinimize = false;
            this.smartKeyboard1.HanYoungKeyDisable = false;
            this.smartKeyboard1.KeyBoardBackImage = null;
            this.smartKeyboard1.KeyboardType = SmartX.SmartKeyboard.KEYBOARDTYPES.NORMAL;
            this.smartKeyboard1.KeyFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(225)))));
            this.smartKeyboard1.KeyOutLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(225)))));
            this.smartKeyboard1.KeyOutLineWidth = 1;
            this.smartKeyboard1.KeyPressFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(28)))), ((int)(((byte)(58)))));
            this.smartKeyboard1.KeyPressImage1 = null;
            this.smartKeyboard1.KeyPressImage2 = null;
            this.smartKeyboard1.KeyPressImage3 = null;
            this.smartKeyboard1.KeyPressOutLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(225)))));
            this.smartKeyboard1.KeyPressTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.smartKeyboard1.KeyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.smartKeyboard1.KeyTextFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.smartKeyboard1.KeyUpImage1 = null;
            this.smartKeyboard1.KeyUpImage2 = null;
            this.smartKeyboard1.KeyUpImage3 = null;
            this.smartKeyboard1.Location = new System.Drawing.Point(34, 126);
            this.smartKeyboard1.MarginLeftRight = 7;
            this.smartKeyboard1.MarginTopBottom = 7;
            this.smartKeyboard1.Name = "smartKeyboard1";
            this.smartKeyboard1.OverlapOptimize = true;
            this.smartKeyboard1.Radius = 5;
            this.smartKeyboard1.RoundedCorners = false;
            this.smartKeyboard1.RoundRectFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.smartKeyboard1.Size = new System.Drawing.Size(741, 292);
            this.smartKeyboard1.SizeRunTime = new System.Drawing.Size(741, 292);
            this.smartKeyboard1.TabIndex = 6;
            this.smartKeyboard1.TABKeyDisable = false;
            this.smartKeyboard1.TargetInputObject = this.txtUserID; // Initially target txtUserID
            this.smartKeyboard1.Text = "smartKeyboard1";
            this.smartKeyboard1.TextColor = System.Drawing.Color.Black;
            this.smartKeyboard1.TextColorDisable = System.Drawing.Color.Gray;
            this.smartKeyboard1.Visible = true;
            this.smartKeyboard1.ThemeStyle = SmartX.SmartKeyboard.KEYBOARDTHEMESTYLE.STANDARD1;

            // LoginForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(801, 431);
            this.Controls.Add(this.smartKeyboard1);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
        }
    }
}
