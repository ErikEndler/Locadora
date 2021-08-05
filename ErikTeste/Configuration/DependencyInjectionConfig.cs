using Data.Repository;
using Manager.Implementation;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ErikTeste.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();

            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IFilmeManager, FilmeManager>();

            services.AddScoped<ILocacaoRepository, LocacaoRepository>();
            services.AddScoped<ILocacaoManager, LocacaoManager>();
        }
    }
}
