using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwORT_lib
{
    public class HorasEmpleado
    {
        private int horasDeAusencia;
        private Empleado empleado;

        public int ObtenerHoras()
        {
            return horasDeAusencia;
        }

        public Empleado ObtenerEmpleado()
        {
            return empleado;
        }


        public void SumarHoras(int pHoras)
        {
            horasDeAusencia += pHoras; 
        }

        public HorasEmpleado()
        {
            horasDeAusencia = 0;
            empleado = null;
        }

        public HorasEmpleado(int pHoras, Empleado pEmp)
        {
            horasDeAusencia = pHoras;
            empleado = pEmp;
        }   
    }
}
