using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentCarSystem.Entidades
{
    public class Vehiculos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehiculoId { get; set; }
        
        public int MarcaId { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string VIN { get; set; }
        public string Placa { get; set; }
        public string Matricula { get; set; }
        public int Ano { get; set; }
        public string Color  { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioPorDia { get; set; }

        public bool Disponible { get; set; }

        [ForeignKey("MarcaId")]
        public virtual Marcas marcas { get; set; }




    }
}
