using System;
using System.Windows.Forms;

namespace TaskLinker.UI.View.Forms
{
    public partial class ExceptionForm : Form, IExceptionView
    {
        public ExceptionForm()
        {
            InitializeComponent();
        }

        public void ShowException(Exception ex)
        {
            lblMainExceptionName.Text = ex.GetType().Name;
            txbStackTraceException.Text = ex.ToString();

            ShowDialog();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
