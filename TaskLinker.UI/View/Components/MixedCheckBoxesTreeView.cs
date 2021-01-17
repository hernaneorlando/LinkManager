using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TaskLinker.UI.View.Components
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

        public MixedCheckBoxesTreeView()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref TV_ITEM lParam);

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
    }
}
