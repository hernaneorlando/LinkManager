using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskLinker.Forms
{
    internal class NodePrompt : IDisposable
    {
        private Form Prompt { get; set; }
        public string Result { get; }

        public NodePrompt(string text, string caption)
        {
            Result = ShowDialog(text, caption);
        }
        //use a using statement
        private string ShowDialog(string text, string caption)
        {
            Prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                TopMost = true
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { Prompt.Close(); };
            Prompt.Controls.Add(textBox);
            Prompt.Controls.Add(confirmation);
            Prompt.Controls.Add(textLabel);
            Prompt.AcceptButton = confirmation;

            return Prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public void Dispose()
        {
            Prompt.Dispose();
        }
    }
}