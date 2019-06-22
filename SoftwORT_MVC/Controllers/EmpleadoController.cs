using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwORT_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return RedirectToAction("MainMenuEmpleado", "Empleado");
            }
        }


        public ActionResult MainMenuEmpleado()
        {


            return View();
        }
    }
}