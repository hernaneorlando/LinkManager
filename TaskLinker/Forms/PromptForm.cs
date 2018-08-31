using System.Windows.Forms;

namespace TaskLinker.Forms
{
    public partial class PromptForm : Form
    {
        public string Result { get; private set; }

        public PromptForm(string text, string caption)
        {
            InitializeComponent();

            textLabel.Text = text;
            this.Text = caption;
        }

        private void Confirmation_Click(object sender, System.EventArgs e)
        {
            Result = textBox.Text;
            this.Close();
        }
    }
}
