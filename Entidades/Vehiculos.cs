using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentCarSystem.Entidades
{
    public class Vehiculos
    {
        [Key]

        public int VehiculoId { get; set; }
        public string Descripcion { get; set; }
        public string VIN { get; set; }
        public string Placa { get; set; }
        public string Matricula { get; set; }
        public int Ano { get; set; }
        public string Color  { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioPorDia { get; set; }

        public bool Disponible { get; set; }
    }
}
