using System.Windows.Forms;

namespace TaskLinker.Extensions
{
    internal static class TreeNodeExtensions
    {
        const string message = "There is a node with that name at that level";
        const string caption = "Input validation";

        public static bool AddWithValidation(this TreeNode node, TreeNode newNode)
        {
            return ValidateCollection(newNode, node.Nodes);
        }

        public static bool AddWithValidation(this TreeView node, TreeNode newNode)
        {
            return ValidateCollection(newNode, node.Nodes);
        }

        private static bool ValidateCollection(TreeNode newNode, TreeNodeCollection nodeCollection)
        {
            var enumerator = nodeCollection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var inNode = (TreeNode)enumerator.Current;
                if (string.Equals(inNode.Text, newNode.Text.Trim(), System.StringComparison.InvariantCultureIgnoreCase))
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
