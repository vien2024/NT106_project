namespace ChatAppForms
{
    partial class ChatServer
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
            this.menuStripServer = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.btSendMessage = new System.Windows.Forms.Button();
            this.txtRemoveClient = new System.Windows.Forms.TextBox();
            this.btRemoveClient = new System.Windows.Forms.Button();
            this.txtIPa = new System.Windows.Forms.TextBox();
            this.txtBanClient = new System.Windows.Forms.TextBox();
            this.btBanClient = new System.Windows.Forms.Button();
            this.txtWhoIsHereServer = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.menuStripServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripServer
            // 
            this.menuStripServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStripServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.serverOptionsToolStripMenuItem,
            this.themesToolStripMenuItem,
            this.chatToolStripMenuItem});
            this.menuStripServer.Location = new System.Drawing.Point(0, 0);
            this.menuStripServer.Name = "menuStripServer";
            this.menuStripServer.Size = new System.Drawing.Size(1048, 24);
            this.menuStripServer.TabIndex = 0;
            this.menuStripServer.Text = "menuStripServer";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // serverOptionsToolStripMenuItem
            // 
            this.serverOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setServerToolStripMenuItem,
            this.exitServerToolStripMenuItem,
            this.serverManagerToolStripMenuItem});
            this.serverOptionsToolStripMenuItem.Name = "serverOptionsToolStripMenuItem";
            this.serverOptionsToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.serverOptionsToolStripMenuItem.Text = "Server Options";
            // 
            // setServerToolStripMenuItem
            // 
            this.setServerToolStripMenuItem.Name = "setServerToolStripMenuItem";
            this.setServerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.setServerToolStripMenuItem.Text = "Set server";
            this.setServerToolStripMenuItem.Click += new System.EventHandler(this.setServerToolStripMenuItem_Click);
            // 
            // exitServerToolStripMenuItem
            // 
            this.exitServerToolStripMenuItem.Name = "exitServerToolStripMenuItem";
            this.exitServerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exitServerToolStripMenuItem.Text = "Exit server";
            this.exitServerToolStripMenuItem.Click += new System.EventHandler(this.exitServerToolStripMenuItem_Click);
            // 
            // serverManagerToolStripMenuItem
            // 
            this.serverManagerToolStripMenuItem.Name = "serverManagerToolStripMenuItem";
            this.serverManagerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.serverManagerToolStripMenuItem.Text = "Server manager";
            // 
            // themesToolStripMenuItem
            // 
            this.themesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightThemeToolStripMenuItem,
            this.darkThemeToolStripMenuItem});
            this.themesToolStripMenuItem.Name = "themesToolStripMenuItem";
            this.themesToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.themesToolStripMenuItem.Text = "Themes";
            // 
            // lightThemeToolStripMenuItem
            // 
            this.lightThemeToolStripMenuItem.Name = "lightThemeToolStripMenuItem";
            this.lightThemeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.lightThemeToolStripMenuItem.Text = "Light theme";
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.darkThemeToolStripMenuItem.Text = "Dark theme";
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontSizeToolStripMenuItem});
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.chatToolStripMenuItem.Text = "Chat";
            // 
            // fontSizeToolStripMenuItem
            // 
            this.fontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pxToolStripMenuItem,
            this.pxToolStripMenuItem1,
            this.pxToolStripMenuItem2,
            this.pxToolStripMenuItem3,
            this.pxToolStripMenuItem4,
            this.pxToolStripMenuItem5});
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.fontSizeToolStripMenuItem.Text = "Font size";
            // 
            // pxToolStripMenuItem
            // 
            this.pxToolStripMenuItem.Name = "pxToolStripMenuItem";
            this.pxToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pxToolStripMenuItem.Text = "10 px";
            // 
            // pxToolStripMenuItem1
            // 
            this.pxToolStripMenuItem1.Name = "pxToolStripMenuItem1";
            this.pxToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.pxToolStripMenuItem1.Text = "12 px";
            // 
            // pxToolStripMenuItem2
            // 
            this.pxToolStripMenuItem2.Name = "pxToolStripMenuItem2";
            this.pxToolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.pxToolStripMenuItem2.Text = "14 px";
            // 
            // pxToolStripMenuItem3
            // 
            this.pxToolStripMenuItem3.Name = "pxToolStripMenuItem3";
            this.pxToolStripMenuItem3.Size = new System.Drawing.Size(102, 22);
            this.pxToolStripMenuItem3.Text = "16 px";
            // 
            // pxToolStripMenuItem4
            // 
            this.pxToolStripMenuItem4.Name = "pxToolStripMenuItem4";
            this.pxToolStripMenuItem4.Size = new System.Drawing.Size(102, 22);
            this.pxToolStripMenuItem4.Text = "18 px";
            // 
            // pxToolStripMenuItem5
            // 
            this.pxToolStripMenuItem5.Name = "pxToolStripMenuItem5";
            this.pxToolStripMenuItem5.Size = new System.Drawing.Size(102, 22);
            this.pxToolStripMenuItem5.Text = "20 px";
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSendMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSendMessage.Location = new System.Drawing.Point(0, 447);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(572, 33);
            this.txtSendMessage.TabIndex = 2;
            this.txtSendMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btSendMessage
            // 
            this.btSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSendMessage.BackColor = System.Drawing.Color.LightGray;
            this.btSendMessage.Location = new System.Drawing.Point(578, 447);
            this.btSendMessage.Name = "btSendMessage";
            this.btSendMessage.Size = new System.Drawing.Size(69, 33);
            this.btSendMessage.TabIndex = 3;
            this.btSendMessage.Text = "Send";
            this.btSendMessage.UseVisualStyleBackColor = false;
            this.btSendMessage.Click += new System.EventHandler(this.btSendMessage_Click);
            // 
            // txtRemoveClient
            // 
            this.txtRemoveClient.BackColor = System.Drawing.Color.Yellow;
            this.txtRemoveClient.Location = new System.Drawing.Point(653, 27);
            this.txtRemoveClient.Multiline = true;
            this.txtRemoveClient.Name = "txtRemoveClient";
            this.txtRemoveClient.Size = new System.Drawing.Size(100, 93);
            this.txtRemoveClient.TabIndex = 4;
            // 
            // btRemoveClient
            // 
            this.btRemoveClient.BackColor = System.Drawing.Color.LightGray;
            this.btRemoveClient.Location = new System.Drawing.Point(653, 126);
            this.btRemoveClient.Name = "btRemoveClient";
            this.btRemoveClient.Size = new System.Drawing.Size(100, 33);
            this.btRemoveClient.TabIndex = 5;
            this.btRemoveClient.Text = "Remove Client";
            this.btRemoveClient.UseVisualStyleBackColor = false;
            // 
            // txtIPa
            // 
            this.txtIPa.BackColor = System.Drawing.SystemColors.Window;
            this.txtIPa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPa.Location = new System.Drawing.Point(865, 27);
            this.txtIPa.Multiline = true;
            this.txtIPa.Name = "txtIPa";
            this.txtIPa.ReadOnly = true;
            this.txtIPa.Size = new System.Drawing.Size(171, 132);
            this.txtIPa.TabIndex = 6;
            // 
            // txtBanClient
            // 
            this.txtBanClient.BackColor = System.Drawing.Color.Red;
            this.txtBanClient.Location = new System.Drawing.Point(759, 27);
            this.txtBanClient.Multiline = true;
            this.txtBanClient.Name = "txtBanClient";
            this.txtBanClient.Size = new System.Drawing.Size(100, 93);
            this.txtBanClient.TabIndex = 7;
            // 
            // btBanClient
            // 
            this.btBanClient.BackColor = System.Drawing.Color.LightGray;
            this.btBanClient.Location = new System.Drawing.Point(759, 126);
            this.btBanClient.Name = "btBanClient";
            this.btBanClient.Size = new System.Drawing.Size(100, 33);
            this.btBanClient.TabIndex = 8;
            this.btBanClient.Text = "Ban Client";
            this.btBanClient.UseVisualStyleBackColor = false;
            // 
            // txtWhoIsHereServer
            // 
            this.txtWhoIsHereServer.BackColor = System.Drawing.SystemColors.Window;
            this.txtWhoIsHereServer.Location = new System.Drawing.Point(653, 165);
            this.txtWhoIsHereServer.Multiline = true;
            this.txtWhoIsHereServer.Name = "txtWhoIsHereServer";
            this.txtWhoIsHereServer.ReadOnly = true;
            this.txtWhoIsHereServer.Size = new System.Drawing.Size(383, 315);
            this.txtWhoIsHereServer.TabIndex = 9;
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.SystemColors.Window;
            this.txtChat.Location = new System.Drawing.Point(0, 27);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.Size = new System.Drawing.Size(647, 417);
            this.txtChat.TabIndex = 11;
            // 
            // ChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 480);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.txtWhoIsHereServer);
            this.Controls.Add(this.btBanClient);
            this.Controls.Add(this.txtBanClient);
            this.Controls.Add(this.txtIPa);
            this.Controls.Add(this.btRemoveClient);
            this.Controls.Add(this.txtRemoveClient);
            this.Controls.Add(this.btSendMessage);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.menuStripServer);
            this.MainMenuStrip = this.menuStripServer;
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "ChatServer";
            this.ShowIcon = false;
            this.Text = "ChatServer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatServer_FormClosing);
            this.menuStripServer.ResumeLayout(false);
            this.menuStripServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripServer;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Button btSendMessage;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem5;
        private System.Windows.Forms.TextBox txtRemoveClient;
        private System.Windows.Forms.Button btRemoveClient;
        private System.Windows.Forms.TextBox txtIPa;
        private System.Windows.Forms.TextBox txtBanClient;
        private System.Windows.Forms.Button btBanClient;
        private System.Windows.Forms.TextBox txtWhoIsHereServer;
        private System.Windows.Forms.TextBox txtChat;
    }
}