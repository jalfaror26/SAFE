using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class PagosProveedores
     {    

        private int flujo;   
        private double monto;
        private string proveedor, tipoPago, detallePago;
        private Int64 documento;
        
        public string Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        public string TipoPago
        {
            get { return tipoPago; }
            set { tipoPago = value; }
        }
        
        public Int64 Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public string DetallePago
        {
            get { return detallePago; }
            set { detallePago = value; }
        }
       

       public int Flujo
       {
           get { return flujo; }
           set { flujo = value; }
       }
           
           public double Monto
           {
               get { return monto; }
               set { monto = value; }
           }
    }
}
