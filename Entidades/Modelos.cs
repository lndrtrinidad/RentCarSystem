using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentCarSystem.Entidades
{
    public class Modelos
    {
        [Key]
        public int ModeloId { get; set; }
        public string Descripcion { get; set; }

    }
}
