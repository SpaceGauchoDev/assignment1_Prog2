﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwORT_lib
{
    public class Admin
    {
        private List<Empleado> empleados;

        public struct ResultadoString
        {
            public string valor;
            public bool exito;

            public ResultadoString(string p1, bool p2)
            {
                valor = p1;
                exito = p2;
            }
        }

        public struct ResultadoInt
        {
            public int valor;
            public bool exito;

            public ResultadoInt(int p1, bool p2)
            {
                valor = p1;
                exito = p2;
            }
        }

        private void PrecargaDeDatos()
        {
            // creacion de empleados
            DateTime fechaNac = new DateTime(1990, 2, 15);
            DateTime fechaCon = DateTime.Now;
            fechaCon = fechaCon.AddYears(-7);
            float sueldo = FloatAleatorio(100.0f, 500.0f);
            ResultadoString alta1 = AltaEmpleado("Manuel De Armas", "junior", 42935324, fechaNac, fechaCon, sueldo);
            Console.WriteLine(alta1.valor);

            fechaNac = new DateTime(1999, 1, 17);
            sueldo = FloatAleatorio(100.0f, 500.0f);
            fechaCon = DateTime.Now;
            fechaCon = fechaCon.AddYears(-1);
            ResultadoString alta2 = AltaEmpleado("Avril Ruglio", "tech lead", 50431051, fechaNac, fechaCon, sueldo);
            Console.WriteLine(alta2.valor);

            fechaNac = new DateTime(1962, 4, 22);
            fechaCon = DateTime.Now;
            fechaCon = fechaCon.AddYears(-15);
            sueldo = FloatAleatorio(100.0f, 500.0f);
            ResultadoString alta3 = AltaEmpleado("Silvia Mazon", "senior", 32768555, fechaNac, fechaCon, sueldo);
            Console.WriteLine(alta3.valor);

            fechaNac = new DateTime(1992, 6, 15);
            sueldo = FloatAleatorio(100.0f, 500.0f);
            fechaCon = DateTime.Now;
            fechaCon = fechaCon.AddYears(-3);
            ResultadoString alta4 = AltaEmpleado("Matias Martines", "junior", 49005954, fechaNac, fechaCon, sueldo);
            Console.WriteLine(alta4.valor);

            // modificacion de empleados
            int idEmp1 = ObtenerIdEmpleadoPorCi(49005954);
            Empleado empMod1 = ObtenerEmpleadoPorId(idEmp1); 
            ResultadoString mod1 = ModificacionEmpleado(idEmp1, empMod1.ObtenerNombre(), "senior", empMod1.ObtenerCi(), empMod1.ObtenerFechaNacimiento(), empMod1.ObtenerFechaContratacion(), empMod1.ObtenerSueldo());
            Console.WriteLine(mod1.valor);

            int idEmp2 = ObtenerIdEmpleadoPorCi(50431051);
            Empleado empMod2 = ObtenerEmpleadoPorId(idEmp2);
            ResultadoString mod2 = ModificacionEmpleado(idEmp2, empMod2.ObtenerNombre(), empMod2.ObtenerCategoria(), empMod2.ObtenerCi(), empMod2.ObtenerFechaNacimiento(), empMod2.ObtenerFechaContratacion(), 50.0f);
            Console.WriteLine(mod2.valor);

            int idEmp3 = ObtenerIdEmpleadoPorCi(42935324);
            Empleado empMod3 = ObtenerEmpleadoPorId(idEmp3);
            ResultadoString mod3 = ModificacionEmpleado(idEmp3, empMod3.ObtenerNombre(), "tech lead", empMod3.ObtenerCi(), empMod3.ObtenerFechaNacimiento(), empMod3.ObtenerFechaContratacion(), empMod3.ObtenerSueldo() - 50.0f);
            Console.WriteLine(mod3.valor);

            Console.ReadLine();
        }

        private ResultadoString AltaEmpleado(string pNom, string pCat, int pCi, DateTime pFNac, DateTime pFCon, float pSueldo)
        {
            ResultadoString validesDeDatos;

            // chekeamos que un empleado con la misma ci no esté ya ingresado en el sistema
            if (ObtenerEmpleadoPorCi(pCi) != null)
            {
                validesDeDatos.exito = false;
                validesDeDatos.valor = "Error: \n";
                validesDeDatos.valor += "Empleado con misma cedula ya ingresado en el sistema \n";
            }
            else
            {
                // validamos el resto de los datos de acuerdo a las reglas de negocio de empleado
                validesDeDatos = Empleado.DatosEmpleadoValidos(pNom, pCat, pFNac, pFCon, pSueldo);

            }

            // si entramos aca es que todos los campos fueron validados
            if (validesDeDatos.exito)
            {
                validesDeDatos.valor = "Empleado creado exitosamente.";
                int nuevoIdEmpleado = Empleado.ultimoIdEmpleado + 1;
                Empleado.ultimoIdEmpleado = nuevoIdEmpleado;
                DateTime fechaActual = DateTime.Now;

                Empleado empleado = new Empleado(pNom, pCat, nuevoIdEmpleado, pCi, fechaActual, pFNac, pSueldo);
                empleados.Add(empleado);
            }

            return validesDeDatos;
        }



        private ResultadoString ModificacionEmpleado(int pId, string pNom, string pCat, int pCi, DateTime pFNac, DateTime pFCon, float pSueldo)
        {
            ResultadoString validesDeDatos;
            Empleado empleado = ObtenerEmpleadoPorId(pId);

            // checkeamos que el empleado exista en el sistema
            if (empleado == null)
            {
                validesDeDatos.exito = false;
                validesDeDatos.valor = "Error: \n";
                validesDeDatos.valor += "Empleado con la cedula indicada no existe en el sistema \n";
            }
            else
            {
                // validamos el resto de los datos de acuerdo a las reglas de negocio de empleado
                validesDeDatos = Empleado.DatosEmpleadoValidos(pNom, pCat, pFNac, pFCon, pSueldo);
            }

            // si entramos aca es que todos los campos fueron validados
            if (validesDeDatos.exito)
            {
                validesDeDatos.valor = "Datos de empleado actualizados exitosamente.";
                empleado.ModificarDatos(pNom, pCat, pCi, pFNac, pFCon, pSueldo);
            }

            return validesDeDatos;
        }



        private int ObtenerIdEmpleadoPorCi(int pCi)
        {
            int id = -1;
            int cont = 0;

            while (cont < empleados.Count && id == -1)
            {
                if (empleados[cont].ObtenerCi() == pCi)
                {
                    id = empleados[cont].ObtenerId();
                }
                else
                {
                    cont++;
                }
            }
            return id;
        }


        private Empleado ObtenerEmpleadoPorId(int id)
        {
            Empleado resultado = null;
            if (empleados.Count > 0)
            {
                int i = 0;
                while (i < empleados.Count && resultado == null)
                {

                    if (empleados[i].ObtenerId() == id)
                    {
                        resultado = empleados[i];

                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return resultado;
        }


        private Empleado ObtenerEmpleadoPorCi(int ci)
        {
            Empleado resultado = null;
            if (empleados.Count > 0)
            {
                int i = 0;
                while (i < empleados.Count && resultado == null)
                {

                    if (empleados[i].ObtenerCi() == ci)
                    {
                        resultado = empleados[i];

                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return resultado;
        }



        float FloatAleatorio(float a, float b)
        {
            float result;
            Random rand = new Random();
            result = (float)(rand.NextDouble() * b) + a;
            result = (float)Math.Round(result * 100f) / 100f; // redondeamos el valor para 2 decimales
            return result;
        }

        public Admin()
        {
            //inicializacion de admin
            empleados = new List<Empleado>();
            PrecargaDeDatos();
        }
    }
}