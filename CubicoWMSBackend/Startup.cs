using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Persistence.Repositories;
using ControlNetBackend.Service;
using CubicoWMSBackend.Domain.IRepositories;
using CubicoWMSBackend.Domain.IService;
using CubicoWMSBackend.Persistence.Context;
using CubicoWMSBackend.Persistence.Repositories;
using CubicoWMSBackend.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
namespace CubicoWMSBackend
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Conexion")));

            //Service
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISedeService, SedeService>();
            services.AddScoped<IEmpresaService,EmpresaService>();
            services.AddScoped<IMenuAccesoService, MenuAccesoService>();
            services.AddScoped<IConfiguracionParametrosService, ConfiguracionParametrosService>();
            services.AddScoped<IPersonalService, PersonalService>();
            services.AddScoped<ICitaService, CitaService>();
            services.AddScoped<IMovimientosPersonalVisitanteService, MovimientosPersonalVisitanteService>();
            services.AddScoped<ICentroCostoService,CentroCostoService>();
            services.AddScoped<IEdificioService, EdificioService>();
            services.AddScoped<IPisoService, PisoService>();
            services.AddScoped<IVisitaService, VisitaService>();
            services.AddScoped<IPuertaService, PuertaService>();
            services.AddScoped<IGrupoAccesosService, Grupo_AccesosService>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<ITarjetaAccesoService, TarjetaAccesoService>();
            services.AddScoped<ITipoPersonalService, TipoPersonalService>();
            services.AddScoped<ITipoVisitanteService, TipoVisitanteService>();
            services.AddScoped<IVisitanteService, VisitanteService>();
            services.AddScoped<IVisitanteNoDeseadoService, VisitanteNoDeseadoService>();
            services.AddScoped<IAccesosPermisoService, AccesosPermisoService>();
            services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();
            services.AddScoped<IMailingService, MailingService>();
            //Repository
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ISedeRepository, SedeRepository>();
            services.AddScoped<IEmpresaRepository,EmpresaRepository>();
            services.AddScoped<IMenuAccesoRepository, MenuAccesoRepository>();
            services.AddScoped<IConfiguracionParametrosRepository, ConfiguracionParametrosRepository>();
            services.AddScoped<IPersonalRepository, PersonalRepository>();
            services.AddScoped<ICitaRepository, CitaRepository>();
            services.AddScoped<IMovimientosPersonalVisitanteRepository, MovimientosPersonalVisitanteRepository>();
            services.AddScoped<ICentroCostoRepository, CentroCostoRepository>();
            services.AddScoped<IEdificioRepository, EdificioRepository>();
            services.AddScoped<IPisoRepository, PisoRepository>();
            services.AddScoped<IVisitaRepository, VisitaRepository>();
            services.AddScoped<IPuertaRepository, PuertaRepository>();
            services.AddScoped<IGrupoAccesosRepository, GrupoAccesosRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<ITarjetaAccesoRepository, TarjetaAccesoRepository>();
            services.AddScoped<ITipoPersonalRepository, TipoPersonalRepository>();
            services.AddScoped<ITipoVisitanteRepository, TipoVisitanteRepository>();
            services.AddScoped<IVisitanteRepository, VisitanteRepository>();
            services.AddScoped<IVisitanteNoDeseadoRepository, VisitanteNoDeseadoRepository>();
            services.AddScoped<IAccesoPermisoRepository, AccesoPermisoRepository>();
            services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
            services.AddScoped<IMailingRepository, MailingRepository>();
            //cors
            services.AddCors(options => options.AddPolicy("AllowWebApp",
                    builder=> builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod()));
            // add authentication

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => 
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer= true,
                        ValidateAudience=true,
                        ValidateLifetime=true,
                        ValidateIssuerSigningKey=true,
                        ValidIssuer=Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                        ClockSkew=TimeSpan.Zero
                    });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowWebApp");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

