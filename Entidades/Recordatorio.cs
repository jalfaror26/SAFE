using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Recordatorio
    {
        private DateTime fechaHora;
        private String detalle, estado, detalleProviene, tipo;
        private int linea, indiceProviene, persona;
        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public int Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public int Linea
        {
            get { return linea; }
            set { linea = value; }
        }

        public int IndiceProviene
        {
            get { return indiceProviene; }
            set { indiceProviene = value; }
        }

        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public String Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String DetalleProviene
        {
            get { return detalleProviene; }
            set { detalleProviene = value; }
        }
    }
}
