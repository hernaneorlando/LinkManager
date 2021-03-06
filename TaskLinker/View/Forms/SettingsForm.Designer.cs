using System.Windows.Forms;
using TaskLinker.View.Components;

namespace TaskLinker.View.Forms
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
            this.tabCommandItems = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.btnAddNewGroup = new System.Windows.Forms.Button();
            this.btnMarkGroup = new System.Windows.Forms.Button();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.tvwCommandItems = new TaskLinker.View.Components.MixedCheckBoxesTreeView();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabCommandItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCommandItems);
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
            // tabCommandItems
            // 
            this.tabCommandItems.Controls.Add(this.btnSave);
            this.tabCommandItems.Controls.Add(this.btnDeleteNode);
            this.tabCommandItems.Controls.Add(this.btnAddNewGroup);
            this.tabCommandItems.Controls.Add(this.btnMarkGroup);
            this.tabCommandItems.Controls.Add(this.btnExpandAll);
            this.tabCommandItems.Controls.Add(this.tvwCommandItems);
            this.tabCommandItems.Location = new System.Drawing.Point(4, 24);
            this.tabCommandItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCommandItems.Name = "tabCommandItems";
            this.tabCommandItems.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCommandItems.Size = new System.Drawing.Size(907, 446);
            this.tabCommandItems.TabIndex = 0;
            this.tabCommandItems.Text = "Command Items";
            this.tabCommandItems.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(808, 408);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 27);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.Location = new System.Drawing.Point(272, 9);
            this.btnDeleteNode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(88, 27);
            this.btnDeleteNode.TabIndex = 3;
            this.btnDeleteNode.Text = "Delete Node";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            this.btnDeleteNode.Visible = false;
            this.btnDeleteNode.Click += new System.EventHandler(this.BtnDeleteNode_Click);
            // 
            // btnAddNewGroup
            // 
            this.btnAddNewGroup.Location = new System.Drawing.Point(9, 8);
            this.btnAddNewGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddNewGroup.Name = "btnAddNewGroup";
            this.btnAddNewGroup.Size = new System.Drawing.Size(113, 27);
            this.btnAddNewGroup.TabIndex = 4;
            this.btnAddNewGroup.Text = "Add New Group";
            this.btnAddNewGroup.UseVisualStyleBackColor = true;
            this.btnAddNewGroup.Click += new System.EventHandler(this.BtnAddNewGroup_Click);
            // 
            // btnMarkGroup
            // 
            this.btnMarkGroup.Location = new System.Drawing.Point(131, 8);
            this.btnMarkGroup.Margin = new System.Windows.Forms.Padding(5);
            this.btnMarkGroup.Name = "btnMarkGroup";
            this.btnMarkGroup.Size = new System.Drawing.Size(132, 27);
            this.btnMarkGroup.TabIndex = 2;
            this.btnMarkGroup.Text = "Mark Group";
            this.btnMarkGroup.UseVisualStyleBackColor = true;
            this.btnMarkGroup.Click += new System.EventHandler(this.BtnMarkGroup_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Location = new System.Drawing.Point(9, 408);
            this.btnExpandAll.Margin = new System.Windows.Forms.Padding(5);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(88, 27);
            this.btnExpandAll.TabIndex = 1;
            this.btnExpandAll.Text = "Expand All";
            this.btnExpandAll.UseVisualStyleBackColor = true;
            this.btnExpandAll.Click += new System.EventHandler(this.BtnExpandAll_Click);
            // 
            // tvwCommandItems
            // 
            this.tvwCommandItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwCommandItems.ItemHeight = 18;
            this.tvwCommandItems.Location = new System.Drawing.Point(9, 42);
            this.tvwCommandItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tvwCommandItems.Name = "tvwCommandItems";
            this.tvwCommandItems.Size = new System.Drawing.Size(887, 367);
            this.tvwCommandItems.TabIndex = 0;
            // 
            // tabAbout
            // 
            this.tabAbout.Location = new System.Drawing.Point(4, 24);
            this.tabAbout.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabAbout.Size = new System.Drawing.Size(907, 446);
            this.tabAbout.TabIndex = 1;
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
            this.tabCommandItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage tabCommandItems;
        private TabPage tabAbout;
        private MixedCheckBoxesTreeView tvwCommandItems;
        private Button btnExpandAll;
        private Button btnMarkGroup;
        private Button btnAddNewGroup;
        private Button btnDeleteNode;
        private Button btnSave;
    }
}

