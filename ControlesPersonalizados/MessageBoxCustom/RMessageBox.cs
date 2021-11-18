using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoxCustom
{
    public class RMessageBox
    {
        public static RDialogResult Show(string mensaje)
        {
            return ShowCore(mensaje, null, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None);
        }

        public static RDialogResult Show(string mensaje, string titulo)
        {
            return ShowCore(mensaje, titulo, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None);
        }

        public static RDialogResult Show(string mensaje, string titulo, RMessageBoxButtons buttons)
        {
            return ShowCore(mensaje, titulo, buttons, RMessageBoxIcon.None, RMessageBoxDefaultButton.None);
        }

        public static RDialogResult Show(string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon)
        {
            return ShowCore(mensaje, titulo, buttons, icon, RMessageBoxDefaultButton.None);
        }

        public static RDialogResult Show(string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, RMessageBoxDefaultButton buttonDefault)
        {
            return ShowCore(mensaje, titulo, buttons, icon, buttonDefault);
        }



        private static RDialogResult ShowCore(string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, RMessageBoxDefaultButton buttonDefault)
        {
            FrmRMessageBox frm = new FrmRMessageBox(mensaje, titulo, buttons, GetIcon(icon), buttonDefault);
            frm.ShowDialog();
            return frm.Resultado;
        }

        private static Image GetIcon(RMessageBoxIcon icon)
        {
            switch (icon)
            {
                case RMessageBoxIcon.None:
                    return null;

                case RMessageBoxIcon.Error:
                    return Properties.Resources.icons8_error_64px;
                case RMessageBoxIcon.Warning:
                    return Properties.Resources.icons8_warning_64px;
                case RMessageBoxIcon.Ok:
                    return Properties.Resources.icons8_ok_64px;
                case RMessageBoxIcon.Information:
                    return Properties.Resources.icons8_info_64px;


                default:
                    return null;
            }
        }


    }
}
