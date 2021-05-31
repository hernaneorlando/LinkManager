using System;
using System.Windows.Forms;

namespace LM.UI.View.Forms.CommandItems
{
    public partial class EditForm : Form
    {
        private string _result;

        public EditForm()
        {
            InitializeComponent();
        }

        public string ShowPrompt(string caption, string fieldText)
        {
            Text = caption;
            txtCommandLine.Text = fieldText;

            return ShowDialog() == DialogResult.OK
                ? _result
                : string.Empty;
        }

        private void BtnConfirmation_Click(object sender, EventArgs e)
        {
            _result = txtCommandLine.Text;
            Close();
            txtCommandLine.Text = string.Empty;
        }
    }
}
