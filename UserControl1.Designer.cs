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
            lbName = new Label();
            SuspendLayout();
            // 
            // lbName
            // 
            lbName.Font = new Font("Segoe UI", 11F);
            lbName.Location = new Point(13, 13);
            lbName.Name = "lbName";
            lbName.Size = new Size(176, 25);
            lbName.TabIndex = 0;
            lbName.Text = "label1";
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            Controls.Add(lbName);
            Name = "UserControl1";
            Size = new Size(228, 331);
            ResumeLayout(false);
        }

        #endregion

        private Label lbName;
    }
}
