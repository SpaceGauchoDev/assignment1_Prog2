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


        // inicializamos los parametros con valores por defecto para poder comparar contra
        // ingresos vacios
        public ActionResult AltaEmpleado(   DateTime? fNacEmp = null, 
                                            DateTime? fContEmp = null,
                                            bool adminEmp = false,
                                            string nomEmp = "", 
                                            int ciEmp = -1,
                                            string catEmp = "",                                         
                                            float sueldoEmp = -1,
                                            string usuEmp = "",
                                            string contEmp1 = ""){

            // si usuario ha ingresado todos los datos
            if (nomEmp != "" && 
                ciEmp != -1 && 
                sueldoEmp != -1 &&
                usuEmp != "" &&
                contEmp1 != "")
            {
                Admin.ResultadoString intento;
                intento.valor = "";
                intento.exito = false;
                intento = Admin.Instancia.AltaEmpleado(nomEmp, catEmp, ciEmp, fNacEmp.Value, fContEmp.Value, sueldoEmp, adminEmp, usuEmp, contEmp1);

                ViewBag.Mensaje = intento.valor;
            }
            else
            {
                ViewBag.Mensaje = "Faltan datos";           
            }

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