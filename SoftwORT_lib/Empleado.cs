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
        public static int ultimoIdEmpleado = 0;

        private string nombreCompleto;
        private int id;
        private int ci;
        private DateTime fechaDeNacimiento;
        private DateTime fechaDeContratacion;
        private float sueldoPorHora;
        private string categoria;

        public int ObtenerId()
        {
            return id;
        }


        public int ObtenerCi()
        {
            return ci;
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


        public static Admin.ResultadoString DatosEmpleadoValidos(string pNom, string pCat, DateTime pFNac, float pSueldo)
        {
            // checkeamos que los parametros ingresados sean validos
            // se asume que la fecha de contratacion es la misma que la fecha de ingreso al sistema  

            Admin.ResultadoString result;
            bool exito = true;
            string msg = "Error en ingreso de nuevo empleado: \n";

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

            // chekeamos que la fecha no sea nula
            if (pFNac == null)
            {
                exito = false;
                msg += "Fecha de nacimiento invalida \n";
            }
            else
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

            // chekeamos que el sueldo por hora no sea negativo
            if (pSueldo < 0)
            {
                exito = false;
                msg += "Sueldo invalido, no puede ser negativo \n";
            }

            if (exito)
            {
                msg = "Datos empleado validos.";
            }

            result.exito = exito;
            result.valor = msg;
            return result;
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
        }

        // constructor con parametros
        public Empleado(string pNom, string pCat, int pId, int pCi, DateTime pFCont, DateTime pFNac, float pSueldo)
        {
            nombreCompleto = pNom;
            id = pId;
            ci = pCi;
            fechaDeContratacion = pFCont;
            fechaDeNacimiento = pFNac;
            sueldoPorHora = pSueldo;
            categoria = pCat;
        }
    }
}
