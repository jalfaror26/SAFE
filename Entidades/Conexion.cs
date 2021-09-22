using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTIDADES
{
    public class Conexion
    {
        public static Conexion instance = null;
        String clave = "SAFE_UTN";

        public static Conexion getInstance()
        {
            if (instance == null)
                instance = new Conexion();
            return instance;
        }

        private Conexion() { }



        public string Clave { get => clave; set => clave = value; }
    }
}
