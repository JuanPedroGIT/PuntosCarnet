using API.Data;
using API.Interfaces;
using API.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PuntosCarnetContext>(x => x.UseSqlite(_config.GetConnectionString("ConexionPuntosCarnet")));
            services.AddControllers();

            services.AddScoped<IVehiculosRepository, VehiculosRepository>();
            services.AddScoped<IConductorRepository, ConductorRepository>();
            services.AddScoped<IInfraccionRepository, InfraccionRepository>();
            services.AddScoped<IRegistroInfraccionesRepository, RegistroInfraccionesRepository>();
            services.AddScoped<IVehiculoConductorRepository, VehiculoConductorRepository>();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddScoped<IApiService, ApiService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
