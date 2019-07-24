using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PorHora : Proyecto
    {

        #region Atributos

        private int duracion;

        private static decimal cargoExtra;

        private List<Ausencia> ausencias = new List<Ausencia>() { };

        #endregion


        #region Propierties

        public int Duracion
        {
            get { return duracion; }
        }

        public static decimal CargoExtra
        {
            get { return cargoExtra; }
            set { cargoExtra = value; }
        }

        public List<Ausencia> Ausencias
        {
            get { return ausencias; }
        }

        #endregion



        public int CalcularAusencias(Empleado empleado)
        {
            int ausenciasEmpleado = 0;
            for (int i = 0; i < ausencias.Count; i++)
            {
                if (empleado == ausencias[i].Empleado)
                {
                    ausenciasEmpleado = ausenciasEmpleado + ausencias[i].HorasAusencia;
                }
            }
            return ausenciasEmpleado;
        }

        public void CalcularCosto()
        {
            decimal costoFinal = 0;
            foreach (Empleado e in Empleados)
            {
                costoFinal = costoFinal + (((duracion / 5) * 40 - CalcularAusencias(e)) * e.Sueldo);
            }
            this.CostoFinal = costoFinal;
        }


        public PorHora(DateTime fechaComienzo, string nombre, int duracionEstimada, List<Empleado> empleados, bool finalizado)
        {
            this.FechaComienzo = fechaComienzo;
            this.Nombre = nombre;
            this.DuracionEstimada = duracionEstimada;
            this.Empleados = empleados;
            this.Finalizado = finalizado;
        }

        public override string ToString()
        {
            string mensaje = "";
            int ausenciasTotales = 0;
            String txtFinalizado = "No finalizado";
            if (Finalizado) txtFinalizado = "Finalizado";
            foreach (Empleado e in Empleados)
            {
                ausenciasTotales = ausenciasTotales + CalcularAusencias(e);
            }
            mensaje += "Fecha Comienzo: " + FechaComienzo.ToShortDateString() + ", Nombre: " + Nombre + ", Duracion Estimada: " + DuracionEstimada + " días, Empleados: " + Empleados.Count + ", Finalizado: " + txtFinalizado + ", Duracion: " + duracion + " días, Cargo Extra: $" + cargoExtra + ", Ausencias: " + ausenciasTotales + ", Tipo: Por hora.";

            return mensaje;
        }

    }

}
