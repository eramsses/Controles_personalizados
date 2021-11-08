namespace Notificaciones
{
    partial class FrmNotificaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtTitulo = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pgrsBarCerrar = new System.Windows.Forms.ProgressBar();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.picIcono = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(66, 9);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(239, 20);
            this.txtTitulo.TabIndex = 6;
            this.txtTitulo.MouseEnter += new System.EventHandler(this.TxtTitulo_MouseEnter);
            this.txtTitulo.MouseLeave += new System.EventHandler(this.TxtTitulo_MouseLeave);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMensaje.Location = new System.Drawing.Point(67, 34);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(271, 93);
            this.txtMensaje.TabIndex = 7;
            this.txtMensaje.Text = "Mensaje";
            this.txtMensaje.MouseEnter += new System.EventHandler(this.TxtMensaje_MouseEnter);
            this.txtMensaje.MouseLeave += new System.EventHandler(this.TxtMensaje_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pgrsBarCerrar
            // 
            this.pgrsBarCerrar.Location = new System.Drawing.Point(5, 144);
            this.pgrsBarCerrar.Name = "pgrsBarCerrar";
            this.pgrsBarCerrar.Size = new System.Drawing.Size(340, 1);
            this.pgrsBarCerrar.TabIndex = 8;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::Notificaciones.Properties.Resources.icons8_close_window_32px_2;
            this.btnCerrar.Location = new System.Drawing.Point(320, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 29);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.BtnCerrar_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.BtnCerrar_MouseLeave);
            // 
            // picIcono
            // 
            this.picIcono.Location = new System.Drawing.Point(12, 55);
            this.picIcono.Name = "picIcono";
            this.picIcono.Size = new System.Drawing.Size(50, 50);
            this.picIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcono.TabIndex = 5;
            this.picIcono.TabStop = false;
            this.picIcono.MouseEnter += new System.EventHandler(this.PicIcono_MouseEnter);
            this.picIcono.MouseLeave += new System.EventHandler(this.PicIcono_MouseLeave);
            // 
            // FrmNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(350, 150);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pgrsBarCerrar);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.picIcono);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotificaciones";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmNotificaciones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmNotificaciones_Load);
            this.MouseEnter += new System.EventHandler(this.FrmNotificaciones_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FrmNotificaciones_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcono;
        private System.Windows.Forms.Label txtTitulo;
        internal System.Windows.Forms.Label txtMensaje;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar pgrsBarCerrar;
        private System.Windows.Forms.PictureBox btnCerrar;
    }
}