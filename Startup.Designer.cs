namespace NT106_project
{
    partial class Startup
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
            btServer = new Button();
            btClient = new Button();
            SuspendLayout();
            // 
            // btServer
            // 
            btServer.Location = new Point(146, 48);
            btServer.Name = "btServer";
            btServer.Size = new Size(94, 55);
            btServer.TabIndex = 0;
            btServer.Text = "Server";
            btServer.UseVisualStyleBackColor = true;
            btServer.Click += btServer_Click;
            // 
            // btClient
            // 
            btClient.Location = new Point(146, 209);
            btClient.Name = "btClient";
            btClient.Size = new Size(94, 55);
            btClient.TabIndex = 0;
            btClient.Text = "Client";
            btClient.UseVisualStyleBackColor = true;
            btClient.Click += btClient_Click;
            // 
            // Startup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btClient);
            Controls.Add(btServer);
            Name = "Startup";
            Text = "Startup";
            ResumeLayout(false);
        }

        #endregion

        private Button btServer;
        private Button btClient;
    }
}