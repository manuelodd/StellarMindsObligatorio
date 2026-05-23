using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.EntityFramework;
using LogicaAccesoDatos.EntityFramework.Repositorios;
using LogicaAplicacion.CasosDeUso.CUEquipo;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace StellarMindsWebAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // El addsession de P2
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // ini repos

            //cambio RepositorioUsuario a RepositorioUsuarioEF para utilizar la base de datos


            // PROBANDO SIN EF - - -  -  - - > Cambiar RepositorioUsuario a RepositorioUsuarioEF despues
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipoEF>();


            //ini caos de uso
            builder.Services.AddScoped<IAltaUsuario, AltaUsuarioCU>();
            builder.Services.AddScoped<IListarUsuarios, ListarUsuariosCU>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuarioCU>();

            builder.Services.AddScoped<IAltaEquipo, AltaEquipoCU>();
            builder.Services.AddScoped<IListarEquipos, ListarEquiposCU>();
            builder.Services.AddScoped<IBuscarEquipoPorID, BuscarEquipoPorIDCU>();
            builder.Services.AddScoped<IEditarTelescopio, EditarTelescopioCU>();
            builder.Services.AddScoped<IEditarMontura, EditarMonturaCU>();
            builder.Services.AddScoped<IEditarCamara, EditarCamaraCU>();
            builder.Services.AddScoped<IEditarOcular, EditarOcularCU>();
            builder.Services.AddScoped<IDeleteEquipo, DeleteEquipoCU>();






            builder.Services.AddDbContext<StellarMindsContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("StellarMinds"))
                    );
            

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
            app.UseSession();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
