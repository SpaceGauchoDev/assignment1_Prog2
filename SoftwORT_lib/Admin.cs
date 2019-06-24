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
        private Usuario usuarioActual;

        // singleton var
        public static Admin instancia;

        // singleton access / creation
        public static Admin Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Admin();
                }
                return instancia;
            }
        }


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

            CreacionDeEmpleados(randomSeed);

            CreacionDeClientes(randomSeed);

            // CreacionDeProyectos() debe ejecutarse ultima dentro de PrecargaDeDatos() ya 
            // que necesita que los arrays empleados y clientes esten iniciados y poblados
            CreacionDeProyectos();
        }




        private void CreacionDeEmpleados(Random randomSeed)
        {
            // creacion de empleados           
            //0
            DateTime fechaNac = new DateTime(1990, 2, 15);
            AltaEmpleado("Manuel De Armas", "tech lead", 42935324, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), true, "e0", "e0");

            //1
            fechaNac = new DateTime(1999, 1, 17);
            AltaEmpleado("Avril Ruglio", "tech lead", 50431051, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e1", "e1");

            //2
            fechaNac = new DateTime(1962, 4, 22);
            AltaEmpleado("Silvia Mazon", "senior", 32768555, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e2", "e2");

            //3
            fechaNac = new DateTime(1992, 6, 15);
            AltaEmpleado("Matias Martines", "junior", 49005954, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e3", "e3");

            //4
            fechaNac = new DateTime(1995, 3, 7);
            AltaEmpleado("Juan Perez", "junior", 49005955, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e4", "e4");

            //5
            fechaNac = new DateTime(1991, 7, 22);
            AltaEmpleado("Maria Rodriguez", "senior", 49005956, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e5", "e5");

            //6
            fechaNac = new DateTime(1987, 10, 31);
            AltaEmpleado("Nicolas Batalla", "semi-senior", 49005957, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e6", "e6");

            //7
            fechaNac = new DateTime(1984, 1, 14);
            AltaEmpleado("Andrea Durlacher", "tech lead", 49005958, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e7", "e7");

            //8
            fechaNac = new DateTime(1991, 6, 5);
            AltaEmpleado("Alfonso Correa", "junior", 49005959, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e8", "e8");

            //9
            fechaNac = new DateTime(1995, 2, 1);
            AltaEmpleado("Julian Cabrera", "semi-senior", 49005960, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e9", "e9");

            //10
            fechaNac = new DateTime(1992, 12, 23);
            AltaEmpleado("Sebastian Sueldo", "junior", 49005961, fechaNac, FechaPasadaAleatoria(5, randomSeed), FloatAleatorio(100.0f, 500.0f, randomSeed), false, "e10", "e10");

            // modificacion de empleados
            ResultadoInt idEmp1 = ObtenerIdEmpleadoPorCi(49005954);
            Empleado empMod1 = ObtenerEmpleadoPorId(idEmp1.valor);
            ModificacionEmpleado(idEmp1.valor, empMod1.ObtenerNombre(), "senior", empMod1.ObtenerCi(), empMod1.ObtenerFechaNacimiento(), empMod1.ObtenerFechaContratacion(), empMod1.ObtenerSueldo(), false, "e3", "e3");

            ResultadoInt idEmp2 = ObtenerIdEmpleadoPorCi(50431051);
            Empleado empMod2 = ObtenerEmpleadoPorId(idEmp2.valor);
            ModificacionEmpleado(idEmp2.valor, empMod2.ObtenerNombre(), empMod2.ObtenerCategoria(), empMod2.ObtenerCi(), empMod2.ObtenerFechaNacimiento(), empMod2.ObtenerFechaContratacion(), 50.0f, false, "e1", "e1");

            ResultadoInt idEmp3 = ObtenerIdEmpleadoPorCi(42935324);
            Empleado empMod3 = ObtenerEmpleadoPorId(idEmp3.valor);
            ModificacionEmpleado(idEmp3.valor, empMod3.ObtenerNombre(), "tech lead", empMod3.ObtenerCi(), empMod3.ObtenerFechaNacimiento(), empMod3.ObtenerFechaContratacion(), empMod3.ObtenerSueldo() - 50.0f, true, "e0", "e0");
        }

        private void CreacionDeClientes(Random randomSeed)
        {
            // creacion de clientes       
            Cliente cliente0 = new Cliente("Umbrella", 123456789111, FechaPasadaAleatoria(15, randomSeed), "c0", "c0");
            clientes.Add(cliente0);

            Cliente cliente1 = new Cliente("MomCorp", 123456789112, FechaPasadaAleatoria(15, randomSeed), "c1", "c1");
            clientes.Add(cliente1);

            Cliente cliente2 = new Cliente("BuyNLarge", 123456789113, FechaPasadaAleatoria(15, randomSeed), "c2", "c2");
            clientes.Add(cliente2);

            Cliente cliente3 = new Cliente("WolframAndHart", 123456789114, FechaPasadaAleatoria(15, randomSeed), "c3", "c3");
            clientes.Add(cliente3);

            Cliente cliente4 = new Cliente("OsCorp", 123456789115, FechaPasadaAleatoria(15, randomSeed), "c4", "c4");
            clientes.Add(cliente4);

            Cliente cliente5 = new Cliente("HansoFoundation", 123456789116, FechaPasadaAleatoria(15, randomSeed), "c5", "c5");
            clientes.Add(cliente5);

            Cliente cliente6 = new Cliente("ZorgIndustries", 123456789117, FechaPasadaAleatoria(15, randomSeed), "c6", "c6");
            clientes.Add(cliente6);

            Cliente cliente7 = new Cliente("OCP", 123456789118, FechaPasadaAleatoria(15, randomSeed), "c7", "c7");
            clientes.Add(cliente7);
        }

        private void CreacionDeProyectos()
        {
            // creacion de proyectos presupuestados
            List<Empleado> empList1 = new List<Empleado>() { empleados[0], empleados[1] };
            int nuevoIdProyecto = Proyecto.NuevoIdProyecto();
            Presupuestado proyect1 = new Presupuestado(nuevoIdProyecto, "Virus-T", DateTime.Now.AddDays(-10), clientes[0], 3, empList1);
            proyectos.Add(proyect1);
            proyect1.CerrarProyecto(DateTime.Now.AddDays(-7)); // cerramos un proyecto tres dias despues que inició, en fecha

            List<Empleado> empList2 = new List<Empleado>() { empleados[2] };
            nuevoIdProyecto = Proyecto.NuevoIdProyecto();
            Presupuestado proyect2 = new Presupuestado(nuevoIdProyecto, "EyePhone", DateTime.Now.AddDays(-30), clientes[0], 10, empList2);
            proyectos.Add(proyect2);
            proyect2.CerrarProyecto(DateTime.Now.AddDays(-15)); // cerramos un proyecto 15 dias despues de que inició, 5 dias pasados

            List<Empleado> empList3 = new List<Empleado>() { empleados[3], empleados[4], empleados[5] };
            nuevoIdProyecto = Proyecto.NuevoIdProyecto();
            Presupuestado proyect3 = new Presupuestado(nuevoIdProyecto, "WallEBot", DateTime.Now.AddDays(-40), clientes[0], 10, empList3);
            proyectos.Add(proyect3);
            proyect3.CerrarProyecto(DateTime.Now.AddDays(-30)); // cerramos un proyecto 10 días despues de que inició, en fecha


            // creacion de proyectos por hora
            List<Empleado> empList5 = new List<Empleado>() { empleados[8] };
            nuevoIdProyecto = Proyecto.NuevoIdProyecto();
            PorHora proyect5 = new PorHora(nuevoIdProyecto, "Sabadebodueira", DateTime.Now.AddDays(-3), clientes[1], 7, empList5);
            proyectos.Add(proyect5);

            List<Empleado> empList6 = new List<Empleado>() { empleados[9], empleados[10] };
            nuevoIdProyecto = Proyecto.NuevoIdProyecto();
            PorHora proyect6 = new PorHora(nuevoIdProyecto, "Fiebre de sabado a la noche", DateTime.Now.AddDays(-1), clientes[2], 3, empList6);
            proyectos.Add(proyect6);

            List<Empleado> empList4 = new List<Empleado>() { empleados[6], empleados[7] };
            nuevoIdProyecto = Proyecto.NuevoIdProyecto();
            PorHora proyect4 = new PorHora(nuevoIdProyecto, "RoboCop2", DateTime.Now.AddDays(2), clientes[1], 5, empList4);
            proyectos.Add(proyect4);
        }


        public ResultadoString NuevoCargoExtra(float pNuevoCargo)
        {
            ResultadoString resultado = PorHora.ActualizarCargoExtra(pNuevoCargo);
            return resultado;
        }

        public ResultadoString ListarTodosLosProyectos()
        {
            ResultadoString resultado;
            resultado.exito = false;
            resultado.valor = "";

            if (proyectos.Count > 0)
            {
                resultado.exito = true;
                for (int i = 0; i < proyectos.Count; i++)
                {
                    resultado.valor += proyectos[i].ObtenerNombreFechaDuracionCliente_AsString();
                }
            }
            else {
                resultado.valor = "No hay proyectos ingresados en el sistema.";
                resultado.exito = false;
            }

            resultado.valor += "\n";
            return resultado;
        }


        public ResultadoString ListarProyectosPorFechaDeComienzo(DateTime pFecha)
        {
            ResultadoString resultado;
            resultado.exito = false;
            resultado.valor = "";

            int cont = 0; 

            if (proyectos.Count > 0)
            {
                resultado.exito = true;
                for (int i = 0; i < proyectos.Count; i++)
                {
                    if (pFecha.Year == proyectos[i].ObtenerFechaDeComienzo().Year &&
                        pFecha.Month == proyectos[i].ObtenerFechaDeComienzo().Month &&
                        pFecha.Day == proyectos[i].ObtenerFechaDeComienzo().Day)
                    {
                        resultado.valor += proyectos[i].ObtenerNombreFechaDuracionCliente_AsString();
                        cont++;
                    }
                }
                if (cont == 0)
                {
                    resultado.valor = "No hay proyectos ingresados que cumplieran los requisitos de busqueda.";
                    resultado.exito = false;
                }
            }
            else
            {
                resultado.valor = "No hay proyectos ingresados en el sistema.";
                resultado.exito = false;
            }

            resultado.valor += "\n";
            return resultado;
        }


        public ResultadoString ListarClientesConCantidadDeProyectos()
        {
            ResultadoString resultado;
            resultado.exito = true;
            resultado.valor = "";

            for (int i = 0; i < clientes.Count; i++)
            {
                long rutCliente = clientes[i].ObtenerRut();
                int cantProCli = 0;

                for (int j = 0; j < proyectos.Count; j++)
                {
                    if (rutCliente == proyectos[j].ObtenerCliente().ObtenerRut())
                    {
                        cantProCli++;
                    }
                }

                resultado.valor += "Cantidad de proyectos " +  cantProCli.ToString() + " | " + clientes[i].ObtenerNomRutRelLab_AsString();
            }

            resultado.valor += "\n";
            return resultado;
        }


        public ResultadoString ClientesPorAntiguedad(DateTime pFCli)
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

        public ResultadoString AltaEmpleado(string pNom, string pCat, int pCi, DateTime pFNac, DateTime pFCon, float pSueldo, bool pAdmin, string pNomUsu, string pCon)
        {
            ResultadoString validesDeDatos;
            validesDeDatos.valor = "";
            validesDeDatos.exito = true;

            // chekeamos que un empleado con la misma ci no esté ya ingresado en el sistema
            if (ObtenerEmpleadoPorCi(pCi) != null)
            {
                validesDeDatos.exito = false;
                validesDeDatos.valor = "Error: ";
                validesDeDatos.valor += "Empleado con misma cedula ya ingresado en el sistema. ";
            }

            // checkeamos que combinacion nombre de usuario/contrasenia no existen en el sistema
            if (ObtenerUsuario(pNomUsu, pCon) != null)
            {           
                if (!validesDeDatos.exito)
                {
                    validesDeDatos.valor = "Error: \n";
                }               
                validesDeDatos.valor += "La combinacion nombre de usuario y contraseña ingresada ya existe en el sistema. ";
                validesDeDatos.exito = false;
            }

            // validamos el resto de los datos de acuerdo a las reglas de negocio de empleado
            if (validesDeDatos.exito)
            {             
                validesDeDatos = Empleado.DatosEmpleadoValidos(pNom, pCat, pFNac, pFCon, pSueldo);
            }

            // si entramos aca es que todos los campos fueron validados
            if (validesDeDatos.exito)
            {
                validesDeDatos.valor = "Empleado creado exitosamente. ";
                int nuevoIdEmpleado = Empleado.NuevoIdEmpleado();

                Empleado empleado = new Empleado(pNom, pCat, nuevoIdEmpleado, pCi, pFCon, pFNac, pSueldo,pAdmin, pNomUsu, pCon);
                empleados.Add(empleado);
            }

            return validesDeDatos;
        }



        public ResultadoString ModificacionEmpleado(int pId, string pNom, string pCat, int pCi, DateTime pFNac, DateTime pFCon, float pSueldo, bool pAdmin, string pNomUsu, string pCon)
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

        public Usuario ObtenerUsuario(string pNom, string pCon)
        {
            Usuario result = null;
            if (empleados.Count != 0 || clientes.Count != 0)
            {
                int i = 0;
                //hacemos busqueda por empleados primero
                while (result == null && i < empleados.Count)
                {
                    Usuario temp = empleados[i].ObtenerUsuario();
                    string[] NomCon = temp.ObtenerNomCont();
                    if (NomCon[0] == pNom && NomCon[1] == pCon)
                    {
                        result = temp;
                    }
                    else
                    {
                        i++;
                    }
                }
                // reseteamos el contador
                i = 0;

                // hacemos busqueda por clientes segundo, solo deberia entrar 
                // si no ha encontrado usuario en la primer busqueda
                while (result == null && i < clientes.Count)
                {
                    Usuario temp = clientes[i].ObtenerUsuario();
                    string[] NomCon = temp.ObtenerNomCont();
                    if (NomCon[0] == pNom && NomCon[1] == pCon)
                    {
                        result = temp;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return result;
        }

        public Cliente ObtenerClientePorUsuario(Usuario pU)
        {
            Cliente c = null;

            string pNom = pU.ObtenerNomCont()[0];
            string pCont = pU.ObtenerNomCont()[1];

            int i = 0;
            while (i < clientes.Count && c == null)
            {
                string nom = clientes[i].ObtenerUsuario().ObtenerNomCont()[0];
                string cont = clientes[i].ObtenerUsuario().ObtenerNomCont()[1];
                if (nom == pNom && cont == pCont)
                {
                    c = clientes[i];
                }
                else
                {
                    i++;
                }
            }

            return c;
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

        public Empleado ObtenerEmpleadoPorId(int id)
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



        public Proyecto ObtenerProyectoPorId(int id)
        {
            Proyecto resultado = null;
            if (proyectos.Count > 0)
            {
                int i = 0;
                while (i < proyectos.Count && resultado == null)
                {

                    if (proyectos[i].ObtenerId() == id)
                    {
                        resultado = proyectos[i];

                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return resultado;
        }


        public List<string> ProyectosPorCliente(Cliente c)
        {
            List<string> infoPsC = new List<string>();
            List<Proyecto> PsC = new List<Proyecto>();

            for (int i = 0; i < proyectos.Count; i++)
            {
                if (proyectos[i].ObtenerCliente().ObtenerRut() == c.ObtenerRut()  && !proyectos[i].Abierto)
                {
                    PsC.Add(proyectos[i]);
                }
            }

            PsC.Sort(new Proyecto.CompareByCosto());
            PsC.Reverse();

            for (int j = 0; j < PsC.Count; j++)
            {
                infoPsC.Add(PsC[j].ObtenerComFinCos());
            }

            return infoPsC;
        }


        public List<string> EmpleadosPorProyecto(Proyecto p)
        {
            return p.ListarEmpleados();
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

        private Admin()
        {
            //inicializacion de admin
            empleados = new List<Empleado>();
            clientes = new List<Cliente>();
            proyectos = new List<Proyecto>();
            usuarioActual = new Usuario(Usuario.Rol.SinRol,"" ,"" );
            PrecargaDeDatos();
        }
    }
}
