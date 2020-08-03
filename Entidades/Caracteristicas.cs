using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentCarSystem.Entidades
{
    public class Caracteristicas
    {
        [Key]
        public int CaracteristicasId{ get; set; }
        public string Descripcion { get; set; }
    }
}
