using System.ComponentModel.DataAnnotations;

namespace Ing_soft_3_ASP_MVC.Models
{
    public class EstudianteCursoModel
    {
        [Required(ErrorMessage = "El campo del id del estudiante es obligatorio")]
        public int Estudiante_id { get; set; }

        [Required(ErrorMessage = "El campo del id del curso es obligatorio")]
        public int Curso_id { get; set; }
    }
}
