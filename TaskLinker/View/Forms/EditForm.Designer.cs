
namespace TaskLinker.View.Forms
{
    partial class EditForm
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
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.btnConfirmation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Location = new System.Drawing.Point(13, 44);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(473, 23);
            this.txtCommandLine.TabIndex = 1;
            // 
            // btnConfirmation
            // 
            this.btnConfirmation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmation.Location = new System.Drawing.Point(391, 78);
            this.btnConfirmation.Name = "btnConfirmation";
            this.btnConfirmation.Size = new System.Drawing.Size(94, 29);
            this.btnConfirmation.TabIndex = 2;
            this.btnConfirmation.Text = "OK";
            this.btnConfirmation.UseVisualStyleBackColor = true;
            this.btnConfirmation.Click += new System.EventHandler(this.BtnConfirmation_Click);
            // 
            // EditForm
            // 
            this.AcceptButton = this.btnConfirmation;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(498, 142);
            this.Controls.Add(this.btnConfirmation);
            this.Controls.Add(this.txtCommandLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Button btnConfirmation;
    }
}