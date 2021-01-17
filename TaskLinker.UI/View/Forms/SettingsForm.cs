using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TaskLinker.Model;
using TaskLinker.UI.Presenter;
using TaskLinker.UI.View.Components;

namespace TaskLinker.UI.View.Forms
{
    public partial class SettingsForm : Form, ISettingView
    {
        private const string Collapse = "Collapse All";
        private const string Expand = "Expand All";
        private const string Mark = "Mark Group";
        private const string UnMark = "Unmark Group";
        private const string GroupName = "Type group name:";
        private const string SubGroupName = "Type sub group name:";
        private const string NewGroup = "Add New Group";
        private const string NewSubGroup = "Add New Sub Group";
        private const string NewUrl = "Add new URL";
        private const string Edit = "Edit";
        private const string EditUrl = "Edit URL";

        private bool _collapsed = true;

        private readonly SettingPresenter _presenter;
        private readonly INewCommandLineView _newCommandLineView;

        public SettingsForm(SettingPresenter presenter, INewCommandLineView newCommandLineView)
        {
            _presenter = presenter;
            _newCommandLineView = newCommandLineView;

            InitializeComponent();
            Load += SettingsForm_Load;
        }

        public void ShowConfig()
        {
            if (Visible)
                Activate();
            else
                ShowDialog();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _presenter.AttachView(this);
            CreateNodes(true);
        }

        private void CreateNodes(bool createGroupNodeContextMenu)
        {
            tvwCommandItems.Nodes.Clear();
            _presenter.Groups.ForEach(node =>
            {
                var nodes = node.CommandItems.Select(item =>
                {
                    var urlNode = new TreeNode
                    {
                        Text = item.LinkName,
                        ContextMenuStrip = new ContextMenuStrip()
                    };

                    if (string.IsNullOrWhiteSpace(item.CommandLine) && createGroupNodeContextMenu)
                    {
                        urlNode.ContextMenuStrip.Items.Add(NewUrl, null, (sender, e) => AddNewSubGroup(urlNode));
                    }
                    else
                    {
                        var textNode = new HiddenCheckBoxTreeNode
                        {
                            Text = item.CommandLine,
                            Checked = false,
                            ContextMenuStrip = new ContextMenuStrip()
                        };

                        if (!string.IsNullOrWhiteSpace(item.CommandLine))
                        {
                            textNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNodeName(textNode, EditUrl));
                        }

                        urlNode.Nodes.Add(textNode);
                    }

                    urlNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNodeName(urlNode, Edit));

                    return urlNode;
                }).ToArray();

                var groupNode = new TreeNode(node.Name, nodes)
                {
                    ContextMenuStrip = new ContextMenuStrip()
                };

                if (createGroupNodeContextMenu)
                {
                    groupNode.ContextMenuStrip.Items.Add(NewSubGroup, null, (sender, e) => AddNewSubGroup(groupNode));
                    groupNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNodeName(groupNode, Edit));
                }

                tvwCommandItems.Nodes.Add(groupNode);
            });

            EnableButtons();
        }

        private void AddNewSubGroup(TreeNode groupNode)
        {
            CreateNodeContextMenu(groupNode, SubGroupName, NewSubGroup, NewUrl);
        }

        private void EditTreeNodeName(TreeNode node, string caption)
        {
            var text = _newCommandLineView.ShowPrompt(caption, Edit, node.Text);

            if (node.Level == 0)
            {
                var group = _presenter.Groups.SingleOrDefault(g => g.Name == node.Text);
                _presenter.Groups.Remove(group);
            }

            if (!string.IsNullOrWhiteSpace(text))
                node.Text = text;
        }

        private void CreateNodeContextMenu(TreeNode node, string nodeText, string nodeCaption, string menuText)
        {
            var nodePrompt = _newCommandLineView.ShowPrompt(nodeText, nodeCaption);
            if (string.IsNullOrWhiteSpace(nodePrompt))
                return;

            var newNode = new TreeNode
            {
                Text = nodePrompt,
                ContextMenuStrip = new ContextMenuStrip()
            };

            switch (node?.Level)
            {
                case 0:
                    node.Nodes.Add(newNode);
                    break;

                case 1:
                    node.Nodes.Add(newNode);
                    node.ContextMenuStrip = new ContextMenuStrip();
                    node.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNodeName(node, Edit));
                    newNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNodeName(newNode, Edit));
                    return;

                default:
                    tvwCommandItems.Nodes.Add(newNode);
                    break;
            }

            newNode.ContextMenuStrip.Items.Add(menuText, null, (sender, e) => AddNewSubGroup(newNode));
            newNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNodeName(newNode, Edit));
        }

        private void EnableButtons()
        {
            var enable = tvwCommandItems.Nodes.Count > 0 && tvwCommandItems.Nodes[0].Nodes.Count > 0;

            btnExpandAll.Enabled = enable;
            btnMarkGroup.Enabled = enable;
        }

        private void BtnExpandAll_Click(object sender, EventArgs e)
        {
            if (!Equals(sender, btnExpandAll))
                return;

            btnExpandAll.Text = _collapsed ? Collapse : Expand;
            tvwCommandItems.BeginUpdate();
            if (_collapsed)
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

            _collapsed = !_collapsed;
        }

        private void BtnMarkGroup_Click(object sender, EventArgs e)
        {
            if (!Equals(sender, btnMarkGroup))
                return;

            RedrawMarkedTree(!tvwCommandItems.CheckBoxes);
        }

        private void BtnAddNewGroup_Click(object sender, EventArgs e)
        {
            CreateNodeContextMenu(null, GroupName, NewGroup, NewSubGroup);
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            foreach (TreeNode groupNode in tvwCommandItems.Nodes)
            {
                var persistedGroup = _presenter.Groups.FirstOrDefault(g => g.Name == groupNode.Text.Trim());
                if (persistedGroup != null)
                {
                    persistedGroup.CommandItems.Clear();
                    SetCommandItems(groupNode, persistedGroup);
                }
                else
                {
                    var group = new Group
                    {
                        Name = groupNode.Text.Trim()
                    };

                    SetCommandItems(groupNode, group);

                    _presenter.Groups.Add(group);
                }
            }

            _presenter.SaveList();

            Close();
        }

        private void SetCommandItems(TreeNode groupNode, Group group)
        {
            foreach (TreeNode subGroupNode in groupNode.Nodes)
            {
                group.CommandItems.Add(new CommandItem
                {
                    LinkName = subGroupNode.Text,
                    CommandLine = subGroupNode.Nodes[0]?.Text
                });
            }
        }

        private void RedrawMarkedTree(bool enableCheckBox)
        {
            var buttomText = enableCheckBox ? UnMark : Mark;

            btnMarkGroup.Text = buttomText;
            tvwCommandItems.BeginUpdate();
            tvwCommandItems.CheckBoxes = enableCheckBox;
            btnDeleteNode.Visible = enableCheckBox;
            CreateNodes(!enableCheckBox);

            if (!_collapsed)
                tvwCommandItems.ExpandAll();

            tvwCommandItems.EndUpdate();

            if (tvwCommandItems.Nodes.Count > 0)
                tvwCommandItems.SelectedNode = tvwCommandItems.Nodes[0];
        }
    }
}
