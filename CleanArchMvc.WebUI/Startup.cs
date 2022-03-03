using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Infra.IoC;

namespace CleanArchMvc.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration{get;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment environment)
        {
            
        }


    }
}