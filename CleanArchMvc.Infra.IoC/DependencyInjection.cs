using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Repositories;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext> // registrou o contexto
            (options=>options.UseSqlServer  // definiu provedor do banco de dados 
            (configuration.GetConnectionString("DefaultConnection"), // definiu a string de conexão
            b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))); // definiu q a migração vai ficar na pasta..
                                                                                        // ..aonde está definido o arquivo de contexto
            
            //services.AddTransient();   Adciona o serviço sempre que for requisitado
            //services.AddScoped();      Adciona o serviço uma vez por solicitação
            //services.AddSingleton();   Adciona o serviço apenas na primeira vez que for solicitado
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();

            return services;
        }
    }
}