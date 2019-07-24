using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado
    {
        #region Atributos

        private int id;

        private string ci;

        private string nombreCompleto;

        private DateTime fechaNacimiento;

        private DateTime fechaContratacion;

        private decimal sueldo;

        private string categoria;

        private static int ultId;

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

        public int Id
        {
            get { return id; }
        }

        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public DateTime FechaContratacion
        {
            get { return fechaContratacion; }
            set { fechaContratacion = value; }
        }

        public decimal Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        #endregion


        public Empleado(string ci, string nombreCompleto, DateTime fechaNacimiento, DateTime fechaContratacion, decimal sueldo, string categoria)
        {
            this.ci = ci;
            this.nombreCompleto = nombreCompleto;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaContratacion = fechaContratacion;
            this.sueldo = sueldo;
            this.categoria = categoria;
            this.id = Empleado.ultId;
            Empleado.ultId++;
        }

        public Empleado(string ci, string nombreCompleto, DateTime fechaNacimiento, DateTime fechaContratacion, decimal sueldo, string categoria, string username, string password)
        {
            this.ci = ci;
            this.nombreCompleto = nombreCompleto;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaContratacion = fechaContratacion;
            this.sueldo = sueldo;
            this.categoria = categoria;
            this.id = Empleado.ultId;
            this.username = username;
            this.password = password;
            Empleado.ultId++;
        }

        public override string ToString()
        {
            string mensaje = "";
            mensaje += "Id: " + id + ", CI: " + ci + ", Nombre: " + nombreCompleto + ", Fecha Nacimiento: " + fechaNacimiento.ToShortDateString() + ", Fecha Contratacion: " + fechaContratacion.ToShortDateString() + ", Suelo por hora: $" + sueldo + ", Categoria: " + categoria;

            return mensaje;
        }

    }
}

