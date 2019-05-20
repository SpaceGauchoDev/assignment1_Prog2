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
        private string rut;
        private DateTime primeraRelacionLaboral;


        public Cliente()
        {
            nombre = "";
            rut = "";
            primeraRelacionLaboral = new DateTime();
        }

        public Cliente(string pNombre, string pRut, DateTime pPRL)
        {
            nombre = pNombre;
            rut = pRut;
            primeraRelacionLaboral = pPRL;
        }

        public DateTime ObtenerRelLab()
        {
            return primeraRelacionLaboral;
        }

        public string ObtenerNomRutRelLab_AsString()
        {
            string fecha = primeraRelacionLaboral.Day.ToString() + " - " + primeraRelacionLaboral.Month.ToString() + " - "  + primeraRelacionLaboral.Year.ToString();
            string result = "Nombre: " + nombre + " | Rut: " + rut + " | Primer relacion laboral: " + fecha + "\n";                 
            return result;
        }

        public string ObtenerRelLabRut_AsString()
        {
            string fecha = primeraRelacionLaboral.Day.ToString() + " - " + primeraRelacionLaboral.Month.ToString() + " - " + primeraRelacionLaboral.Year.ToString();
            string result = "Primer relacion laboral: " + fecha + " | Rut: " + rut +" " ;
            return result;
        }



    }
}
