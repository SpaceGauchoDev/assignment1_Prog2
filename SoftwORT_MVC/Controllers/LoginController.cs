using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftwORT_lib;

namespace SoftwORT_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(string nombreUsuario = "", string contrasenia = "")
        {
            if (nombreUsuario != "" && contrasenia != "")
            {
                Usuario usuarioActual = Admin.Instancia.ObtenerUsuario(nombreUsuario, contrasenia);
                string msg = "";
                string myControlador = "";

                if (usuarioActual != null)
                {
                    switch (usuarioActual.ObtenerRol())
                    {
                        case Usuario.Rol.SinRol:
                            msg = "Algo ha salido mal, bienvenido/a SinRol";
                            break;
                        case Usuario.Rol.Empleado:
                            msg = "Los datos son correctos, bienvenido/a Empleado/a";
                            myControlador = "Empleado";
                            break;
                        case Usuario.Rol.Cliente:
                            msg = "Los datos son correctos, bienvenido/a Cliente";
                            myControlador = "Cliente";
                            break;
                        case Usuario.Rol.Admin:
                            msg = "Los datos son correctos, bienvenido/a Administrador/a";
                            myControlador = "Empleado";
                            break;
                    }

                    ViewBag.Mensaje = msg;

                    Session["usuario"] = usuarioActual;
                    return RedirectToAction("Index", myControlador);
                }
                else
                {
                    ViewBag.Mensaje = "Los datos no son correctos.";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {        
            Session["usuario"] = null;          
            return View("Login");
        }
    }
}