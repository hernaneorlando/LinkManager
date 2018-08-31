using System.Windows.Forms;
using TaskLinker.Properties;

namespace TaskLinker.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRepository = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.addNewGroupButton = new System.Windows.Forms.Button();
            this.deleteNodeButton = new System.Windows.Forms.Button();
            this.markGroupButton = new System.Windows.Forms.Button();
            this.expandAllButton = new System.Windows.Forms.Button();
            this.repositoryTreeView = new TaskLinker.Forms.MixedCheckBoxesTreeView();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabRepository.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRepository);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 411);
            this.tabControl1.TabIndex = 0;
            // 
            // tabRepository
            // 
            this.tabRepository.Controls.Add(this.saveButton);
            this.tabRepository.Controls.Add(this.addNewGroupButton);
            this.tabRepository.Controls.Add(this.deleteNodeButton);
            this.tabRepository.Controls.Add(this.markGroupButton);
            this.tabRepository.Controls.Add(this.expandAllButton);
            this.tabRepository.Controls.Add(this.repositoryTreeView);
            this.tabRepository.Location = new System.Drawing.Point(4, 22);
            this.tabRepository.Name = "tabRepository";
            this.tabRepository.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepository.Size = new System.Drawing.Size(776, 385);
            this.tabRepository.TabIndex = 0;
            this.tabRepository.Text = "Repository";
            this.tabRepository.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(695, 354);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // addNewGroupButton
            // 
            this.addNewGroupButton.Location = new System.Drawing.Point(209, 7);
            this.addNewGroupButton.Name = "addNewGroupButton";
            this.addNewGroupButton.Size = new System.Drawing.Size(97, 23);
            this.addNewGroupButton.TabIndex = 4;
            this.addNewGroupButton.Text = "Add New Group";
            this.addNewGroupButton.UseVisualStyleBackColor = true;
            this.addNewGroupButton.Click += new System.EventHandler(this.AddNewGroupButton_Click);
            // 
            // deleteNodeButton
            // 
            this.deleteNodeButton.Location = new System.Drawing.Point(312, 7);
            this.deleteNodeButton.Name = "deleteNodeButton";
            this.deleteNodeButton.Size = new System.Drawing.Size(75, 23);
            this.deleteNodeButton.TabIndex = 3;
            this.deleteNodeButton.Text = "Delete Node";
            this.deleteNodeButton.UseVisualStyleBackColor = true;
            this.deleteNodeButton.Visible = false;
            this.deleteNodeButton.Click += new System.EventHandler(this.DeleteNodeButton_Click);
            // 
            // markGroupButton
            // 
            this.markGroupButton.Location = new System.Drawing.Point(90, 7);
            this.markGroupButton.Name = "markGroupButton";
            this.markGroupButton.Size = new System.Drawing.Size(113, 23);
            this.markGroupButton.TabIndex = 2;
            this.markGroupButton.Text = "Mark Group";
            this.markGroupButton.UseVisualStyleBackColor = true;
            this.markGroupButton.Click += new System.EventHandler(this.MarkGroupButton_Click);
            // 
            // expandAllButton
            // 
            this.expandAllButton.Location = new System.Drawing.Point(9, 7);
            this.expandAllButton.Name = "expandAllButton";
            this.expandAllButton.Size = new System.Drawing.Size(75, 23);
            this.expandAllButton.TabIndex = 1;
            this.expandAllButton.Text = "Expand All";
            this.expandAllButton.UseVisualStyleBackColor = true;
            this.expandAllButton.Click += new System.EventHandler(this.ExpandAllButton_Click);
            // 
            // repositoryTreeView
            // 
            this.repositoryTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.repositoryTreeView.ItemHeight = 18;
            this.repositoryTreeView.Location = new System.Drawing.Point(8, 36);
            this.repositoryTreeView.Name = "repositoryTreeView";
            this.repositoryTreeView.Size = new System.Drawing.Size(760, 318);
            this.repositoryTreeView.TabIndex = 0;
            // 
            // tabAbout
            // 
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(776, 385);
            this.tabAbout.TabIndex = 1;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormConfig";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabRepository.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRepository;
        private System.Windows.Forms.TabPage tabAbout;
        private MixedCheckBoxesTreeView repositoryTreeView;
        private Button expandAllButton;
        private Button markGroupButton;
        private Button addNewGroupButton;
        private Button deleteNodeButton;
        private Button saveButton;
    }
}

