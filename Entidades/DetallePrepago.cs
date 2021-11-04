using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class DetallePrepago
    {
        private int indice, prepago, codProveedor;       
        private String numFactura ;
        private Double monto, saldo, abono;


        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
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

        public int CodProveedor
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
