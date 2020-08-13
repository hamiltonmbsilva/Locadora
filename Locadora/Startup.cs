using AutoMapper;
using Domain.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Repository.Context;
using Repository.EntityRepository;
using Service;

namespace Locadora
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
            services.AddCors();
            services.AddControllers();

            string stringConexao = "Server=localhost;Port=3306;DataBase=db_locadora;Uid=root;Pwd=root";
            services.AddDbContext<BaseContext>(options =>
            options.UseMySql(stringConexao));

            services.AddControllersWithViews();
            

            #region Repository

            // Scoped - cria uma instancia por requisi��o dentro do escopo

            services.AddScoped<ClienteRepository>();
            services.AddScoped<FilmeRepository>();
            services.AddScoped<LocacaoRepository>();          

            #endregion

            #region Service

            services.AddScoped<ClienteService>();
            services.AddScoped<FilmeService>();
            services.AddScoped<LocacaoService>();

            #endregion

            #region Configura��es de retorno Json

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.UseCamelCasing(true);
            });

            #endregion

            #region Automapper

            // Configurando AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClienteMapping());
                mc.AddProfile(new FilmeMapping());
                mc.AddProfile(new LocacaoMapping());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x
                .WithOrigins("http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });


            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
