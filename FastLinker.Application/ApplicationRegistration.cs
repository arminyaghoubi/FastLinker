using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FastLinker.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
}
