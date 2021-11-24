using System.Drawing;
using System.Windows.Forms;

namespace MessageBoxCustom
{
    public class RMessageBox
    {
        private static string[] noChangeText = { "", "", "" };
        public static Color darkText = Color.FromArgb(64, 64, 64);
        public static Color lightText = Color.FromArgb(220, 220, 220);

        private static Color textColor = darkText;
        private static Color textColorTittle = darkText;
        private static Color textColorMessage = darkText;
        private static Color headerColor = Color.Empty;
        private static Color bodyColor = Color.Empty;
        private static Color footerColor = Color.Empty;
        private static Color allButtonColor = Color.Empty;
        private static Color buttonLeftColor = Color.Empty;
        private static Color buttonCenterColor = Color.Empty;
        private static Color buttonRightColor = Color.Empty;
        private static Image customIcon = null;

        private static bool holdCustom = false;

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

        public static Image CustomIcon
        {
            get
            {
                return customIcon;
            }

            set
            {
                customIcon = value;
            }
        }



        #endregion

        #region -> Implementación

        public static RDialogResult Show(Color colorBase, string mensaje)
        {
            return ShowCore(colorBase, mensaje, null, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, noChangeText);
        }

        public static RDialogResult Show(Color colorBase, string mensaje, string titulo)
        {
            return ShowCore(colorBase, mensaje, titulo, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, noChangeText);
        }

        public static RDialogResult Show(Color colorBase, string mensaje, string titulo, RMessageBoxButtons buttons)
        {
            return ShowCore(colorBase, mensaje, titulo, buttons, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, noChangeText);
        }

        public static RDialogResult Show(Color colorBase, string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon)
        {
            return ShowCore(colorBase, mensaje, titulo, buttons, icon, RMessageBoxDefaultButton.None, noChangeText);
        }

        public static RDialogResult Show(Color colorBase, string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, RMessageBoxDefaultButton buttonDefault)
        {
            return ShowCore(colorBase, mensaje, titulo, buttons, icon, buttonDefault, noChangeText);
        }

        //Implementación con modificación de texto y de resultado
        public static RDialogResult Show(Color colorBase, string mensaje, string[] txtButtons)
        {
            return ShowCore(colorBase, mensaje, null, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, txtButtons);
        }

        public static RDialogResult Show(Color colorBase, string mensaje, string titulo, string[] txtButtons)
        {
            return ShowCore(colorBase, mensaje, titulo, RMessageBoxButtons.OK, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, txtButtons);
        }

        public static RDialogResult Show(Color colorBase, string mensaje, string titulo, RMessageBoxButtons buttons, string[] txtButtons)
        {
            return ShowCore(colorBase, mensaje, titulo, buttons, RMessageBoxIcon.None, RMessageBoxDefaultButton.None, txtButtons);
        }

        public static RDialogResult Show(Color colorBase, string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, string[] txtButtons)
        {
            return ShowCore(colorBase, mensaje, titulo, buttons, icon, RMessageBoxDefaultButton.None, txtButtons);
        }

        public static RDialogResult Show(Color colorBase, string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, RMessageBoxDefaultButton buttonDefault, string[] txtButtons)
        {
            return ShowCore(colorBase, mensaje, titulo, buttons, icon, buttonDefault, txtButtons);
        }



        private static RDialogResult ShowCore(Color colorBase, string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxIcon icon, RMessageBoxDefaultButton buttonDefault, string[] txtButtons)
        {
            FrmRMessageBox frm = new FrmRMessageBox(mensaje, titulo, buttons, buttonDefault, txtButtons);
            SetDefaultBackColor(colorBase, frm);
            Personalizacion(frm);
            frm.IconMessage = GetIcon(icon);

            frm.ShowDialog();
            ResetCustom(colorBase, frm);
            return frm.Resultado;
        }


        #endregion

        #region -> Metodos

        private static void SetDefaultBackColor(Color colorBase, FrmRMessageBox frm)
        {
            if (colorBase != Color.Empty)
            {
                    frm.HeaderColor = ControlPaint.Light(colorBase, 0.2F);
                    frm.BodyColor = ControlPaint.LightLight(colorBase);
                    frm.FooterColor = ControlPaint.Light(colorBase, 0.4F);
                if (ControlPaint.Light(colorBase, 0.4F).GetBrightness() >= 0.6F)
                    frm.AllButtonColor = ControlPaint.Dark(colorBase, 0.5F);
                else
                    frm.AllButtonColor = ControlPaint.Light(colorBase, 0.1F);
            }
            else
            {
                
                frm.HeaderColor = Color.DimGray;
                frm.BodyColor = Color.SlateGray;
                frm.FooterColor = Color.LightGray;
                frm.AllButtonColor = Color.DarkOrange;
                
            }
        }

        private static void Personalizacion(FrmRMessageBox frm)
        {
            //Color de fondo
            if (headerColor != Color.Empty)
                frm.HeaderColor = headerColor;

            if (bodyColor != Color.Empty)
                frm.BodyColor = bodyColor;

            if (footerColor != Color.Empty)
                frm.FooterColor = footerColor;

            //Color de Botones
            if (allButtonColor != Color.Empty)
                frm.AllButtonColor = allButtonColor;

            if (ButtonLeftColor != Color.Empty)
                frm.ButtonLeftColor = buttonLeftColor;

            if (buttonCenterColor != Color.Empty)
                frm.ButtonCenterColor = buttonCenterColor;

            if (buttonRightColor != Color.Empty)
                frm.ButtonRightColor = buttonRightColor;

            //color texto
            frm.TextColor = textColor;
            frm.TextColorTittle = textColorTittle;
            frm.TextColorMessage = textColorMessage;
        }

        private static void ResetCustom(Color colorBase, FrmRMessageBox frm)
        {
            if (!holdCustom)
            {
                textColor = darkText;
                textColorTittle = darkText;
                textColorMessage = darkText;
                headerColor = Color.Empty;
                bodyColor = Color.Empty;
                footerColor = Color.Empty;
                allButtonColor = Color.Empty;
                buttonLeftColor = Color.Empty;
                buttonCenterColor = Color.Empty;
                buttonRightColor = Color.Empty;

                SetDefaultBackColor(colorBase, frm);

                
            }
        }

        private static Image GetIcon(RMessageBoxIcon icon)
        {
            switch (icon)
            {
                case RMessageBoxIcon.None:
                    return null;
                case RMessageBoxIcon.Asterisk:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Asterisk_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Asterisk_light_50px;
                    }
                case RMessageBoxIcon.Error:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Error_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Error_light_50px;
                    }
                case RMessageBoxIcon.Warning:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Warning_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Warning_light_50px;
                    }
                case RMessageBoxIcon.Ok:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.OK_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.OK_light_50px;
                    }
                case RMessageBoxIcon.Information:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Information_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Information_light_50px;
                    }
                case RMessageBoxIcon.Hand:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Hand_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Hand_light_50px;
                    }
                case RMessageBoxIcon.Question:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Question_dark_50px_2;
                    }
                    else
                    {
                        return Properties.Resources.Question_light_50px_1;
                    }
                case RMessageBoxIcon.Exclamation:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Exclamation_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Exclamation_light_50px;
                    }
                case RMessageBoxIcon.Stop:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Stop_dark_50px_1;
                    }
                    else
                    {
                        return Properties.Resources.Stop_light_50px_1;
                    }
                case RMessageBoxIcon.Like:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Like_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Like_light_50px_2;
                    }
                case RMessageBoxIcon.User:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.User_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.User_light_50px;
                    }
                case RMessageBoxIcon.Trash:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Trash_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Trash_light_50px_1;
                    }
                case RMessageBoxIcon.Save:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Save_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Save_light_50px;
                    }
                case RMessageBoxIcon.Lock:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Lock_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Lock_light_50px;
                    }
                case RMessageBoxIcon.Unlock:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Unlock_dark_50px;
                    }
                    else
                    {
                        return Properties.Resources.Unlock_light_50px_1;
                    }
                case RMessageBoxIcon.Key:
                    if (bodyColor.GetBrightness() >= 0.6F)
                    {
                        return Properties.Resources.Key_dark_50px_1;
                    }
                    else
                    {
                        return Properties.Resources.Key_light_50px_2;
                    }
                case RMessageBoxIcon.Hand_Color:
                    return Properties.Resources.Hand_color_50px;
                case RMessageBoxIcon.Question_Color:
                    return Properties.Resources.Question_color_50px;
                case RMessageBoxIcon.Exclamation_Color:
                    return Properties.Resources.Exclamation_color_50px;
                case RMessageBoxIcon.Asterisk_Color:
                    return Properties.Resources.Asterisk_color_50px_1;
                case RMessageBoxIcon.Stop_Color:
                    return Properties.Resources.Stop_color_50px;
                case RMessageBoxIcon.Error_Color:
                    return Properties.Resources.Error_color_50px;
                case RMessageBoxIcon.Warning_Color:
                    return Properties.Resources.Warning_color_50px;
                case RMessageBoxIcon.Information_Color:
                    return Properties.Resources.Information_color_50px;
                case RMessageBoxIcon.Ok_Color:
                    return Properties.Resources.OK_color_50px;
                case RMessageBoxIcon.Like_Color:
                    return Properties.Resources.Like_color_50px_1;
                case RMessageBoxIcon.User_Color:
                    return Properties.Resources.User_color_50px;
                case RMessageBoxIcon.Trash_Color:
                    return Properties.Resources.Trash_color_50px_2;
                case RMessageBoxIcon.Save_Color:
                    return Properties.Resources.Save_color_50px;
                case RMessageBoxIcon.Lock_Color:
                    return Properties.Resources.Lock_color_50px_2;
                case RMessageBoxIcon.Unlock_Color:
                    return Properties.Resources.Unlock_color_50px;
                case RMessageBoxIcon.Key_Color:
                    return Properties.Resources.Key_color_50px;
                case RMessageBoxIcon.Custom:
                    return customIcon;

                default:
                    return null;
            }
        }


        #endregion


    }
}
