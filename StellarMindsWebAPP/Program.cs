using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.EntityFramework.Repositorios;
using LogicaAccesoDatos.RepositorioMemoria;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.InterfacesCasosDeUso;

namespace StellarMindsWebAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // ini repos

            //cambio RepositorioUsuario a RepositorioUsuarioEF para utilizar la base de datos


            // PROBANDO SIN EF - - -  -  - - > Cambiar RepositorioUsuario a RepositorioUsuarioEF despues
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            //ini caos de uso
            builder.Services.AddScoped<IAltaUsuario, AltaUsuarioCU>();
            builder.Services.AddScoped<IListarUsuarios, ListarUsuariosCU>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
