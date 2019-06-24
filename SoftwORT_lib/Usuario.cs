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
        private bool esAdmin;


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

        public bool EsAdmin
        {
            get { return esAdmin; }
            set { esAdmin = value; }
        }

        public Usuario()
        {
            rol = Rol.SinRol;
            nombreDeUsuario = "";
            contrasenia = "";
            esAdmin = false;
        }

        public Usuario(Rol pRol, string pNom, string pCon)
        {
            rol = pRol;

            esAdmin = false;
            if (pRol == Rol.Admin)
            {
                esAdmin = true;
            }
            nombreDeUsuario = pNom;
            contrasenia = pCon;
        }

    }
}
