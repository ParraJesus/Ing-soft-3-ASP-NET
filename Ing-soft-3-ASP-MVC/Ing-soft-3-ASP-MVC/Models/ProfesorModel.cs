using System.ComponentModel.DataAnnotations;

namespace Ing_soft_3_ASP_MVC.Models
{
    public class ProfesorModel
    {
        public int Profesor_id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string? Apellido { get; set; }
    }
}
