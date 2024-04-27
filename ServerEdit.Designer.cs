namespace NT106_project
{
    partial class ServerEdit
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
            Delete = new Button();
            ban = new Button();
            lbEmailname = new Label();
            label1 = new Label();
            label3 = new Label();
            button5 = new Button();
            button7 = new Button();
            label4 = new Label();
            button2 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            button4 = new Button();
            label5 = new Label();
            label6 = new Label();
            ListInfo = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)ListInfo).BeginInit();
            SuspendLayout();
            // 
            // Delete
            // 
            Delete.BackColor = Color.Brown;
            Delete.Font = new Font("Segoe UI", 12F);
            Delete.ForeColor = SystemColors.ButtonFace;
            Delete.Location = new Point(168, 218);
            Delete.Name = "Delete";
            Delete.Size = new Size(100, 44);
            Delete.TabIndex = 2;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = false;
            Delete.Click += button3_Click;
            // 
            // ban
            // 
            ban.BackColor = Color.Firebrick;
            ban.Font = new Font("Segoe UI", 12F);
            ban.ForeColor = SystemColors.ButtonFace;
            ban.Location = new Point(317, 218);
            ban.Name = "ban";
            ban.Size = new Size(107, 44);
            ban.TabIndex = 3;
            ban.Text = "Ban";
            ban.UseVisualStyleBackColor = false;
            ban.Click += ban_Click;
            // 
            // lbEmailname
            // 
            lbEmailname.AutoEllipsis = true;
            lbEmailname.BackColor = Color.Gray;
            lbEmailname.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmailname.Location = new Point(216, 9);
            lbEmailname.Name = "lbEmailname";
            lbEmailname.Size = new Size(150, 37);
            lbEmailname.TabIndex = 4;
            lbEmailname.Text = "Profile User";
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.BackColor = Color.Gainsboro;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 64);
            label1.Name = "label1";
            label1.Size = new Size(112, 37);
            label1.TabIndex = 8;
            label1.Text = "User Name: ";
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.BackColor = Color.Gainsboro;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(50, 166);
            label3.Name = "label3";
            label3.Size = new Size(112, 37);
            label3.TabIndex = 10;
            label3.Text = "Status: ";
            // 
            // button5
            // 
            button5.BackColor = Color.Silver;
            button5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(168, 68);
            button5.Name = "button5";
            button5.Size = new Size(256, 33);
            button5.TabIndex = 7;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Silver;
            button7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.Location = new Point(168, 119);
            button7.Name = "button7";
            button7.Size = new Size(256, 33);
            button7.TabIndex = 12;
            button7.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.BackColor = Color.Gainsboro;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(50, 277);
            label4.Name = "label4";
            label4.Size = new Size(112, 37);
            label4.TabIndex = 13;
            label4.Text = "Find:";
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(168, 170);
            button2.Name = "button2";
            button2.Size = new Size(256, 33);
            button2.TabIndex = 14;
            button2.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Gainsboro;
            flowLayoutPanel1.Location = new Point(32, 49);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(429, 299);
            flowLayoutPanel1.TabIndex = 15;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.BackColor = Color.Gainsboro;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(50, 115);
            label2.Name = "label2";
            label2.Size = new Size(112, 37);
            label2.TabIndex = 16;
            label2.Text = "User ID:";
            label2.Click += label2_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Silver;
            button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(168, 281);
            button4.Name = "button4";
            button4.Size = new Size(256, 33);
            button4.TabIndex = 17;
            button4.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.BackColor = Color.Gainsboro;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(50, 225);
            label5.Name = "label5";
            label5.Size = new Size(112, 37);
            label5.TabIndex = 18;
            label5.Text = "Option:";
            // 
            // label6
            // 
            label6.AutoEllipsis = true;
            label6.BackColor = Color.Gray;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(578, 9);
            label6.Name = "label6";
            label6.Size = new Size(150, 37);
            label6.TabIndex = 20;
            label6.Text = "List InfoUsers";
            // 
            // ListInfo
            // 
            ListInfo.BackgroundColor = Color.Gainsboro;
            ListInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListInfo.Columns.AddRange(new DataGridViewColumn[] { ID, name, Status });
            ListInfo.Location = new Point(498, 49);
            ListInfo.Name = "ListInfo";
            ListInfo.RowHeadersWidth = 51;
            ListInfo.Size = new Size(430, 467);
            ListInfo.TabIndex = 21;
            ListInfo.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "User ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 125;
            // 
            // name
            // 
            name.DataPropertyName = "name";
            name.HeaderText = "User Name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // ServerEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(958, 545);
            Controls.Add(ListInfo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(button7);
            Controls.Add(label3);
            Controls.Add(button5);
            Controls.Add(lbEmailname);
            Controls.Add(ban);
            Controls.Add(Delete);
            Controls.Add(flowLayoutPanel1);
            Name = "ServerEdit";
            Text = "ServerEdit";
            Load += ServerEdit_Load;
            ((System.ComponentModel.ISupportInitialize)ListInfo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Delete;
        private Button ban;
        private Label lbEmailname;
        private Label label1;
        private Label label3;
        private Button button5;
        private Button button7;
        private Label label4;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Button button4;
        private Label label5;
        private Label label6;
        private DataGridView ListInfo;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Status;
    }
}