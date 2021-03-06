using System;
using System.Collections.Generic;

namespace TaskLinker.Model
{
    public class Group
    {
        public Group()
        {
            CommandItems = new List<CommandItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CommandItem> CommandItems { get; set; }

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
