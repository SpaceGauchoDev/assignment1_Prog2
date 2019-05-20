using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwORT_lib
{
    public class PorHora : Proyecto
    {
        private static float cargoExtra = 175.0F;
        private HorasEmpleado horasAusenteEmp;

        public static Admin.ResultadoString ActualizarCargoExtra(float pCE)
        {
            Admin.ResultadoString resultado;
            resultado.exito = false;
            resultado.valor = "";

            if (pCE > 0.0f)
            {
                resultado.exito = true;
                if (pCE != cargoExtra)
                {
                    resultado.valor = "Cargo extra a proyectos por hora actualizado de "+ cargoExtra + " a "+ pCE + " \n";
                    cargoExtra = pCE;
                }
                else
                {
                    resultado.valor = "Nuevo cargo extra a proyectos por hora es igual al anterior, ningun cambio se ha efectuado. \n";
                }
            }
            else
            {
                resultado.exito = false;
                resultado.valor = "Cargo extra a proyectos por hora no puede ser menor o igual que cero. \n";
            }

            return resultado;
        }


        public PorHora() : base()
        {
            horasAusenteEmp = new HorasEmpleado();
        }

        public PorHora( HorasEmpleado pHorasEmpleado, 
                        string pNom,
                        DateTime pFechCom,
                        Cliente pCliente,
                        int pDur,
                        List<Empleado> pEmpleados) : base ( pNom,
                                                            pFechCom,
                                                            pCliente,
                                                            pDur,
                                                            pEmpleados)
        {

            horasAusenteEmp = pHorasEmpleado;
        }
    }
}
