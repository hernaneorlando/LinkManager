using Microsoft.EntityFrameworkCore;
using TaskLinker.Persistence;
using TaskLinker.Persistence.Impl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceDependency(this ServiceCollection service)
        {
            service.AddDbContext<DataContext>(ServiceLifetime.Singleton);
            service.AddSingleton<IMenuItemRepository, MenuItemRepository>();

            var dataContext = service.BuildServiceProvider().GetService<DataContext>();
            dataContext.Database.Migrate();

            return service;
        }
    }
}
