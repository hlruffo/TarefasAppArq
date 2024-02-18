using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Application.Data;
using TarefasApp.Application.Interfaces;
using TarefasApp.Application.Services;

namespace TarefasApp.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //configurar o MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            //registrar a classe FakeDataStore
            services.AddSingleton<FakeDataStore>();

            //registrar o ciclo de vida do TarefaAppService
            services.AddTransient<ITarefaAppService, TarefaAppService>();
            return services;
        }
    }
}
