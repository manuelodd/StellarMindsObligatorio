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
            //ini casos de uso AUDITORIAS PRESTAMO
            builder.Services.AddScoped<IListarAuditoriasPrestamo, ListarAuditoriasPrestamoCU>();
            builder.Services.AddScoped<IListarAuditoriasByCoordinador, ListarAuditoriasByCoordinadorCU>();
            builder.Services.AddScoped<IFindAuditoriaById, FindAuditoriaById>();

            //ini casos de uso OBJETOS CELESTES
            builder.Services.AddScoped<IListarObjetosCelestes, ListarObjetosCelestesCU>();
            builder.Services.AddScoped<IRankObjetosCelestes, RankObjetosCelestesCU>();
            //ini casos de uso OBSERVACIONES
            builder.Services.AddScoped<IAltaObservacion, AltaObservacionCU>();



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
