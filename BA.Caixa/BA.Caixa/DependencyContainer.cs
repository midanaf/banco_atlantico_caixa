using BA.Caixa.Application.Interfaces;
using BA.Caixa.Application.Services;
using BA.Caixa.Data.Repositories;
using BA.Caixa.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BA.Caixa
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICaixaService, CaixaService>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddScoped<INotaRepository, NotaRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
        }
    }
}
