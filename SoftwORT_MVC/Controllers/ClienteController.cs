using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwORT_MVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Login", "Login");
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
    }
}