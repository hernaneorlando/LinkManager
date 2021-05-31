
namespace LM.UI.View.Forms
{
    partial class ExceptionForm
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
            this.lblMainExceptionName = new System.Windows.Forms.Label();
            this.txbStackTraceException = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMainExceptionName
            // 
            this.lblMainExceptionName.AutoSize = true;
            this.lblMainExceptionName.Location = new System.Drawing.Point(13, 13);
            this.lblMainExceptionName.Name = "lblMainExceptionName";
            this.lblMainExceptionName.Size = new System.Drawing.Size(131, 15);
            this.lblMainExceptionName.Text = "lblMainExceptionName";
            // 
            // txbStackTraceException
            // 
            this.txbStackTraceException.Location = new System.Drawing.Point(13, 43);
            this.txbStackTraceException.Name = "txbStackTraceException";
            this.txbStackTraceException.Size = new System.Drawing.Size(775, 359);
            this.txbStackTraceException.TabIndex = 0;
            this.txbStackTraceException.Text = "";
            this.txbStackTraceException.ReadOnly = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(713, 415);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // ExceptionForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblMainExceptionName);
            this.Controls.Add(this.txbStackTraceException);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exception View";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainExceptionName;
        private System.Windows.Forms.RichTextBox txbStackTraceException;
        private System.Windows.Forms.Button btnOk;
    }
}