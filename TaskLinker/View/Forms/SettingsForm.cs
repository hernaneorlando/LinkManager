using System;
using System.Linq;
using System.Windows.Forms;
using TaskLinker.Model;
using TaskLinker.Extensions;
using TaskLinker.Presenter;
using TaskLinker.View.Components;

namespace TaskLinker.View.Forms
{
    public partial class SettingsForm : Form, ISettingView
    {
        private const string Collapse = "Collapse All";
        private const string Expand = "Expand All";
        private const string Mark = "Mark Group";
        private const string UnMark = "Unmark Group";
        private const string GroupName = "Type group name:";
        private const string SubGroupName = "Type sub group name:";
        private const string NewSubGroup = "Add New Sub Group";
        private const string NewUrl = "Add new URL";
        private const string Edit = "Edit";
        private const string EditUrl = "Edit URL";

        private bool _collapsed = true;

        private readonly SettingPresenter _presenter;
        private readonly IEditView _editView;
        private readonly ICommandLineEditView _commandLineEditView;

        public SettingsForm(
            SettingPresenter presenter,
            IEditView editView,
            ICommandLineEditView commandLineEditView)
        {
            _presenter = presenter;
            _editView = editView;
            _commandLineEditView = commandLineEditView;

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
            CreateNodeContextMenu(null, GroupName, NewSubGroup);
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

        private void CreateNodes(bool createGroupNodeContextMenu)
        {
            tvwCommandItems.Nodes.Clear();
            _presenter.Groups.ForEach(group =>
            {
                var newSubGroupNodes = group.CommandItems.Select(item =>
                {
                    var commandItemNode = new TreeNode
                    {
                        Text = item.LinkName,
                        ContextMenuStrip = new ContextMenuStrip()
                    };

                    if (string.IsNullOrWhiteSpace(item.CommandLine) && createGroupNodeContextMenu)
                    {
                        commandItemNode.ContextMenuStrip.Items.Add(NewUrl, null, (sender, e) => CreateNodeContextMenu(commandItemNode, SubGroupName, NewUrl));
                    }
                    else
                    {
                        var commandLineNode = new HiddenCheckBoxTreeNode
                        {
                            Text = item.CommandLine,
                            Checked = false,
                            ContextMenuStrip = new ContextMenuStrip()
                        };

                        if (!string.IsNullOrWhiteSpace(item.CommandLine))
                        {
                            commandLineNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditCommantLineNode(commandLineNode));
                        }

                        commandItemNode.Nodes.Add(commandLineNode);
                    }

                    commandItemNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNode(commandItemNode, Edit));

                    return commandItemNode;
                }).ToArray();

                var newGroupNode = new TreeNode(group.Name, newSubGroupNodes)
                {
                    ContextMenuStrip = new ContextMenuStrip()
                };

                if (createGroupNodeContextMenu)
                {
                    newGroupNode.ContextMenuStrip.Items.Add(NewSubGroup, null, (sender, e) => CreateNodeContextMenu(newGroupNode, SubGroupName, NewUrl));
                    newGroupNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNode(newGroupNode, Edit));
                }

                tvwCommandItems.Nodes.Add(newGroupNode);
            });

            var enable = tvwCommandItems.Nodes.Count > 0 && tvwCommandItems.Nodes[0].Nodes.Count > 0;

            btnExpandAll.Enabled = enable;
            btnMarkGroup.Enabled = enable;
        }

        private void CreateNodeContextMenu(TreeNode node, string caption, string menuText)
        {
            var nodePrompt = _editView.ShowPrompt(caption, null);
            if (string.IsNullOrWhiteSpace(nodePrompt))
                return;

            var newNode = new TreeNode
            {
                Text = nodePrompt,
                ContextMenuStrip = new ContextMenuStrip()
            };

            if (node == null)
            {
                tvwCommandItems.AddWithValidation(newNode);
                newNode.ContextMenuStrip.Items.Add(menuText, null, (sender, e) => CreateNodeContextMenu(newNode, SubGroupName, NewUrl));
            }
            else if (node?.Level == 0)
            {
                node.AddWithValidation(newNode);
                newNode.ContextMenuStrip.Items.Add(menuText, null, (sender, e) => EditCommantLineNode(newNode));
            }

            newNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNode(newNode, Edit));
        }

        private void EditTreeNode(TreeNode node, string caption)
        {
            var text = _editView.ShowPrompt(caption, node.Text);

            if (node.Level == 0)
            {
                var group = _presenter.Groups.SingleOrDefault(g => g.Name == node.Text);
                _presenter.Groups.Remove(group);
            }

            if (!string.IsNullOrWhiteSpace(text))
                node.Text = text;
        }

        private void EditCommantLineNode(TreeNode node)
        {
            if (node?.Level == 1)
            {
                var commandLine = _commandLineEditView.ShowPrompt(string.Empty, null);

                var newNode = new TreeNode
                {
                    Text = commandLine.Value,
                    ContextMenuStrip = new ContextMenuStrip()
                };

                if (node.AddWithValidation(newNode))
                {
                    node.ContextMenuStrip = new ContextMenuStrip();
                    node.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNode(node, Edit));
                    newNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditCommantLineNode(newNode));
                }
            }
            else
            {
                var text = node.Text;
                var image = node.ContextMenuStrip.Items[0]?.Image;

                var commandLine = _commandLineEditView.ShowPrompt(text, image);
                if (commandLine != null)
                {
                    node.Text = commandLine.Value;
                    var item = node.ContextMenuStrip.Items[0];
                    if (item != null)
                        item.Image = commandLine.Image;
                }
            }
        }

        private void SetCommandItems(TreeNode groupNode, Group group)
        {
            foreach (TreeNode subGroupNode in groupNode.Nodes)
            {
                var node = subGroupNode.Nodes[0];

                group.CommandItems.Add(new CommandItem
                {
                    LinkName = subGroupNode.Text,
                    CommandLine = node?.Text
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
