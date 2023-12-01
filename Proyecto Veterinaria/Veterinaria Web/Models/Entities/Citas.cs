using System.ComponentModel.DataAnnotations;

namespace Veterinaria_Web.Models.Entities
{
    public class Citas
    {

        [Key]
        public int PkCita { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }


        [Required]
        public string Nombreanimal { get; set; }

        [Required]
        public string Animal { get; set; }



        [Required]
        public string Servicio { get; set; }

        [Required]
        public int Numero{ get; set; }




    }
}
