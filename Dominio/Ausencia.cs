using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ausencia
    {

        #region Atributos

        private Empleado empleado;

        private PorHora proyecto;

        private int horasAusencia;

        #endregion


        #region Propierties

        public Empleado Empleado
        {
            get { return empleado; }
        }

        public int HorasAusencia
        {
            get { return horasAusencia; }
        }

        public Proyecto Proyecto
        {
            get { return proyecto; }
        }

        #endregion



        public Ausencia(Empleado empleado, int horasAusencia, PorHora proyecto)
        {
            this.empleado = empleado;
            this.horasAusencia = horasAusencia;
            this.proyecto = proyecto;
        }

        public override string ToString()
        {
            string mensaje = "";
            mensaje += "Empleado: " + empleado + ", Horas de Ausencia: " + horasAusencia;

            return mensaje;
        }

    }

}
