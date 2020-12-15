using System;
using System.Collections.Generic;

namespace TaskLinker.Model
{
    public class Group
    {
        public Group()
        {
            Commands = new List<Command>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Command> Commands { get; set; }
    }
}
