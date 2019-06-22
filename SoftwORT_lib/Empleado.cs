using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwORT_lib
{
    public class Empleado
    {
        public static int edadMinima = 18;
        private static int ultimoIdEmpleado = 0;

        private string nombreCompleto;
        private int id;
        private int ci;
        private DateTime fechaDeNacimiento;
        private DateTime fechaDeContratacion;
        private float sueldoPorHora;
        private string categoria;
        private Usuario usuario;

        public int ObtenerId()
        {
            return id;
        }


        public int ObtenerCi()
        {
            return ci;
        }

        public string ObtenerNombre()
        {
            return nombreCompleto;
        }

        public string ObtenerCategoria()
        {
            return categoria;
        }

        public float ObtenerSueldo()
        {
            return sueldoPorHora;
        }

        public DateTime ObtenerFechaContratacion()
        {
            return fechaDeContratacion;
        }

        public DateTime ObtenerFechaNacimiento()
        {
            return fechaDeNacimiento;
        }

        public Usuario ObtenerUsuario()
        {
            return usuario;
        }


        public string ObtenerInfo()
        {
            string result = "Nombre: " + nombreCompleto + " | Ci: " + ci.ToString() + " | Categoria: " + categoria + "\n";
            return result;   
        }

        public void ModificarDatos(string pNom, string pCat, int pCi, DateTime pFNac, DateTime pFCon, float pSueldo)
        {
            nombreCompleto = pNom;
            categoria = pCat;
            ci = pCi;
            fechaDeNacimiento = pFNac;
            fechaDeContratacion = pFCon;
            sueldoPorHora = pSueldo;
        }


        public static int NuevoIdEmpleado()
        {
            ultimoIdEmpleado++;
            return ultimoIdEmpleado;
        }

        public static Admin.ResultadoString DatosEmpleadoValidos(string pNom, string pCat, DateTime pFNac, DateTime pFCon, float pSueldo)
        {
            // checkeamos que los parametros ingresados sean validos basados en reglas de negocio
            // y que los parametros ingresados no sean vacios

            Admin.ResultadoString result;
            bool exito = true;
            string msg = "Error en datos de empleado: \n";

            // checkeamos que el parametro nombre no este vacio    
            if (pNom == "")
            {
                exito = false;
                msg += "Nombre vacío \n";
            }

            // checkeamos que el parametro categoria no este vacio
            if (pCat == "")
            {
                exito = false;
                msg += "Categoria vacía \n";
            }
            else
            {
                // si el parametro categoria no esta vacio, checkeamos que sea valido
                if (!EsCategoriaEmpleadoValida(pCat))
                {
                    exito = false;
                    msg += "Categoria invalida \n";
                }
            }

            // ===================================
            // FECHAS DE NACIMIENTO Y CONTRATACION
            // vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

            // checkeamos que la fecha de contratacion no sea nula
            if (pFCon == null)
            {
                exito = false;
                msg += "Fecha de contratacion invalida \n";
            }

            // chekeamos que la fecha de nacimiento no sea nula
            if (pFNac == null)
            {
                exito = false;
                msg += "Fecha de nacimiento invalida \n";
            }
            else
            {
                // checkeamos que la fecha de nacimiento no sea mayor a la fecha actual
                if (pFNac > DateTime.Now)
                {
                    exito = false;
                    msg += "Fecha de nacimiento no puede ser mayor a la fecha actual \n";
                }
                else
                {
                    // checkeamos que la fecha de contratacion no sea menor que la fecha de nacimiento
                    if (pFCon < pFNac)
                    {
                        exito = false;
                        msg += "Fecha de contratacion no puede ser menor que la fecha de nacimiento \n";
                    }
                    else
                    {
                        // si la fecha de contratacion es el mismo dia que hoy
                        if (EsMismoDia(pFCon, DateTime.Now))
                        {
                            // checkeamos que el empleado tiene una fecha de nacimiento 
                            // tal que lo haga mayor de edad
                            DateTime fechaMayoriaEdad = DateTime.Now;
                            fechaMayoriaEdad = fechaMayoriaEdad.AddYears(-1 * edadMinima);

                            if (pFNac > fechaMayoriaEdad)
                            {
                                exito = false;
                                msg += "No puede ser menor de edad \n";
                            }
                        }
                    }
                }
            }

            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            // FECHAS DE NACIMIENTO Y CONTRATACION
            // ===================================

            // chekeamos que el sueldo por hora no sea negativo
            if (pSueldo < 0)
            {
                exito = false;
                msg += "Sueldo invalido, no puede ser negativo \n";
            }

            if (exito)
            {
                msg = "Datos empleado validos";
            }

            result.exito = exito;
            result.valor = msg;
            return result;
        }


        // devuelve verdadero si las dos fechas son el mismo dia
        // implementada para distinguir de los casos donde potencialmente 
        // ambas fechas son el mismo dia pero distintas horas, minutos y/o segundos
        private static bool EsMismoDia(DateTime pA, DateTime pB)
        {
            bool resultado = false;

            int diaA = pA.Day;
            int mesA = pA.Month;
            int anioA = pA.Year;

            int diaB = pB.Day;
            int mesB = pB.Month;
            int anioB = pB.Year;

            if ((diaA == diaB) &&
                (mesA == mesB) &&
                (anioA == anioB))
            {
                resultado = true;
            }

            return resultado;
        }


        public static string CodigoWebACategoria(int pCat)
        {
            string result = "";

            switch (pCat)
            {
                case 1:
                    result = "junior";
                    break;
                case 2:
                    result = "semi-senior";
                    break;
                case 3:
                    result = "senior";
                    break;
                case 4:
                    result = "tech lead";
                    break;
            }
            return result;
        } 

        public static bool EsCategoriaEmpleadoValida(string pCat)
        {
            bool exito;

            switch (pCat)
            {
                case "junior":
                    exito = true;
                    break;
                case "semi-senior":
                    exito = true;
                    break;
                case "senior":
                    exito = true;
                    break;
                case "tech lead":
                    exito = true;
                    break;
                default:
                    exito = false;
                    break;
            }
            return exito;
        }

        // constructor por defecto
        public Empleado()
        {
            nombreCompleto = "";
            id = -1;
            ci = -1;
            fechaDeContratacion = new DateTime(0, 0, 0);
            fechaDeNacimiento = new DateTime(0, 0, 0);
            sueldoPorHora = -1;
            categoria = "";

            usuario = new Usuario();
        }

        // constructor con parametros
        public Empleado(string pNom, string pCat, int pId, int pCi, DateTime pFCont, DateTime pFNac, float pSueldo, bool pAdmin, string pNomUsu, string pCon)
        {
            nombreCompleto = pNom;
            id = pId;
            ci = pCi;
            fechaDeContratacion = pFCont;
            fechaDeNacimiento = pFNac;
            sueldoPorHora = pSueldo;
            categoria = pCat;

            if (pAdmin)
            {
                usuario = new Usuario(Usuario.Rol.Admin, pNomUsu, pCon);
            }
            else
            {
                usuario = new Usuario(Usuario.Rol.Empleado, pNomUsu, pCon);
            }            
        }
    }
}
