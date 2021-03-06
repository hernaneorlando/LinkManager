using System;
using System.Windows.Forms;
using TaskLinker.Presenter;

namespace TaskLinker.View.Forms
{
    public partial class EditForm : Form, IEditView
    {
        private readonly EditPresenter _presenter;

        private string _result;

        public EditForm(EditPresenter presenter)
        {
            _presenter = presenter;

            InitializeComponent();
            Load += NewCommandLineForm_Load;
        }

        public string ShowPrompt(string caption, string fieldText)
        {
            Text = caption;
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
