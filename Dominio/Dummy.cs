using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Dummy
    {

        public void Crear(Empresa e)
        {
            //EMPLEADOS
            Empleado e1 = new Empleado("50264555", "Martín Sánchez", Convert.ToDateTime("29/08/1998"), Convert.ToDateTime("01/05/2017"), 150, "Junior", "e1", "pass");
            Empleado e2 = new Empleado("40264555", "Carlos Garro", Convert.ToDateTime("29/12/1992"), Convert.ToDateTime("01/05/2018"), 120, "Junior", "e2", "pass");
            Empleado e3 = new Empleado("40164555", "Juan Perez", Convert.ToDateTime("01/01/1987"), Convert.ToDateTime("15/05/2018"), 155, "Junior",  "e3", "pass");
            Empleado e4 = new Empleado("30264555", "Michael Rodríguez", Convert.ToDateTime("29/12/1972"), Convert.ToDateTime("19/03/2010"), 300, "Junior");
            Empleado e5 = new Empleado("50264700", "Rafael Machín", Convert.ToDateTime("10/03/1998"), Convert.ToDateTime("01/08/2016"), 200, "Semi-Senior");
            Empleado e6 = new Empleado("50264701", "Miguel Rocco", Convert.ToDateTime("10/02/1996"), Convert.ToDateTime("01/08/2016"), 200, "Semi-Senior");
            Empleado e7 = new Empleado("50264702", "Juan Gonzalez", Convert.ToDateTime("10/03/1998"), Convert.ToDateTime("01/08/2016"), 200, "Semi-Senior");
            Empleado e8 = new Empleado("50264800", "Luis Gonzalez", Convert.ToDateTime("10/03/1988"), Convert.ToDateTime("01/08/2016"), 300, "Senior");
            Empleado e9 = new Empleado("50264801", "Jose Carlos Cardozo", Convert.ToDateTime("09/03/1988"), Convert.ToDateTime("01/08/2016"), 300, "Senior");
            Empleado e10 = new Empleado("50264802", "Facundo Rocha", Convert.ToDateTime("10/03/1990"), Convert.ToDateTime("01/02/2016"), 350, "Senior");
            Empleado e11 = new Empleado("50264100", "Manuel Pucler", Convert.ToDateTime("10/03/1970"), Convert.ToDateTime("01/08/2010"), 450, "Tech Lead");
            Empleado e12 = new Empleado("50264101", "Rodrigo Lujan", Convert.ToDateTime("10/04/1970"), Convert.ToDateTime("07/08/2010"), 450, "Tech Lead");
            Empleado e13 = new Empleado("50264102", "Carlos Sánchez", Convert.ToDateTime("10/03/1970"), Convert.ToDateTime("01/06/2010"), 500, "Tech Lead");

            //CLIENTES
            Cliente c1 = new Cliente("21001930193", "Carlos Martirena", Convert.ToDateTime("01/01/2000"), "cli1", "pass");
            Cliente c2 = new Cliente("21001930194", "Carlos Rodriguez", Convert.ToDateTime("01/01/2005"));
            Cliente c3 = new Cliente("21001930192", "Juan Piriz", Convert.ToDateTime("01/08/2018"));
            Cliente c4 = new Cliente("21001930191", "Marcelo Sosa", Convert.ToDateTime("01/01/1990"));
            Cliente c5 = new Cliente("21001930195", "Maria Nieves", Convert.ToDateTime("30/10/1980"));

            //PROYECTOS
            PorHora ph1 = new PorHora(Convert.ToDateTime("01/01/2000"), "Anetra", 5, new List<Empleado>() { e1, e4, e13 }, false);
            PorHora ph2 = new PorHora(Convert.ToDateTime("01/01/2000"), "Presidencia", 2, new List<Empleado>() { e1, e2, e10 }, false);
            PorHora ph3 = new PorHora(Convert.ToDateTime("01/05/2010"), "Inmoviliaria Carlos", 1, new List<Empleado>() { e5, e6 }, false);
            PorHora ph4 = new PorHora(Convert.ToDateTime("22/12/2018"), "Presidencia", 2, new List<Empleado>() { e12, e9 }, false);
            PorHora ph5 = new PorHora(Convert.ToDateTime("10/04/2018"), "ANEP", 1, new List<Empleado>() { e5 }, false);
            PorHora ph6 = new PorHora(Convert.ToDateTime("13/06/2017"), "Casinos del Uruguay", 6, new List<Empleado>() { e10, e9, e7, e8, e3, e6 }, false);
            PorHora ph7 = new PorHora(Convert.ToDateTime("01/01/2000"), "Supermercado Sin ideas", 1, new List<Empleado>() { e4 }, false);

            Ausencia au1 = new Ausencia(e2, 10, ph1);
            Ausencia au2 = new Ausencia(e2, 2, ph1);
            Ausencia au3 = new Ausencia(e2, 40, ph2);
            ph1.Ausencias.Add(au1);
            ph1.Ausencias.Add(au2);
            ph2.Ausencias.Add(au3);

            Presupuestado p1 = new Presupuestado(Convert.ToDateTime("01/01/2000"), "Ideas 1000", 2, new List<Empleado>() { e2, e8 }, false, 500000);
            Presupuestado p2 = new Presupuestado(Convert.ToDateTime("01/01/1998"), "Ideas 999", 8, new List<Empleado>() { e7 }, false, 200000);
            Presupuestado p3 = new Presupuestado(Convert.ToDateTime("17/11/2002"), "Mercado Agrícola", 1, new List<Empleado>() { e1, e12 }, false, 4500000);

            //ADMINISTRADORES 
            Administrador a1 = new Administrador("1", "Admin 1", "adm1", "adm1111");
            Administrador a2 = new Administrador("2", "Admin 2", "adm2", "adm2222");
            Administrador a3 = new Administrador("3", "Admin 3", "admin", "pass");


            //Asignación de proyectos
            c1.Proyectos.Add(ph1);
            c2.Proyectos.Add(ph2);
            c3.Proyectos.Add(ph3);
            c4.Proyectos.Add(ph4);
            c5.Proyectos.Add(ph5);
            c1.Proyectos.Add(ph6);
            c5.Proyectos.Add(ph7);
            c2.Proyectos.Add(p1);
            c1.Proyectos.Add(ph2);
            c1.Proyectos.Add(ph3);

            //Agregación a las listas
            e.Proyectos.Add(ph1);
            e.Proyectos.Add(ph2);
            e.Proyectos.Add(ph3);
            e.Proyectos.Add(ph4);
            e.Proyectos.Add(ph5);
            e.Proyectos.Add(ph6);
            e.Proyectos.Add(ph7);
            e.Proyectos.Add(p1);
            e.Proyectos.Add(p2);
            e.Proyectos.Add(p3);

            e.Empleados.Add(e1);
            e.Empleados.Add(e2);
            e.Empleados.Add(e3);
            e.Empleados.Add(e4);
            e.Empleados.Add(e5);
            e.Empleados.Add(e6);
            e.Empleados.Add(e7);
            e.Empleados.Add(e8);
            e.Empleados.Add(e9);
            e.Empleados.Add(e11);
            e.Empleados.Add(e12);
            e.Empleados.Add(e13);

            e.Clientes.Add(c1);
            e.Clientes.Add(c2);
            e.Clientes.Add(c3);
            e.Clientes.Add(c4);
            e.Clientes.Add(c5);

            e.Administradores.Add(a1);
            e.Administradores.Add(a2);
            e.Administradores.Add(a3);
        }
    }
}
