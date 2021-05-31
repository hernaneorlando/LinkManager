using System;
using System.Collections.Generic;

namespace LM.Gateway.Model
{
    public class Group
    {
        public int Index { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CommandItem> CommandItems { get; set; } = new List<CommandItem>();

        public override bool Equals(object obj)
        {
            if (obj is Group group)
                return Equals(Name, group.Name);

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode(StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
