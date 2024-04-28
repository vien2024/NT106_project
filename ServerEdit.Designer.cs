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
            lbEmailname = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            ListInfo = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)ListInfo).BeginInit();
            SuspendLayout();
            // 
            // lbEmailname
            // 
            lbEmailname.AutoEllipsis = true;
            lbEmailname.BackColor = Color.Gray;
            lbEmailname.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmailname.Location = new Point(168, 9);
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Gainsboro;
            flowLayoutPanel1.Location = new Point(24, 49);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(429, 299);
            flowLayoutPanel1.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.BackColor = Color.Gainsboro;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(50, 119);
            label2.Name = "label2";
            label2.Size = new Size(112, 33);
            label2.TabIndex = 16;
            label2.Text = "User ID:";
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
            label6.Location = new Point(639, 9);
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
            // textBox1
            // 
            textBox1.Location = new Point(168, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 27);
            textBox1.TabIndex = 22;

            // 
            // textBox2
            // 
            textBox2.Location = new Point(168, 176);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 27);
            textBox2.TabIndex = 23;

            // 
            // textBox3
            // 
            textBox3.Location = new Point(168, 125);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(250, 27);
            textBox3.TabIndex = 24;

            // 
            // textBox4
            // 
            textBox4.Location = new Point(168, 287);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(250, 27);
            textBox4.TabIndex = 25;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Firebrick;
            button1.ForeColor = Color.White;
            button1.Location = new Point(168, 218);
            button1.Name = "button1";
            button1.Size = new Size(72, 44);
            button1.TabIndex = 26;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Firebrick;
            button2.ForeColor = Color.White;
            button2.Location = new Point(246, 218);
            button2.Name = "button2";
            button2.Size = new Size(92, 44);
            button2.TabIndex = 27;
            button2.Text = "Reset";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Firebrick;
            button3.ForeColor = Color.White;
            button3.Location = new Point(344, 217);
            button3.Name = "button3";
            button3.Size = new Size(74, 44);
            button3.TabIndex = 28;
            button3.Text = "Ban";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // ServerEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(958, 545);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(ListInfo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lbEmailname);
            Controls.Add(flowLayoutPanel1);
            Name = "ServerEdit";
            Text = "ServerEdit";
            Load += ServerEdit_Load;
            ((System.ComponentModel.ISupportInitialize)ListInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbEmailname;
        private Label label1;
        private Label label3;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Label label5;
        private Label label6;
        private DataGridView ListInfo;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Status;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}