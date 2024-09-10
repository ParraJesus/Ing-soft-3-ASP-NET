using System.ComponentModel.DataAnnotations;

namespace Ing_soft_3_ASP_MVC.Models
{
    public class EstudianteModel
    {
        public int Estudiante_id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string? Apellido { get; set; }
    }
}
