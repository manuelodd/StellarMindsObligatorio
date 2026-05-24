
using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.EntityFramework;
using LogicaAccesoDatos.EntityFramework.Repositorios;
using LogicaAplicacion.CasosDeUso.CUEquipo;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<StellarMindsContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("StellarMinds"))
            );
            //ini repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipoEF>();
            //ini casos de uso USUARIOS
            builder.Services.AddScoped<IAltaUsuario, AltaUsuarioCU>();
            builder.Services.AddScoped<IListarUsuarios, ListarUsuariosCU>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuarioCU>();
            //ini casos de uso EQUIPOS
            builder.Services.AddScoped<IAltaEquipo, AltaEquipoCU>();
            builder.Services.AddScoped<IListarEquipos, ListarEquiposCU>();
            builder.Services.AddScoped<IBuscarEquipoPorID, BuscarEquipoPorIDCU>();
            builder.Services.AddScoped<IEditarTelescopio, EditarTelescopioCU>();
            builder.Services.AddScoped<IEditarMontura, EditarMonturaCU>();
            builder.Services.AddScoped<IEditarCamara, EditarCamaraCU>();
            builder.Services.AddScoped<IEditarOcular, EditarOcularCU>();
            builder.Services.AddScoped<IDeleteEquipo, DeleteEquipoCU>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
