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
        private static string[] noChangeText = { "", "", "" };
        public static Color darkText = Color.FromArgb(64, 64, 64);
        public static Color ligthText = Color.FromArgb(220, 220, 220);

        private static Color textColor = darkText;
        private static Color textColorTittle = darkText;
        private static Color textColorMessage = darkText;
        private static Color headerColor = Color.DimGray;
        private static Color bodyColor = Color.SlateGray;
        private static Color footerColor = Color.LightGray;
        private static Color allButtonColor = Color.DarkOrange;
        private static Color buttonLeftColor = Color.DarkOrange;
        private static Color buttonCenterColor = Color.DarkOrange;
        private static Color buttonRightColor = Color.DarkOrange;

        private static bool holdCustom = true;
        

        #region -> Propiedades de personalización

        public static Color TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        public static Color TextColorTittle
        {
            get { return textColorTittle; }
            set { textColorTittle = value; }
        }

        public static Color TextColorMessage
        {
            get { return textColorMessage; }
            set { textColorMessage = value; }
        }

        public static Color HeaderColor
        {
            get { return headerColor; }
            set { headerColor = value; }
        }

        public static Color BodyColor
        {
            get { return bodyColor; }
            set { bodyColor = value; }
        }

        public static Color FooterColor
        {
            get { return footerColor; }
            set { footerColor = value; }
        }

        public static Color AllButtonColor
        {
            get { return allButtonColor; }
            set { allButtonColor = value; }
        }

        public static Color ButtonLeftColor
        {
            get { return buttonLeftColor; }
            set { buttonLeftColor = value; }
        }

        public static Color ButtonCenterColor
        {
            get { return buttonCenterColor; }
            set { buttonCenterColor = value; }
        }

        public static Color ButtonRightColor
        {
            get { return buttonRightColor; }
            set { buttonRightColor = value; }
        }

        public static bool HoldCustom
        {
            get
            {
                return holdCustom;
            }

            set
            {
                holdCustom = value;
            }
        }



        #endregion

        #region -> Implementación


        public static RDialogResult Show(string mensaje)
        {
            return ShowCore(mensaje, null, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, noChangeText);
        }

        public static RDialogResult Show(string mensaje, string titulo)
        {
            return ShowCore(mensaje, titulo, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, noChangeText);
        }

        public static RDialogResult Show(string mensaje, string titulo, RMessageBoxButtons buttons)
        {
            return ShowCore(mensaje, titulo, buttons, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, noChangeText);
        }

        public static RDialogResult Show(string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon)
        {
            return ShowCore(mensaje, titulo, buttons, icon, RMessageBoxDefaultButton.None, noChangeText);
        }

        public static RDialogResult Show(string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, RMessageBoxDefaultButton buttonDefault)
        {
            return ShowCore(mensaje, titulo, buttons, icon, buttonDefault, noChangeText);
        }

        //Implementación con modificación de texto y de resultado
        public static RDialogResult Show(string mensaje, string[] txtButtons)
        {
            return ShowCore(mensaje, null, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, txtButtons);
        }

        public static RDialogResult Show(string mensaje, string titulo, string[] txtButtons)
        {
            return ShowCore(mensaje, titulo, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, txtButtons);
        }

        public static RDialogResult Show(string mensaje, string titulo, RMessageBoxButtons buttons, string[] txtButtons)
        {
            return ShowCore(mensaje, titulo, buttons, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, txtButtons);
        }

        public static RDialogResult Show(string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, string[] txtButtons)
        {
            return ShowCore(mensaje, titulo, buttons, icon, RMessageBoxDefaultButton.None, txtButtons);
        }

        public static RDialogResult Show(string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, RMessageBoxDefaultButton buttonDefault, string[] txtButtons)
        {
            return ShowCore(mensaje, titulo, buttons, icon, buttonDefault, txtButtons);
        }



        private static RDialogResult ShowCore(string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, RMessageBoxDefaultButton buttonDefault, string[] txtButtons)
        {
            FrmRMessageBox frm = new FrmRMessageBox(mensaje, titulo, buttons, GetIcon(icon), buttonDefault, txtButtons);
            Personalizacion(frm);

            frm.ShowDialog();
            ResetCustom();
            return frm.Resultado;
        }

        #endregion

        #region -> Metodos

        private static void Personalizacion(FrmRMessageBox frm)
        {



            //Color de fondo
            frm.HeaderColor = headerColor;
            frm.BodyColor = bodyColor;
            frm.FooterColor = footerColor;

            //Color de Botones
            frm.AllButtonColor = allButtonColor;
            frm.ButtonLeftColor = buttonLeftColor;
            frm.ButtonCenterColor = buttonCenterColor;
            frm.ButtonRightColor = buttonRightColor;

            //color texto
            frm.TextColor = textColor;
            frm.TextColorTittle = textColorTittle;
            frm.TextColorMessage = textColorMessage;


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

        private static void ResetCustom()
        {
            if (!holdCustom)
            {
                textColor = darkText;
                textColorTittle = darkText;
                textColorMessage = darkText;
                headerColor = Color.DimGray;
                bodyColor = Color.SlateGray;
                footerColor = Color.LightGray;
                allButtonColor = Color.DarkOrange;
                buttonLeftColor = Color.DarkOrange;
                buttonCenterColor = Color.DarkOrange;
                buttonRightColor = Color.DarkOrange;
            }
            
        }

        #endregion


    }
}
