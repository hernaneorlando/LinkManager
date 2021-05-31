using LM.UI.View.ViewItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LM.UI.View.Forms.CommandItems
{
    public partial class CommandItemsTabPage : UserControl
    {
        private const string Collapse = "Collapse All";
        private const string Expand = "Expand All";
        private const string Mark = "Mark Group";
        private const string UnMark = "Unmark Group";

        private SettingsForm parent;
        private bool collapsed = true;

        public CommandItemsTabPage()
        {
            InitializeComponent();
        }

        internal void AttachParent(SettingsForm parent)
        {
            this.parent = parent;
        }

        internal void CreateNodes()
        {
            tvwCommandItems.DrawNodes(parent.Presenter.Groups);

            var enable = parent.Presenter.Groups.Any();
            btnExpandAll.Enabled = enable;
            btnMarkGroup.Enabled = enable;
        }

        private void TvwCommandItems_DataSourceChanged(object sender, EventArgs e)
        {
            var groupList = (List<GroupViewItem>)sender;
            var enable = groupList.Any();
            btnExpandAll.Enabled = enable;
            btnMarkGroup.Enabled = enable;
        }

        private void BtnAddNewGroup_Click(object sender, EventArgs e)
        {
            tvwCommandItems.AddNewGroup();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            parent.Presenter.SaveGroups(tvwCommandItems.GetGroups());
            parent.Close();
        }

        private void BtnMarkGroup_Click(object sender, EventArgs e)
        {
            if (!Equals(sender, btnMarkGroup))
                return;

            var enableCheckBox = !tvwCommandItems.CheckBoxes;
            var buttomText = enableCheckBox ? UnMark : Mark;

            btnMarkGroup.Text = buttomText;
            tvwCommandItems.BeginUpdate();
            tvwCommandItems.CheckBoxes = enableCheckBox;
            btnDeleteNode.Visible = enableCheckBox;

            tvwCommandItems.ExpandAll();
            tvwCommandItems.SelectedNode = tvwCommandItems.Nodes[0];
            tvwCommandItems.EndUpdate();
        }





        private void BtnDeleteNode_Click(object sender, EventArgs e)
        {
            var firstLevelNodes = tvwCommandItems.Nodes;
            for (var i = firstLevelNodes.Count - 1; i >= 0; i--)
            {
                if (firstLevelNodes[i].Checked)
                {
                    firstLevelNodes.RemoveAt(i);
                }
                else
                {
                    var secondLevelNodes = firstLevelNodes[i].Nodes;
                    for (var j = secondLevelNodes.Count - 1; j >= 0; j--)
                    {
                        if (secondLevelNodes[j].Checked)
                            secondLevelNodes.RemoveAt(j);
                    }
                }
            }
        }

        private void BtnExpandAll_Click(object sender, EventArgs e)
        {
            if (!Equals(sender, btnExpandAll))
                return;

            btnExpandAll.Text = collapsed ? Collapse : Expand;
            tvwCommandItems.BeginUpdate();
            if (collapsed)
            {
                tvwCommandItems.ExpandAll();
            }
            else
            {
                tvwCommandItems.CollapseAll();

            }

            tvwCommandItems.EndUpdate();
            if (tvwCommandItems.Nodes.Count > 0)
                tvwCommandItems.SelectedNode = tvwCommandItems.Nodes[0];

            collapsed = !collapsed;
        }
    }
}
