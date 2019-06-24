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

        public Presupuestado(   int pId,
                                string pNom,
                                DateTime pFechCom,
                                Cliente pCliente,
                                int pDur,
                                List<Empleado> pEmpleados) : base(  pId,
                                                                    pNom,
                                                                    pFechCom,
                                                                    pCliente,
                                                                    pDur,
                                                                    pEmpleados) {

            pFechCom = HacerLaborable(pFechCom);
                    
            // calculamos la fecha estimada de fin basado en la fecha de comienzo
            // y la duracion en dias, habria que tener en cuenta los dias laborables 
            // y no laborables
            fechaEstimadaDeFin = pFechCom.AddDays(pDur);
            fechaEstimadaDeFin = HacerLaborable(fechaEstimadaDeFin);
            CalcularMontoEstimado();          
        }


        public float CalcularMontoEstimado()
        {
            float me = 0f;
            List<Empleado> empleadosEnEsteProyecto = ObtenerEmpleados();
            int diasEstimados = ContarDias(ObtenerFechaDeComienzo(), fechaEstimadaDeFin);

            for (int i = 0; i < empleadosEnEsteProyecto.Count; i++)
            {
                me += empleadosEnEsteProyecto[i].ObtenerSueldo() * 8 * diasEstimados;
            }

            montoEstimado = me;
            return me;
        }


        public override void CerrarProyecto(DateTime? fCierre = default(DateTime?))
        {
            base.CerrarProyecto(fCierre);

            // System.Diagnostics.Debug.WriteLine("monto estimado: " + montoEstimado.ToString());

            if (fechaEstimadaDeFin.Date <= fCierre.Value.Date)
            {
                MontoFinal = montoEstimado;
            }
            else
            {
                int diasDeRetraso = ContarDias(fechaEstimadaDeFin, fCierre.Value);

                if (diasDeRetraso >= 1 && diasDeRetraso < 15)
                {
                    MontoFinal = montoEstimado * 0.95f;
                }

                if (diasDeRetraso >= 15)
                {
                    MontoFinal = montoEstimado * 0.90f;
                }
            }

            if (ObtenerCliente().MasDeXAnios(fCierre))
            {
                CostoAlCliente = MontoFinal * 0.96f;
            }

            // System.Diagnostics.Debug.WriteLine("costo al cierre: " + CostoAlCliente.ToString());
        }

    }
}
