namespace NT106_project
{
    partial class Server
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
            lvMess = new ListView();
            tbMess = new TextBox();
            btSend = new Button();
            SuspendLayout();
            // 
            // lvMess
            // 
            lvMess.Location = new Point(68, 24);
            lvMess.Name = "lvMess";
            lvMess.Size = new Size(540, 298);
            lvMess.TabIndex = 0;
            lvMess.UseCompatibleStateImageBehavior = false;
            lvMess.View = View.List;
            // 
            // tbMess
            // 
            tbMess.Location = new Point(64, 363);
            tbMess.Multiline = true;
            tbMess.Name = "tbMess";
            tbMess.Size = new Size(544, 44);
            tbMess.TabIndex = 1;
            // 
            // btSend
            // 
            btSend.Location = new Point(670, 363);
            btSend.Name = "btSend";
            btSend.Size = new Size(94, 44);
            btSend.TabIndex = 2;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click_1;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btSend);
            Controls.Add(tbMess);
            Controls.Add(lvMess);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvMess;
        private TextBox tbMess;
        private Button btSend;
    }
}