using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_project
{
    public partial class EmojiPickerForm : Form
    {
        public string SelectedEmoji { get; private set; }
        public event EventHandler<string> EmojiSelected;

        private void OnEmojiSelected(string emoji)
        {
            EmojiSelected?.Invoke(this, emoji);
        }
        public EmojiPickerForm(List<string> emojis)
        {
            InitializeComponent();
            PopulateEmojis(emojis);
        }
        private void ConfigureTableLayoutPanel(int emojiCount, int columns)
        {
            int rows = (int)Math.Ceiling(emojiCount / (double)columns);

            emojiTableLayoutPanel.ColumnCount = columns;
            emojiTableLayoutPanel.RowCount = rows;

            emojiTableLayoutPanel.ColumnStyles.Clear();
            emojiTableLayoutPanel.RowStyles.Clear();

            for (int i = 0; i < columns; i++)
            {
                emojiTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columns));
            }

            for (int i = 0; i < rows; i++)
            {
                emojiTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
        }
        private void PopulateEmojis(List<string> emojis)
        {
            int columns = 5;
            ConfigureTableLayoutPanel(emojis.Count, columns);

            int column = 0, row = 0;
            foreach (var emoji in emojis)
            {
                var emojiButton = new Button
                {
                    Text = emoji,
                    Dock = DockStyle.Fill
                };
                emojiButton.Click += (sender, e) =>
                {
                    OnEmojiSelected(emoji);
                };

                if (column >= columns)
                {
                    column = 0;
                    row++;
                }

                emojiTableLayoutPanel.Controls.Add(emojiButton, column, row);
                column++;
            }
        }
    }
}
