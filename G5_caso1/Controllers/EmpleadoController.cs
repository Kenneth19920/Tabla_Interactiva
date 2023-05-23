using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G5_caso1.Models;
using G5_caso1.Class;

namespace G5_caso1.Controllers
{
    public class EmpleadoController : Controller
    {

        Persona persona = new Persona();


        // GET: Empleado
        public ActionResult Index()
        {

            IEnumerable<EMPLEADO> lst = persona.consultar();
            return View(lst);
        }

        public ActionResult Guardar(EMPLEADO modelo)
        {

            ViewBag.Mensaje = "";
            return View(modelo);
        }

        public ActionResult Agregar(EMPLEADO modelo)
        {
            if (ModelState.IsValid)
            {
                persona.guardar(modelo);
                ViewBag.Mensaje = "El Empleado se guardó correctamente.";
                return View("Guardar", modelo);
            }
            else
            {
                
                return View("Guardar", modelo);
            }
        }

        public ActionResult Detalle(int id)
        {
            EMPLEADO modelo = persona.ConsultarId(id);

            if (modelo == null)
            {
                return HttpNotFound();
            }

            return View(modelo);
        }


        public ActionResult Eliminar(int id)
        {
            EMPLEADO empleado = persona.ConsultarId(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }

            persona.eliminar(empleado);

            TempData["Mensaje"] = $"El Empleado {empleado.NOMBRE} ha sido eliminado correctamente";

            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int id)
        {

            EMPLEADO modelo = persona.ConsultarId(id);
            ViewBag.Mensaje = " ";
            return View(modelo);


        }

        public ActionResult Cambiar(EMPLEADO modelo)
        {

            persona.modificar(modelo);
            ViewBag.Mensaje = "El Empleado se guardo correctamente ";
            return View("Modificar", modelo);

        }


    }
}