using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROYECTO
{
    public class RedondearNumero
    {
        public double Redondear(double numero)
        {
            if (!PROYECTO.Properties.Settings.Default.RedondearPrecioVenta)
                return numero;

            numero = Math.Round(numero, 0);
            string numero2 = numero.ToString();
            numero2 = "00000000" + numero2;

            if (int.Parse(numero2[numero2.Length - 1].ToString()) == 0)
                numero = numero + 0;
            else if (int.Parse(numero2[numero2.Length - 1].ToString()) == 5)
                numero = numero + 0;
            else if (int.Parse(numero2[numero2.Length - 1].ToString()) <= 9)
            {
                string precio2 = numero2.Substring(0, numero2.Length - 2).ToString();
                string precio3 = numero2[numero2.Length - 2].ToString();
                string precio4 = "";
                if (int.Parse(precio3) < 9)
                {
                    precio3 = (int.Parse(precio3) + 1) + "";
                    precio4 = precio2 + precio3 + "0";
                }
                else
                {
                    precio2 = numero2.Substring(0, numero2.Length - 3).ToString();
                    precio3 = numero2[numero2.Length - 3].ToString();
                    if (int.Parse(precio3) < 9)
                    {
                        precio3 = (int.Parse(precio3) + 1) + "";
                        precio4 = precio2 + precio3 + "00";
                    }
                    else
                    {
                        precio2 = numero2.Substring(0, numero2.Length - 4).ToString();
                        precio3 = numero2[numero2.Length - 4].ToString();

                        if (int.Parse(precio3) < 9)
                        {
                            precio3 = (int.Parse(precio3) + 1) + "";
                            precio4 = precio2 + precio3 + "000";
                        }
                        else
                        {
                            precio2 = numero2.Substring(0, numero2.Length - 5).ToString();
                            precio3 = numero2[numero2.Length - 5].ToString();

                            if (int.Parse(precio3) < 9)
                            {
                                precio3 = (int.Parse(precio3) + 1) + "";
                                precio4 = precio2 + precio3 + "0000";
                            }
                            else
                            {
                                precio2 = numero2.Substring(0, numero2.Length - 6).ToString();
                                precio3 = numero2[numero2.Length - 6].ToString();

                                if (int.Parse(precio3) < 9)
                                {
                                    precio3 = (int.Parse(precio3) + 1) + "";
                                    precio4 = precio2 + precio3 + "00000";
                                }
                                else
                                {
                                    precio2 = numero2.Substring(0, numero2.Length - 7).ToString();
                                    precio3 = numero2[numero2.Length - 7].ToString();

                                    if (int.Parse(precio3) < 9)
                                    {
                                        precio3 = (int.Parse(precio3) + 1) + "";
                                        precio4 = precio2 + precio3 + "000000";
                                    }
                                    else
                                    {
                                        precio2 = numero2.Substring(0, numero2.Length - 8).ToString();
                                        precio3 = numero2[numero2.Length - 8].ToString();

                                        if (int.Parse(precio3) < 9)
                                        {
                                            precio3 = (int.Parse(precio3) + 1) + "";
                                            precio4 = precio2 + precio3 + "0000000";
                                        }
                                        else
                                        {
                                            precio2 = numero2.Substring(0, numero2.Length - 9).ToString();
                                            precio3 = numero2[numero2.Length - 9].ToString();

                                            if (int.Parse(precio3) < 9)
                                            {
                                                precio3 = (int.Parse(precio3) + 1) + "";
                                                precio4 = precio2 + precio3 + "00000000";
                                            }
                                            else
                                            {
                                                precio2 = numero2.Substring(0, numero2.Length - 10).ToString();
                                                precio3 = numero2[numero2.Length - 10].ToString();
                                                precio3 = (int.Parse(precio3) + 1) + "";
                                                precio4 = precio2 + precio3 + "000000000";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                numero = double.Parse(precio4);
            }
            return numero;
        }

    }
}
