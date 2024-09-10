using Ing_soft_3_ASP_MVC.Datos;
using Ing_soft_3_ASP_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ing_soft_3_ASP_MVC.Controllers
{
    public class EstudianteCursoController : Controller
    {
        private EstudianteCursoDatos estudianteCursoDatos = new EstudianteCursoDatos();

        public IActionResult Listar()
        {
            var oLista = estudianteCursoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EstudianteCursoModel oEstudianteCurso)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = estudianteCursoDatos.Guardar(oEstudianteCurso);

            if (respuesta) return RedirectToAction("Listar");
            else return View();
        }

        public IActionResult Eliminar(int Estudiante_id, int Curso_id)
        {
            var oEstudianteCurso = estudianteCursoDatos.Obtener(Estudiante_id, Curso_id);
            return View(oEstudianteCurso);
        }

        [HttpPost]
        public IActionResult Eliminar(EstudianteCursoModel oEstudianteCurso)
        {
            var respuesta = estudianteCursoDatos.Eliminar(oEstudianteCurso.Estudiante_id,oEstudianteCurso.Curso_id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
