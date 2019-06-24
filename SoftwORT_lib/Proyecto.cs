using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwORT_lib
{
    public abstract class Proyecto
    {
        private static int ultimoIdProyecto = 0;
        private string nombre;
        private DateTime fechaDeComienzo;
        private DateTime fechaDeFin;
        private Cliente cliente;
        private int duracionEstimada; // dias laborables totales
        private List<Empleado> empleados;
        private bool abierto;
        private float montoFinal;
        private float costoAlCliente;
        private int idProyecto;


        public class CompareByCosto : IComparer<Proyecto>
        {
            int IComparer<Proyecto>.Compare(Proyecto pA, Proyecto pB)
            {
                return pA.CostoAlCliente.CompareTo(pB.CostoAlCliente);
            }
        }


        public class CompareByFechaComienzo : IComparer<Proyecto>
        {
            int IComparer<Proyecto>.Compare(Proyecto pA, Proyecto pB)
            {
                return pA.ObtenerFechaDeComienzo().CompareTo(pB.ObtenerFechaDeComienzo());
            }
        }

        public bool Abierto
        {
            get { return abierto; }
            set { abierto = value; }
        }

        public float MontoFinal
        {
            get { return montoFinal; }
            set { montoFinal = value; }
        }

        public float CostoAlCliente
        {
            get { return costoAlCliente; }
            set { costoAlCliente = value; }
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return empleados;
        }

        public int ObtenerId()
        {
            return idProyecto;
        }

        public Cliente ObtenerCliente()
        {
            return cliente;
        }

        public static int NuevoIdProyecto()
        {
            ultimoIdProyecto++;
            return ultimoIdProyecto;
        }


        public virtual void CerrarProyecto( DateTime? fCierre = null)
        {
            if (fCierre == null)
            {
                fCierre = DateTime.Now;
            }

            fechaDeFin = fCierre.Value;
            abierto = false;

            // here starts child class implementations
        }


        public List<string> ListarEmpleados()
        {
            List<string> result = new List<string>();

            for (int i = 0; i < empleados.Count; i++)
            {
                result.Add(empleados[i].ObtenerInfo());
            }

            return result;
        } 

        public string ObtenerComFinCos()
        {
            string result = "";
            string fechaC = "Fecha de comienzo: " + fechaDeComienzo.Day.ToString() + "-" + fechaDeComienzo.Month.ToString() + "-" + fechaDeComienzo.Year.ToString();
            string fechaF = "Fecha de fin: " + fechaDeFin.Day.ToString() + "-" + fechaDeFin.Month.ToString() + "-" + fechaDeFin.Year.ToString();
            string costo = "Costo final: " + CostoAlCliente.ToString();
            string ID = "Id: " + idProyecto.ToString();

            result = fechaC + " | " + fechaF + " | " + costo + " | " + ID;

            return result;
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


        public DateTime ObtenerFechaDeFin()
        {
            return fechaDeFin;
        }

        public DateTime HacerLaborable(DateTime pA)
        {
            if (pA.DayOfWeek == DayOfWeek.Saturday)
            {
                pA = pA.AddDays(2);
            }

            if (pA.DayOfWeek == DayOfWeek.Sunday)
            {
                pA = pA.AddDays(1);
            }
            return pA;
        }

        public int ContarDias(DateTime start, DateTime end)
        {
            int counter = 0;

            foreach (DateTime day in CadaDia(start, end))
            {
                if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                {
                    counter++;
                }
            }
            return counter;
        }

        private IEnumerable<DateTime> CadaDia(DateTime start, DateTime end)
        {
            for (var day = start.Date; day.Date <= end.Date; day = day.AddDays(1))
                yield return day;
        }


        protected Proyecto()
        {
            nombre = "";
            fechaDeComienzo = new DateTime();
            cliente = new Cliente();
            duracionEstimada = 0;
            empleados = new List<Empleado>();
            abierto = true;
            montoFinal = -1;
            idProyecto = -1;
        }
        
        protected Proyecto( int pId,
                            string pNom, 
                            DateTime pFechCom, 
                            Cliente pCliente, 
                            int pDur, 
                            List<Empleado> pEmpleados)
        {
            idProyecto = pId;
            nombre = pNom;
            fechaDeComienzo = pFechCom;
            cliente = pCliente;
            duracionEstimada = pDur;
            empleados = pEmpleados;
            abierto = true;
            montoFinal = -1;
        }     
    }
}
