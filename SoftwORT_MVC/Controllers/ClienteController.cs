using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftwORT_lib;

namespace SoftwORT_MVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("MainMenuCliente", "Cliente");
            }
        }


        public ActionResult MainMenuCliente()
        {

            return View();
        }


        public ActionResult BlaBla()
        {

            return View();
        }



        public ActionResult VerProyectos()
        {
            Usuario user = (Usuario)Session["usuario"];
            Cliente c = Admin.Instancia.ObtenerClientePorUsuario(user);
            List<string> listado = Admin.Instancia.ProyectosPorCliente(c);


            return View(listado);
        }

        public ActionResult EmpleadosProyecto_Buscar(int idProy = -1)
        {
            // si usuario ha ingresado ci
            if (idProy != -1)
            {
                Proyecto pro = Admin.Instancia.ObtenerProyectoPorId(idProy);
                if (pro != null)
                {
                    TempData["proTemp"] = pro;
                    ViewBag.Mensaje = "Proyecto existe";
                    return RedirectToAction("EmpleadosProyecto_Mostrar", "Cliente");
                }
                else
                {
                    ViewBag.Mensaje = "Proyecto no existe";
                }
            }
            else
            {
                ViewBag.Mensaje = "Falta id";
            }

            return View();
        }


        public ActionResult EmpleadosProyecto_Mostrar()
        {
            Proyecto proRead;
            proRead = (Proyecto)TempData["proTemp"];

            List<string> infoEmpleados = Admin.Instancia.EmpleadosPorProyecto(proRead);         

            return View(infoEmpleados);
        }



        public ActionResult Logout()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}