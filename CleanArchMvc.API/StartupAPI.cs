using CleanArchMvc.Infra.IoC;

namespace CleanArchMvc.API
{
    public class StartupAPI
    {
         public IConfiguration Configuration{get;}
        public StartupAPI(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructureAPI(Configuration);
            services.AddInfrastructureJWT(Configuration);
            services.AddInfrastructureSwagger();
        }

    }
}