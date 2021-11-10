using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class ServicioImpuestos
    {
        private string clave, afectaVenta;
        
        private Double indiceServicio;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public string Clave { get => clave; set => clave = value; }
        public string AfectaVenta { get => afectaVenta; set => afectaVenta = value; }
        public double IndiceServicio { get => indiceServicio; set => indiceServicio = value; }
    }
}
