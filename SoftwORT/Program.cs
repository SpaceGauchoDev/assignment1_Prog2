using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwORT_lib;
using System.Globalization;

namespace SoftwORT
{
    class Program
    {
        //variable de control para la ejecucion continuada del programa
        static bool correrMenu;
        //variable que guarda la instancia de nuestra clase administradora
        static Admin admin;

        static void Main(string[] args)
        {
            //mientras que correrMenu sea true, el menu principal sera mostrado cuando 
            //todos los otros metodos hallan llegado a su fin
            correrMenu = true;
            admin = new Admin();

            while (correrMenu)
            {
                Menu();
            }
            
            Console.ReadLine();
        }

        static void Menu()
        {
            // selector de funcionalidades
            // el usuario debe elegir una de las funcionalidades listadas para salir del 
            // menu principal
            Console.Clear();
            MostrarMenuPrincipal();
                      
            string msg = "Seleccione función: ";
            string errMsg = "Numero de función incorrecta, intente nuevamente.";
            string succMsg = "Seleccion exitosa, presione cualquier tecla para continuar.";
            Admin.ResultadoInt seleccionDeFuncion = ObtenerIntDentroDeRango(msg, errMsg, succMsg, "", false, 1, 9);
            

            switch (seleccionDeFuncion.valor)
            {
                case 1:
                    AltaModificacionEmpleado(true);
                    break;
                case 2:
                    AltaModificacionEmpleado(false);
                    break;
                case 3:
                    ListarEmpleados();
                    break;
                case 4:
                    ListarClientesPorAntiguedad();
                    break;
                case 5:
                    ListarClientesPorAntiguedad();
                    break;
                case 6:
                    ListarClientesPorAntiguedad();
                    break;
                case 7:
                    AsignarValorCargoExtra(); 
                    break;
                case 8:
                    ListarClientesPorAntiguedad();
                    break;
                case 9:
                    Salir();
                    break;
                default:
                    Console.WriteLine("Case incorrecto en Program.cs/Menu");
                    break;
            }
        }


        static void AsignarValorCargoExtra()
        {
            Console.Clear();
            Console.WriteLine("Asignar valor 'Cargo Extra'");
            string msg = "Ingrese una numero mayor que cero, s para salir: ";
            string errMsg = "Valor incorrecto, debe ingresar un numero mayor que cero.";
            string succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoFloat cE = ObtenerFloatDentroDeRango(msg, errMsg, succMsg, "s", true, 0.1f, float.MaxValue);

            Admin.ResultadoString modificacion = admin.NuevoCargoExtra(cE.valor);
            Console.WriteLine(modificacion.valor);

            Console.WriteLine("Presione cualquier tecla para volver al menu principal");
            Console.ReadLine();
        }






        static void ListarClientesPorAntiguedad()
        {
            Console.Clear();
            Console.WriteLine("Listado de clientes por antiguedad");
            int maximoAnioPosible = DateTime.Now.Year;
            int minimoAnioPosible = 1900;
            string msg = "Ingrese una fecha, formato: dd-mm-aaaa, tal que año esta entre "+ minimoAnioPosible.ToString() +" y " + maximoAnioPosible.ToString() + ", s para salir: ";
            string errMsg = "Valor incorrecto, el formato debe ser: 'dia-mes-año' (ej: 15-2-1990)";
            string succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoFecha fCli = ObtenerFechaEntreRangoDeAnios(msg, errMsg, succMsg, "s", true, minimoAnioPosible, maximoAnioPosible);

            Admin.ResultadoString lista = admin.ClientesPorAntiguuedad(fCli.valor);
            Console.WriteLine(lista.valor);

            Console.WriteLine("Presione cualquier tecla para volver al menu principal");
            Console.ReadLine();
        }



        static void ListarEmpleados()
        {
            string entradaUsuario;
            Console.Clear();
            Console.WriteLine("Listado de empleados por categoria: ");
            Console.WriteLine("Categorias: ");
            Console.WriteLine("Junior");
            Console.WriteLine("Semi-Senior");
            Console.WriteLine("Senior");
            Console.WriteLine("Tech Lead");
            Console.Write("Ingrese categoria (vacio o categoría inválida listará todos los empleados): ");
            entradaUsuario = Console.ReadLine();

            Console.Clear();
            Admin.ResultadoString listado = admin.ListarEmpleados(entradaUsuario);
            Console.Write(listado.valor);

            Console.WriteLine("Presione cualquier tecla para volver al menu principal");
            Console.ReadLine();
        }







        static void AltaModificacionEmpleado(bool pAlta)
        {
            string modo;
            if (pAlta)
            {
                modo = "alta";
            }
            else
            {
                modo = "modificación";
            }

            Console.Clear();
            Console.WriteLine(modo + "de empleado: ");    
            string msg = "Ingrese un nombre, s para salir: ";
            string errMsg = "Valor incorrecto, no puede ser vacío";
            string succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoString nom = ObtenerStringNoVacio(msg, errMsg, succMsg, "s", true);

            // usuario quiere salir a la mitad de ingresar datos
            if (!nom.exito)
            {
                Console.WriteLine("Salida de "+ modo +" de empleado detectada, presione cualquier tecla para volver al menu principal.");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine(modo + "de empleado: ");
            Console.WriteLine("Categorias: ");
            Console.WriteLine("1 - Junior");
            Console.WriteLine("2 - Semi-Senior");
            Console.WriteLine("3 - Senior");
            Console.WriteLine("4 - Tech - Lead");

            msg = "Seleccione categoria entre 1 y 4, s para salir: ";
            errMsg = "Valor incorrecto, debe ser un numero entero entre 1 y 4 inclusive";
            succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoInt cat = ObtenerIntDentroDeRango(msg, errMsg, succMsg, "s" , true, 1, 4);

            // usuario quiere salir a la mitad de ingresar datos
            if (!cat.exito)
            {
                Console.WriteLine("Salida de " + modo + " de empleado detectada, presione cualquier tecla para volver al menu principal.");
                Console.ReadLine();
                return;
            }

            string catString = Empleado.CodigoWebACategoria(cat.valor);

            Console.Clear();
            Console.WriteLine(modo + "de empleado: ");
            msg = "Ingrese una cedula, s para salir: ";
            errMsg = "Valor incorrecto, debe ser un numero entero entre 1 y 99999999 inclusive";
            succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoInt ci = ObtenerIntDentroDeRango(msg, errMsg, succMsg, "s", true, 1, 99999999);


            // usuario quiere salir a la mitad de ingresar datos
            if (!ci.exito)
            {
                Console.WriteLine("Salida de " + modo + " de empleado detectada, presione cualquier tecla para volver al menu principal.");
                Console.ReadLine();
                return;
            }


            Console.Clear();
            Console.WriteLine(modo + "de empleado: ");
            string minimoAnioPosible = (DateTime.Now.Year - Empleado.edadMinima).ToString();
            msg = "Ingrese una fecha de nacimiento, formato: dd-mm-aaaa, tal que año esta entre 1900 y "+ minimoAnioPosible +", s para salir: ";
            errMsg = "Valor incorrecto, el formato debe ser: 'dia-mes-año' (ej: 15-2-1990)";
            succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoFecha fNac = ObtenerFechaEntreRangoDeAnios(msg, errMsg, succMsg, "s", true, 1900, DateTime.Now.Year - Empleado.edadMinima);

            // usuario quiere salir a la mitad de ingresar datos
            if (!fNac.exito)
            {
                Console.WriteLine("Salida de " + modo + " de empleado detectada, presione cualquier tecla para volver al menu principal.");
                Console.ReadLine();
                return;
            }


            Console.Clear();
            Console.WriteLine(modo + "de empleado: ");
            string maximoAnioPosible = DateTime.Now.Year.ToString();
            msg = "Ingrese una fecha de contratacion, formato: dd-mm-aaaa, tal que año esta entre 1900 y " + maximoAnioPosible + ", s para salir: ";
            errMsg = "Valor incorrecto, el formato debe ser: 'dia-mes-año' (ej: 17-7-2015)";
            succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoFecha fCon = ObtenerFechaEntreRangoDeAnios(msg, errMsg, succMsg, "s", true, 1900, DateTime.Now.Year);

            // usuario quiere salir a la mitad de ingresar datos
            if (!fCon.exito)
            {
                Console.WriteLine("Salida de " + modo + " de empleado detectada, presione cualquier tecla para volver al menu principal.");
                Console.ReadLine();
                return;
            }


            Console.Clear();
            Console.WriteLine(modo + "de empleado: ");
            msg = "Ingrese un sueldo por hora, s para salir: ";
            errMsg = "Valor incorrecto, debe ser un numero entre 1 y 10000 inclusive";
            succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoFloat sueldo = ObtenerFloatDentroDeRango(msg, errMsg, succMsg, "s", true, 1.0f, 10000);

            // usuario quiere salir a la mitad de ingresar datos
            if (!sueldo.exito)
            {
                Console.WriteLine("Salida de " + modo + " de empleado detectada, presione cualquier tecla para volver al menu principal.");
                Console.ReadLine();
                return;
            }

            // si llegamos aca todos los datos han sido ingresados y considerados no vacios y validos, pendiente aprobacion de reglas de negocios

            Admin.ResultadoString intento;
            intento.valor = "";
            intento.exito = false;

            if (pAlta)
            {
                intento = admin.AltaEmpleado(nom.valor, catString, ci.valor, fNac.valor, fCon.valor, sueldo.valor);
            }
            else
            {
                Admin.ResultadoInt idEmp;
                idEmp.valor = -1;
                idEmp.exito = false;
                idEmp = admin.ObtenerIdEmpleadoPorCi(ci.valor);       
                intento = admin.ModificacionEmpleado(idEmp.valor, nom.valor, catString, ci.valor, fNac.valor, fCon.valor, sueldo.valor);
            }

            
            if (!intento.exito)
            {
                Console.Clear();
                Console.Write(intento.valor);
                Console.WriteLine("Intente nuevamente.");            
            }
            else
            {
                Console.Clear();
                Console.Write(intento.valor);
                Console.WriteLine("Presione cualquier tecla para continuar.");
            }
            Console.ReadLine();
        }

        /*
        static void Funcion2()
        {
            Console.Clear();
            Console.WriteLine("Funcion 2 seleccionada.");
            string msg = "Ingresar nombre (no puede estar vacio, s para salir): ";
            string errMsg = "Valor incorrecto.";
            string succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoString test = ObtenerStringNoVacio(msg, errMsg, succMsg, "s", true);

        }

        static void Funcion3()
        {
            Console.Clear();
            Console.WriteLine("Funcion 3 seleccionada.");
            string msg = "Ingresar nombre (hasta 8 caracteres de largo, s para salir): ";
            string errMsg = "Valor incorrecto.";
            string succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            Admin.ResultadoString test = ObtenerStringDeLenghtDentroDeUnRango(msg, errMsg, succMsg, "s", true, 1, 8);

            Console.ReadLine();
        }


        static void Funcion4()
        {
            Console.Clear();
            Console.WriteLine("Funcion 4 seleccionada.");

            Console.ReadLine();
        }
        */

        static void Salir()
        {
            Console.Clear();
            Console.WriteLine("Comando de salida detectado, presione cualquier tecla para salir.");
            correrMenu = false;
        }



        static void MostrarMenuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("===============");
            Console.WriteLine("1 - Alta de empleado");
            Console.WriteLine("2 - Modificacion de empleado");
            Console.WriteLine("3 - Listar empleados");
            Console.WriteLine("4 - Listar clientes por antiguedad");
            Console.WriteLine("5 - Listar clientes por cantidad de proyectos UNDER CONSTRUCTION");
            Console.WriteLine("6 - Listar proyectos UNDER CONSTRUCTION");
            Console.WriteLine("7 - Asignar valor 'cargo extra'");
            Console.WriteLine("8 - Listar clientes por antiguedad UNDER CONSTRUCTION");
            Console.WriteLine("9 - Salir");
        }


        static Admin.ResultadoInt ObtenerIntDentroDeRango(string solicitudAlUsuario, string mensajeDeError, string mensajeDeExito, string comandoDeEscape, bool escapable, int min, int max)
        {
            Admin.ResultadoInt resultado;
            string entradaDeUsuario = "";

            // si el usuario no ingresa comando de escape, lo seteamos a algo para evitar que se dispare con ingresos vacios                    
            if (comandoDeEscape == "")
            {
                comandoDeEscape = "s";
            }

            Console.WriteLine("");
            Console.Write(solicitudAlUsuario);
            entradaDeUsuario = Console.ReadLine();

            //usuario quiere salir
            if((entradaDeUsuario == comandoDeEscape) && escapable)
            {
                resultado.exito = false;
                resultado.valor = 0;
                return resultado;
            }

            int entradaParseada = 0;
            int.TryParse(entradaDeUsuario, out entradaParseada);
    
            while ((entradaParseada < min || entradaParseada > max) && entradaDeUsuario != comandoDeEscape)
            {
                Console.WriteLine("");
                Console.WriteLine(mensajeDeError);
                Console.Write(solicitudAlUsuario);
                entradaDeUsuario = Console.ReadLine();
                int.TryParse(entradaDeUsuario, out entradaParseada);
            }

            if (entradaDeUsuario == comandoDeEscape && escapable)
            {
                resultado.valor = 0;
                resultado.exito = false;
            }
            else
            {
                Console.WriteLine(mensajeDeExito);
                resultado.valor = entradaParseada;
                resultado.exito = true;
                Console.ReadLine();
            }
            return resultado;
        }


        static Admin.ResultadoFloat ObtenerFloatDentroDeRango(string solicitudAlUsuario, string mensajeDeError, string mensajeDeExito, string comandoDeEscape, bool escapable, float min, float max)
        {
            Admin.ResultadoFloat resultado;
            string entradaDeUsuario = "";

            // si el usuario no ingresa comando de escape, lo seteamos a algo para evitar que se dispare con ingresos vacios                    
            if (comandoDeEscape == "")
            {
                comandoDeEscape = "s";
            }

            Console.WriteLine("");
            Console.Write(solicitudAlUsuario);
            entradaDeUsuario = Console.ReadLine();

            //usuario quiere salir
            if ((entradaDeUsuario == comandoDeEscape) && escapable)
            {
                resultado.exito = false;
                resultado.valor = 0;
                return resultado;
            }

            float entradaParseada = 0;
            float.TryParse(entradaDeUsuario, out entradaParseada);

            while ((entradaParseada < min || entradaParseada > max) && entradaDeUsuario != comandoDeEscape)
            {
                Console.WriteLine("");
                Console.WriteLine(mensajeDeError);
                Console.Write(solicitudAlUsuario);
                entradaDeUsuario = Console.ReadLine();
                float.TryParse(entradaDeUsuario, out entradaParseada);
            }

            if (entradaDeUsuario == comandoDeEscape && escapable)
            {
                resultado.valor = 0.0f;
                resultado.exito = false;
            }
            else
            {
                Console.WriteLine(mensajeDeExito);
                resultado.valor = (float)Math.Round(entradaParseada * 100f) / 100f;// redondeamos el valor para 2 decimales
                resultado.exito = true;
                Console.ReadLine();
            }
            return resultado;
        }



        static Admin.ResultadoString ObtenerStringNoVacio(string solicitudAlUsuario, string mensajeDeError, string mensajeDeExito, string comandoDeEscape, bool escapable)
        {
            Admin.ResultadoString resultado;
            string entradaDeUsuario = "";

            // si el usuario no ingresa comando de escape, lo seteamos a algo para evitar que se dispare con ingresos vacios
            if (comandoDeEscape == "")
            {
                comandoDeEscape = "s";
            }

            Console.WriteLine("");
            Console.Write(solicitudAlUsuario);
            entradaDeUsuario = Console.ReadLine();

            //usuario quiere salir
            if (entradaDeUsuario == comandoDeEscape && escapable)
            {
                resultado.valor = "";
                resultado.exito = false;
                return resultado;
            }

            while ((entradaDeUsuario == "") && (entradaDeUsuario != comandoDeEscape))
            {
                Console.WriteLine("");
                Console.WriteLine(mensajeDeError);
                Console.Write(solicitudAlUsuario);
                entradaDeUsuario = Console.ReadLine();
            }    

            if (entradaDeUsuario == comandoDeEscape && escapable)
            {
                resultado.valor = "";
                resultado.exito = false;
            }
            else
            {
                Console.WriteLine(mensajeDeExito);
                resultado.valor = entradaDeUsuario;
                resultado.exito = true;
                Console.ReadLine();
            }

            return resultado;
        }



        static Admin.ResultadoString ObtenerStringDeLenghtDentroDeUnRango(string solicitudAlUsuario, string mensajeDeError, string mensajeDeExito, string comandoDeEscape, bool escapable, int min, int max)
        {
            Admin.ResultadoString resultado;
            string entradaDeUsuario = "";

            // si el usuario no ingresa comando de escape, lo seteamos a algo para evitar que se dispare con ingresos vacios
            if (comandoDeEscape == "")
            {
                comandoDeEscape = "s";
            }

            Console.WriteLine("");
            Console.Write(solicitudAlUsuario);
            entradaDeUsuario = Console.ReadLine();

            //usuario quiere salir
            if (entradaDeUsuario == comandoDeEscape && escapable)
            {
                resultado.valor = "";
                resultado.exito = false;
                return resultado;
            }

            while ((entradaDeUsuario.Length < min || entradaDeUsuario.Length > max) && (entradaDeUsuario != comandoDeEscape))
            {
                Console.WriteLine("");
                Console.WriteLine(mensajeDeError);
                Console.Write(solicitudAlUsuario);
                entradaDeUsuario = Console.ReadLine();
            }

            if (entradaDeUsuario == comandoDeEscape && escapable)
            {
                resultado.valor = "";
                resultado.exito = false;
            }
            else
            {
                Console.WriteLine(mensajeDeExito);
                resultado.valor = entradaDeUsuario;
                resultado.exito = true;
                Console.ReadLine();
            }

            return resultado;
        }



        static Admin.ResultadoFecha ObtenerFechaEntreRangoDeAnios(string solicitudAlUsuario, string mensajeDeError, string mensajeDeExito, string comandoDeEscape, bool escapable, int min, int max)
        {
         
            Admin.ResultadoFecha resultado;
            resultado.exito = false;
            resultado.valor = new DateTime();
            
            string entradaDeUsuario = "";

            // si el usuario no ingresa comando de escape, lo seteamos a algo para evitar que se dispare con ingresos vacios
            if (comandoDeEscape == "")
            {
                comandoDeEscape = "s";
            }

            Console.WriteLine("");
            Console.WriteLine(solicitudAlUsuario);
            entradaDeUsuario = Console.ReadLine();

            //usuario quiere salir
            if (entradaDeUsuario == comandoDeEscape && escapable)
            {
                resultado.valor = new DateTime();
                resultado.exito = false;
                return resultado;
            }

            resultado = StringAFecha(entradaDeUsuario);

            while ( (resultado.valor.Year > max || resultado.valor.Year < min) && (resultado.exito) && (entradaDeUsuario != comandoDeEscape))
            {
                Console.WriteLine("");
                Console.WriteLine(mensajeDeError);
                Console.Write(solicitudAlUsuario);
                entradaDeUsuario = Console.ReadLine();
                resultado = StringAFecha(entradaDeUsuario);
            }

            if (entradaDeUsuario == comandoDeEscape && escapable)
            {
                resultado.valor = new DateTime();
                resultado.exito = false;
            }
            else
            {
                Console.WriteLine(mensajeDeExito);
                Console.ReadLine();
            }
            
            return resultado;        
        }

        //interpreta strings de formato "DD-MM-YYYY" o "D-M-YYYY"
        //a formato DateTime
        static Admin.ResultadoFecha StringAFecha(string pEntrada)
        {
            Admin.ResultadoFecha result;
            result.exito = false;
            result.valor = new DateTime();
            string formato = "d-M-yyyy";
            CultureInfo proveedor = new CultureInfo("es-ES", false);
            try
            {
                result.valor = DateTime.ParseExact(pEntrada, formato, proveedor);
                result.exito = true;
            }
            catch (FormatException)
            {
                result.exito = false;
            }

            return result;
        } 
    }
}
