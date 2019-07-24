using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empresa
    {

        #region Atributos
        private static Empresa instancia;
        private List<Proyecto> proyectos = new List<Proyecto>();
        private List<Empleado> empleados = new List<Empleado>();
        private List<Cliente> clientes = new List<Cliente>();
        private List<string> categorias = new List<string>() { "Junior", "Semi-Senior", "Senior", "Tech Lead" };
        private List<Administrador> administradores = new List<Administrador>();

        #endregion


        #region Propierties


        public List<Proyecto> Proyectos
        {
            get { return proyectos; }
            set { proyectos = value; }
        }

        public List<Empleado> Empleados
        {
            get { return empleados; }
            set { empleados = value; }
        }

        public List<Cliente> Clientes
        {
            get { return clientes; }
            set { clientes = value; }
        }

        public List<string> Categorias
        {
            get { return categorias; }
        }

        public List<Administrador> Administradores
        {
            get { return administradores; }
            set { administradores = value; }
        }

        #endregion


        private Empresa(){

        }

        #region Metodos
        public static Empresa Instancia()
        {
            if (instancia == null)
            {
                instancia = new Empresa();
                Dummy d = new Dummy();
                d.Crear(instancia);
            }
            return instancia;
        }


        public List<Empleado> ListarEmpleados(string categoria)
        {
            List<Empleado> dev = new List<Empleado>() { };
            if (categoria == "Todos")
            {
                dev = empleados;
            }
            else
            {
                if (ValidarCategoria(categoria))
                {
                    if (empleados.Count != 0)
                    {
                        foreach (Empleado e in empleados)
                        {
                            if (e.Categoria == categoria)
                            {
                                dev.Add(e);
                            }
                        }
                    }

                }
            }
            return dev;
        }

        public List<Proyecto> ListarProyectos(DateTime fecha)
        {

            List<Proyecto> dev = new List<Proyecto>();
            if (ValidarFechaPasada(fecha))
            {
                if (proyectos.Count != 0)
                {
                    foreach (Proyecto p in proyectos)
                    {
                        if (p.FechaComienzo == fecha)
                        {
                            dev.Add(p);
                        }
                    }
                }
            }
            return dev;
        }

        public List<Proyecto> ListarProyectos(Empleado e)
        {
            List<Proyecto> dev = new List<Proyecto>();
            foreach (Proyecto p in proyectos)
            {
                foreach(Empleado emp in p.Empleados)
                {
                    if (emp == e)
                    {
                        dev.Add(p);
                    }
                }
            }

            dev.Sort((a, b) => a.FechaComienzo.CompareTo(b.FechaComienzo));
            // COMPROBAR EL ORDEN
            return dev;
        }

        public Object Login (String username, String password)
        {
            Object dev = null;

            foreach(Empleado e in empleados)
            {
                if ( e.Username != null && e.Username == username && e.Password == password ) {
                    dev = e;
                }
            }

            if (dev == null)
            {
                foreach (Administrador a in administradores)
                {
                    if (a.Username != null && a.Username == username && a.Password == password)
                    {
                        dev = a;
                    }
                }
            }

            if (dev == null)
            {
                foreach (Cliente c in clientes)
                {
                    if (c.Username != null && c.Username == username && c.Password == password)
                    {
                        dev = c;
                    }
                }
            }

            return dev;
        }

        public List<Cliente> ListarClientes(String antiguedadAux)
        {
            List<Cliente> dev = new List<Cliente>();
            if (antiguedadAux != "Todos")
            {
                try
                {
                    int antiguedad = Convert.ToInt32(antiguedadAux);
                    foreach (Cliente c in clientes)
                    {
                        if (c.CalcularAntiguedad() <= antiguedad)
                        {
                            dev.Add(c);
                        }
                    }
                }
                catch (Exception e)
                {
                    return dev;
                }

            }
            else
            {
                dev = clientes;
            }

            return dev;
        }

        public bool AltaEmpleado(string ci, string nombreCompleto, DateTime fechaNacimiento, DateTime fechaContratacion, decimal sueldo, string categoria, string nombreUsuario, string contrasenia)
        {

            //Realiza las validaciones y si las cumple, da de alta el Empleado.
            if (ValidacionAltaEmpleado(ci, nombreCompleto, fechaNacimiento.ToString(), fechaContratacion.ToString(), sueldo.ToString(), categoria, nombreUsuario))
            {
                empleados.Add(new Empleado(ci, nombreCompleto, fechaNacimiento, fechaContratacion, sueldo, categoria, nombreUsuario, contrasenia));
                return true;
            }
            else {
                return false;
            }
        }

        public bool ModificarEmpleado(int idEmpleado, String cedulaEmpleado,
            String nombreCompleto, String fechaNacimiento, String fechaContratacion, String sueldo, String categoria)
        {
            Empleado empleado = BuscarEmpleado(idEmpleado);
            Boolean valida = ValidacionModificarEmpleado(cedulaEmpleado, nombreCompleto, fechaNacimiento, fechaContratacion, sueldo, categoria);

            if (empleado != null && valida)
            {
                //if (empleado.Ci != cedulaEmpleado) ModificarCi(empleado, cedulaEmpleado);

                if (empleado.NombreCompleto != nombreCompleto) ModificarNombre(empleado, nombreCompleto);

                DateTime fNacimiento = Convert.ToDateTime(fechaNacimiento);
                if (empleado.FechaNacimiento != fNacimiento) ModificarFechaNacimiento(empleado, fNacimiento);

                DateTime fContratacion = Convert.ToDateTime(fechaContratacion);
                if (empleado.FechaContratacion != fContratacion) ModificarFechaContratacion(empleado, fContratacion);

                if (empleado.Sueldo != Int32.Parse(sueldo)) ModificarSueldo(empleado, decimal.Parse(sueldo));

                if (empleado.Categoria != categoria) ModificarCategoria(empleado, categoria);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarCi(Empleado empleado, string ci)
        {
            if (!ValidarExistenciaCi(ci) && (ci.Length == 8 || ci.Length == 7))
            {
                try
                {
                    empleado.Ci = ci;
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        public bool ModificarNombre(Empleado empleado, string nombre)
        {
            try
            {
                empleado.NombreCompleto = nombre;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ModificarFechaNacimiento(Empleado empleado, DateTime fechaNacimiento)
        {
            if (ValidarPersonaMayor(fechaNacimiento, 18))
            {
                try
                {
                    empleado.FechaNacimiento = fechaNacimiento;
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        public bool ModificarFechaContratacion(Empleado empleado, DateTime fechaContratacion)
        {
            if (ValidarFechaPasada(fechaContratacion))
            {
                try
                {
                    empleado.FechaContratacion = fechaContratacion;
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        public bool ModificarSueldo(Empleado empleado, decimal sueldo)
        {
            try
            {
                if (ValidarNumeroPositivo(sueldo))
                {
                    empleado.Sueldo = sueldo;
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ModificarCategoria(Empleado empleado, string categoria)
        {
            Boolean dev = false;
            if (ValidarCategoria(categoria))
            {
                try
                {
                    empleado.Categoria = categoria;
                    dev = true;
                }
                catch (Exception e)
                {
                    dev = false;
                }
            }
            return dev;
        }

        public List<Ausencia> ListarAusencias(Empleado e)
        {
            List<Ausencia> dev = new List<Ausencia>() { };

            foreach (Proyecto p in proyectos)
            {
                if (p.GetType().Name == "PorHora")
                {
                    PorHora pph = (PorHora) p;
                    foreach(Empleado emp in empleados)
                    {
                        if ( emp == e)
                        {
                            foreach(Ausencia a in pph.Ausencias)
                            {
                                if (a.Empleado == emp)
                                {
                                    dev.Add(a);
                                }
                            }
                        }
                    }
                }
            }


            return dev;
        }

        public Empleado BuscarEmpleado(int id)
        {
            foreach (Empleado e in empleados)
            {
                if (e.Id == id)
                {
                    return e;
                }
            }
            return null;
        }

        public bool ValidarCategoria(string categoria)
        {
            foreach (String cat in categorias)
            {
                if (cat == categoria)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidarFechaPasada(DateTime fecha)
        {
            DateTime hoy = DateTime.Today;
            if (fecha < hoy) return true;

            return false;
        }

        public bool ValidarPersonaMayor(DateTime fechaNacimiento, int edad)
        {
            DateTime hoy = DateTime.Today;
            DateTime diaMesNacimiento = new DateTime(hoy.Year, fechaNacimiento.Month, fechaNacimiento.Day);

            //Si es mayor de "edad" retorna true
            if (hoy.Year - fechaNacimiento.Year > edad)
            {
                return true;

                //Si tiene el valor de "edad" valida que no haya cumplido años
            }
            else if (hoy.Year - fechaNacimiento.Year > edad)
            {
                Boolean cumplioAnios = false;
                if (diaMesNacimiento > hoy)
                {
                    cumplioAnios = true;

                }
                return cumplioAnios;

                //Es menor de "edad"
            }
            else {
                return false;
            }

        }
        public Boolean ValidacionAltaEmpleado(String ci, String nombreCompleto, String fechaNacimiento, String fechaContratacion, String sueldo, String categoria, string nombreUsuario)
        {
            try
            {
                DateTime fechaNacimientoAux = Convert.ToDateTime(fechaNacimiento);
                DateTime fechaContratacionAux = Convert.ToDateTime(fechaContratacion);
                Decimal sueldoAux = Convert.ToDecimal(sueldo);

                //Realiza todas las validaciones
                if (ValidarCategoria(categoria) && !ValidarExistenciaCi(ci) && ValidarPersonaMayor(fechaNacimientoAux, 18)
                    && ValidarFechaPasada(fechaContratacionAux) && ValidarNumeroPositivo(sueldoAux) && !ValidarExistenciaNombreUsuario(nombreUsuario))
                {
                    return true;
                }
                else {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean ValidacionModificarEmpleado(String ci, String nombreCompleto, String fechaNacimiento, String fechaContratacion, String sueldo, String categoria)
        {
            try
            {
                DateTime fechaNacimientoAux = Convert.ToDateTime(fechaNacimiento);
                DateTime fechaContratacionAux = Convert.ToDateTime(fechaContratacion);
                Decimal sueldoAux = Convert.ToDecimal(sueldo);

                //Realiza todas las validaciones
                if (ValidarCategoria(categoria) && ValidarPersonaMayor(fechaNacimientoAux, 18)
                    && ValidarFechaPasada(fechaContratacionAux) && ValidarNumeroPositivo(sueldoAux))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean ValidarExistenciaCi(string ci)
        {
            foreach (Empleado e in empleados)
            {
                if (e.Ci == ci)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean ValidarExistenciaNombreUsuario(string nombreUsuario)
        {
            Boolean dev = false;

            foreach (Empleado e in empleados)
            {
                if (e.Username == nombreUsuario)
                {
                    dev = true;
                }
            }

            if (!dev)
            {
                foreach (Administrador a in administradores)
                {
                    if (a.Username == nombreUsuario)
                    {
                        dev = true;
                    }
                }
            }

            if (!dev)
            {
                foreach (Cliente c in clientes)
                {
                    if (c.Username == nombreUsuario)
                    {
                        dev = true;
                    }
                }
            }

            return dev;
        }

        public Boolean ValidarNumeroPositivo(Decimal numero)
        {
            if (numero >= 0) return true;

            return false;
        }

        public Boolean ModificarHorasExtras(Decimal horasExtras)
        {
            if (ValidarNumeroPositivo(horasExtras))
            {
                PorHora.CargoExtra = horasExtras;
                return true;
            }
            return false;
        }

        public Boolean ValidarAsignacionProyectos(Empleado e)
        {

            foreach (Proyecto p in proyectos)
            {
                foreach (Empleado emp in p.Empleados)
                {
                    if (emp == e)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //RAFA
        public Cliente BuscarCliente(string rut)
        {
            foreach (Cliente c in clientes)
            {
                if (c.Rut == rut)
                {
                    return c;
                }
            }
            return null;
        }

        //RAFA
        public Proyecto BuscarProyecto(string nombre)
        {
            foreach (Proyecto p in proyectos)
            {
                if (p.Nombre == nombre)
                {
                    return p;
                }
            }
            return null;
        }

        public bool FinalizarProyecto(String nombre)
        {
            Proyecto p = BuscarProyecto(nombre);
            Boolean dev = false;

            if (p != null)
            {
                p.Finalizado = true;
                DateTime hoy = DateTime.Today;
                DateTime fechaComienza = p.FechaComienzo;

                if (p.GetType().Name == "PorHora")
                {
                    PorHora ph = (PorHora)p;
                    ph.CalcularCosto();

                    dev = true;
                }
                else
                {
                    Presupuestado ps = (Presupuestado)p;
                    ps.CostoFinal = ps.PresupuestoEstimadoIni;
                    dev = true;
                }
            }
            return dev;
        }

        public bool AgregarAusencia(int horas, int id, String nombreProyecto)
        {
            Proyecto p = BuscarProyecto(nombreProyecto);
            Empleado e = BuscarEmpleado(id);
            Boolean dev = false;

            if (ValidarNumeroPositivo(horas) && p.GetType().Name == "PorHora")
            {
                PorHora ph = (PorHora)p;
                ph.Ausencias.Add(new Ausencia(e, horas, ph));
                dev = true;
            }
            return dev;
        }

        #endregion
    }

    

}
