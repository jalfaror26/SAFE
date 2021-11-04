using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class GuiaPrepagoProveedor
    {
        private Double id;
        private string proveedor, moneda, estado;
        private double monto;
        private DateTime fecha;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public Double Id
        {
            get { return id; }
            set { id = value; }
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
