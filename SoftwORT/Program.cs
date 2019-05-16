using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwORT_lib;

namespace SoftwORT
{
    class Program
    {
        static bool correrMenu;
        static Admin admin;

        struct ResultadoInt
        {
            public int valor;
            public bool exito;

            public ResultadoInt(int p1, bool p2)
            {
                valor = p1;
                exito = p2;
            }
        }

        struct ResultadoString
        {
            public string valor;
            public bool exito;

            public ResultadoString(string p1, bool p2)
            {
                valor = p1;
                exito = p2;
            }
        }

        static void Main(string[] args)
        {
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
            Console.Clear();
            MostrarMenuPrincipal();

            /*
            Console.Write("Seleccione función: ");            
            string userInput = Console.ReadLine();
            int parsedInput;
            int.TryParse(userInput, out parsedInput);

            while (parsedInput < 1 || parsedInput > 5)
            {
                Console.WriteLine("Numero de función incorrecta, intente nuevamente.");
                Console.Write("Seleccione función: ");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out parsedInput);
            }
            */
            
            string msg = "Seleccione función: ";
            string errMsg = "Numero de función incorrecta, intente nuevamente.";
            string succMsg = "Seleccion exitosa, presione cualquier tecla para continuar.";
            ResultadoInt seleccionDeFuncion = ObtenerIntDentroDeRango(msg, errMsg, succMsg, "", false, 1, 5);
            

            switch (seleccionDeFuncion.valor)
            {
                case 1:
                    Funcion1();
                    break;
                case 2:
                    Funcion2();
                    break;
                case 3:
                    Funcion3();
                    break;
                case 4:
                    Funcion4();
                    break;
                case 5:
                    Salir();
                    break;
                default:
                    Console.WriteLine("Case incorrecto en Program.cs/Menu");
                    break;
            }
        }


        static void Funcion1()
        {
            Console.Clear();
            Console.WriteLine("Funcion 1 seleccionada.");

            string msg = "Ingrese un numero entre 10 y 15 inclusive, s para salir: ";
            string errMsg = "Valor incorrecto.";
            string succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            ResultadoInt test = ObtenerIntDentroDeRango(msg, errMsg, succMsg, "s" , true, 10, 15);

        }


        static void Funcion2()
        {
            Console.Clear();
            Console.WriteLine("Funcion 2 seleccionada.");
            string msg = "Ingresar nombre (no puede estar vacio, s para salir): ";
            string errMsg = "Valor incorrecto.";
            string succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            ResultadoString test = ObtenerStringNoVacio(msg, errMsg, succMsg, "s", true);

        }

        static void Funcion3()
        {
            Console.Clear();
            Console.WriteLine("Funcion 3 seleccionada.");
            string msg = "Ingresar nombre (hasta 8 caracteres de largo, s para salir): ";
            string errMsg = "Valor incorrecto.";
            string succMsg = "Valor recibido exitosamente, presione cualquier tecla para continuar.";
            ResultadoString test = ObtenerStringDeLenghtDentroDeUnRango(msg, errMsg, succMsg, "s", true, 1, 8);

            Console.ReadLine();
        }


        static void Funcion4()
        {
            Console.Clear();
            Console.WriteLine("Funcion 4 seleccionada.");

            Console.ReadLine();
        }


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
            Console.WriteLine("1 - función 1");
            Console.WriteLine("2 - función 2");
            Console.WriteLine("3 - función 3");
            Console.WriteLine("4 - función 4");
            Console.WriteLine("5 - Salir");
        }


        static ResultadoInt ObtenerIntDentroDeRango(string solicitudAlUsuario, string mensajeDeError, string mensajeDeExito, string comandoDeEscape, bool escapable, int min, int max)
        {
            ResultadoInt resultado;
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


        static ResultadoString ObtenerStringNoVacio(string solicitudAlUsuario, string mensajeDeError, string mensajeDeExito, string comandoDeEscape, bool escapable)
        {
            ResultadoString resultado;
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




        static ResultadoString ObtenerStringDeLenghtDentroDeUnRango(string solicitudAlUsuario, string mensajeDeError, string mensajeDeExito, string comandoDeEscape, bool escapable, int min, int max)
        {
            ResultadoString resultado;
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




    }
}
