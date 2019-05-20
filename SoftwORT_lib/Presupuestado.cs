using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwORT_lib
{
    public class Presupuestado : Proyecto
    {
        private float montoEstimado;
        private DateTime fechaEstimadaDeFin;
        
        public Presupuestado() : base()
        {
            montoEstimado = 0;
            fechaEstimadaDeFin = new DateTime();
        }      

        public Presupuestado(   float pMontoE, 
                                string pNom,
                                DateTime pFechCom,
                                Cliente pCliente,
                                int pDur,
                                List<Empleado> pEmpleados) : base(  pNom,
                                                                    pFechCom,
                                                                    pCliente,
                                                                    pDur,
                                                                    pEmpleados)
        {
            montoEstimado = pMontoE;
            // calculamos la fecha estimada de fin basado en la fecha de comienzo
            // y la duracion en dias, habria que tener en cuenta los dias laborables 
            // y no laborables
            fechaEstimadaDeFin = pFechCom.AddDays(pDur);
        } 
    }
}
