using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class TipoCambio
    {
        private DateTime fecharegistro;
        private double dolar;
        private String usuario;
        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }
        
        public DateTime Fecharegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }

        public double Dolar
        {
            get { return dolar; }
            set { dolar = value; }
        }        

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}
