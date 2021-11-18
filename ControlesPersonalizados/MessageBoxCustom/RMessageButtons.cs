using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoxCustom
{
    //
    // Resumen:
    //     Especifica las constantes que definen qué botones se han de mostrar en un System.Windows.Forms.MessageBox.
    public enum RMessageBoxButtons
    {
        //
        // Resumen:
        //     El cuadro de mensaje contiene un botón Aceptar.
        OK,
        //
        // Resumen:
        //     El cuadro de mensaje contiene un botón Aceptar y otro Cancelar.
        OKCancel,
        //
        // Resumen:
        //     El cuadro de mensaje contiene los botones Anular, Reintentar y Omitir.
        AbortRetryIgnore,
        //
        // Resumen:
        //     El cuadro de mensaje contiene los botones Sí, No y Cancelar.
        YesNoCancel,
        //
        // Resumen:
        //     El cuadro de mensaje contiene un botón Sí y otro No.
        YesNo,
        //
        // Resumen:
        //     El cuadro de mensaje contiene un botón Reintentar y otro Cancelar.
        RetryCancel
    }
}
