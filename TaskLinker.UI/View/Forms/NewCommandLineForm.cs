using System;
using System.Windows.Forms;
using TaskLinker.UI.Presenter;

namespace TaskLinker.UI.View.Forms
{
    public partial class NewCommandLineForm : Form, INewCommandLineView
    {
        private readonly NewCommandLinePresenter _presenter;

        private string _result;

        public NewCommandLineForm(NewCommandLinePresenter presenter)
        {
            _presenter = presenter;

            InitializeComponent();
            Load += NewCommandLineForm_Load;
        }

        public string ShowPrompt(string caption = null, string labelText = null, string fieldText = null)
        {
            Text = caption;
            lblCommandLineName.Text = labelText;
            txtCommandLine.Text = fieldText;

            return ShowDialog() == DialogResult.OK
                ? _result
                : string.Empty;
        }

        private void NewCommandLineForm_Load(object sender, EventArgs e)
        {
            _presenter.AttachView(this);
        }

        private void BtnConfirmation_Click(object sender, EventArgs e)
        {
            _result = txtCommandLine.Text;
            Close();
            txtCommandLine.Text = string.Empty;
        }
    }
}
