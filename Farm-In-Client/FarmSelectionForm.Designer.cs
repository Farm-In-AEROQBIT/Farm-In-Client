namespace Farm_In_Client
{
    partial class FarmSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbFarms;
        private System.Windows.Forms.Button btnSelectFarm;
        private System.Windows.Forms.Label lblSelectFarm;

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
            this.cbFarms = new System.Windows.Forms.ComboBox();
            this.btnSelectFarm = new System.Windows.Forms.Button();
            this.lblSelectFarm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbFarms
            // 
            this.cbFarms.Location = new System.Drawing.Point(86, 107);
            this.cbFarms.Name = "cbFarms";
            this.cbFarms.Size = new System.Drawing.Size(588, 23);
            this.cbFarms.TabIndex = 0;
            // 
            // btnSelectFarm
            // 
            this.btnSelectFarm.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btnSelectFarm.Location = new System.Drawing.Point(528, 263);
            this.btnSelectFarm.Name = "btnSelectFarm";
            this.btnSelectFarm.Size = new System.Drawing.Size(146, 61);
            this.btnSelectFarm.TabIndex = 1;
            this.btnSelectFarm.Text = "확인";
            this.btnSelectFarm.Click += new System.EventHandler(this.btnSelectFarm_Click);
            // 
            // lblSelectFarm
            // 
            this.lblSelectFarm.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular);
            this.lblSelectFarm.Location = new System.Drawing.Point(86, 35);
            this.lblSelectFarm.Name = "lblSelectFarm";
            this.lblSelectFarm.Size = new System.Drawing.Size(145, 41);
            this.lblSelectFarm.Text = "농장 선택:";
            // 
            // FarmSelectionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(801, 431);
            this.Controls.Add(this.lblSelectFarm);
            this.Controls.Add(this.btnSelectFarm);
            this.Controls.Add(this.cbFarms);
            this.Name = "FarmSelectionForm";
            this.Text = "Farm Selection";
            this.ResumeLayout(false);

        }
    }
}
