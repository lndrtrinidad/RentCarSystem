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
       
        public DbSet<Vehiculos> vehiculos { get; set; }
        public DbSet<Caracteristicas> Caracteristicas { get; set; }
        public DbSet<Mantenimientos> Mantenimientos { get; set; }
        public DbSet<Rentas> Rentas { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\RentCarSystem.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Leandro Trinidad",
                FechaCreacion = new DateTime(2020, 08, 3),
                NombreUsuario = "admin",
                Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92"
            });
        }


    }
} 
