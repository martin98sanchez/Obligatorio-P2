using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;


namespace ObligatorioP2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Empresa
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtUsuario, string txtContrasenia)
        {
            Empresa empresa = Empresa.Instancia();
            Object dev = null;
            if (txtContrasenia != null && txtUsuario != null)
            {
                dev = empresa.Login(txtUsuario, txtContrasenia);
            }
            
            if (dev != null)
            {
                VariablesGlobales vg = new VariablesGlobales();

                if (dev.GetType().Name == "Administrador")
                {
                    Administrador adm = (Administrador)dev;
                    vg.LoggedUserId = adm.Id;
                    vg.LoggedUser_Nombre = adm.NombreCompleto;
                }
                else if (dev.GetType().Name == "Empleado")
                {
                    Empleado emp = (Empleado)dev;
                    vg.LoggedUserId = emp.Id.ToString();
                    vg.LoggedUser_Nombre = emp.NombreCompleto;
                }
                else if (dev.GetType().Name == "Cliente")
                {
                    Cliente cli = (Cliente)dev;
                    vg.LoggedUserId = cli.Rut.ToString();
                    vg.LoggedUser_Nombre = cli.Nombre;
                }
                vg.LoggedUserType = dev.GetType().Name;

                return RedirectToAction("Dashboard");

            }
            else
            {
                ViewBag.msg = "Usuario y/o contraseña incorrectos.";
                return View();
            }
        }

        public ActionResult Dashboard()
        {
            VariablesGlobales vg = new VariablesGlobales();
            ViewBag.userID = vg.LoggedUserId;
            ViewBag.userType = vg.LoggedUserType;
            ViewBag.nombre = vg.LoggedUser_Nombre;
            return View();
        }

        public ActionResult Logout()
        {
            VariablesGlobales vg = new VariablesGlobales();
             vg.LoggedUserId = "";
            vg.LoggedUserType = "";
            vg.LoggedUser_Nombre = "";

            return RedirectToAction("Login");
        }

    }
}