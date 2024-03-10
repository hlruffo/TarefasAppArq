using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //configurando automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //registrar o ciclo de vida do TarefaAppService
            services.AddTransient<ITarefaAppService, TarefaAppService>();
            return services;
        }
    }
}
