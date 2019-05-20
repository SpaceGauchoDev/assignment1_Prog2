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
