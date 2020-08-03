using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentCarSystem.Entidades
{
    public class Rentas
    {
        [Key]
        public int RentaId { get; set; }
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaRenta { get; set; } = DateTime.Now;
        public DateTime FechaDevolucion { get; set; }
        public int CantidadDias { get; set; }
        public decimal PrecioPorDia { get; set; }
        public decimal MontoAPagar { get; set; }
        public string Comentario { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes clientes { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos vehiculos { get; set; }

        [ForeignKey("EmpleadoId")]
        public virtual Empleados empleados { get; set; }
    }
}
