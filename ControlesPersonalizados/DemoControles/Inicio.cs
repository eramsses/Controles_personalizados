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

namespace DemoControles
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private int i = 0;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPersonalizado.Checked)
            {
                lblPersonalizado.Text = "Personalizado  Encendido";
            }
            else
            {
                lblPersonalizado.Text = "Personalizado  Apagado";
            }
            
        }

        private void chkBtnDefecto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBtnDefecto.Checked)
            {
                lblDefecto.Text = "Valores por defecto Encendido";
            }
            else
            {
                lblDefecto.Text = "Valores por defecto Apagado";
            }
            
        }

        private void chkBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkBtn.Checked)
            {
                lblChk.Text = "Encendido";
            }
            else
            {
                lblChk.Text = "Apagado";
            }
        }

        private void erButton2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Hola Mundo!!!!", "Botón Personalizado", MessageBoxButtons.OK);
        }

        private void erButton1_Click(object sender, EventArgs e)
        {
            if(cmbMunicipios.SelectedItem != null) 
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
            if(bp1.Maximum > i)
            {
                bp0.Value = i;
                bp1.Value = i;
                bp2.Value = i;
                bp3.Value = i;
                bp4.Value = i;
                bp5.Value = i;
                bp6.Value = i;

            }
            else
            {
                bp0.Value = 0;
                bp1.Value = 0;
                bp2.Value = 0;
                bp3.Value = 0;
                bp4.Value = 0;
                bp5.Value = 0;
                bp6.Value = 0;

                i = 0;
            }
            
            i += 10;
        }

        private void erButton4_Click(object sender, EventArgs e)
        {
            bp0.Value = 0;
            bp1.Value = 0;
            bp2.Value = 0;
            bp3.Value = 0;
            bp4.Value = 0;
            bp5.Value = 0;
            bp6.Value = 0;

            timer1.Start();
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

    }
}
