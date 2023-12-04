using System.ComponentModel.DataAnnotations;

namespace Veterinaria_Web.Models.Entities
{
    public class Rol
    {
        [Key]
        public int PkRoles { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
