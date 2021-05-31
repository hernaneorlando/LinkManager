using LM.Gateway.Model;
using LM.UI.Extensions;
using System;
using System.Drawing;

namespace LM.UI.View.ViewItem
{
    internal class CommandItemViewItem
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string CommandLine { get; set; }
        public Image Image { get; set; }
        public string ImageKey { get; private set; }

        public CommandItemViewItem() { }

        public CommandItemViewItem(CommandItem commandItem)
        {
            Index = commandItem.Index;
            Name = commandItem.Name;
            CommandLine = commandItem.CommandLine;
            Image = commandItem.Image.ToImage();
        }

        internal void CreateImageKey() => ImageKey = Guid.NewGuid().ToString();

        internal CommandItem ToModel() =>
            new CommandItem
            {
                Index = Index,
                Name = Name,
                CommandLine = CommandLine,
                Image = Image.ToByteArray()
            };

        public override bool Equals(object obj)
        {
            if (obj is CommandItemViewItem command)
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
