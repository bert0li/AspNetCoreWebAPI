using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
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

            // Passando pela aplicação de domino dos assemblies e procura dentro dos assemblies quem herda de Profile. 
            // Faz o mapeamento entre os DTOs e o domínio(Models)
            // Cria uma injeção de dependência nas controllers 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers()
                    // ignora os relacionamentos ciclicos para gerar o json 
                    .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddVersionedApiExplorer(opcoes =>
            {
                opcoes.GroupNameFormat = "'v'VVV";
                opcoes.SubstituteApiVersionInUrl = true; // Substituir as APIs das versões em URL
            })
            .AddApiVersioning(opcoes =>
            {
                opcoes.AssumeDefaultVersionWhenUnspecified = true; // A versão padrão quando não definida será definida pela ApiVersion abaixo
                opcoes.DefaultApiVersion = new ApiVersion(1, 0);
                opcoes.ReportApiVersions = true;
            });

            // Pegando as ApiVersion(versões) das controllers 
            var apiProviderDescricao = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            // Configurando o swagger
            services.AddSwaggerGen(o =>
            {
                foreach (var descricao in apiProviderDescricao.ApiVersionDescriptions)
                {
                    o.SwaggerDoc(
                    descricao.GroupName, // Nome da URL 
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "School API",
                        Version = descricao.ApiVersion.ToString(),
                        //TermsOfService = new Uri(""), // Url de termos de uso
                        Description = "Descrição da WebApi",
                        License = new Microsoft.OpenApi.Models.OpenApiLicense
                        {
                            Name = "Licença School API",
                            //Url = new Uri("http://mit.com") // URL da licença (precisa ser uma url valida)
                        },
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Bertoli",
                            Email = "bert0li@outlook.com.br"
                            //Url = new Uri("")
                        }
                    });
                }

                var xmlComentario = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // Criando o arq xml com o nome do Assembly
                var xmlComentarioCaminho = Path.Combine(AppContext.BaseDirectory, xmlComentario); // Combinando o caminho com o arq xml
                o.IncludeXmlComments(xmlComentarioCaminho); // Incluindo o arq xml
            });

            
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        // Incluindo a param IApiVersionDescriptionProvider para colocarmos a versão no SwaggerEndpoint
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //não estamos usando https nesse projeto
            //app.UseHttpsRedirection();

            // Incicando para aplicação que vai ser usar o swagger
            app.UseSwagger()
                .UseSwaggerUI(opcoes =>
                {
                    foreach (var descricao in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    {
                        opcoes.SwaggerEndpoint($"/swagger/{descricao.GroupName}/swagger.json", descricao.GroupName.ToUpperInvariant());
                    }

                    opcoes.RoutePrefix = ""; // Quando não ser digitado nada no pré-fixo ele vai para essa URL
                });

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
