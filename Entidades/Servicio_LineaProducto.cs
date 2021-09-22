using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Servicio_LineaProducto
    {

        private int marca;
        private Double articulo;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public Double Articulo
        {
            get { return articulo; }
            set { articulo = value; }
        }

        public int Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        
    }
}
