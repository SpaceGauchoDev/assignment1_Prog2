using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwORT_lib
{
    public class Usuario
    {
        public enum Rol {SinRol, Empleado, Cliente, Admin }

        private Rol rol; //sinRol, empleado, cliente, admin
        private string nombreDeUsuario;
        private string contrasenia;


        public string[] ObtenerNomCont()
        {
            string[] result = new string[2];
            result[0] = nombreDeUsuario;
            result[1] = contrasenia;
            return result;
        }


        public Rol ObtenerRol()
        {
            return rol;
        }

        public Usuario()
        {
            rol = Rol.SinRol;
            nombreDeUsuario = "";
            contrasenia = "";
        }

        public Usuario(Rol pRol, string pNom, string pCon)
        {
            rol = pRol;
            nombreDeUsuario = pNom;
            contrasenia = pCon;
        }

    }
}
