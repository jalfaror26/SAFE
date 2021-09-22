using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Empresa
    {
        #region Propiedades privadas

        private String tipoId;
        private String nombre;
        private String telefono;
        private String correo;
        private String ubicacion;
        private String identificacion, tipo,  nombreLogo;
        private String posRestaurant;
        private String provincia, canton, distrito, barrio;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public String NombreLogo
        {
            get { return nombreLogo; }
            set { nombreLogo = value; }
        }
        
        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public String Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        #endregion
        #region Set's and Get's

        public String TipoId
        {
            get { return tipoId; }
            set { tipoId = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public String Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public string Provincia { get => provincia; set => provincia = value; }
        public string Canton { get => canton; set => canton = value; }
        public string Distrito { get => distrito; set => distrito = value; }
        public string Barrio { get => barrio; set => barrio = value; }

        #endregion
    }
}
