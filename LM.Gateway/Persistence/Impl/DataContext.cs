using LiteDB;
using LM.Gateway.Model;
using System;
using System.IO;

namespace LM.Gateway.Persistence.Impl
{
    internal class DataContext : LiteDatabase
    {
        private static readonly ConnectionString connection = new ConnectionString
        {
            Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LinkManager", "LinkManager.db"),
            Upgrade = true
        };

        public DataContext()
            : base(connection)
        {
            Groups = GetCollection<Group>("groups");
            CommandItems = GetCollection<CommandItem>("commandItems");

            CreateCustomMapping();
        }

        public ILiteCollection<Group> Groups { get; set; }
        public ILiteCollection<CommandItem> CommandItems { get; set; }

        private void CreateCustomMapping()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<Group>()
                .Id(g => g.Id)
                .DbRef(g => g.CommandItems, CommandItems.Name);
            mapper.Entity<CommandItem>().Id(c => c.Id);

            Groups.EnsureIndex(g => g.Name);
            Groups.EnsureIndex(g => g.Index);
            CommandItems.EnsureIndex(c => c.Index);
        }
    }
}
