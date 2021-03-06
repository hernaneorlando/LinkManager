using Microsoft.EntityFrameworkCore;
using TaskLinker.Model;

namespace TaskLinker.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<CommandItem> CommandItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=tasklinker.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var groupBuilder = modelBuilder.Entity<Group>();
            groupBuilder.HasIndex(e => e.Name).IsUnique();

            var commandBuilder = modelBuilder.Entity<CommandItem>();
            commandBuilder.HasIndex(e => e.CommandLine).IsUnique();
        }
    }
}
