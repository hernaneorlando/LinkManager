using System.Drawing;
using System.Windows.Forms;

namespace TaskLinker.Forms
{
    partial class PromptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.confirmation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(1, 25);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(500, 28);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "label1";
            this.textLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(50, 55);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(400, 22);
            this.textBox.TabIndex = 1;
            // 
            // confirmation
            // 
            this.confirmation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmation.Location = new System.Drawing.Point(350, 83);
            this.confirmation.Name = "confirmation";
            this.confirmation.Size = new System.Drawing.Size(100, 28);
            this.confirmation.TabIndex = 2;
            this.confirmation.Text = "Ok";
            this.confirmation.Click += new System.EventHandler(this.Confirmation_Click);
            // 
            // PromptForm
            // 
            this.AcceptButton = this.confirmation;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(500, 150);
            this.Controls.Add(this.confirmation);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.textLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label textLabel;
        private TextBox textBox;
        private Button confirmation;
    }
}