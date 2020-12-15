using System;

namespace TaskLinker.Model
{
    public class Command
    {
        public Guid Id { get; set; }
        public string LinkName { get; set; }
        public string CommandLine { get; set; }
    }
}
