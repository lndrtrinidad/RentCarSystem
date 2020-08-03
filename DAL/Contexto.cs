using Microsoft.EntityFrameworkCore;
using RentCarSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Permissions;
using System.Text;


namespace RentCarSystem.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Modelos> Modelos { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Caracteristicas> Caracteristicas { get; set; }
        public DbSet<Mantenimientos> Mantenimientos { get; set; }
        public DbSet<Rentas> Rentas { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\RentCarSystem.db");
        }

        
    }

} 
