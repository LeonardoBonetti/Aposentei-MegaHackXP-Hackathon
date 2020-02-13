using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Hackaton.CrossCutting.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Hackaton.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Startup
    {
        private const string ConnectionString = "Server=localhost;Port=3306;Database=Course;Uid=root;Pwd=admin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=HackaDB;Uid=root;Pwd=admin")
            );


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            Bootstrapper.SetupIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
