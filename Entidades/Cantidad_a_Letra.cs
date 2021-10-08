using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Cantidad_a_Letra
    {
        private string[] sUnidades = {"", "un", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", 
									"once", "doce", "trece", "catorce", "quince", "dieciseis", "diecisiete", "dieciocho", "diecinueve", "veinte", 
									"veintiún", "veintidos", "veintitres", "veinticuatro", "veinticinco", "veintiseis", "veintisiete", "veintiocho", "veintinueve"};

        private string[] sDecenas = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

        private string[] sCentenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

        private string sResultado = "";

        public string ConvertirCadena(string sNumero, string moneda)
        {
            double dNumero;
            double dNumAux = 0;
            char x;
            string sAux;

            sResultado = " ";
            try
            {
                dNumero = Convert.ToDouble(sNumero);
            }
            catch
            {
                return "";
            }

            if (dNumero > 999999999999)
                return "";

            if (dNumero > 999999999)
            {
                dNumAux = dNumero % 1000000000000;
                sResultado += Numeros(dNumAux, 1000000000) + " mil ";
            }

            if (dNumero > 999999)
            {
                dNumAux = dNumero % 1000000000;
                sResultado += Numeros(dNumAux, 1000000) + " millones ";
            }

            if (dNumero > 999)
            {
                dNumAux = dNumero % 1000000;
                sResultado += Numeros(dNumAux, 1000) + " mil ";
            }

            dNumAux = dNumero % 1000;
            sResultado += Numeros(dNumAux, 1);


            sAux = dNumero.ToString();

            if (sAux.IndexOf(".") >= 0)
                sResultado += ObtenerDecimales(sAux, moneda);
            else
                sResultado += moneda + " con 00/100";

            sAux = sResultado;
            x = char.ToUpper(sResultado[1]);
            sResultado = x.ToString();

            for (int i = 2; i < sAux.Length; i++)
                sResultado += sAux[i].ToString();

            if (sResultado.StartsWith("Un  mil"))
            {
                sResultado = sResultado.Substring(5);
                sResultado = "M" + sResultado;
            }

            if (sResultado.StartsWith("Un colones"))
            {
                sResultado = sResultado.Substring(10);
                sResultado = "Un colon" + sResultado;
            }else if (sResultado.StartsWith("Un dolares"))
            {
                sResultado = sResultado.Substring(10);
                sResultado = "Un dolar" + sResultado;
            }
            else if (sResultado.StartsWith("Un euros"))
            {
                sResultado = sResultado.Substring(8);
                sResultado = "Un euro" + sResultado;
            }

            return sResultado;
        }

        public string ConvertirCadena(double dNumero, string moneda)
        {
            double dNumAux = 0;
            char x;
            string sAux;

            sResultado = " ";

            if (dNumero > 999999999999)
                return "";

            if (dNumero > 999999999)
            {
                dNumAux = dNumero % 1000000000000;
                sResultado += Numeros(dNumAux, 1000000000) + " mil ";
            }

            if (dNumero > 999999)
            {
                dNumAux = dNumero % 1000000000;
                sResultado += Numeros(dNumAux, 1000000) + " millones ";
            }

            if (dNumero > 999)
            {
                dNumAux = dNumero % 1000000;
                sResultado += Numeros(dNumAux, 1000) + " mil ";
            }

            dNumAux = dNumero % 1000;
            sResultado += Numeros(dNumAux, 1);


            sAux = dNumero.ToString();

            if (sAux.IndexOf(".") >= 0)
                sResultado += ObtenerDecimales(sAux, moneda);
            else
                sResultado += moneda + " con 00/100";

            sAux = sResultado;
            x = char.ToUpper(sResultado[1]);
            sResultado = x.ToString();

            for (int i = 2; i < sAux.Length; i++)
                sResultado += sAux[i].ToString();

            if (sResultado.StartsWith("Un  millones"))
            {
                sResultado = sResultado.Substring(12);
                sResultado = "Un millon" + sResultado;
            }
            else
            if (sResultado.StartsWith("Un  mil"))
            {
               sResultado=sResultado.Substring(5);
                sResultado = "M" + sResultado;
            }

            if (sResultado.StartsWith("Un colones"))
            {
                sResultado = sResultado.Substring(10);
                sResultado = "Un colon" + sResultado;
            }
            else if (sResultado.StartsWith("Un dolares"))
            {
                sResultado = sResultado.Substring(10);
                sResultado = "Un dolar" + sResultado;
            }
            else if (sResultado.StartsWith("Un euros"))
            {
                sResultado = sResultado.Substring(8);
                sResultado = "Un euro" + sResultado;
            }
           

            return sResultado;
        }

        public string ConvertirCadenaSinDecimales(double dNumero, string moneda)
        {
            double dNumAux = 0;
            char x;
            string sAux;

            sResultado = " ";

            if (dNumero > 999999999999)
                return "";

            if (dNumero > 999999999)
            {
                dNumAux = dNumero % 1000000000000;
                sResultado += Numeros(dNumAux, 1000000000) + " mil ";
            }

            if (dNumero > 999999)
            {
                dNumAux = dNumero % 1000000000;
                sResultado += Numeros(dNumAux, 1000000) + " millones ";
            }

            if (dNumero > 999)
            {
                dNumAux = dNumero % 1000000;
                sResultado += Numeros(dNumAux, 1000) + " mil ";
            }

            dNumAux = dNumero % 1000;
            sResultado += Numeros(dNumAux, 1);


            sAux = dNumero.ToString();

            sAux = sResultado;
            x = char.ToUpper(sResultado[1]);
            sResultado = x.ToString();

            for (int i = 2; i < sAux.Length; i++)
                sResultado += sAux[i].ToString();

            return sResultado;
        }

        private string Numeros(double dNumAux, double dFactor)
        {
            double dCociente = dNumAux / dFactor;
            double dNumero = 0;
            int iNumero = 0;
            string sNumero = "";
            string sTexto = "";

            if (dCociente >= 100)
            {
                dNumero = dCociente / 100;
                sNumero = dNumero.ToString();
                iNumero = int.Parse(sNumero[0].ToString());
                sTexto += this.sCentenas[iNumero] + " ";
            }

            dCociente = dCociente % 100;
            if (dCociente >= 30)
            {
                dNumero = dCociente / 10;
                sNumero = dNumero.ToString();
                iNumero = int.Parse(sNumero[0].ToString());
                if (iNumero > 0)
                    sTexto += this.sDecenas[iNumero] + " ";

                dNumero = dCociente % 10;
                sNumero = dNumero.ToString();
                iNumero = int.Parse(sNumero[0].ToString());
                if (iNumero > 0)
                    sTexto += "y " + this.sUnidades[iNumero] + " ";
            }

            else
            {
                dNumero = dCociente;
                sNumero = dNumero.ToString();
                if (sNumero.Length > 1)
                    if (sNumero[1] != '.')
                        iNumero = int.Parse(sNumero[0].ToString() + sNumero[1].ToString());
                    else
                        iNumero = int.Parse(sNumero[0].ToString());
                else
                    iNumero = int.Parse(sNumero[0].ToString());
                sTexto += this.sUnidades[iNumero] + " ";
            }

            return sTexto;
        }

        private string ObtenerDecimales(string sNumero, string moneda)
        {
            string[] sNumPuntos;
            string sTexto = "";
            double dNumero = 0;

            sNumPuntos = sNumero.Split('.');


            dNumero = Convert.ToDouble(sNumPuntos[1]);
            sTexto = moneda+" con " + dNumero+"/100";

            return sTexto;
        }
    }
}
