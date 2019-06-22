using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwORT_lib
{
    public abstract class Proyecto
    {
        private string nombre;
        private DateTime fechaDeComienzo;
        private Cliente cliente;
        private int duracionEstimada; // dias laborables totales
        private List<Empleado> empleados;

        public Cliente ObtenerCliente()
        {
            return cliente;
        }

        public string ObtenerNombreFechaDuracionCliente_AsString()
        {
            string fecha = fechaDeComienzo.Day.ToString() + "-" + fechaDeComienzo.Month.ToString() + "-" + fechaDeComienzo.Year.ToString();
            string result = "Nombre: " + nombre + " | Fecha de comienzo: " + fecha + " | Duracion estimada: " + duracionEstimada.ToString() + " días | Cliente: " + cliente.ObtenerNombre() + "\n";
            return result;
        }

        public DateTime ObtenerFechaDeComienzo()
        {
            return fechaDeComienzo;
        }
   
        protected Proyecto()
        {
            nombre = "";
            fechaDeComienzo = new DateTime();
            cliente = new Cliente();
            duracionEstimada = 0;
            empleados = new List<Empleado>();
        }
        
        protected Proyecto( string pNom, 
                            DateTime pFechCom, 
                            Cliente pCliente, 
                            int pDur, 
                            List<Empleado> pEmpleados)
        {
            nombre = pNom;
            fechaDeComienzo = pFechCom;
            cliente = pCliente;
            duracionEstimada = pDur;
            empleados = pEmpleados;
        }     
    }
}
