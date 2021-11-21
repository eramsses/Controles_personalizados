namespace MessageBoxCustom
{
    partial class FrmRMessageBox
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.PnlBotones = new System.Windows.Forms.Panel();
            this.RBtn3 = new ControlesPersonalizados.RButton();
            this.RBtn2 = new ControlesPersonalizados.RButton();
            this.RBtn1 = new ControlesPersonalizados.RButton();
            this.PnlIcono = new System.Windows.Forms.Panel();
            this.PicIcon = new System.Windows.Forms.PictureBox();
            this.PnlMensaje = new System.Windows.Forms.Panel();
            this.LblMensaje = new System.Windows.Forms.Label();
            this.PnlTitulo.SuspendLayout();
            this.PnlBotones.SuspendLayout();
            this.PnlIcono.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcon)).BeginInit();
            this.PnlMensaje.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PnlTitulo.Controls.Add(this.LblTitulo);
            this.PnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.PnlTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(439, 43);
            this.PnlTitulo.TabIndex = 0;
            this.PnlTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitulo_MouseDown);
            // 
            // LblTitulo
            // 
            this.LblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulo.Location = new System.Drawing.Point(13, 12);
            this.LblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(402, 22);
            this.LblTitulo.TabIndex = 0;
            this.LblTitulo.Text = "Título";
            this.LblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // PnlBotones
            // 
            this.PnlBotones.Controls.Add(this.RBtn3);
            this.PnlBotones.Controls.Add(this.RBtn2);
            this.PnlBotones.Controls.Add(this.RBtn1);
            this.PnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBotones.Location = new System.Drawing.Point(0, 159);
            this.PnlBotones.Margin = new System.Windows.Forms.Padding(4);
            this.PnlBotones.Name = "PnlBotones";
            this.PnlBotones.Size = new System.Drawing.Size(439, 54);
            this.PnlBotones.TabIndex = 1;
            // 
            // RBtn3
            // 
            this.RBtn3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RBtn3.BackColor = System.Drawing.Color.DarkOrange;
            this.RBtn3.BackGroundColor = System.Drawing.Color.DarkOrange;
            this.RBtn3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RBtn3.BorderRadius = 0;
            this.RBtn3.BorderSize = 0;
            this.RBtn3.FlatAppearance.BorderSize = 0;
            this.RBtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RBtn3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtn3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RBtn3.Location = new System.Drawing.Point(322, 10);
            this.RBtn3.Name = "RBtn3";
            this.RBtn3.Size = new System.Drawing.Size(108, 34);
            this.RBtn3.TabIndex = 2;
            this.RBtn3.Text = "Aceptar";
            this.RBtn3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RBtn3.UseVisualStyleBackColor = false;
            this.RBtn3.Click += new System.EventHandler(this.RBtn3_Click);
            this.RBtn3.Enter += new System.EventHandler(this.RBtn3_Enter);
            this.RBtn3.Leave += new System.EventHandler(this.RBtn3_Leave);
            // 
            // RBtn2
            // 
            this.RBtn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RBtn2.BackColor = System.Drawing.Color.DarkOrange;
            this.RBtn2.BackGroundColor = System.Drawing.Color.DarkOrange;
            this.RBtn2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RBtn2.BorderRadius = 0;
            this.RBtn2.BorderSize = 0;
            this.RBtn2.FlatAppearance.BorderSize = 0;
            this.RBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RBtn2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RBtn2.Location = new System.Drawing.Point(208, 10);
            this.RBtn2.Name = "RBtn2";
            this.RBtn2.Size = new System.Drawing.Size(108, 34);
            this.RBtn2.TabIndex = 1;
            this.RBtn2.Text = "Reintentar";
            this.RBtn2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RBtn2.UseVisualStyleBackColor = false;
            this.RBtn2.Click += new System.EventHandler(this.RBtn2_Click);
            this.RBtn2.Enter += new System.EventHandler(this.RBtn2_Enter);
            this.RBtn2.Leave += new System.EventHandler(this.RBtn2_Leave);
            // 
            // RBtn1
            // 
            this.RBtn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RBtn1.BackColor = System.Drawing.Color.DarkOrange;
            this.RBtn1.BackGroundColor = System.Drawing.Color.DarkOrange;
            this.RBtn1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RBtn1.BorderRadius = 0;
            this.RBtn1.BorderSize = 0;
            this.RBtn1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RBtn1.FlatAppearance.BorderSize = 0;
            this.RBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RBtn1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RBtn1.Location = new System.Drawing.Point(94, 10);
            this.RBtn1.Name = "RBtn1";
            this.RBtn1.Size = new System.Drawing.Size(108, 34);
            this.RBtn1.TabIndex = 0;
            this.RBtn1.Text = "Cancelar";
            this.RBtn1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RBtn1.UseVisualStyleBackColor = false;
            this.RBtn1.Click += new System.EventHandler(this.RBtn1_Click);
            this.RBtn1.Enter += new System.EventHandler(this.RBtn1_Enter);
            this.RBtn1.Leave += new System.EventHandler(this.RBtn1_Leave);
            // 
            // PnlIcono
            // 
            this.PnlIcono.Controls.Add(this.PicIcon);
            this.PnlIcono.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlIcono.Location = new System.Drawing.Point(0, 43);
            this.PnlIcono.Margin = new System.Windows.Forms.Padding(4);
            this.PnlIcono.Name = "PnlIcono";
            this.PnlIcono.Size = new System.Drawing.Size(86, 116);
            this.PnlIcono.TabIndex = 1;
            // 
            // PicIcon
            // 
            this.PicIcon.Image = global::MessageBoxCustom.Properties.Resources.OK_light_50px;
            this.PicIcon.Location = new System.Drawing.Point(9, 23);
            this.PicIcon.Margin = new System.Windows.Forms.Padding(4);
            this.PicIcon.Name = "PicIcon";
            this.PicIcon.Size = new System.Drawing.Size(64, 64);
            this.PicIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicIcon.TabIndex = 2;
            this.PicIcon.TabStop = false;
            // 
            // PnlMensaje
            // 
            this.PnlMensaje.Controls.Add(this.LblMensaje);
            this.PnlMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMensaje.Location = new System.Drawing.Point(86, 43);
            this.PnlMensaje.Margin = new System.Windows.Forms.Padding(4);
            this.PnlMensaje.Name = "PnlMensaje";
            this.PnlMensaje.Size = new System.Drawing.Size(353, 116);
            this.PnlMensaje.TabIndex = 1;
            // 
            // LblMensaje
            // 
            this.LblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblMensaje.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMensaje.Location = new System.Drawing.Point(12, 4);
            this.LblMensaje.Name = "LblMensaje";
            this.LblMensaje.Size = new System.Drawing.Size(317, 108);
            this.LblMensaje.TabIndex = 0;
            this.LblMensaje.Text = "label1";
            // 
            // FrmRMessageBox
            // 
            this.AcceptButton = this.RBtn3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.RBtn1;
            this.ClientSize = new System.Drawing.Size(439, 213);
            this.ControlBox = false;
            this.Controls.Add(this.PnlMensaje);
            this.Controls.Add(this.PnlIcono);
            this.Controls.Add(this.PnlBotones);
            this.Controls.Add(this.PnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRMessageBox_KeyDown);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlBotones.ResumeLayout(false);
            this.PnlIcono.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicIcon)).EndInit();
            this.PnlMensaje.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel PnlBotones;
        private System.Windows.Forms.Panel PnlIcono;
        private System.Windows.Forms.PictureBox PicIcon;
        private System.Windows.Forms.Panel PnlMensaje;
        private System.Windows.Forms.Label LblMensaje;
        private ControlesPersonalizados.RButton RBtn3;
        private ControlesPersonalizados.RButton RBtn2;
        private ControlesPersonalizados.RButton RBtn1;
    }
}

