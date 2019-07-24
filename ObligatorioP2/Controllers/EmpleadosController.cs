using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace ObligatorioP2.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleado
        public ActionResult ListarEmpleados(Boolean borrar = false, String nombre = null, String msg = null)
        {

            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;

            Empresa e = Empresa.Instancia();
            if (borrar)
            {
                ViewBag.msg = "El empleado \" " + nombre + " \" no puede ser eliminado debido a que está asignado a uno o más proyectos.";
            }

            if (msg != null)
            {
                ViewBag.msg = msg;
            }
            ViewBag.lista = e.Empleados;
            return View();
        }

        [HttpPost]
        public ActionResult ListarEmpleados(String submitButton, String id)
        {
            if (submitButton == "Modificar")
            {
                return RedirectToAction("ModificarEmpleado", new { idEmpleado = id });
            }
            else if (submitButton == "Eliminar")
            {
                return RedirectToAction("BajaEmpleado", new { idEmpleado = id });
            }
            return RedirectToAction("ListarEmpleados");
        }

        public ActionResult ListarEmpleadosPorProyectos(String id)
        {
            Empresa e = Empresa.Instancia();
            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;
            ViewBag.nombreProyecto = id;
            ViewBag.lista = e.BuscarProyecto(id).Empleados;

            return View();
        }

        public ActionResult AltaEmpleado(String msg = null)
        {
            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;
            Empresa e = Empresa.Instancia();
            ViewBag.Categorias = e.Categorias;

            if (msg != null)
            {
                ViewBag.msg = msg;
            }

            return View();
        }

        [HttpPost]
        public ActionResult AltaEmpleado(String idEmpleado, String cedulaEmpleado,
            String nombreCompleto, String fechaNacimiento, String fechaContratacion, String sueldo, String categoria, String nombreUsuario)
        {
            Empresa e = Empresa.Instancia();
            Boolean dev = e.AltaEmpleado(cedulaEmpleado, nombreCompleto, Convert.ToDateTime(fechaNacimiento), Convert.ToDateTime(fechaContratacion), Convert.ToDecimal(sueldo), categoria, nombreUsuario, "pass");
            String msg;
            if (dev)
            {
                msg = "Empleado agregado con éxito";
                return RedirectToAction("ListarEmpleados", new { idEmpleado, msg });
            }
            else
            {
                msg = "No se ha podido agregar el empleado. Verifique sus datos.";
                return RedirectToAction("AltaEmpleado", new { idEmpleado, msg });
            }
        }

        public ActionResult BajaEmpleado(String idEmpleado)
        {
            Empresa e = Empresa.Instancia();
            Empleado emp = e.BuscarEmpleado(Int32.Parse(idEmpleado));
            Boolean tieneProyectos = e.ValidarAsignacionProyectos(emp);
            if (!tieneProyectos)
            {
                e.Empleados.Remove(emp);
            }
            return RedirectToAction("ListarEmpleados", new { borrar = tieneProyectos, nombre = emp.NombreCompleto });
        }

        public ActionResult ModificarEmpleado(String idEmpleado, String msg = null)
        {
            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;
            Empresa e = Empresa.Instancia();
            ViewBag.Empleado = e.BuscarEmpleado(Int32.Parse(idEmpleado));
            ViewBag.Categorias = e.Categorias;
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult ModificarEmpleado(String idEmpleado, String cedulaEmpleado, 
            String nombreCompleto, String fechaNacimiento, String fechaContratacion, String sueldo, String categoria, String nombreUsuario)
        {
            Empresa e = Empresa.Instancia();
            Empleado emp = e.BuscarEmpleado(Int32.Parse(idEmpleado));
            Boolean dev = e.ModificarEmpleado(Int32.Parse(idEmpleado), cedulaEmpleado, nombreCompleto, fechaNacimiento, fechaContratacion, sueldo, categoria);
            String msg;
            if (dev)
            {
                msg = "Empleado modificado con éxito";
            }
            else
            {
               msg = "No se ha podido modificar el empleado. Verifique sus datos.";
            }
            return RedirectToAction("ModificarEmpleado", new { idEmpleado, msg });
        }
    }
}