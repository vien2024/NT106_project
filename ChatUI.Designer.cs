using System.Windows.Forms;

namespace NT106_project
{
    partial class ChatUI
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
            btLogout = new Button();
            lbEmailname = new Label();
            label1 = new Label();
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pnUserprofile = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            tbProfilePass = new TextBox();
            tbProfileEmail = new TextBox();
            tbProfileLast = new TextBox();
            tbProfileFirst = new TextBox();
            label2 = new Label();
            SettingProfile = new Panel();
            button4 = new Button();
            tbSetLast = new TextBox();
            tbSetpass = new TextBox();
            tbSetFirst = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label10 = new Label();
            label7 = new Label();
            panelChat = new Panel();
            button5 = new Button();
            tbMess = new TextBox();
            lvMess = new ListView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            userControl11 = new UserControl1();
            panel1.SuspendLayout();
            pnUserprofile.SuspendLayout();
            SettingProfile.SuspendLayout();
            panelChat.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btLogout
            // 
            btLogout.BackColor = Color.DarkTurquoise;
            btLogout.Font = new Font("Segoe UI", 12F);
            btLogout.Location = new Point(0, 218);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(210, 37);
            btLogout.TabIndex = 0;
            btLogout.Text = "Log out";
            btLogout.UseVisualStyleBackColor = false;
            btLogout.Click += btLogout_Click;
            // 
            // lbEmailname
            // 
            lbEmailname.AutoEllipsis = true;
            lbEmailname.Location = new Point(12, 82);
            lbEmailname.Name = "lbEmailname";
            lbEmailname.Size = new Size(166, 27);
            lbEmailname.TabIndex = 1;
            lbEmailname.Text = "Email name";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(56, 42);
            label1.Name = "label1";
            label1.Size = new Size(86, 40);
            label1.TabIndex = 2;
            label1.Text = "Profile";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Tan;
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btLogout);
            panel1.Location = new Point(1, 122);
            panel1.Name = "panel1";
            panel1.Size = new Size(210, 329);
            panel1.TabIndex = 3;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkTurquoise;
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(0, 36);
            button3.Name = "button3";
            button3.Size = new Size(210, 44);
            button3.TabIndex = 1;
            button3.Text = "Home";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkTurquoise;
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(0, 98);
            button2.Name = "button2";
            button2.Size = new Size(210, 44);
            button2.TabIndex = 1;
            button2.Text = "Chat";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkTurquoise;
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(0, 157);
            button1.Name = "button1";
            button1.Size = new Size(210, 44);
            button1.TabIndex = 1;
            button1.Text = "Settings";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pnUserprofile
            // 
            pnUserprofile.BackColor = Color.SeaShell;
            pnUserprofile.Controls.Add(label6);
            pnUserprofile.Controls.Add(label5);
            pnUserprofile.Controls.Add(label4);
            pnUserprofile.Controls.Add(label3);
            pnUserprofile.Controls.Add(tbProfilePass);
            pnUserprofile.Controls.Add(tbProfileEmail);
            pnUserprofile.Controls.Add(tbProfileLast);
            pnUserprofile.Controls.Add(tbProfileFirst);
            pnUserprofile.Controls.Add(label2);
            pnUserprofile.Location = new Point(337, 48);
            pnUserprofile.Name = "pnUserprofile";
            pnUserprofile.Size = new Size(379, 309);
            pnUserprofile.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 250);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 2;
            label6.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 191);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 2;
            label5.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 143);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 2;
            label4.Text = "Last name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 97);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 2;
            label3.Text = "First name";
            // 
            // tbProfilePass
            // 
            tbProfilePass.Location = new Point(125, 243);
            tbProfilePass.Name = "tbProfilePass";
            tbProfilePass.Size = new Size(185, 27);
            tbProfilePass.TabIndex = 1;
            // 
            // tbProfileEmail
            // 
            tbProfileEmail.Location = new Point(125, 184);
            tbProfileEmail.Name = "tbProfileEmail";
            tbProfileEmail.Size = new Size(185, 27);
            tbProfileEmail.TabIndex = 1;
            // 
            // tbProfileLast
            // 
            tbProfileLast.Location = new Point(125, 136);
            tbProfileLast.Name = "tbProfileLast";
            tbProfileLast.Size = new Size(185, 27);
            tbProfileLast.TabIndex = 1;
            // 
            // tbProfileFirst
            // 
            tbProfileFirst.Location = new Point(125, 90);
            tbProfileFirst.Name = "tbProfileFirst";
            tbProfileFirst.Size = new Size(185, 27);
            tbProfileFirst.TabIndex = 1;
            // 
            // label2
            // 
            label2.BackColor = Color.Moccasin;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(125, 23);
            label2.Name = "label2";
            label2.Size = new Size(119, 25);
            label2.TabIndex = 0;
            label2.Text = "User profile";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // SettingProfile
            // 
            SettingProfile.BackColor = Color.Cornsilk;
            SettingProfile.Controls.Add(button4);
            SettingProfile.Controls.Add(tbSetLast);
            SettingProfile.Controls.Add(tbSetpass);
            SettingProfile.Controls.Add(tbSetFirst);
            SettingProfile.Controls.Add(label9);
            SettingProfile.Controls.Add(label8);
            SettingProfile.Controls.Add(label10);
            SettingProfile.Controls.Add(label7);
            SettingProfile.Location = new Point(319, 29);
            SettingProfile.Name = "SettingProfile";
            SettingProfile.Size = new Size(435, 348);
            SettingProfile.TabIndex = 5;
            // 
            // button4
            // 
            button4.Location = new Point(178, 294);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 2;
            button4.Text = "Save";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // tbSetLast
            // 
            tbSetLast.Location = new Point(165, 182);
            tbSetLast.Name = "tbSetLast";
            tbSetLast.Size = new Size(125, 27);
            tbSetLast.TabIndex = 1;
            // 
            // tbSetpass
            // 
            tbSetpass.Location = new Point(165, 227);
            tbSetpass.Name = "tbSetpass";
            tbSetpass.Size = new Size(125, 27);
            tbSetpass.TabIndex = 1;
            // 
            // tbSetFirst
            // 
            tbSetFirst.Location = new Point(165, 137);
            tbSetFirst.Name = "tbSetFirst";
            tbSetFirst.Size = new Size(125, 27);
            tbSetFirst.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(48, 234);
            label9.Name = "label9";
            label9.Size = new Size(73, 20);
            label9.TabIndex = 0;
            label9.Text = "Password:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(48, 191);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 0;
            label8.Text = "Last name:";
            label8.Click += label8_Click;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 14F);
            label10.Location = new Point(135, 33);
            label10.Name = "label10";
            label10.Size = new Size(193, 34);
            label10.TabIndex = 0;
            label10.Text = "Settings profile";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(48, 142);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 0;
            label7.Text = "First name:";
            // 
            // panelChat
            // 
            panelChat.Controls.Add(button5);
            panelChat.Controls.Add(tbMess);
            panelChat.Controls.Add(lvMess);
            panelChat.Controls.Add(flowLayoutPanel1);
            panelChat.Location = new Point(217, 0);
            panelChat.Name = "panelChat";
            panelChat.Size = new Size(581, 438);
            panelChat.TabIndex = 6;
            // 
            // button5
            // 
            button5.Location = new Point(319, 363);
            button5.Name = "button5";
            button5.Size = new Size(73, 38);
            button5.TabIndex = 3;
            button5.Text = "Send";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // tbMess
            // 
            tbMess.Location = new Point(31, 363);
            tbMess.Multiline = true;
            tbMess.Name = "tbMess";
            tbMess.Size = new Size(252, 34);
            tbMess.TabIndex = 2;
            // 
            // lvMess
            // 
            lvMess.Location = new Point(31, 29);
            lvMess.Name = "lvMess";
            lvMess.Size = new Size(361, 311);
            lvMess.TabIndex = 1;
            lvMess.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(userControl11);
            flowLayoutPanel1.Location = new Point(428, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(153, 438);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // userControl11
            // 
            userControl11.BackColor = Color.PapayaWhip;
            userControl11.Location = new Point(3, 3);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(150, 59);
            userControl11.TabIndex = 0;
            userControl11.Title = null;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelChat);
            Controls.Add(SettingProfile);
            Controls.Add(pnUserprofile);
            Controls.Add(panel1);
            Controls.Add(lbEmailname);
 
            SettingProfile.PerformLayout();
            panelChat.ResumeLayout(false);
            panelChat.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btLogout;
        private Label lbEmailname;
        private Label label1;
        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel pnUserprofile;
        public Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox tbProfilePass;
        private TextBox tbProfileEmail;
        private TextBox tbProfileLast;
        private TextBox tbProfileFirst;
        private Panel SettingProfile;
        private Button button4;
        private TextBox tbSetLast;
        private TextBox tbSetpass;
        private TextBox tbSetFirst;
        private Label label9;
        private Label label8;
        private Label label10;
        private Label label7;
        private Panel panelChat;
        private FlowLayoutPanel flowLayoutPanel1;
        private UserControl1 userControl11;
        private ListView lvMess;
        private Button button5;
        private TextBox tbMess;
    }
}