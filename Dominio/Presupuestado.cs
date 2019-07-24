using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Presupuestado : Proyecto
    {

        private decimal presupuestoEstimadoIni;


        public decimal PresupuestoEstimadoIni
        {
            get { return presupuestoEstimadoIni; }
        }



        public int Rembolso(int dias)
        {
            int rembolso = 0;
            if (dias < 15)
            {
                rembolso = 5;
            }
            else
            {
                rembolso = 10;
            }
            return rembolso;
        }

        public Presupuestado(DateTime fechaComienzo, string nombre, int duracionEstimada, List<Empleado> empleados, bool finalizado, decimal presupuestoEstimadoIni)
        {
            this.FechaComienzo = fechaComienzo;
            this.Nombre = nombre;
            this.DuracionEstimada = duracionEstimada;
            this.Empleados = empleados;
            this.Finalizado = finalizado;
            this.presupuestoEstimadoIni = presupuestoEstimadoIni;
        }

        public override string ToString()
        {
            string mensaje = "";
            String txtFinalizado = "No finalizdo";
            if (Finalizado) txtFinalizado = "Finalizado";
            mensaje += "Fecha Comienzo: " + FechaComienzo.ToShortDateString() + ", Nombre: " + Nombre + ", Duracion Estimada: " + DuracionEstimada + " días, Empleados: " + Empleados.Count + ", Finalizado: " + txtFinalizado + ", Presupuesto Estimado Inicial: $" + presupuestoEstimadoIni + ", Tipo: Presupuestado.";

            return mensaje;
        }

    }
}

