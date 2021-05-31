using LM.UI.View.Forms.CommandItems;
using System.Windows.Forms;

namespace LM.UI.View.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCommandLine = new System.Windows.Forms.TabPage();
            this.commandItemsTabPage = new LM.UI.View.Forms.CommandItems.CommandItemsTabPage();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabCommandLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCommandLine);
            this.tabControl.Controls.Add(this.tabAbout);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(915, 474);
            this.tabControl.TabIndex = 0;
            // 
            // tabCommandLine
            // 
            this.tabCommandLine.Controls.Add(this.commandItemsTabPage);
            this.tabCommandLine.Location = new System.Drawing.Point(4, 24);
            this.tabCommandLine.Name = "tabCommandLine";
            this.tabCommandLine.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommandLine.Size = new System.Drawing.Size(907, 446);
            this.tabCommandLine.TabIndex = 1;
            this.tabCommandLine.Text = "Command Lines";
            this.tabCommandLine.UseVisualStyleBackColor = true;
            // 
            // commandItemsTabPage
            // 
            this.commandItemsTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandItemsTabPage.Location = new System.Drawing.Point(3, 3);
            this.commandItemsTabPage.Name = "commandItemsTabPage";
            this.commandItemsTabPage.Size = new System.Drawing.Size(901, 440);
            this.commandItemsTabPage.TabIndex = 0;
            // 
            // tabAbout
            // 
            this.tabAbout.Location = new System.Drawing.Point(4, 24);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(907, 446);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(915, 474);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabControl.ResumeLayout(false);
            this.tabCommandLine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage tabAbout;
        private TabPage tabCommandLine;
        private CommandItemsTabPage commandItemsTabPage;
    }
}

