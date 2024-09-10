using System.ComponentModel.DataAnnotations;

namespace Ing_soft_3_ASP_MVC.Models
{
    public class CursoModel
    {
        public int Curso_id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo del id del profesor es obligatorio")]
        public int Profesor_id { get; set; }
    }
}
