using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class GuiaPrepagoProveedor
    {
        private Int64 id;
        private string proveedor, moneda, estado, usuario;
        private double monto;
        private DateTime fecha;

        public GuiaPrepagoProveedor()
        {
        }
        
        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public string Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }
        
        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

    
    }
}
