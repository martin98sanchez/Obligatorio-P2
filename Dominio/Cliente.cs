using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {

        #region Atributos

        private string rut;

        private string nombre;

        private DateTime fechaComienzoRelacion;

        private List<Proyecto> proyectos = new List<Proyecto>() { };

        private string username;

        private string password;

        #endregion


        #region Propierties

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Rut
        {
            get { return rut; }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public DateTime FechaComienzoRelacion
        {
            get { return fechaComienzoRelacion; }
        }

        public List<Proyecto> Proyectos
        {
            get { return proyectos; }
            set { proyectos = value; }
        }


        #endregion


        public Cliente(string rut, string nombre, DateTime fechaComienzoRelacion)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.fechaComienzoRelacion = fechaComienzoRelacion;
        }

        public Cliente(string rut, string nombre, DateTime fechaComienzoRelacion, string username, string password)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.fechaComienzoRelacion = fechaComienzoRelacion;
            this.username = username;
            this.password = password;
        }

        public override string ToString()
        {
            string mensaje = "";
            mensaje += "Rut: " + rut + ", Nombre: " + nombre + ", Fecha Comienzo de la Relacion: " + fechaComienzoRelacion.ToShortDateString() + ", Proyectos: " + proyectos.Count;

            return mensaje;
        }

        public int CalcularAntiguedad()
        {
            DateTime hoy = DateTime.Today;
            int anioRelacion = fechaComienzoRelacion.Year;
            int antiguedadCliente = Convert.ToInt32(hoy.Year - anioRelacion);
            return antiguedadCliente;
        }

    }

}
