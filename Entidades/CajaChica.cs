using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class CajaChica
    {
        private int linea, estado;
        private string documento, moneda;
        private DateTime fechaapertura, fechacierre;
        private double monto, saldo;

        public string Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public int Linea
        {
            get { return linea; }
            set { linea = value; }
        }

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        
        public DateTime Fechaapertura
        {
            get { return fechaapertura; }
            set { fechaapertura = value; }
        }

        public DateTime Fechacierre
        {
            get { return fechacierre; }
            set { fechacierre = value; }
        }
            

            public double Monto
            {
                get { return monto; }
                set { monto = value; }
            }

            public double Saldo
            {
                get { return saldo; }
                set { saldo = value; }
            }
    }
}
