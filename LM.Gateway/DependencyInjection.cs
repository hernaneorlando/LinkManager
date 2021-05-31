using LM.Gateway.Persistence;
using LM.Gateway.Persistence.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddGatewayDependencies(this ServiceCollection service)
        {
            service.AddSingleton<DataContext>();
            service.AddSingleton<IMenuItemRepository, MenuItemRepository>();
        }
    }
}
