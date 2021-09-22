using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class TipoCambio
    {
        private DateTime fecharegistro;
        private double dolar, euro, minDolar, minEuro, bcDolar, bcEuro;
        private String usuario;
        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public double BcEuro
        {
            get { return bcEuro; }
            set { bcEuro = value; }
        }

        public double BcDolar
        {
            get { return bcDolar; }
            set { bcDolar = value; }
        }

        public double MinEuro
        {
            get { return minEuro; }
            set { minEuro = value; }
        }

        public double MinDolar
        {
            get { return minDolar; }
            set { minDolar = value; }
        }

        public DateTime Fecharegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }

        public double Euro
        {
            get { return euro; }
            set { euro = value; }
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
