using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VariablesGlobales
    {
        private static String loggedUserType = "";

        private static String loggedUserId = "";

        private static String loggedUser_Nombre = "";

        public VariablesGlobales()
        {

        }

        public String LoggedUserId
        {
            get { return loggedUserId; }
            set { loggedUserId = value; }
        }

        public String LoggedUser_Nombre
        {
            get { return loggedUser_Nombre; }
            set { loggedUser_Nombre = value; }
        }

        public String LoggedUserType
        {
            get { return loggedUserType; }
            set { loggedUserType = value; }
        }

    }
}
