
using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.EntityFramework;
using LogicaAccesoDatos.EntityFramework.Repositorios;
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

            //Inicializar repos/CU antes de buildear

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();

            //ini caos de uso
            builder.Services.AddScoped<IAltaUsuario, AltaUsuarioCU>();
            builder.Services.AddScoped<IListarUsuarios, ListarUsuariosCU>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuarioCU>();


            builder.Services.AddDbContext<StellarMindsContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("StellarMinds"))
                    );

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
