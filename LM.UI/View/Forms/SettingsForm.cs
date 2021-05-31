using LM.UI.Presenter;
using System;
using System.Windows.Forms;

namespace LM.UI.View.Forms
{
    public partial class SettingsForm : Form, ISettingView
    {
        internal readonly SettingPresenter Presenter;

        public SettingsForm(SettingPresenter presenter)
        {
            Presenter = presenter;

            InitializeComponent();
            Load += SettingsForm_Load;
        }

        public void ShowConfig()
        {
            if (Visible)
                Activate();
            else
                ShowDialog();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Presenter.AttachView(this);
            commandItemsTabPage.AttachParent(this);
            commandItemsTabPage.CreateNodes();
        }
    }
}
