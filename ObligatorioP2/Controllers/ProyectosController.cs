using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace ObligatorioP2.Controllers
{
    public class ProyectosController : Controller
    {
        // GET: Proyectos
        public ActionResult ListarProyectosPorEmpleado()
        {
            VariablesGlobales vg = new VariablesGlobales();

            if (vg.LoggedUserType == "Empleado")
            {
                Empresa e = Empresa.Instancia();
                Empleado empleado = e.BuscarEmpleado(Int32.Parse(vg.LoggedUserId));
                List<Proyecto> lista = e.ListarProyectos(empleado);
                ViewBag.Lista = lista;
            }
                ViewBag.userID = vg.LoggedUserId;
                ViewBag.userType = vg.LoggedUserType;
                ViewBag.nombre = vg.LoggedUser_Nombre;
                return View();
        }

        // RAFA TIENE VISTA
        public ActionResult ListarProyectosPorEmpresa()
        {
            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;
            Empresa e = Empresa.Instancia();
            Cliente cliente = e.BuscarCliente(vg.LoggedUserId);

            foreach (Cliente cli in e.Clientes)
            {
                if (vg.LoggedUserId == cli.Rut)
                {
                    ViewBag.Lista = cli.Proyectos;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult ListarProyectosPorEmpresa(String id)
        {
           return  RedirectToAction("ListarEmpleadosPorProyectos", "Empleados", new { id });
        }

        public ActionResult RegistrarProyecto()
        {
            return View();
        }

        public ActionResult AgregarAusencia(String pNombre)
        {
            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;
            Empresa e = Empresa.Instancia();

            Proyecto p = e.BuscarProyecto(pNombre);
            ViewBag.Proyecto = p;

            return View();
        }

        [HttpPost]
        public ActionResult AgregarAusencia(int Horas, int IdEmpleado, String proyecto)
        {
            Empresa e = Empresa.Instancia();
            Boolean agregado = e.AgregarAusencia(Horas, IdEmpleado, proyecto);
            String msg;
            if (agregado)
            {
                msg = "Ausencia registrada con éxito.";
            }
            else
            {
                msg = "No se ha podido registrar la ausencia.";
            }

            return RedirectToAction("ListarProyectosAdmin", new { msg });

        }

        public ActionResult FinalizarProyecto(String pNombre)
        {
            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;

            Empresa e = Empresa.Instancia();
            Boolean finaliza = e.FinalizarProyecto(pNombre);
            String msg;
            if (finaliza)
            {
                msg = "Proyecto finalizado con éxito.";
            }else
            {
                msg = "No se ha podido finalizar el proyecto.";
            }
            return RedirectToAction("ListarProyectosAdmin", new { msg });
        }

        public ActionResult ListarAusencias()
        {
            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;

            Empresa e = Empresa.Instancia();
            Empleado empleado = e.BuscarEmpleado(Convert.ToInt32(vg.LoggedUserId));
            ViewBag.lista = e.ListarAusencias(empleado);
            return View();
        }


        public ActionResult ListarProyectosAdmin(String msg = null)
        {
            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;
            ViewBag.msg = msg;

            Empresa e = Empresa.Instancia();
            ViewBag.lista = e.Proyectos;
            return View();
        }

        [HttpPost]
        public ActionResult ListarProyectosAdmin(String submit, String nombre)
        {
            if (submit == "Finalizar")
            {
                return RedirectToAction("FinalizarProyecto", new { pNombre = nombre });
            }
            else if (submit == "Agregar Ausencia")
            {
                return RedirectToAction("AgregarAusencia", new { pNombre = nombre });
            }
            return RedirectToAction("ListarProyectosAdmin");
        }
    }
}