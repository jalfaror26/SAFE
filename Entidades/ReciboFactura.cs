using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class ReciboFactura
    {

        private String moneda, factura;
        private int recibo;
        private double monto, montoOriginal;
        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public double MontoOriginal
        {
            get { return montoOriginal; }
            set { montoOriginal = value; }
        }

        public String Factura
        {
            get { return factura; }
            set { factura = value; }
        }

        public int Recibo
        {
            get { return recibo; }
            set { recibo = value; }
        }

        public String Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }        

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }
    }
}
