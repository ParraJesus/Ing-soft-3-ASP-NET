using Microsoft.AspNetCore.Mvc;
using Ing_soft_3_ASP_MVC.Datos;
using Ing_soft_3_ASP_MVC.Models;

namespace Ing_soft_3_ASP_MVC.Controllers
{
    public class EstudianteController : Controller
    {
        private EstudianteDatos estudianteDatos = new EstudianteDatos();

        public IActionResult Listar()
        {
            var oLista = estudianteDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EstudianteModel oEstudiante)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = estudianteDatos.Guardar(oEstudiante);

            if (respuesta) return RedirectToAction("Listar");
            else return View();
        }

        public IActionResult Editar(int Estudiante_id)
        {
            var ocontacto = estudianteDatos.Obtener(Estudiante_id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(EstudianteModel oEstudiante)
        {
            if (!ModelState.IsValid) return View();

            var respuesta = estudianteDatos.Editar(oEstudiante);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Estudiante_id)
        {
            var ocontacto = estudianteDatos.Obtener(Estudiante_id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(EstudianteModel oEstudiante)
        {

            var respuesta = estudianteDatos.Eliminar(oEstudiante.Estudiante_id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
