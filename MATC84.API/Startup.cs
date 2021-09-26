using MATC84.Application;
using MATC84.Application.Contracts;
using MATC84.Persistence;
using MATC84.Persistence.Context;
using MATC84.Persistence.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MATC84.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuração da DB
            services.AddDbContext<MATC84Context>(

                context => context.UseSqlite(Configuration.GetConnectionString("Default"))

            );

            services.AddControllers().AddNewtonsoftJson(
                        x => x.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();

            //Permite a injeção de dependências
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<ISeminarioService, SeminarioService>();
            services.AddScoped<IGeralPersistence, GeralPersistence>();
            services.AddScoped<IPessoaPersistence, PessoaPersistence>();
            services.AddScoped<ISeminarioPersistence, SeminarioPersistence>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MATC84.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MATC84.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // //Permite requisições compartilhadas de qualquer origem -> Fragiliza a segurança da API
            // app.UseCors(cors => cors.AllowAnyHeader()
            //                     .AllowAnyMethod()
            //                     .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
