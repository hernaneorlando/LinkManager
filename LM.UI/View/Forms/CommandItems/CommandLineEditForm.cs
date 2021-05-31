using LM.UI.View.ViewItem;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LM.UI.View.Forms.CommandItems
{
    public partial class CommandLineEditForm : Form
    {
        private CommandItemViewItem commandLine;
        private bool isImagedChanged;

        public CommandLineEditForm()
        {
            InitializeComponent();
        }

        internal CommandItemViewItem ShowPrompt(string commandLine, Image image)
        {
            if (image != null)
                picFileImage.Image = new Bitmap(image, new Size(picFileImage.Width, picFileImage.Height)); ;

            txtCommandLine.Text = commandLine;
            isImagedChanged = false;
            return ShowDialog() == DialogResult.OK ? this.commandLine : null;
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
                var image = Icon.ExtractAssociatedIcon(filePath);
                picFileImage.Image = new Bitmap(image.ToBitmap(), new Size(picFileImage.Width, picFileImage.Height));
                picFileImage.BackgroundImage = null;
                isImagedChanged = true;
                txtCommandLine.Text = filePath;
            }
        }

        private void BtnConfirmation_Click(object sender, EventArgs e)
        {
            commandLine = new CommandItemViewItem
            {
                CommandLine = txtCommandLine.Text,
                Image = picFileImage.Image
            };

            if (isImagedChanged)
                commandLine.CreateImageKey();

            Close();

            txtCommandLine.Text = string.Empty;
            picFileImage.Image = null;
        }
    }
}
