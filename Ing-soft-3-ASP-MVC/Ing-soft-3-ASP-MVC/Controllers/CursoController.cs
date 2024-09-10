using Ing_soft_3_ASP_MVC.Datos;
using Ing_soft_3_ASP_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ing_soft_3_ASP_MVC.Controllers
{
    public class CursoController : Controller
    {
        private CursoDatos cursoDatos = new CursoDatos();

        public IActionResult Listar()
        {
            var oLista = cursoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(CursoModel oCurso)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = cursoDatos.Guardar(oCurso);

            if (respuesta) return RedirectToAction("Listar");
            else return View();
        }

        public IActionResult Editar(int Curso_id)
        {
            var ocontacto = cursoDatos.Obtener(Curso_id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(CursoModel oCurso)
        {
            if (!ModelState.IsValid) return View();

            var respuesta = cursoDatos.Editar(oCurso);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Curso_id)
        {
            var ocontacto = cursoDatos.Obtener(Curso_id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(CursoModel oCurso)
        {

            var respuesta = cursoDatos.Eliminar(oCurso.Curso_id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
