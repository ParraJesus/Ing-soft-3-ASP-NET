using Microsoft.AspNetCore.Mvc;
using Ing_soft_3_ASP_MVC.Datos;
using Ing_soft_3_ASP_MVC.Models;

namespace Ing_soft_3_ASP_MVC.Controllers
{
    public class ProfesorController : Controller
    {
        private ProfesorDatos profesorDatos = new ProfesorDatos();

        public IActionResult Listar()
        {
            var oLista = profesorDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ProfesorModel oProfesor)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = profesorDatos.Guardar(oProfesor);

            if (respuesta) return RedirectToAction("Listar");
            else return View();
        }

        public IActionResult Editar(int Profesor_id)
        {
            var ocontacto = profesorDatos.Obtener(Profesor_id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(ProfesorModel oProfesor)
        {
            if (!ModelState.IsValid) return View();

            var respuesta = profesorDatos.Editar(oProfesor);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Profesor_id)
        {
            var ocontacto = profesorDatos.Obtener(Profesor_id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ProfesorModel oProfesor)
        {

            var respuesta = profesorDatos.Eliminar(oProfesor.Profesor_id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
