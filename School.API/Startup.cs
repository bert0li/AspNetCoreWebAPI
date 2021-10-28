using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using School.API.Data;

namespace School.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchoolContexto>(c => c.UseSqlite(Configuration.GetConnectionString("Desenv")));

            services.AddScoped<IRepository, Repository>();

            // Passando a aplicação de domino dos assemblies e procura dentro dos assemblies quem herda de Profile. 
            // Faz o mapeamento entre os DTOs e o domínio(Models)
            // Cria uma injeção de dependência nas controllers 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers()
                    // ignora os relacionamentos ciclicos para gerar o json 
                    .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);  
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //não estamos usando https nesse projeto
            //app.UseHttpsRedirection();

            app.UseRouting();

            //não estamos usando nesse projeto
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
