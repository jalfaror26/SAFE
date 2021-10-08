using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Gasto
    {
        private int indice;
        private String codigo, nombre, tipo;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public Gasto(int indice, String nombre, String codigo) {
            this.indice = indice;
            this.nombre = nombre;
            this.codigo = codigo;
        }

        public Gasto()
        {
            
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
