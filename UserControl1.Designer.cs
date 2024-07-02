using System.Xml.Linq;

namespace NT106_project
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BorderRadius = 25;
            guna2TextBox1.CustomizableEdges = customizableEdges1;
            guna2TextBox1.DefaultText = "Nhật ho vĩnh tai sao lại ko\r\n\r\n";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.Dock = DockStyle.Left;
            guna2TextBox1.FillColor = Color.Gray;
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 12F);
            guna2TextBox1.ForeColor = Color.White;
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(0, 0);
            guna2TextBox1.Margin = new Padding(4, 6, 4, 6);
            guna2TextBox1.MaximumSize = new Size(400, 600);
            guna2TextBox1.MaxLength = 1500;
            guna2TextBox1.MinimumSize = new Size(50, 50);
            guna2TextBox1.Multiline = true;
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.ReadOnly = true;
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(400, 586);
            guna2TextBox1.TabIndex = 3;
            guna2TextBox1.WordWrap = false;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(guna2TextBox1);
            MaximumSize = new Size(500, 600);
            MinimumSize = new Size(50, 50);
            Name = "UserControl1";
            Size = new Size(500, 586);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}
