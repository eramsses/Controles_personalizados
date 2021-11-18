using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RMessageBoxCustom
{
    public static class RMessageBox
    {
        private static string idioma = Thread.CurrentThread.CurrentCulture.ToString();

        public static RDialogResult Show()
        {
            FrmRMessageBox frm = new FrmRMessageBox();
            frm.ShowDialog();
            return frm.ShowCore();
        }

        
    }
}
