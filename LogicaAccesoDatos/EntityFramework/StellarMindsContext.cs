using Microsoft.EntityFrameworkCore;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework
{
    public class StellarMindsContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"SERVER=(localdb)\MsSqlLocalDb;DATABASE=StellarMinds;Integrated Security=true;"
            );
        }
    }
}
