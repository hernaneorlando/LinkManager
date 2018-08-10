using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using TaskLinker.Model;
using TaskLinker.Util;

namespace TaskLinker.Forms
{
    public partial class FormConfig : Form
    {
        private const string AddNewUrl = "Add new URL";

        private bool _collapsed = true;

        private RepositoryViewModel _repository;

        public FormConfig()
        {
            InitializeComponent();
        }

        public RepositoryViewModel Repository
        {
            get { return _repository; }
            set
            {
                _repository = value;
                CreateNodes(true);
            }
        }

        private void ExpandAllButton_Click(object sender, EventArgs e)
        {
            if (!Equals(sender, expandAllButton))
            {
                return;
            }

            expandAllButton.Text = _collapsed ? "Collapse All" : "Expand All";
            repositoryTreeView.BeginUpdate();
            if (_collapsed)
            {
                repositoryTreeView.ExpandAll();
            }
            else
            {
                repositoryTreeView.CollapseAll();

            }

            repositoryTreeView.EndUpdate();
            if (repositoryTreeView.Nodes.Count > 0)
            {
                repositoryTreeView.SelectedNode = repositoryTreeView.Nodes[0];
            }

            _collapsed = !_collapsed;
        }

        private void MarkGroupButton_Click(object sender, EventArgs e)
        {
            if (!Equals(sender, markGroupButton))
            {
                return;
            }

            RedrawMarkedTree(!repositoryTreeView.CheckBoxes);
        }

        private void DeleteNodeButton_Click(object sender, EventArgs e)
        {
            var firstLevelNodes = repositoryTreeView.Nodes;
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
                        {
                            secondLevelNodes.RemoveAt(j);
                        }
                    }
                }
            }
        }

        private void AddNewGroupButton_Click(object sender, EventArgs e)
        {
            CreateNodeContextMenu(null, "Type group name:", "Add New Group", "Add new sub group");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Repository.Group.Clear();
            foreach (TreeNode group in repositoryTreeView.Nodes)
            {
                var groupModel = new UrlGroupViewModel
                {
                    GroupName = group.Text
                };

                foreach (TreeNode subGroup in group.Nodes)
                {
                    groupModel.UrlList.Add(new UrlViewModel
                    {
                        LinkName = subGroup.Text,
                        Url = subGroup.Nodes[0]?.Text
                    });
                }

                Repository.Group.Add(groupModel);
            }

            Close();

            using (var stream = new FileStream(TaskLinkerUtil.RepositoryFilePath, FileMode.OpenOrCreate))
            {
                var serializer = new XmlSerializer(typeof(RepositoryViewModel));
                serializer.Serialize(stream, Repository);
            }
        }

        private void AddNewSubGroup(ref TreeNode groupNode)
        {
            CreateNodeContextMenu(groupNode, "Type sub group name:", "Add New SubGroup", AddNewUrl);
        }

        private void CreateNodeContextMenu(TreeNode node, string nodeText, string nodeCaption, string menuText)
        {
            var nodePrompt = new NodePrompt(nodeText, nodeCaption);
            var newNode = new TreeNode(nodePrompt.Result);

            switch (node?.Level)
            {
                case 0:
                    node.Nodes.Add(newNode);
                    break;

                case 1:
                    node.Nodes.Add(newNode);
                    node.ContextMenu = null;
                    return;

                default:
                    repositoryTreeView.Nodes.Add(newNode);
                    break;
            }

            newNode.AddNodeContextMenu(menuText, (sender, e) => AddNewSubGroup(ref newNode));
        }

        private void CreateNodes(bool createGroupNodeContextMenu)
        {
            repositoryTreeView.Nodes.Clear();
            Repository.Group.ForEach(node =>
            {
                var urlNodes = node.UrlList.Select(url =>
                {
                    var urlNode = new TreeNode(url.LinkName);

                    if (string.IsNullOrWhiteSpace(url.Url) && createGroupNodeContextMenu)
                    {
                        urlNode.AddNodeContextMenu(AddNewUrl, (sender, e) => AddNewSubGroup(ref urlNode));
                    }
                    else
                    {
                        urlNode.Nodes.Add(new HiddenCheckBoxTreeNode
                        {
                            Text = url.Url,
                            Checked = false
                        });
                    }

                    return urlNode;
                }).ToArray();

                var groupNode = new TreeNode(node.GroupName, urlNodes);
                if (createGroupNodeContextMenu)
                {
                    groupNode.AddNodeContextMenu("Add new sub group", (sender, e) => AddNewSubGroup(ref groupNode));
                }

                repositoryTreeView.Nodes.Add(groupNode);
            });

            EnableButtons();
        }

        private void EnableButtons()
        {
            if (repositoryTreeView.Nodes.Count > 0 && repositoryTreeView.Nodes[0].Nodes.Count > 0)
            {
                expandAllButton.Enabled = true;
                markGroupButton.Enabled = true;
            }
            else
            {
                expandAllButton.Enabled = false;
                markGroupButton.Enabled = false;
            }
        }

        private void RedrawMarkedTree(bool enableCheckBox)
        {
            var buttomText = enableCheckBox ? "Unmark Group" : "Mark Group";

            markGroupButton.Text = buttomText;
            repositoryTreeView.BeginUpdate();
            repositoryTreeView.CheckBoxes = enableCheckBox;
            deleteNodeButton.Visible = enableCheckBox;
            CreateNodes(!enableCheckBox);

            if (!_collapsed)
            {
                repositoryTreeView.ExpandAll();
            }

            repositoryTreeView.EndUpdate();

            if (repositoryTreeView.Nodes.Count > 0)
            {
                repositoryTreeView.SelectedNode = repositoryTreeView.Nodes[0];
            }
        }


    }
}
