using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class CajaChicaDetalle
    {
        private int linea, caja;
        private DateTime fechamovimiento;
        private double credito, debito;
        private string empleado, documento, usuario, tipoMovimiento, movimiento, justificacion;
        
        public string Justificacion
        {
            get { return justificacion; }
            set { justificacion = value; }
        }

        public string Movimiento
        {
            get { return movimiento; }
            set { movimiento = value; }
        }

        public string TipoMovimiento
        {
            get { return tipoMovimiento; }
            set { tipoMovimiento = value; }
        }
        

        public int Caja
        {
            get { return caja; }
            set { caja = value; }
        }

        public int Linea
        {
            get { return linea; }
            set { linea = value; }
        }

        public DateTime Fechamovimiento
        {
            get { return fechamovimiento; }
            set { fechamovimiento = value; }
        }

            public double Credito
            {
                get { return credito; }
                set { credito = value; }
            }

            public double Debito
            {
                get { return debito; }
                set { debito = value; }
            }

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }

    }
}
