using LM.UI.View.ViewItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM.UI.View.Forms.CommandItems
{
    internal partial class MixedCheckBoxesTreeView : TreeView
    {
        /// <summary>
        /// Specifies the attributes of a node
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TV_ITEM
        {
            public int Mask;
            public IntPtr ItemHandle;
            public int State;
            public int StateMask;
            public IntPtr TextPtr;
            public int TextMax;
            public int Image;
            public int SelectedImage;
            public int Children;
            public IntPtr LParam;
        }

        public const int TVIF_STATE = 0x8;
        public const int TVIS_STATEIMAGEMASK = 0xF000;
        public const int TVM_SETITEMA = 0x110d;
        public const int TVM_SETITEM = 0x110d;
        public const int TVM_SETITEMW = 0x113f;
        public const int TVM_GETITEM = 0x110C;

        internal delegate void DataSourceChangedEventHandler(object sender, EventArgs e);
        internal event DataSourceChangedEventHandler DataSourceChanged;

        private const string GroupName = "Type group name:";
        private const string SubGroupName = "Type sub group name:";
        private const string NewSubGroup = "Add New Sub Group";
        private const string NewUrl = "Add new URL";
        private const string NewCommandLine = "New Command Line";
        private const string Edit = "Edit";

        private readonly EditForm editForm = new EditForm();
        private readonly CommandLineEditForm commandLineEditForm = new CommandLineEditForm();

        private BindingList<GroupViewItem> listDataSource = new BindingList<GroupViewItem>()
        {
            AllowNew = true,
            AllowRemove = true,
            AllowEdit = true
        };

        public MixedCheckBoxesTreeView()
        {
            InitializeComponent();
            listDataSource.ListChanged += ListDataSource_ListChanged;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref TV_ITEM lParam);

        internal void AddNewGroup()
        {
            var nodePrompt = editForm.ShowPrompt(GroupName, null);
            if (string.IsNullOrWhiteSpace(nodePrompt))
                return;

            listDataSource.Add(new GroupViewItem { Name = nodePrompt });
        }

        internal void DrawNodes(IList<GroupViewItem> groupList)
        {
            Nodes.Clear();
            listDataSource.Clear();

            foreach (var group in groupList)
            {
                listDataSource.Add(group);
            }
        }

        internal IList<GroupViewItem> GetGroups()
        {
            return listDataSource.ToList();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // trap TVM_SETITEM message
            if (m.Msg == TVM_SETITEM || m.Msg == TVM_SETITEMA || m.Msg == TVM_SETITEMW)
            {
                // check if CheckBoxes are turned on
                if (CheckBoxes)
                {
                    // get information about the node
                    var tv_item = (TV_ITEM)m.GetLParam(typeof(TV_ITEM));
                    HideCheckBox(tv_item);
                }
            }
        }

        protected void HideCheckBox(TV_ITEM tv_item)
        {
            if (tv_item.ItemHandle != IntPtr.Zero)
            {
                // get TreeNode-object, that corresponds to TV_ITEM-object
                var currentTN = TreeNode.FromHandle(this, tv_item.ItemHandle);

                // check if it's HiddenCheckBoxTreeNode and
                // if its checkbox already has been hidden

                if (currentTN is HiddenCheckBoxTreeNode)
                {
                    var treeHandleRef = new HandleRef(this, Handle);

                    // check if checkbox already has been hidden
                    var currentTvItem = new TV_ITEM
                    {
                        ItemHandle = tv_item.ItemHandle,
                        StateMask = TVIS_STATEIMAGEMASK,
                        State = 0
                    };

                    var res = SendMessage(treeHandleRef, TVM_GETITEM, 0, ref currentTvItem);
                    var needToHide = res.ToInt32() > 0 && currentTvItem.State != 0;

                    if (needToHide)
                    {
                        // specify attributes to update
                        var updatedTvItem = new TV_ITEM
                        {
                            ItemHandle = tv_item.ItemHandle,
                            Mask = TVIF_STATE,
                            StateMask = TVIS_STATEIMAGEMASK,
                            State = 0
                        };

                        // send TVM_SETITEM message
                        SendMessage(treeHandleRef, TVM_SETITEM, 0, ref updatedTvItem);
                    }
                }
            }
        }

        protected override void OnBeforeCheck(TreeViewCancelEventArgs e)
        {
            base.OnBeforeCheck(e);

            // prevent checking/unchecking of HiddenCheckBoxTreeNode,
            // otherwise, we will have to repeat checkbox hiding
            if (e.Node is HiddenCheckBoxTreeNode)
                e.Cancel = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void ListDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            var bindingList = (BindingList<GroupViewItem>)sender;
            DataSourceChanged?.Invoke(bindingList.ToList(), new EventArgs());

            var group = bindingList.ElementAtOrDefault(e.NewIndex);
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    AddNewGroup(group);
                    break;

                case ListChangedType.ItemChanged:

                    break;
            }
        }

        private void AddNewGroup(GroupViewItem group)
        {
            BeginUpdate();

            var newSubGroupNodes = group.CommandItems.Select(item =>
            {
                var commandItemNode = new TreeNode
                {
                    Text = item.Name,
                    Name = item.Name,
                    ContextMenuStrip = new ContextMenuStrip()
                };

                if (string.IsNullOrWhiteSpace(item.CommandLine))
                {
                    commandItemNode.ContextMenuStrip.Items.Add(NewUrl, null, (sender, e) => CreateSubNode(commandItemNode, SubGroupName));
                }
                else
                {
                    var commandLineNode = new HiddenCheckBoxTreeNode
                    {
                        Text = item.CommandLine,
                        Name = item.CommandLine,
                        ContextMenuStrip = new ContextMenuStrip()
                    };

                    if (!string.IsNullOrWhiteSpace(item.CommandLine))
                    {
                        commandLineNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditCommandLineNode(commandLineNode));
                    }

                    if (!StateImageList.Images.ContainsKey(item.ImageKey))
                    {
                        item.CreateImageKey();
                        StateImageList.Images.Add(item.ImageKey, item.Image);
                        commandLineNode.StateImageKey = item.ImageKey;
                    }

                    commandItemNode.Nodes.Add(commandLineNode);
                }

                commandItemNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNode(commandItemNode, Edit));
                return commandItemNode;
            }).ToArray();

            var newGroupNode = new TreeNode(group.Name, newSubGroupNodes)
            {
                Name = group.Name,
                ContextMenuStrip = new ContextMenuStrip()
            };

            newGroupNode.ContextMenuStrip.Items.Add(NewSubGroup, null, (sender, e) => CreateSubNode(newGroupNode, SubGroupName));
            newGroupNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNode(newGroupNode, Edit));

            if (!ValidateCollection(newGroupNode, Nodes))
            {
                listDataSource.Remove(group);
            }

            EndUpdate();
        }

        private void CreateSubNode(TreeNode node, string caption)
        {
            var group = GetGroup(node);

            if (node.Level == 0)
            {
                var nodePrompt = editForm.ShowPrompt(caption, null);
                if (string.IsNullOrWhiteSpace(nodePrompt))
                    return;

                var newNode = new TreeNode
                {
                    Text = nodePrompt,
                    Name = nodePrompt,
                    ContextMenuStrip = new ContextMenuStrip()
                };

                var newCommandItem = new CommandItemViewItem { Name = nodePrompt };
                group.CommandItems.Add(newCommandItem);

                if (ValidateCollection(newNode, node.Nodes))
                {
                    newNode.ContextMenuStrip.Items.Add(NewUrl, null, (sender, e) => CreateSubNode(newNode, NewCommandLine));
                    newNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNode(newNode, Edit));
                    node.Expand();
                }
            }
            else if (node?.Level == 1)
            {
                var newCommandLine = commandLineEditForm.ShowPrompt(string.Empty, null);
                if (newCommandLine is null)
                    return;

                var newCommandLineNode = new HiddenCheckBoxTreeNode
                {
                    Text = newCommandLine.CommandLine,
                    Name = newCommandLine.CommandLine,
                    ContextMenuStrip = new ContextMenuStrip()
                };

                if (ValidateCollection(newCommandLineNode, node.Nodes))
                {
                    var commandItem = GetCommandItem(node, group);
                    commandItem.CommandLine = newCommandLine.CommandLine;
                    commandItem.Image = newCommandLine.Image;

                    commandItem.CreateImageKey();
                    StateImageList.Images.Add(commandItem.ImageKey, commandItem.Image);
                    newCommandLineNode.StateImageKey = commandItem.ImageKey;

                    node.ContextMenuStrip = new ContextMenuStrip();
                    node.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditTreeNode(node, Edit));
                    newCommandLineNode.ContextMenuStrip.Items.Add(Edit, null, (sender, e) => EditCommandLineNode(newCommandLineNode));
                    node.Expand();
                }
            }
        }

        private void EditTreeNode(TreeNode node, string caption)
        {
            var nodePrompt = editForm.ShowPrompt(caption, node.Text);
            if (string.IsNullOrWhiteSpace(nodePrompt))
                return;

            var group = GetGroup(node);

            if (node.Level == 0)
            {
                group.Name = nodePrompt;
            }
            else
            {
                var commandItem = GetCommandItem(node, group);
                commandItem.Name = nodePrompt;
            }

            node.Text = nodePrompt;
            node.Name = nodePrompt;
        }

        private void EditCommandLineNode(HiddenCheckBoxTreeNode node)
        {
            var image = StateImageList.Images[node.StateImageKey];
            var editedCommandLine = commandLineEditForm.ShowPrompt(node.Text, image);
            if (editedCommandLine != null)
            {
                BeginUpdate();

                var commandItem = listDataSource
                    .SelectMany(g => g.CommandItems)
                    .Single(c => c.CommandLine == node.Text);


                commandItem.CommandLine = editedCommandLine.CommandLine;
                node.Text = commandItem.CommandLine;

                if (!string.IsNullOrWhiteSpace(editedCommandLine.ImageKey))
                {
                    commandItem.Image = editedCommandLine.Image;

                    StateImageList.Images.RemoveByKey(commandItem.ImageKey);
                    commandItem.CreateImageKey();
                    StateImageList.Images.Add(commandItem.ImageKey, commandItem.Image);

                    node.StateImageKey = commandItem.ImageKey;
                }

                EndUpdate();
            }
        }

        private GroupViewItem GetGroup(TreeNode node)
        {
            var groupNodeText = node.Level == 0 ? node.Text : node.Parent.Text;
            return listDataSource.Single(g => g.Name == groupNodeText);
        }

        private CommandItemViewItem GetCommandItem(TreeNode node, GroupViewItem group) =>
            group.CommandItems.Single(c => c.Name == node.Name);

        private bool ValidateCollection(TreeNode newNode, TreeNodeCollection nodeCollection)
        {
            const string caption = "Input validation";
            const string message = "There is a node with that name at that level";

            foreach (TreeNode node in nodeCollection)
            {
                if (string.Equals(node.Text, newNode.Text.Trim(), System.StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    return false;
                }
            }

            nodeCollection.Add(newNode);
            return true;
        }
    }
}
