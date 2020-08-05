using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace RentCarSystem.Entidades
{
    public class VehiculosDetalle
    {
        [Key]
        public int VehihiculoDetalleId { get; set; }
        public int MarcaId { get; set; }
        public int VehiculoId { get; set; }
        public int CaracteristicasId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;


        [ForeignKey("CaracteristicasId")]
        public virtual Caracteristicas caracteristicas { get; set; }




    }
}
