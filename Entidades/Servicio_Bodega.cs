using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Servicio_Bodega
    {       
        
        private int proveedor;
        private String tipo, bodega;
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

        public String Bodega
        {
            get { return bodega; }
            set { bodega = value; }
        }
                
        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
                
        public int Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }
        
    }
}
