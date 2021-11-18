using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MessageBoxCustom
{

    internal class Traductor
    {
        private static string idioma = Thread.CurrentThread.CurrentCulture.ToString();



        public static string Traducir(string txt)
        {
            txt = txt.ToLower();
            if (idioma.Contains("es") || idioma.Contains("ES"))
            {
                switch (txt)
                {
                    case "ok":
                        return "Aceptar";
                    case "cancel":
                        return "Cancelar";
                    case "abort":
                        return "Anular";
                    case "retry":
                        return "Reintentar";
                    case "ignore":
                        return "Omitir";
                    case "yes":
                        return "Si";
                    case "no":
                        return "No";
                    default: return txt;
                }
            }
            else
            {
                return txt;
            }


        }

    }


}
