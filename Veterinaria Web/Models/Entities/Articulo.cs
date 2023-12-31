﻿using Azure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria_Web.Models.Entities
{
    public class Articulo
    {
        [Key]
        public int PKArticulo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [NotMapped]
        [Display(Name = "Imagen")]

        public IFormFile Img { get; set; }

        public string UrlImagenPath { get; set; }
        public List<Factura> Facturas { get; } = new();
    }
}
