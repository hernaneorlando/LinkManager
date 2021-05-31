
namespace LM.UI.View.Forms.CommandItems
{
    partial class CommandLineEditForm
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.picFileImage = new System.Windows.Forms.PictureBox();
            this.btnConfirmation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Location = new System.Drawing.Point(40, 50);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(419, 23);
            this.txtCommandLine.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelectFile.FlatAppearance.BorderSize = 0;
            this.btnSelectFile.Image = global::LM.UI.Properties.Resources.Folder;
            this.btnSelectFile.Location = new System.Drawing.Point(465, 49);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(27, 25);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // picFileImage
            // 
            this.picFileImage.BackgroundImage = global::LM.UI.Properties.Resources.EmptyImage;
            this.picFileImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picFileImage.Location = new System.Drawing.Point(12, 50);
            this.picFileImage.Margin = new System.Windows.Forms.Padding(0);
            this.picFileImage.Name = "picFileImage";
            this.picFileImage.Size = new System.Drawing.Size(23, 23);
            this.picFileImage.TabIndex = 2;
            this.picFileImage.TabStop = false;
            // 
            // btnConfirmation
            // 
            this.btnConfirmation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmation.Location = new System.Drawing.Point(417, 106);
            this.btnConfirmation.Name = "btnConfirmation";
            this.btnConfirmation.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmation.TabIndex = 3;
            this.btnConfirmation.Text = "OK";
            this.btnConfirmation.UseVisualStyleBackColor = true;
            this.btnConfirmation.Click += new System.EventHandler(this.BtnConfirmation_Click);
            // 
            // CommandLineEditForm
            // 
            this.AcceptButton = this.btnConfirmation;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(504, 141);
            this.Controls.Add(this.btnConfirmation);
            this.Controls.Add(this.picFileImage);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtCommandLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandLineEditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picFileImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.PictureBox picFileImage;
        private System.Windows.Forms.Button btnConfirmation;
    }
}