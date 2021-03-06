using System;
using System.Drawing;
using System.Windows.Forms;
using TaskLinker.View.Components;

namespace TaskLinker.View.Forms
{
    public partial class CommandLineEditForm : Form, ICommandLineEditView
    {
        private CommandLine _commandLine;

        public CommandLineEditForm()
        {
            InitializeComponent();
        }

        public CommandLine ShowPrompt(string commandLine, Image image)
        {
            picFileImage.Image = image;
            txtCommandLine.Text = commandLine;

            return ShowDialog() == DialogResult.OK ? _commandLine : null;
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                var icon = Icon.ExtractAssociatedIcon(filePath);
                picFileImage.Image = new Bitmap(icon.ToBitmap(), new Size(picFileImage.Width, picFileImage.Height));

                txtCommandLine.Text = filePath;
            }
        }

        private void BtnConfirmation_Click(object sender, EventArgs e)
        {
            _commandLine = new CommandLine
            {
                Value = txtCommandLine.Text,
                Image = picFileImage.Image
            };

            Close();

            txtCommandLine.Text = string.Empty;
            picFileImage.Image = null;
        }
    }
}
