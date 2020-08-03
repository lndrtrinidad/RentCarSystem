using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentCarSystem.Entidades
{
    public class Mantenimientos
    {
        [Key]
        public int MantenimientoId { get; set; }
        public int VehiculoId { get; set; }
        public string Observacion { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos vehiculos { get; set; }


    }
}
