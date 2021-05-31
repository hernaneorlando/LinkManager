using LM.Gateway.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LM.UI.View.ViewItem
{
    internal class GroupViewItem
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public List<CommandItemViewItem> CommandItems { get; set; } = new List<CommandItemViewItem>();

        public GroupViewItem() { }

        public GroupViewItem(Group group)
        {
            Index = group.Index;
            Name = group.Name;
            CommandItems = group.CommandItems
                .Select(c => new CommandItemViewItem(c))
                .ToList();
        }

        internal Group ToModel() =>
            new Group
            {
                Index = Index,
                Name = Name,
                CommandItems = CommandItems
                    .Select(c => c.ToModel())
                    .ToList()
            };

        public override bool Equals(object obj)
        {
            if (obj is GroupViewItem group)
                return Equals(Name, group.Name);

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode(StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
