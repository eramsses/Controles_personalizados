using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MessageBoxCustom
{
    public partial class FrmRMessageBox : Form
    {

        private static Color darkText = Color.FromArgb(64, 64, 64);
        private static Color ligthText = Color.FromArgb(220, 220, 220);

        private RDialogResult resultado = RDialogResult.None;
        private RDialogResult resultadoBoton1 = RDialogResult.None;
        private RDialogResult resultadoBoton2 = RDialogResult.None;
        private RDialogResult resultadoBoton3 = RDialogResult.None;

        #region -> Propiedades de Personalización

        public Color TextColor
        {
            set
            {
                if (value != darkText && value != ligthText)
                {
                    this.LblTitulo.ForeColor = value;
                    this.LblMensaje.ForeColor = value;
                }
            }
        }

        public Color TextColorTittle
        {
            set
            {
                if (value != darkText && value != ligthText)
                {
                    this.LblTitulo.ForeColor = value;
                }
            }
        }

        public Color TextColorMessage
        {
            set
            {
                if (value != darkText && value != ligthText)
                {
                    this.LblMensaje.ForeColor = value;
                }
            }
        }

        public Color HeaderColor
        {
            set
            {
                //if (this.LblTitulo.ForeColor == darkText || this.LblTitulo.ForeColor == ligthText)
                //{
                if (value.GetBrightness() >= 0.6F)
                {
                    LblTitulo.ForeColor = darkText;
                }
                else
                {
                    LblTitulo.ForeColor = ligthText;
                }
                //}
                this.PnlTitulo.BackColor = value;
            }
        }

        public Color BodyColor
        {
            set
            {
                //if (this.LblMensaje.ForeColor == darkText || this.LblMensaje.ForeColor == ligthText)
                //{
                if (value.GetBrightness() >= 0.6F)
                {
                    LblMensaje.ForeColor = darkText;
                }
                else
                {
                    LblMensaje.ForeColor = ligthText;
                }
                //}
                this.PnlIcono.BackColor = value;
                this.PnlMensaje.BackColor = value;
            }
        }

        public Color FooterColor
        {
            set
            {
                this.PnlBotones.BackColor = value;
            }
        }

        public Color AllButtonColor
        {
            set
            {
                if (value.GetBrightness() >= 0.6F)
                {
                    RBtn1.TextColor = darkText;
                    RBtn2.TextColor = darkText;
                    RBtn3.TextColor = darkText;
                }
                else
                {
                    RBtn1.TextColor = ligthText;
                    RBtn2.TextColor = ligthText;
                    RBtn3.TextColor = ligthText;
                }
                RBtn1.BackColor = value;
                RBtn2.BackColor = value;
                RBtn3.BackColor = value;
            }
        }

        public Color ButtonLeftColor
        {
            set
            {
                if (value.GetBrightness() >= 0.6F)
                {
                    RBtn1.TextColor = darkText;
                }
                else
                {
                    RBtn1.TextColor = ligthText;
                }
                RBtn1.BackColor = value;

            }
        }

        public Color ButtonCenterColor
        {
            set
            {
                if (value.GetBrightness() >= 0.6F)
                {
                    RBtn2.TextColor = darkText;
                }
                else
                {
                    RBtn2.TextColor = ligthText;
                }
                RBtn2.BackColor = value;
            }
        }

        public Color ButtonRightColor
        {
            set
            {
                if (value.GetBrightness() >= 0.6F)
                {
                    RBtn3.TextColor = darkText;
                }
                else
                {
                    RBtn3.TextColor = ligthText;
                }
                RBtn3.BackColor = value;
            }

        }


        public Image IconMessage
        { 
            set
            {
                PicIcon.Image = value;
                if (value == null)
                {
                    PnlIcono.Visible = false;
                }
            }
        }




        #endregion

        #region Constructores
        public FrmRMessageBox()
        {
            InitializeComponent();
        }

        public FrmRMessageBox(string mensaje, string titulo, RMessageBoxButtons buttons, RMessageBoxDefaultButton buttonDefault, string[] txtButtons)
        {
            InitializeComponent();
            this.LblTitulo.Text = titulo;
            this.LblMensaje.Text = mensaje;
            MostrarBotones(buttons);
            
            SetDefaultButton(buttonDefault);
            SetTxtValueButtons(txtButtons);
        }


        

        #endregion

        #region -> Contrucción de Botones

        private void SetTxtValueButtons(string[] txtButtons)
        {
            for (int i = 0; i < txtButtons.Length; i++)
            {
                if (i == 0 && txtButtons[i].Length > 0)
                {
                    RBtn3.Text = txtButtons[i];
                    resultadoBoton3 = RDialogResult.x;
                }
                else if (i == 1 && txtButtons[i].Length > 0)
                {
                    RBtn2.Text = txtButtons[i];
                    resultadoBoton2 = RDialogResult.y;
                }
                else if (i == 2 && txtButtons[i].Length > 0)
                {
                    RBtn1.Text = txtButtons[i];
                    resultadoBoton1 = RDialogResult.z;
                }
            }
        }

        private void SetDefaultButton(RMessageBoxDefaultButton buttonDefault)
        {
            switch (buttonDefault)
            {
                case RMessageBoxDefaultButton.None:
                    this.ActiveControl = null;
                    break;
                case RMessageBoxDefaultButton.Button1:
                    this.ActiveControl = RBtn3;
                    RBtn3.BorderColor = Color.Red;
                    RBtn3.BorderSize = 1;
                    break;
                case RMessageBoxDefaultButton.Button2:
                    this.ActiveControl = RBtn2;
                    RBtn2.BorderColor = Color.Red;
                    RBtn2.BorderSize = 1;
                    break;
                case RMessageBoxDefaultButton.Button3:
                    this.ActiveControl = RBtn1;
                    RBtn1.BorderColor = Color.Red;
                    RBtn1.BorderSize = 1;
                    break;
                default:
                    this.ActiveControl = null;
                    break;
            }
        }

        private void MostrarBotones(RMessageBoxButtons buttons)
        {
            RBtn1.Visible = false;
            RBtn2.Visible = false;
            RBtn3.Visible = false;

            switch (buttons)
            {
                case RMessageBoxButtons.OK:
                    //valor devuelto
                    resultadoBoton1 = RDialogResult.None;
                    resultadoBoton2 = RDialogResult.None;
                    resultadoBoton3 = RDialogResult.OK;

                    //Mostrar
                    RBtn3.Visible = true;

                    //Textos
                    RBtn1.Text = Traductor.Traducir("");
                    RBtn2.Text = Traductor.Traducir("");
                    RBtn3.Text = Traductor.Traducir("Ok");

                    break;
                case RMessageBoxButtons.OKCancel:
                    //valor devuelto
                    resultadoBoton1 = RDialogResult.None;
                    resultadoBoton2 = RDialogResult.OK;
                    resultadoBoton3 = RDialogResult.Cancel;

                    //Mostrar
                    RBtn2.Visible = true;
                    RBtn3.Visible = true;

                    //Textos
                    RBtn1.Text = Traductor.Traducir("");
                    RBtn2.Text = Traductor.Traducir("Ok");
                    RBtn3.Text = Traductor.Traducir("Cancel");

                    break;
                case RMessageBoxButtons.AbortRetryIgnore:
                    //valor devuelto
                    resultadoBoton1 = RDialogResult.Abort;
                    resultadoBoton2 = RDialogResult.Retry;
                    resultadoBoton3 = RDialogResult.Ignore;

                    //Mostrar
                    RBtn1.Visible = true;
                    RBtn2.Visible = true;
                    RBtn3.Visible = true;

                    //Textos
                    RBtn1.Text = Traductor.Traducir("Abort");
                    RBtn2.Text = Traductor.Traducir("Retry");
                    RBtn3.Text = Traductor.Traducir("Ignore");

                    break;
                case RMessageBoxButtons.YesNoCancel:
                    //valor devuelto
                    resultadoBoton1 = RDialogResult.Yes;
                    resultadoBoton2 = RDialogResult.No;
                    resultadoBoton3 = RDialogResult.Cancel;

                    //Mostrar
                    RBtn1.Visible = true;
                    RBtn2.Visible = true;
                    RBtn3.Visible = true;

                    //Textos
                    RBtn1.Text = Traductor.Traducir("Yes");
                    RBtn2.Text = Traductor.Traducir("No");
                    RBtn3.Text = Traductor.Traducir("Cancel");

                    break;
                case RMessageBoxButtons.YesNo:
                    //valor devuelto
                    resultadoBoton1 = RDialogResult.None;
                    resultadoBoton2 = RDialogResult.Yes;
                    resultadoBoton3 = RDialogResult.No;

                    //Mostrar
                    RBtn2.Visible = true;
                    RBtn3.Visible = true;

                    //Textos
                    RBtn1.Text = Traductor.Traducir("");
                    RBtn2.Text = Traductor.Traducir("Yes");
                    RBtn3.Text = Traductor.Traducir("No");

                    break;
                case RMessageBoxButtons.RetryCancel:
                    //valor devuelto
                    resultadoBoton1 = RDialogResult.None;
                    resultadoBoton2 = RDialogResult.Retry;
                    resultadoBoton3 = RDialogResult.Cancel;

                    //Mostrar
                    RBtn2.Visible = true;
                    RBtn3.Visible = true;

                    //Textos
                    RBtn1.Text = Traductor.Traducir("");
                    RBtn2.Text = Traductor.Traducir("Retry");
                    RBtn3.Text = Traductor.Traducir("Cancel");

                    break;
            }


        }

        #endregion

        #region -> Resultado
        public RDialogResult Resultado
        {
            get
            {
                return resultado;
            }

        }

        #endregion

        #region -> PPermitir el arrastre de la vantana

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        #region -> Resultados según boton

        private void RBtn1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            resultado = resultadoBoton1;
        }

        private void RBtn2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            resultado = resultadoBoton2;
        }


        private void RBtn3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            resultado = resultadoBoton3;
        }

        private void RBtn3_Enter(object sender, EventArgs e)
        {
            RBtn3.BorderSize = 1;
            RBtn3.BorderColor = Color.Red;
        }

        private void RBtn3_Leave(object sender, EventArgs e)
        {
            RBtn3.BorderSize = 0;
            RBtn3.BorderColor = Color.Red;
        }

        private void RBtn2_Enter(object sender, EventArgs e)
        {
            RBtn2.BorderSize = 1;
            RBtn2.BorderColor = Color.Red;
        }

        private void RBtn2_Leave(object sender, EventArgs e)
        {
            RBtn2.BorderSize = 0;
            RBtn2.BorderColor = Color.Red;
        }

        private void RBtn1_Enter(object sender, EventArgs e)
        {
            RBtn1.BorderSize = 1;
            RBtn1.BorderColor = Color.Red;
        }

        private void RBtn1_Leave(object sender, EventArgs e)
        {
            RBtn1.BorderSize = 0;
            RBtn1.BorderColor = Color.Red;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) // Cerrar con el Tecla Esc
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }
}
