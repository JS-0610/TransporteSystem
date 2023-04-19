using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TranporteSistem.Features.Colaborador.Services;
using TranporteSistem.Features.Sucursal.Services;
using TranporteSistem.Features.SucursalColaborador.Services;
using TranporteSistem.Features.Transportista.Services;
using TranporteSistem.Features.Viaje.Services;
using TranporteSistem.Features.ViajeDetalle.Services;
using TranporteSistem.Interfaces;
using TranporteSistem.Models;

namespace TranporteSistem
{
    public class Startup
    {
        public IConfiguration Configuration {  get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler= ReferenceHandler.IgnoreCycles);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IColaboradorServices, ColaboradorServices>();
            services.AddScoped<ISucursalServices, SucursalServices>();
            services.AddScoped<ITransportistaServices, TransportistaServices>();
            services.AddScoped<ISucursalColaboradorServices, SucursalColaboradorServices>();
            services.AddScoped<IViajeServices, ViajeServices>();
            services.AddScoped<IViajeDetalleServices, ViajeDetalleServices>();
            
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
