using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Proyecto
    {
        #region Atributos

        private DateTime fechaComienzo;

        private DateTime fechaFinalizacion;

        private string nombre;

        private int duracionEstimada;

        private List<Empleado> empleados;

        private bool finalizado;

        private decimal costoFinal;

        #endregion


        #region Propierties

        public DateTime FechaComienzo
        {
            get { return fechaComienzo; }
            set { fechaComienzo = value; }
        }

        public DateTime FechaFinalizacion
        {
            get { return fechaFinalizacion; }
            set { fechaFinalizacion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int DuracionEstimada
        {
            get { return duracionEstimada; }
            set { duracionEstimada = value; }
        }

        public List<Empleado> Empleados
        {
            get { return empleados; }
            set { empleados = value; }
        }

        public bool Finalizado
        {
            get { return finalizado; }
            set { finalizado = value; }
        }

        public decimal CostoFinal
        {
            get { return costoFinal; }
            set { costoFinal = value; }
        }

        #endregion

        public int Descuento(int antiguedad)
        {
            int descuento;
            if (antiguedad > 4)
            {
                descuento = 4;
            }
            else
            {
                descuento = 0;
            }
            return descuento;
        }

        public override string ToString()
        {
            string mensaje = "";
            String txtFinalizado = "No finalizado";
            if (finalizado) txtFinalizado = "Finalizado";
            mensaje += "Fecha Comienzo: " + FechaComienzo.ToShortDateString() + ", Nombre: " + Nombre + ", Duracion Estimada: " + DuracionEstimada + " días, Empleados: " + Empleados.Count + ", Finalizado: " + txtFinalizado;

            return mensaje;
        }


    }
}

