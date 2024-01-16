using FastLinker.Application.Contracts.Services;
using FastLinker.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FastLinker.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) =>
        services.AddSingleton<IUrlShortenerService, UrlShortenerService>();
}
