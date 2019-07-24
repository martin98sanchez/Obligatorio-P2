using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ObligatorioP2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            /* EMPLEfADOS */
            routes.MapRoute(
                name: "ListarProyectosPforEmpleado",
                url: "empleado/proyectos",
                defaults: new { controller = "Proyectos", action = "ListarProyectosPorEmpleado", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ListarAusencias",
                url: "empleado/ausencias",
                defaults: new { controller = "Proyectos", action = "ListarAusencias", id = UrlParameter.Optional }
            );





            /* ADMINISTRADORES */

            routes.MapRoute(
                name: "ListarEmpleados",
                url: "admin/empleados/lista",
                defaults: new { controller = "Empleados", action = "ListarEmpleados", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AltaEmpleado",
                url: "admin/empleados/crear",
                defaults: new { controller = "Empleados", action = "AltaEmpleado", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BajaEmpleado",
                url: "admin/empleados/eliminar",
                defaults: new { controller = "Empleados", action = "BajaEmpleado", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ModificarEmpleado",
                url: "admin/empleados/modificar",
                defaults: new { controller = "Empleados", action = "ModificarEmpleado", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ListarProyectoAdmin",
                url: "admin/proyectos/lista",
                defaults: new { controller = "Proyectos", action = "ListarProyectosAdmin", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RegistrarProyecto",
                url: "admin/proyectos/crear",
                defaults: new { controller = "", action = "RegistrarProyecto", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AgregarAusencia",
                url: "admin/ausencias/registrar",
                defaults: new { controller = "Proyectos", action = "AgregarAusencia", id = UrlParameter.Optional }
            );





            /* CLIENTES */
            routes.MapRoute(
                name: "ListarProyectosPorEmpresa",
                url: "cliente/proyectos",
                defaults: new { controller = "Proyectos", action = "ListarProyectosPorEmpresa", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ListarEmpleadosPorProyectos",
                url: "cliente/empleados",
                defaults: new { controller = "Empleados", action = "ListarEmpleadosPorProyectos", id = UrlParameter.Optional }
            );



            /* LOGIN */
            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Dashboard",
                url: "dashboard",
                defaults: new { controller = "Admin", action = "Dashboard", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Logout",
                url: "logout",
                defaults: new { controller = "Admin", action = "Logout", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
