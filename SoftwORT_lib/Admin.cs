using System;
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
            float sueldo = FloatAleatorio(100.0f, 500.0f);
            AltaEmpleado("Manuel De Armas", "junior", 42935324, fechaNac, sueldo);

            fechaNac = new DateTime(2001, 1, 17);
            sueldo = FloatAleatorio(100.0f, 500.0f);
            AltaEmpleado("Avril Ruglio", "tech lead", 50431051, fechaNac, sueldo);

            fechaNac = new DateTime(1962, 4, 22);
            sueldo = FloatAleatorio(100.0f, 500.0f);
            AltaEmpleado("Silvia Mazon", "senior", 32768555, fechaNac, sueldo);

            fechaNac = new DateTime(1992, 6, 15);
            sueldo = FloatAleatorio(100.0f, 500.0f);
            AltaEmpleado("Matias Martines", "junior", 49005954, fechaNac, sueldo);

        }



        private ResultadoString AltaEmpleado(string pNom, string pCat, int pCi, DateTime pFNac, float pSueldo)
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
                validesDeDatos = Empleado.DatosEmpleadoValidos(pNom, pCat, pFNac, pSueldo);

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
