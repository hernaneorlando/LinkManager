using Microsoft.EntityFrameworkCore;
using TaskLinker.Model;

namespace TaskLinker.Persistence
{
    internal class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var groupBuilder = modelBuilder.Entity<Group>();
            groupBuilder.HasIndex(e => e.Name);

            var commandBuilder = modelBuilder.Entity<Command>();
            commandBuilder.HasIndex(e => e.CommandLine);
        }
    }
}
