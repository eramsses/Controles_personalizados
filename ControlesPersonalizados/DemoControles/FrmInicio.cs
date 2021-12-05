using Notificaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlesPersonalizados;
using System.Threading;
using MessageBoxCustom;

namespace DemoControles
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private int i = 0;
        private bool subir = true;
        private bool barrasActivas = false;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPersonalizado.Checked)
            {
                LblPersonalizado.Text = "Personalizado  Encendido";
            }
            else
            {
                LblPersonalizado.Text = "Personalizado  Apagado";
            }

        }

        private void chkBtnDefecto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBtnDefecto.Checked)
            {
                lblDefecto.Text = "Con bordes";
                rPanelRounded1.BorderSize = 2;
            }
            else
            {
                lblDefecto.Text = "Sin bordes";
                rPanelRounded1.BorderSize = 0;
            }

        }

        private void chkBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkBtn.Checked)
            {
                lblChkRedondeado.Text = "Redondeado";
                rPanelRounded1.BorderRadius = 100;
            }
            else
            {
                lblChkRedondeado.Text = "Cuadrado";
                rPanelRounded1.BorderRadius = 0;
            }
        }

        private void erButton2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Hola Mundo!!!!", "Botón Personalizado", MessageBoxButtons.OK);
        }

        private void erButton1_Click(object sender, EventArgs e)
        {
            if (cmbMunicipios.SelectedItem != null)
            {
                String municipio = cmbMunicipios.SelectedItem.ToString();
                MessageBox.Show("El municipio es " + municipio);
            }
            else
            {
                MessageBox.Show("No hay ningún municipio seleccionado");
            }

        }

        private void erButton3_Click(object sender, EventArgs e)
        {
            if (cmb3.SelectedItem != null)
            {
                String municipio = cmb3.SelectedItem.ToString();
                MessageBox.Show("El municipio es " + municipio);
            }
            else
            {
                MessageBox.Show("No hay ningún municipio seleccionado");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (subir)
                i += 2;
            else
                i -= 2;

            if (i <= bp1.Minimum)
                subir = true;
            else if (i >= bp1.Maximum)
                subir = false;

            if (i < bp1.Minimum)
                i = bp1.Minimum;

            if (i > bp1.Maximum)
                i = bp1.Maximum;



            bp1.Value = i;


            foreach (RVProgressBar pbV in PnlBarrasProgreso.Controls.OfType<RVProgressBar>().ToList())
            {
                pbV.Value = i;
            }

            foreach (RHProgressBar pbH in PnlBarrasProgreso.Controls.OfType<RHProgressBar>().ToList())
            {
                pbH.Value = i;
            }

            foreach (RCProgressBar pbC in PnlBarrasProgreso.Controls.OfType<RCProgressBar>().ToList())
            {
                pbC.Value = i;
            }

            if (i >= bp1.Maximum)
            {
                //timer1.Stop();
                //i = 0;
            }


        }

        private void BtnActivarBarras_Click(object sender, EventArgs e)
        {
            if (!barrasActivas)
            {
                //bp0.Value = 0;
                //bp1.Value = 0;
                //bp2.Value = 0;
                //bp3.Value = 0;
                //bp4.Value = 0;
                //bp5.Value = 0;
                //bp6.Value = 0;

                //i = 0;

                timer1.Start();
                barrasActivas = true;

                BtnActivarBarras.Text = "Detener Barras";
            }
            else
            {
                timer1.Stop();
                barrasActivas = false;

                BtnActivarBarras.Text = "Iniciar Barras";
            }

        }

        private void erButton5_Click(object sender, EventArgs e)
        {
            String txtBox = txtBox1.Texts;
            MessageBox.Show(txtBox, "Mensaje");
        }

        private void erButton6_Click(object sender, EventArgs e)
        {
            String txtBox = txtBox0.Texts;
            MessageBox.Show(txtBox, "Mensaje");
        }

        private void BtnMostrarMensajeOK_Click(object sender, EventArgs e)
        {
            bool autoCerrar = chkCerrarMensaje.Checked;
            if (chkIncluirTitulo.Checked)
            {

                Notificacion.Mostrar(txtContenidoMensaje.Texts, txtContenidoTitulo.Texts, Notificacion.OK, autoCerrar);
            }
            else
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, "", Notificacion.OK, autoCerrar);
            }
        }

        private void BtnWarning_Click(object sender, EventArgs e)
        {
            bool autoCerrar = chkCerrarMensaje.Checked;
            if (chkIncluirTitulo.Checked)
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, txtContenidoTitulo.Texts, Notificacion.WARNING, autoCerrar);
            }
            else
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, "", Notificacion.WARNING, autoCerrar);
            }
        }

        private void btnMensajeError_Click(object sender, EventArgs e)
        {
            bool autoCerrar = chkCerrarMensaje.Checked;
            if (chkIncluirTitulo.Checked)
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, txtContenidoTitulo.Texts, Notificacion.ERROR, autoCerrar);
            }
            else
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, "", Notificacion.ERROR, autoCerrar);
            }
        }

        private void btnMensajeInformacion_Click(object sender, EventArgs e)
        {
            bool autoCerrar = chkCerrarMensaje.Checked;
            if (chkIncluirTitulo.Checked)
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, txtContenidoTitulo.Texts, Notificacion.INFO, autoCerrar);
            }
            else
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, "", Notificacion.INFO, autoCerrar);
            }
        }

        private void btnMensajeDefaul_Click(object sender, EventArgs e)
        {
            bool autoCerrar = chkCerrarMensaje.Checked;
            if (chkIncluirTitulo.Checked)
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, txtContenidoTitulo.Texts, null, autoCerrar);
            }
            else
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, "", null, autoCerrar);
            }
        }

        private void btnPersonalizado_Click(object sender, EventArgs e)
        {
            Notificacion.CUSTOM_OPACIDAD = 0.9;
            Notificacion.CUSTOM_COLOR_FONDO = Color.DarkBlue;
            Notificacion.CUSTOM_ICON = Properties.Resources.icons8_like_it_64px;
            Notificacion.CUSTOM_COLOR_TEXT = Color.FromArgb(220, 220, 220);
            Notificacion.CUSTOM_FONT_TITULO = new Font(base.Font.FontFamily, 8F, FontStyle.Bold);
            Notificacion.CUSTOM_FONT_MENSAJE = new Font("Century Gothic", 11.00F, FontStyle.Regular, GraphicsUnit.Point, 0); //new Font(base.Font.FontFamily, 8F, FontStyle.Regular);

            bool autoCerrar = chkCerrarMensaje.Checked;
            if (chkIncluirTitulo.Checked)
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, txtContenidoTitulo.Texts, Notificacion.CUSTOM_ICON, autoCerrar);
            }
            else
            {
                Notificacion.Mostrar(txtContenidoMensaje.Texts, "", Notificacion.CUSTOM_ICON, autoCerrar);
            }
        }

        private void erButton7_Click(object sender, EventArgs e)
        {
            //Notificacion.Mostrar(txt3.Texts, "Contenido", Notificacion.INFO, true);
            txtAppend.AppendTexts(txt3.Texts);
            txtAppend2.AppendTexts(txt3.Texts + "\r\n");
        }

        private void rButton1_Click(object sender, EventArgs e)
        {

            //Personalización


            //RMessageBox.HoldCustom = true;
            string[] b = { "Botón 1", "Botón 2", "Botón 3" };
            //RMessageBox.HeaderColor = Color.Gainsboro;

            string msj = "Mensaje estandar solo título y mensaje Color:" + this.BackColor.Name;
            RDialogResult r2 = RMessageBox.Show(Color.Empty, msj, "Titulo para mi mensaje");
            lblResultadoMsgBox.Text = r2.ToString();


            RMessageBox.HeaderColor = Color.Gainsboro;
            RMessageBox.BodyColor = Color.Aquamarine;
            RMessageBox.FooterColor = Color.NavajoWhite;
            RMessageBox.ButtonLeftColor = Color.Green;
            RMessageBox.ButtonCenterColor = Color.Red;
            RMessageBox.ButtonRightColor = Color.White;
            RMessageBox.HoldCustom = true;

            msj = "Personalizació de los colores en cada elemento, colores de los botones y manteniendo la configuración para los siguiente mensaje";
            r2 = RMessageBox.Show(this.BackColor, msj, "Titulo para mi mensaje", RMessageBoxButtons.YesNoCancel, RMessageBoxIcon.Information, RMessageBoxDefaultButton.Button1);
            lblResultadoMsgBox.Text = r2.ToString();


            RMessageBox.HoldCustom = false;
            RMessageBox.TextColor = Color.Violet;
            RMessageBox.BodyColor = Color.DarkViolet;

            msj = "Cambio en el color del texto y eliminar la personalización después de este mensaje, textos de los botones personalizado";
            r2 = RMessageBox.Show(this.BackColor, msj, "Titulo para mi mensaje", RMessageBoxButtons.AbortRetryIgnore, RMessageBoxIcon.Information, RMessageBoxDefaultButton.Button2, b);
            lblResultadoMsgBox.Text = r2.ToString();


            RMessageBox.ButtonLeftColor = Color.Green;
            RMessageBox.ButtonCenterColor = Color.Red;
            RMessageBox.ButtonRightColor = Color.White;
            RMessageBox.CustomIcon = Properties.Resources.rostro_mujer_adulta;

            msj = "Colores por defthis.BackColor, ecto cambio solo en los colores de los botones sin guardar la personalización para los demas mensajes";
            r2 = RMessageBox.Show(this.BackColor, msj, "Titulo para mi mensaje", RMessageBoxButtons.YesNoCancel, RMessageBoxIcon.Custom, RMessageBoxDefaultButton.Button3);
            lblResultadoMsgBox.Text = r2.ToString();

            msj = "Vuelve a la configuración por defecto automáticamente ";
            r2 = RMessageBox.Show(Color.Transparent, msj, "Titulo para mi mensaje", RMessageBoxButtons.YesNo, RMessageBoxIcon.Warning, RMessageBoxDefaultButton.Button2);

            lblResultadoMsgBox.Text = r2.ToString();
        }

        private void rhProgressBar2_MouseDown(object sender, MouseEventArgs e)
        {
            int x = rhProgressBar2.Location.X;
            int eX = e.Location.X;

            RMessageBox.Show(Color.Empty, x.ToString(), eX.ToString());
        }

    }
}
