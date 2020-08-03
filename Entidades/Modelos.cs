using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentCarSystem.Entidades
{
    public class Modelos
    {
        [Key]
        public int ModeloId { get; set; }
        public int MarcaId { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("MarcaId")]
        public Marcas marcas { get; set; }


    }
}
