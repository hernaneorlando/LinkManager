using System;

namespace TaskLinker.Model
{
    public class CommandItem
    {
        public Guid Id { get; set; }
        public string LinkName { get; set; }
        public string CommandLine { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is CommandItem command)
            {
                return Equals(LinkName, command.LinkName) &&
                    Equals(CommandLine, command.CommandLine);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return LinkName.GetHashCode(StringComparison.InvariantCultureIgnoreCase) +
                CommandLine.GetHashCode(StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
