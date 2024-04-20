namespace ChatAppForms
{
    partial class SetServer
    {
 
        private System.ComponentModel.IContainer components = null;

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
            this.txtWPTU = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtSUYP = new System.Windows.Forms.TextBox();
            this.btSetUp = new System.Windows.Forms.Button();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.txtAdminName = new System.Windows.Forms.TextBox();
            this.txtSUYAN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtWPTU
            // 
            this.txtWPTU.Location = new System.Drawing.Point(12, 12);
            this.txtWPTU.Name = "txtWPTU";
            this.txtWPTU.ReadOnly = true;
            this.txtWPTU.Size = new System.Drawing.Size(158, 20);
            this.txtWPTU.TabIndex = 0;
            this.txtWPTU.Text = "Which port to use:";
            this.txtWPTU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(12, 38);
            this.txtPort.Multiline = true;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(158, 104);
            this.txtPort.TabIndex = 2;
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSUYP
            // 
            this.txtSUYP.Location = new System.Drawing.Point(304, 12);
            this.txtSUYP.Name = "txtSUYP";
            this.txtSUYP.ReadOnly = true;
            this.txtSUYP.Size = new System.Drawing.Size(162, 20);
            this.txtSUYP.TabIndex = 3;
            this.txtSUYP.Text = "Set up your password";
            this.txtSUYP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btSetUp
            // 
            this.btSetUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetUp.Location = new System.Drawing.Point(102, 148);
            this.btSetUp.Name = "btSetUp";
            this.btSetUp.Size = new System.Drawing.Size(268, 38);
            this.btSetUp.TabIndex = 4;
            this.btSetUp.Text = "Set up port, name and passwd";
            this.btSetUp.UseVisualStyleBackColor = true;
            this.btSetUp.Click += new System.EventHandler(this.btSetUp_Click);
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(304, 38);
            this.txtPasswd.Multiline = true;
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Size = new System.Drawing.Size(162, 104);
            this.txtPasswd.TabIndex = 6;
            // 
            // txtAdminName
            // 
            this.txtAdminName.Location = new System.Drawing.Point(176, 38);
            this.txtAdminName.Multiline = true;
            this.txtAdminName.Name = "txtAdminName";
            this.txtAdminName.Size = new System.Drawing.Size(122, 104);
            this.txtAdminName.TabIndex = 7;
            this.txtAdminName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSUYAN
            // 
            this.txtSUYAN.Location = new System.Drawing.Point(176, 12);
            this.txtSUYAN.Name = "txtSUYAN";
            this.txtSUYAN.ReadOnly = true;
            this.txtSUYAN.Size = new System.Drawing.Size(122, 20);
            this.txtSUYAN.TabIndex = 8;
            this.txtSUYAN.Text = "Set up your admin name";
            this.txtSUYAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SetServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 226);
            this.Controls.Add(this.txtSUYAN);
            this.Controls.Add(this.txtAdminName);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.btSetUp);
            this.Controls.Add(this.txtSUYP);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtWPTU);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetServer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SetServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWPTU;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtSUYP;
        private System.Windows.Forms.Button btSetUp;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.TextBox txtAdminName;
        private System.Windows.Forms.TextBox txtSUYAN;
    }
}