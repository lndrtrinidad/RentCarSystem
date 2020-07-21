using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Packaging;
using System.Text;

namespace RentCarSystem.Entidades
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public decimal PorcientoComision { get; set; }
    }
}
