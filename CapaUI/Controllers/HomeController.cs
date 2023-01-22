using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models;
using CapaBL;

namespace CapaUI.Controllers
{
    public class HomeController : Controller
    {
        private Empleados_BL userBL = new Empleados_BL();
        public ActionResult Index()
        {
            return View(userBL.listaEmpleados());
        }


        //Genera plantilla Editar
        public Puestos_BL materiaBL = new Puestos_BL();
        public ActionResult Agregar()
        {
            ViewBag.Puestos = materiaBL.Listar();
            return View();
        }

        //Registro
        public ActionResult Registro(Empleados_ET user)
        {
            userBL.Registrar(user);
            new Empleados_BL();
            return RedirectToAction("Index");
        }


        //Genera plantilla editar con id
        public ActionResult Editar(int id)
        {
            ViewBag.Puestos = materiaBL.Listar();
            return View(userBL.Obtener(id));
        }

        //Actualiza
        public ActionResult Actualizar(Empleados_ET user)
        {
            return RedirectToAction("Index", userBL.Actualizar(user));
        }

        //Vista Eliminar plantilla
        public ActionResult Eliminar(int id)
        {
            ViewBag.Puestos = materiaBL.Listar();
            return View(userBL.Obtener(id));
        }


        public ActionResult Eliminar_Usuario(int id)
        {
            return RedirectToAction("Index", userBL.Eliminar(id));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}