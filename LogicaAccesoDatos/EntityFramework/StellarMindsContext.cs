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
        public DbSet<Camara> Suscripciones { get; set; }
        public DbSet<Ocular> Oculares { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"SERVER=(localdb)\MsSqlLocalDb;DATABASE=StellarMinds;Integrated Security=true;"
            );
        }
    }
}
