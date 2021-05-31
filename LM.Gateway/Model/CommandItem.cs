using System;

namespace LM.Gateway.Model
{
    public class CommandItem
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string CommandLine { get; set; }
        public byte[] Image { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is CommandItem command)
                return Equals(Name, command.Name) &&
                    Equals(CommandLine, command.CommandLine);

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode(StringComparison.InvariantCultureIgnoreCase) +
                CommandLine.GetHashCode(StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
