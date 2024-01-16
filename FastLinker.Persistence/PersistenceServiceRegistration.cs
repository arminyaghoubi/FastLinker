using FastLinker.Application.Contracts.Persistence;
using FastLinker.Persistence.DatabaseContexts;
using FastLinker.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastLinker.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<FastLinkerContext>(options => options.UseSqlServer(configuration.GetConnectionString("FastLinkerContext")))
        .AddScoped<ILinkRepository, LinkRepository>()
        .AddScoped<IShortLinkRepository, ShortLinkRepository>();
}
