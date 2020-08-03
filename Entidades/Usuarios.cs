using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentCarSystem.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
