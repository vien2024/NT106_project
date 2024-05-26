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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lvMess
            // 
            lvMess.Location = new Point(64, 61);
            lvMess.Name = "lvMess";
            lvMess.Size = new Size(341, 298);
            lvMess.TabIndex = 0;
            lvMess.UseCompatibleStateImageBehavior = false;
            lvMess.View = View.List;
            // 
            // tbMess
            // 
            tbMess.Location = new Point(64, 380);
            tbMess.Multiline = true;
            tbMess.Name = "tbMess";
            tbMess.Size = new Size(223, 44);
            tbMess.TabIndex = 1;
            // 
            // btSend
            // 
            btSend.Location = new Point(311, 380);
            btSend.Name = "btSend";
            btSend.Size = new Size(94, 44);
            btSend.TabIndex = 2;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(457, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(296, 298);
            dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Location = new Point(457, 24);
            label1.Name = "label1";
            label1.Size = new Size(143, 25);
            label1.TabIndex = 4;
            label1.Text = "Connected User:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Location = new Point(64, 24);
            label2.Name = "label2";
            label2.Size = new Size(143, 25);
            label2.TabIndex = 4;
            label2.Text = "Message:";
            label2.Click += label1_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btSend);
            Controls.Add(tbMess);
            Controls.Add(lvMess);
            Name = "Server";
            Text = "Server";
            Load += Server_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvMess;
        private TextBox tbMess;
        private Button btSend;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
    }
}