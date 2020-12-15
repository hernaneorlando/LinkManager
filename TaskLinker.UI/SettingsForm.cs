using System;
using System.Windows.Forms;
using TaskLinker.UI.Presenter;
using TaskLinker.UI.View;

namespace TaskLinker.UI
{
    public partial class SettingsForm : Form, ISettingView
    {
        private readonly SettingPresenter _presenter;

        public SettingsForm(SettingPresenter presenter)
        {
            _presenter = presenter;

            InitializeComponent();
            Load += SettingsForm_Load;
        }

        public void ShowConfig()
        {
            if (Visible)
            {
                Activate();
            }
            else
            {
                ShowDialog();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _presenter.AttachView(this);
        }
    }
}
