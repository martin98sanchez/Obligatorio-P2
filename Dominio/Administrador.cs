using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador
    {
        private string username;
        private string password;
        private string id;
        private string nombreCompleto;

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

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public Administrador(string id, string nombreCompleto, string username, string password)
        {
            this.id = id;
            this.nombreCompleto = nombreCompleto;
            this.username = username;
            this.password = password;
        }
    }
}
