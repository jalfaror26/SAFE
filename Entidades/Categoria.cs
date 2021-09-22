using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Categoria
    {
        private String descripcion;
        private int indice;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }        

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        
    }
}
