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

            return View();
        }


        public ActionResult EmpleadosProyecto()
        {

            return View();
        }

        public ActionResult Logout()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}