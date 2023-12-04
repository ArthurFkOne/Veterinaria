using Azure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria_Web.Models.Entities
{
    public class Factura
    {
        [Key]
        public int PkFactura { get; set; }

        [Required]
        public int Identificador { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Correo { get; set; }
        
        [Required]
        public string Total { get; set; }

        public List<Articulo> Articulo { get; } = new();
    }
}
