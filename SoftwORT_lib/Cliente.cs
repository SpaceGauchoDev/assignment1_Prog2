using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwORT_lib
{
    public class Cliente
    {
        private string nombre;
        private DateTime primeraRelacionLaboral;
        private long rut;
        private Usuario usuario;

        public Cliente()
        {
            nombre = "";
            rut = 0;
            primeraRelacionLaboral = new DateTime();
            usuario = new Usuario();
        }

        public Cliente(string pNombre, long pRut, DateTime pPRL, string pNomUsu, string pCon)
        {
            nombre = pNombre;
            rut = pRut;
            primeraRelacionLaboral = pPRL;

            usuario = new Usuario(Usuario.Rol.Cliente, pNomUsu, pCon);
        }

        public DateTime ObtenerRelLab()
        {
            return primeraRelacionLaboral;
        }

        public long ObtenerRut()
        {
            return rut;
        }

        public string ObtenerNombre()
        {
            return nombre;
        }

        public Usuario ObtenerUsuario()
        {
            return usuario;
        }

        public string ObtenerNomRutRelLab_AsString()
        {
            string fecha = primeraRelacionLaboral.Day.ToString() + " - " + primeraRelacionLaboral.Month.ToString() + " - "  + primeraRelacionLaboral.Year.ToString();
            string result = "Nombre: " + nombre + " | Rut: " + rut.ToString() + " | Primer relacion laboral: " + fecha + "\n";                 
            return result;
        }

        public string ObtenerRelLabRut_AsString()
        {
            string fecha = primeraRelacionLaboral.Day.ToString() + " - " + primeraRelacionLaboral.Month.ToString() + " - " + primeraRelacionLaboral.Year.ToString();
            string result = "Primer relacion laboral: " + fecha + " | Rut: " + rut.ToString() +" " ;
            return result;
        }



    }
}
