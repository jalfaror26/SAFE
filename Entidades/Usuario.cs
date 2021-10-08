using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private String codUsuario, contrasenna, rol, nombre, apellido1, apellido2, cedula, email;

        public string CodUsuario { get => codUsuario; set => codUsuario = value; }
        public string Contrasenna { get => contrasenna; set => contrasenna = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Email { get => email; set => email = value; }
    }
}
