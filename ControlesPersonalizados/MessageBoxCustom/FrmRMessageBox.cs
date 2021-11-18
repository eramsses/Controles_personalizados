using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxCustom
{
    public partial class FrmRMessageBox : Form
    {
        private RDialogResult resultado = RDialogResult.None;
        private RDialogResult resultadoBoton1 = RDialogResult.None;
        private RDialogResult resultadoBoton2 = RDialogResult.None;
        private RDialogResult resultadoBoton3 = RDialogResult.None;


        private string idioma = Thread.CurrentThread.CurrentCulture.ToString();



        #region Constructores
        public FrmRMessageBox()
        {
            InitializeComponent();

        }

        public FrmRMessageBox(string mensaje, string titulo, RMessageBoxButtons buttons, Image icon, RMessageBoxDefaultButton buttonDefault)
        {
            InitializeComponent();
            this.LblTitulo.Text = titulo;
            this.LblMensaje.Text = mensaje;
            MostrarBotones(buttons);
            PicIcon.Image = icon;


            if (icon == null)
            {
                PnlIcono.Visible = false;
            }

            SetDefaultButton(buttonDefault);
        }


        #endregion

        #region Contrucción de Botones


        private void SetDefaultButton(RMessageBoxDefaultButton buttonDefault)
        {

            
            switch (buttonDefault)
            {
                case RMessageBoxDefaultButton.None:
                    this.ActiveControl = null;

                    break;
                case RMessageBoxDefaultButton.Button1:
                    this.ActiveControl = RBtn3;
                    break;
                case RMessageBoxDefaultButton.Button2:
                    this.ActiveControl = RBtn2;
                    break;
                case RMessageBoxDefaultButton.Button3:
                    this.ActiveControl = RBtn1;
                    break;
                default:

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

        public RDialogResult Resultado
        {
            get
            {
                return resultado;
            }

        }

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


    }
}
