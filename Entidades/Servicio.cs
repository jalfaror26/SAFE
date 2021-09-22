using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Servicio
    {
        private Double indice;
        private Double impuestos;
        private String descripcion, nombre, tipo, codigoBarras, tipoCodigo;

        private String no_cia, venta_IVI;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public String TipoCodigo
        {
            get { return tipoCodigo; }
            set { tipoCodigo = value; }
        }

        public String CodigoBarras
        {
            get { return codigoBarras; }
            set { codigoBarras = value; }
        }

        public Double Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Double Impuestos
        {
            get { return impuestos; }
            set { impuestos = value; }
        }

        public String Venta_IVI
        {
            get { return venta_IVI; }
            set { venta_IVI = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

    }
}
