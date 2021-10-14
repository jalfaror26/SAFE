using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class DetallePrepago
    {
        private int indice, prepago;       
        private String numFactura, codProveedor;
        private Double monto, saldo, abono;

            public DetallePrepago()
        {

        }

        public Double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public Double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public int Prepago
        {
            get { return prepago; }
            set { prepago = value; }
        }

        public Double Abono
        {
            get { return abono; }
            set { abono = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public String CodProveedor
        {
            get { return codProveedor; }
            set { codProveedor = value; }
        }

        public String NumFactura
        {
            get { return numFactura; }
            set { numFactura = value; }
        }
    }
}
