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
        private List <HorasEmpleado> horasAusenteEmp;

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


        public void AgregarHorasAusencia(int pHoras, int pIdEmp)
        {
            for (int i = 0; i < horasAusenteEmp.Count; i++)
            {
                if (horasAusenteEmp[i].ObtenerEmpleado().ObtenerId() == pIdEmp)
                {
                    horasAusenteEmp[i].SumarHoras(pHoras);
                }
            }
        }



        public override void CerrarProyecto(DateTime? fCierre = default(DateTime?))
        {
            base.CerrarProyecto(fCierre);

            float costoTotal = 0;
            float valorAusenciasTotales = 0;

            int diasTotales = ContarDias(ObtenerFechaDeComienzo(), fCierre.Value);

            List<Empleado> empleadosEnEsteProyecto = ObtenerEmpleados();

            for (int j = 0; j < empleadosEnEsteProyecto.Count; j++)
            {
                costoTotal += empleadosEnEsteProyecto[j].ObtenerSueldo() * diasTotales * 8;
            }

            for (int k = 0; k < horasAusenteEmp.Count; k++)
            {
                valorAusenciasTotales += horasAusenteEmp[k].ObtenerHoras() * horasAusenteEmp[k].ObtenerEmpleado().ObtenerSueldo();
            }

            MontoFinal = costoTotal - valorAusenciasTotales;

            if (ObtenerCliente().MasDeXAnios(fCierre))
            {
                CostoAlCliente = MontoFinal * 0.96f;
            }
        }

        public PorHora() : base()
        {
            horasAusenteEmp = new List<HorasEmpleado>();
        }

        public PorHora( int pId,
                        string pNom,
                        DateTime pFechCom,
                        Cliente pCliente,
                        int pDur,
                        List<Empleado> pEmpleados) : base ( pId,
                                                            pNom,
                                                            pFechCom,
                                                            pCliente,
                                                            pDur,
                                                            pEmpleados)
        {

            horasAusenteEmp = new List<HorasEmpleado>();

            List<Empleado> emps = ObtenerEmpleados();

            for (int i = 0; i < emps.Count; i++)
            {
                HorasEmpleado he = new HorasEmpleado(0, emps[i]);
                horasAusenteEmp.Add(he);
            }             
        }
    }
}
