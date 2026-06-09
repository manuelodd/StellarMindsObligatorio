
using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.EntityFramework;
using LogicaAccesoDatos.EntityFramework.Repositorios;
using LogicaAplicacion.CasosDeUso.CUAuditoriaPrestamo;
using LogicaAplicacion.CasosDeUso.CUEquipo;
using LogicaAplicacion.CasosDeUso.CUObjetoCeleste;
using LogicaAplicacion.CasosDeUso.CUObservacion;
using LogicaAplicacion.CasosDeUso.CUPrestamo;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace StellarMindsWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services to the container.

            //cors
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MiPolitica",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });
            

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<StellarMindsContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("StellarMinds"))
            );
            //ini repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipoEF>();
            builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamoEF>();
            builder.Services.AddScoped<IRepositorioAuditoriaPrestamo, RepositorioAuditoriaPrestamoEF>();
            builder.Services.AddScoped<IRepositorioObservacion, RepositorioObservacionEF>();
            builder.Services.AddScoped<IRepositorioObjetoCeleste, RepositorioObjetoCelesteEF>();
            //ini casos de uso USUARIOS
            builder.Services.AddScoped<IAltaUsuario, AltaUsuarioCU>();
            builder.Services.AddScoped<IListarUsuarios, ListarUsuariosCU>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuarioCU>();
            builder.Services.AddScoped<IFindUsuById, FindUsuByIdCU>();
            builder.Services.AddScoped<IListarSociosByTelescopio, ListarSociosByTelescopioCU>();
            builder.Services.AddScoped<IListarCoordinadores, ListarCoordinadoresCU>();

            //ini casos de uso EQUIPOS
            builder.Services.AddScoped<IAltaEquipo, AltaEquipoCU>();
            builder.Services.AddScoped<IListarEquipos, ListarEquiposCU>();
            builder.Services.AddScoped<IListarTelescopios, ListarTelescopiosCU>(); //lista telescopios cuya cant disp > 1
            builder.Services.AddScoped<IListarTelescopiosToList, ListarTelescopiosToListCU>(); // devuelve todos
            builder.Services.AddScoped<IListarMonturas, ListarMonturasCU>();
            builder.Services.AddScoped<IListarCamaras, ListarCamarasCU>();
            builder.Services.AddScoped<IListarOculares, ListarOcularesCU>();
            builder.Services.AddScoped<IBuscarEquipoPorID, BuscarEquipoPorIDCU>();
            builder.Services.AddScoped<IEditarTelescopio, EditarTelescopioCU>();
            builder.Services.AddScoped<IEditarMontura, EditarMonturaCU>();
            builder.Services.AddScoped<IEditarCamara, EditarCamaraCU>();
            builder.Services.AddScoped<IEditarOcular, EditarOcularCU>();
            builder.Services.AddScoped<IDeleteEquipo, DeleteEquipoCU>();
            //ini casos de uso PRESTAMOS
            builder.Services.AddScoped<IAltaPrestamo, AltaPrestamoCU>();
            builder.Services.AddScoped<IListarPrestamos, ListarPrestamosCU>();
            builder.Services.AddScoped<IReturnPrestamo, ReturnPrestamoCU>();
            builder.Services.AddScoped<IListarPrestamosSocio, ListarPrestamosSocioCU>();
            builder.Services.AddScoped<IListarPrestamosSocioEntreFechas, ListarPrestamosSocioEntreFechasCU>();
            builder.Services.AddScoped<IFindPrestamoById, FindPrestamoById>();

            //ini casos de uso AUDITORIAS PRESTAMO
            builder.Services.AddScoped<IListarAuditoriasPrestamo, ListarAuditoriasPrestamoCU>();
            builder.Services.AddScoped<IListarAuditoriasByCoordinador, ListarAuditoriasByCoordinadorCU>();
            builder.Services.AddScoped<IFindAuditoriaById, FindAuditoriaById>();

            //ini casos de uso OBJETOS CELESTES
            builder.Services.AddScoped<IListarObjetosCelestes, ListarObjetosCelestesCU>();
            builder.Services.AddScoped<IRankObjetosCelestes, RankObjetosCelestesCU>();
            //ini casos de uso OBSERVACIONES
            builder.Services.AddScoped<IAltaObservacion, AltaObservacionCU>();

            //config autenticacion mierdtoken
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
            {
                opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("SecretTokenKey").Value!)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            //config autorizacion
            builder.Services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });


            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();
            //cors
            app.UseCors("MiPolitica");


        

            app.MapControllers();

            app.Run();
        }
    }
}
