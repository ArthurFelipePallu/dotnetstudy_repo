using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Repositories;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Application.Mappings;
using MediatR;
using CleanArchMvc.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using CleanArchMvc.Domain.Account;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext> // registrou o contexto
            (options=>options.UseSqlServer  // definiu provedor do banco de dados 
            (configuration.GetConnectionString("DefaultConnection"), // definiu a string de conexão
            b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))); // definiu q a migração vai ficar na pasta..
                                                                                        // ..aonde está definido o arquivo de contexto
            services.AddIdentity<ApplicationUser,IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();



            //services.AddTransient();   Adciona o serviço sempre que for requisitado
            //services.AddScoped();      Adciona o serviço uma vez por solicitação
            //services.AddSingleton();   Adciona o serviço apenas na primeira vez que for solicitado
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IAuthenticate,AuthenticateService>();
           
           
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // HANDLERS
            var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}