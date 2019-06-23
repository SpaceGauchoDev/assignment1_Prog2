using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftwORT_lib;

namespace SoftwORT_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Usuario usuarioActual = (Usuario)Session["usuario"];
                string menu = "";
                if (usuarioActual.ObtenerRol() == Usuario.Rol.Empleado)
                {
                    menu = "MainMenuEmpleado";

                }
                if (usuarioActual.ObtenerRol() == Usuario.Rol.Admin)
                {
                    menu = "MainMenuAdministrador";
                }
                return RedirectToAction(menu, "Empleado");
            }
        }

        // =================
        // acciones empleado
        // vvvvvvvvvvvvvvvvv

        public ActionResult MainMenuEmpleado()
        {
            return View();
        }


        public ActionResult ProyectosPorEmpleado()
        {
            return View();
        }

        public ActionResult AusenciasPorProyecto()
        {
            return View();
        }

        // ^^^^^^^^^^^^^^^^^
        // acciones empleado
        // =================



        // ======================
        // acciones administrador
        // vvvvvvvvvvvvvvvvvvvvvv

        public ActionResult MainMenuAdministrador()
        {
            return View();
        }


        public ActionResult AltaEmpleado()
        {
            return View();
        }

        public ActionResult ModificacionEmpleado()
        {
            return View();
        }

        public ActionResult BajaEmpleado()
        {
            return View();
        }


        public ActionResult AltaProyecto()
        {
            return View();
        }


        public ActionResult AusenciasProyecto()
        {
            return View();
        }


        public ActionResult BajaProyecto()
        {
            return View();
        }


        // ^^^^^^^^^^^^^^^^^^^^^^
        // acciones administrador
        // ======================



        public ActionResult Logout()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}