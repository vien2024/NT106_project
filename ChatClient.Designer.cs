namespace Client
{
    partial class clientForm
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

        private void InitializeComponent()
        {
            LBloginUsers = new ListBox();
            LBroomList = new ListBox();
            User = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            RTBroomChat = new RichTextBox();
            TBroomChat = new TextBox();
            BTsendChatRoom = new Button();
            label5 = new Label();
            label6 = new Label();
            BTcreate = new Button();
            BTjoin = new Button();
            LBuserName = new Label();
            TBroomName = new TextBox();
            SuspendLayout();

            // 
            // LBloginUsers
            // 
            LBloginUsers.FormattingEnabled = true;
            LBloginUsers.Location = new Point(1004, 89);
            LBloginUsers.Margin = new Padding(3, 4, 3, 4);
            LBloginUsers.Name = "LBloginUsers";
            LBloginUsers.Size = new Size(117, 744);
            LBloginUsers.TabIndex = 0;
            LBloginUsers.SelectedIndexChanged += LBloginUsers_SelectedIndexChanged;
            // 
            // LBroomList
            // 
            LBroomList.FormattingEnabled = true;
            LBroomList.Location = new Point(851, 89);
            LBroomList.Margin = new Padding(3, 4, 3, 4);
            LBroomList.Name = "LBroomList";
            LBroomList.Size = new Size(120, 244);
            LBroomList.TabIndex = 1;
            // 
            // User
            // 
            User.FormattingEnabled = true;
            User.Location = new Point(851, 509);
            User.Margin = new Padding(3, 4, 3, 4);
            User.Name = "User";
            User.Size = new Size(120, 324);
            User.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(865, 55);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 3;
            label1.Text = "Room List";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1016, 55);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 4;
            label2.Text = "Online Users";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(865, 462);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 5;
            label3.Text = "Users in Room";
            // 
            // RTBroomChat
            // 
            RTBroomChat.Location = new Point(41, 89);
            RTBroomChat.Margin = new Padding(3, 4, 3, 4);
            RTBroomChat.Name = "RTBroomChat";
            RTBroomChat.Size = new Size(791, 602);
            RTBroomChat.TabIndex = 8;
            RTBroomChat.Text = "";
            RTBroomChat.TextChanged += RTBroomChat_TextChanged;
            // 
            // TBroomChat
            // 
            TBroomChat.Location = new Point(41, 744);
            TBroomChat.Margin = new Padding(3, 4, 3, 4);
            TBroomChat.Multiline = true;
            TBroomChat.Name = "TBroomChat";
            TBroomChat.Size = new Size(571, 79);
            TBroomChat.TabIndex = 10;
            TBroomChat.TextChanged += TBroomChat_TextChanged;
            // 
            // BTsendChatRoom
            // 
            BTsendChatRoom.BackColor = SystemColors.ControlDark;
            BTsendChatRoom.Location = new Point(650, 760);
            BTsendChatRoom.Margin = new Padding(3, 4, 3, 4);
            BTsendChatRoom.Name = "BTsendChatRoom";
            BTsendChatRoom.Size = new Size(162, 64);
            BTsendChatRoom.TabIndex = 12;
            BTsendChatRoom.Text = "Send";
            BTsendChatRoom.UseVisualStyleBackColor = false;
            BTsendChatRoom.Click += BTsendChatRoom_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 55);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 13;
            label5.Text = "Room Chat";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 28);
            label6.Name = "label6";
            label6.Size = new Size(85, 20);
            label6.TabIndex = 14;
            label6.Text = "User Name:";
            label6.Click += label6_Click;
            // 
            // BTcreate
            // 
            BTcreate.Location = new Point(851, 391);
            BTcreate.Margin = new Padding(3, 4, 3, 4);
            BTcreate.Name = "BTcreate";
            BTcreate.Size = new Size(66, 44);
            BTcreate.TabIndex = 16;
            BTcreate.Text = "Create";
            BTcreate.UseVisualStyleBackColor = true;
            BTcreate.Click += BTcreate_Click;
            // 
            // BTjoin
            // 
            BTjoin.Location = new Point(923, 391);
            BTjoin.Margin = new Padding(3, 4, 3, 4);
            BTjoin.Name = "BTjoin";
            BTjoin.Size = new Size(48, 44);
            BTjoin.TabIndex = 17;
            BTjoin.Text = "Join";
            BTjoin.UseVisualStyleBackColor = true;
            BTjoin.Click += BTjoin_Click;
            // 
            // LBuserName
            // 
            LBuserName.AutoSize = true;
            LBuserName.Location = new Point(126, 28);
            LBuserName.Name = "LBuserName";
            LBuserName.Size = new Size(111, 20);
            LBuserName.TabIndex = 18;
            LBuserName.Text = "_________________";
            // 
            // TBroomName
            // 
            TBroomName.Location = new Point(851, 356);
            TBroomName.Margin = new Padding(3, 4, 3, 4);
            TBroomName.Name = "TBroomName";
            TBroomName.Size = new Size(120, 27);
            TBroomName.TabIndex = 19;
            // 
            // clientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 880);
            Controls.Add(TBroomName);
            Controls.Add(LBuserName);
            Controls.Add(BTjoin);
            Controls.Add(BTcreate);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(BTsendChatRoom);
            Controls.Add(TBroomChat);
            Controls.Add(RTBroomChat);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(User);
            Controls.Add(LBroomList);
            Controls.Add(LBloginUsers);
            Margin = new Padding(3, 4, 3, 4);
            Name = "clientForm";
            Text = "client form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox LBloginUsers;
        private System.Windows.Forms.ListBox LBroomList;
        private System.Windows.Forms.ListBox User;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox RTBroomChat;
        private System.Windows.Forms.TextBox TBroomChat;
        private System.Windows.Forms.Button BTsendChatRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTcreate;
        private System.Windows.Forms.Button BTjoin;
        private System.Windows.Forms.Label LBuserName;
        private System.Windows.Forms.TextBox TBroomName;
    }
}