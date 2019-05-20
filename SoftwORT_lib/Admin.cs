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
        private List<Proyecto> proyectos;
        private List<Cliente> clientes;

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

        public struct ResultadoFloat
        {
            public float valor;
            public bool exito;

            public ResultadoFloat(float p1, bool p2)
            {
                valor = p1;
                exito = p2;
            }
        }


        public struct ResultadoFecha
        {
            public DateTime valor;
            public bool exito;

            public ResultadoFecha(DateTime p1, bool p2)
            {
                valor = p1;
                exito = p2;
            }
        }

        private void PrecargaDeDatos()
        {
            Random randomSeed = new Random();

            // creacion de empleados
            DateTime fechaNac = new DateTime(1990, 2, 15);
            AltaEmpleado("Manuel De Armas", "junior", 42935324, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed));

            fechaNac = new DateTime(1999, 1, 17);
            AltaEmpleado("Avril Ruglio", "tech lead", 50431051, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed));

            fechaNac = new DateTime(1962, 4, 22);
            AltaEmpleado("Silvia Mazon", "senior", 32768555, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed));

            fechaNac = new DateTime(1992, 6, 15);
            AltaEmpleado("Matias Martines", "junior", 49005954, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed));

            fechaNac = new DateTime(1995, 3, 7);
            AltaEmpleado("Juan Perez", "junior", 49005955, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed));

            fechaNac = new DateTime(1991, 7, 22);
            AltaEmpleado("Maria Rodriguez", "senior", 49005956, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed));

            fechaNac = new DateTime(1987, 10, 31);         
            AltaEmpleado("Nicolas Batalla", "semi-senior", 49005957, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed));

            fechaNac = new DateTime(1984, 1, 14);
            AltaEmpleado("Andrea Durlacher", "tech lead", 49005958, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed));

            fechaNac = new DateTime(1991, 6, 5);         
            AltaEmpleado("Alfonso Correa", "junior", 49005959, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed));

            // modificacion de empleados
            ResultadoInt idEmp1 = ObtenerIdEmpleadoPorCi(49005954);
            Empleado empMod1 = ObtenerEmpleadoPorId(idEmp1.valor);
            ModificacionEmpleado(idEmp1.valor, empMod1.ObtenerNombre(), "senior", empMod1.ObtenerCi(), empMod1.ObtenerFechaNacimiento(), empMod1.ObtenerFechaContratacion(), empMod1.ObtenerSueldo());
    
            ResultadoInt idEmp2 = ObtenerIdEmpleadoPorCi(50431051);
            Empleado empMod2 = ObtenerEmpleadoPorId(idEmp2.valor);
            ModificacionEmpleado(idEmp2.valor, empMod2.ObtenerNombre(), empMod2.ObtenerCategoria(), empMod2.ObtenerCi(), empMod2.ObtenerFechaNacimiento(), empMod2.ObtenerFechaContratacion(), 50.0f);
            

            ResultadoInt idEmp3 = ObtenerIdEmpleadoPorCi(42935324);
            Empleado empMod3 = ObtenerEmpleadoPorId(idEmp3.valor);
            ModificacionEmpleado(idEmp3.valor, empMod3.ObtenerNombre(), "tech lead", empMod3.ObtenerCi(), empMod3.ObtenerFechaNacimiento(), empMod3.ObtenerFechaContratacion(), empMod3.ObtenerSueldo() - 50.0f);
            

            // creacion de clientes       
            Cliente cliente1 = new Cliente("Umbrella", "123456789111", FechaPasadaAleatoria(15, randomSeed));
            clientes.Add(cliente1);

            Cliente cliente2 = new Cliente("MomCorp", "123456789112", FechaPasadaAleatoria(15, randomSeed));
            clientes.Add(cliente2);

            Cliente cliente3 = new Cliente("BuyNLarge", "123456789113", FechaPasadaAleatoria(15, randomSeed));
            clientes.Add(cliente3);

            Cliente cliente4 = new Cliente("WolframAndHart", "123456789114", FechaPasadaAleatoria(15, randomSeed));
            clientes.Add(cliente4);

            Cliente cliente5 = new Cliente("OsCorp", "123456789115", FechaPasadaAleatoria(15, randomSeed));
            clientes.Add(cliente5);

            Cliente cliente6 = new Cliente("HansoFoundation", "123456789116", FechaPasadaAleatoria(15, randomSeed));
            clientes.Add(cliente6);

            Cliente cliente7 = new Cliente("ZorgIndustries", "123456789117", FechaPasadaAleatoria(15, randomSeed));
            clientes.Add(cliente7);

            Cliente cliente8 = new Cliente("OCP", "123456789118", FechaPasadaAleatoria(15, randomSeed));
            clientes.Add(cliente8);

            // creacion de proyectos presupuestados
            List<Empleado> empList1 = new List<Empleado>() { empleados[0], empleados[1] };
            Presupuestado proyect1 = new Presupuestado(456.0f, "Virus-T", DateTime.Now.AddDays(1), cliente1, 3, empList1);
            proyectos.Add(proyect1);

            List<Empleado> empList2 = new List<Empleado>() { empleados[2] };
            Presupuestado proyect2 = new Presupuestado(150.0f, "EyePhone", DateTime.Now.AddDays(-3), cliente2, 8, empList2);
            proyectos.Add(proyect2);

            List<Empleado> empList3 = new List<Empleado>() { empleados[3], empleados[4], empleados[5] };
            Presupuestado proyect3 = new Presupuestado(650.0f, "WallEBot", DateTime.Now.AddDays(5), cliente3, 10, empList3);
            proyectos.Add(proyect3);

            List<Empleado> empList4 = new List<Empleado>() { empleados[6], empleados[7] };
            Presupuestado proyect4 = new Presupuestado(370.0f, "RoboCop2", DateTime.Now.AddDays(2), cliente8, 5, empList4);
            proyectos.Add(proyect4);
        }


        public ResultadoString NuevoCargoExtra(float pNuevoCargo)
        {
            ResultadoString resultado = PorHora.ActualizarCargoExtra(pNuevoCargo);
            return resultado;
        } 

        public ResultadoString ClientesPorAntiguuedad(DateTime pFCli)
        {
            ResultadoString resultado;
            resultado.exito = false;
            resultado.valor = "";
            int cantClientesEncontrados = 0;

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].ObtenerRelLab() <= pFCli)
                {
                    resultado.valor += clientes[i].ObtenerNomRutRelLab_AsString();
                    cantClientesEncontrados++;
                }
            }

            if (cantClientesEncontrados == 0)
            {
                resultado.valor = "No se encontron clientes en el sistema que cumplieran los requisitos de busqueda.";
                resultado.exito = false;
            }else
            {
                resultado.exito = true;
            }

            resultado.valor += "\n";

            return resultado;
        }

        public ResultadoString AltaEmpleado(string pNom, string pCat, int pCi, DateTime pFNac, DateTime pFCon, float pSueldo)
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
                //DateTime fechaActual = DateTime.Now;

                Empleado empleado = new Empleado(pNom, pCat, nuevoIdEmpleado, pCi, pFCon, pFNac, pSueldo);
                empleados.Add(empleado);
            }

            return validesDeDatos;
        }



        public ResultadoString ModificacionEmpleado(int pId, string pNom, string pCat, int pCi, DateTime pFNac, DateTime pFCon, float pSueldo)
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



        public ResultadoString ListarEmpleados(string pCat)
        {
            ResultadoString resultado;
            resultado.exito = false;
            resultado.valor = "";

            resultado.valor += "Listado de empleados: \n";

            pCat = pCat.ToLower();
            int cantEmpleadosEncontrados = 0;

            // si el usuario ingresó una categoría válida
            if (Empleado.EsCategoriaEmpleadoValida(pCat))
            {
                resultado.valor += "\n";
                for (int i = 0; i < empleados.Count; i++)
                {
                    if (empleados[i].ObtenerCategoria() == pCat)
                    {
                        resultado.valor += empleados[i].ObtenerInfo();
                        cantEmpleadosEncontrados++;
                    }
                }
            }
            // si el usuario no ingresó una categoría válida
            else
            {
                resultado.valor += "(categoría inválida o vacía, se listarán todos los empleados) \n";
                resultado.valor += "\n";
                for (int i = 0; i < empleados.Count; i++)
                {
                    resultado.valor += empleados[i].ObtenerInfo();
                    cantEmpleadosEncontrados++;
                }
            }

            if (cantEmpleadosEncontrados == 0)
            {
                resultado.valor = "No se encontron empleados en el sistema que cumplieran los requisitos de busqueda.";
            }

            resultado.valor += "\n";

            return resultado;
        }

        public ResultadoString ListarClientes(string pCat)
        {
            ResultadoString resultado;
            resultado.exito = false;
            resultado.valor = "";

            /*
            resultado.valor += "Listado de empleados: \n";

            pCat = pCat.ToLower();
            int cantEmpleadosEncontrados = 0;

            // si el usuario ingresó una categoría válida
            if (Empleado.EsCategoriaEmpleadoValida(pCat))
            {
                resultado.valor += "\n";
                for (int i = 0; i < empleados.Count; i++)
                {
                    if (empleados[i].ObtenerCategoria() == pCat)
                    {
                        resultado.valor += empleados[i].ObtenerInfo();
                        cantEmpleadosEncontrados++;
                    }
                }
            }
            // si el usuario no ingresó una categoría válida
            else
            {
                resultado.valor += "(categoría inválida o vacía, se listarán todos los empleados) \n";
                resultado.valor += "\n";
                for (int i = 0; i < empleados.Count; i++)
                {
                    resultado.valor += empleados[i].ObtenerInfo();
                    cantEmpleadosEncontrados++;
                }
            }

            if (cantEmpleadosEncontrados == 0)
            {
                resultado.valor = "No se encontron empleados en el sistema que cumplieran los requisitos de busqueda.";
            }

            resultado.valor += "\n";

            */
            return resultado;
        }


        public ResultadoInt ObtenerIdEmpleadoPorCi(int pCi)
        {
            ResultadoInt resultado;
            resultado.valor = -1;
            resultado.exito = false;

            int cont = 0;

            while (cont < empleados.Count && !resultado.exito)
            {
                if (empleados[cont].ObtenerCi() == pCi)
                {
                    resultado.exito = true;
                    resultado.valor = empleados[cont].ObtenerId();
                }
                else
                {
                    cont++;
                }
            }
            return resultado;
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


        DateTime FechaPasadaAleatoria(int pAniosAtrasMax, Random pSeed)
        {
            DateTime result = DateTime.Now.AddYears((IntAleatorio(0, pAniosAtrasMax, pSeed)) * -1);
            result = result.AddMonths(IntAleatorio(1, 12, pSeed));
            result = result.AddDays(IntAleatorio(1, 28, pSeed));
            return result;
        }

        float FloatAleatorio(float min, float max, Random pSeed)
        {
            //Random rand = new Random();
            float result = (float)(pSeed.NextDouble() * max) + min;
            result = (float)Math.Round(result * 100f) / 100f; // redondeamos el valor para 2 decimales
            return result;
        }


        int IntAleatorio(int min, int max, Random pSeed)
        {
            //Random rand = new Random();
            int result = pSeed.Next(min, max + 1);
            return result;
        }

        public Admin()
        {
            //inicializacion de admin
            empleados = new List<Empleado>();
            clientes = new List<Cliente>();
            proyectos = new List<Proyecto>();

            PrecargaDeDatos();
        }
    }
}
