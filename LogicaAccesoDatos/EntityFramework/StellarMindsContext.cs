using Dominio.Entities;
using Dominio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework
{
    // desde cmd carpeta raiz
    // dotnet ef migrations add Inicial --project LogicaAccesoDatos --startup-project StellarMindsWebAPP
    // dotnet ef database update --project LogicaAccesoDatos --startup-project StellarMindsWebAPP

    public class StellarMindsContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Telescopio> Telescopios { get; set; }
        public DbSet<Montura> Monturas { get; set; }
        public DbSet<Camara> Camaras { get; set; } 
        public DbSet<Ocular> Oculares { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<ObjetoCeleste> ObjetosCelestes { get; set; }
        public DbSet<AuditoriaPrestamo> AuditoriaPrestamo { get; set; }
        

        public StellarMindsContext(DbContextOptions optionsBuilder) : base (optionsBuilder)
        { }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"SERVER=(localdb)\MsSqlLocalDb;DATABASE=StellarMinds;Integrated Security=true;"
            );
        }
        */

        protected override void OnModelCreating(
       ModelBuilder modelBuilder)
        {
            //que EF trabaje normal (ejecute la configuracion default de dbcontext), despues yo agrego mis modificaciones
            base.OnModelCreating(modelBuilder);

            //"voy a configurar la entidad prestamo"
            modelBuilder.Entity<Prestamo>()
                //prestamo tiene UNA Relacion con telescsopio
                .HasOne(p => p.Telescopio)
                //no existe navegacion del otro lado, (por ej, telescopio no tiene public List<Prestamo> Prestamos) INTERPRETA QUE VARIOS PRESTAMOS PUEDEN
                //TENER EL MISMO TELESCOPIO
                .WithMany()
                //si se borra el telescopio, no hagas nada automatico, por defecto EF hace cascade delete, si se borra el telescopio tmb borra prestamos
                //que lo incluyan
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Montura)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Camara)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Ocular)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Socio)
                .WithMany()
                .HasForeignKey(a => a.SocioId)
                .OnDelete(DeleteBehavior.NoAction);


            //especificar on delete de auditoria prestamo
            modelBuilder.Entity<AuditoriaPrestamo>()
                .HasOne(a => a.Coordinador)
                .WithMany()
                .HasForeignKey(a => a.CoordinadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AuditoriaPrestamo>()
                .HasOne(a => a.Prestamo)
                .WithMany()
                .HasForeignKey(a => a.PrestamoId)
                .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
