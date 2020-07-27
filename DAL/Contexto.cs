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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\RentCarSystem.db");
        }
    }

} 
