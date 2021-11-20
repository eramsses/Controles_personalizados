using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoxCustom
{
    //
    // Resumen:
    //     Especifica los identificadores que indicarán el valor devuelto por un cuadro
    //     de diálogo.
    public enum RDialogResult
    {
        //
        // Resumen:
        //     El cuadro de diálogo devuelve Nothing. Esto significa que el cuadro de diálogo
        //     modal continúa ejecutándose.
        None,
        //
        // Resumen:
        //     El valor devuelto por el cuadro de diálogo es OK (suele enviarse desde un botón
        //     Aceptar).
        OK,
        //
        // Resumen:
        //     El valor devuelto por el cuadro de diálogo es Cancel (suele enviarse desde un
        //     botón Cancelar).
        Cancel,
        //
        // Resumen:
        //     El valor devuelto por el cuadro de diálogo es Abort (suele enviarse desde un
        //     botón Anular).
        Abort,
        //
        // Resumen:
        //     El valor devuelto por el cuadro de diálogo es Retry (suele enviarse desde un
        //     botón de etiqueta Reintentar).
        Retry,
        //
        // Resumen:
        //     El valor devuelto por el cuadro de diálogo es Ignore (suele enviarse desde un
        //     botón Omitir).
        Ignore,
        //
        // Resumen:
        //     El valor devuelto por el cuadro de diálogo es Yes (suele enviarse desde un botón
        //     de etiqueta Sí).
        Yes,
        //
        // Resumen:
        //     El valor devuelto por el cuadro de diálogo es No (suele enviarse desde un botón
        //     de etiqueta No).
        No,
        x,
        y,
        z
    }
}
