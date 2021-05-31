using System.Windows.Forms;

namespace LM.UI.View.Forms.CommandItems
{
    partial class CommandItemsTabPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.btnAddNewGroup = new System.Windows.Forms.Button();
            this.btnMarkGroup = new System.Windows.Forms.Button();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.tvwCommandItems = new global::LM.UI.View.Forms.CommandItems.MixedCheckBoxesTreeView();
            this.SuspendLayout();
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
            this.btnMarkGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.btnExpandAll.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.tvwCommandItems.HideSelection = false;
            this.tvwCommandItems.ItemHeight = 18;
            this.tvwCommandItems.Location = new System.Drawing.Point(9, 42);
            this.tvwCommandItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tvwCommandItems.Name = "tvwCommandItems";
            this.tvwCommandItems.Size = new System.Drawing.Size(887, 358);
            this.tvwCommandItems.TabIndex = 0;
            this.tvwCommandItems.DataSourceChanged += new MixedCheckBoxesTreeView.DataSourceChangedEventHandler(this.TvwCommandItems_DataSourceChanged);
            // 
            // CommandItemsTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeleteNode);
            this.Controls.Add(this.btnAddNewGroup);
            this.Controls.Add(this.btnMarkGroup);
            this.Controls.Add(this.btnExpandAll);
            this.Controls.Add(this.tvwCommandItems);
            this.Name = "CommandItemsTabPage";
            this.Size = new System.Drawing.Size(901, 440);
            this.ResumeLayout(false);

        }

        #endregion

        private MixedCheckBoxesTreeView tvwCommandItems;
        private Button btnExpandAll;
        private Button btnMarkGroup;
        private Button btnAddNewGroup;
        private Button btnDeleteNode;
        private Button btnSave;
    }
}
