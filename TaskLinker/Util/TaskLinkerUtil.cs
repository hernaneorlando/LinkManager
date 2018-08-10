using System;
using System.Windows.Forms;

namespace TaskLinker.Util
{
    public static class TaskLinkerUtil
    {
        public static string RepositoryFilePath = string.Format("{0}\\repository.xml", AppDomain.CurrentDomain.BaseDirectory);

        public static void AddNodeContextMenu(this TreeNode groupNode, string menuText, EventHandler handler)
        {
            var nodeMenuItem = new MenuItem(menuText, handler);
            groupNode.ContextMenu = new ContextMenu(new[] { nodeMenuItem });
        }
    }
}
