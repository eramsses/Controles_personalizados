namespace RMessageBoxCustom
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
            this.PnlBotones = new System.Windows.Forms.Panel();
            this.rButton3 = new ControlesPersonalizados.RButton();
            this.rButton2 = new ControlesPersonalizados.RButton();
            this.btnCancel = new ControlesPersonalizados.RButton();
            this.LblTitle = new System.Windows.Forms.Label();
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.PnlIcon = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PnlMensaje = new System.Windows.Forms.Panel();
            this.LblMensaje = new System.Windows.Forms.Label();
            this.PnlBotones.SuspendLayout();
            this.PnlTitulo.SuspendLayout();
            this.PnlIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnlMensaje.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlBotones
            // 
            this.PnlBotones.Controls.Add(this.rButton3);
            this.PnlBotones.Controls.Add(this.rButton2);
            this.PnlBotones.Controls.Add(this.btnCancel);
            this.PnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBotones.Location = new System.Drawing.Point(0, 171);
            this.PnlBotones.Margin = new System.Windows.Forms.Padding(5);
            this.PnlBotones.Name = "PnlBotones";
            this.PnlBotones.Size = new System.Drawing.Size(576, 69);
            this.PnlBotones.TabIndex = 1;
            // 
            // rButton3
            // 
            this.rButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rButton3.BackColor = System.Drawing.Color.DarkOrange;
            this.rButton3.BackGroundColor = System.Drawing.Color.DarkOrange;
            this.rButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rButton3.BorderRadius = 0;
            this.rButton3.BorderSize = 0;
            this.rButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.rButton3.FlatAppearance.BorderSize = 0;
            this.rButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.rButton3.Location = new System.Drawing.Point(119, 12);
            this.rButton3.Margin = new System.Windows.Forms.Padding(5);
            this.rButton3.Name = "rButton3";
            this.rButton3.Size = new System.Drawing.Size(141, 44);
            this.rButton3.TabIndex = 2;
            this.rButton3.Text = "rButton3";
            this.rButton3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.rButton3.UseVisualStyleBackColor = false;
            // 
            // rButton2
            // 
            this.rButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rButton2.BackColor = System.Drawing.Color.DarkOrange;
            this.rButton2.BackGroundColor = System.Drawing.Color.DarkOrange;
            this.rButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rButton2.BorderRadius = 0;
            this.rButton2.BorderSize = 0;
            this.rButton2.FlatAppearance.BorderSize = 0;
            this.rButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.rButton2.Location = new System.Drawing.Point(270, 12);
            this.rButton2.Margin = new System.Windows.Forms.Padding(5);
            this.rButton2.Name = "rButton2";
            this.rButton2.Size = new System.Drawing.Size(141, 44);
            this.rButton2.TabIndex = 1;
            this.rButton2.Text = "rButton2";
            this.rButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.rButton2.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancel.BackGroundColor = System.Drawing.Color.DarkOrange;
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnCancel.Location = new System.Drawing.Point(421, 12);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 44);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // LblTitle
            // 
            this.LblTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(9, 4);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(553, 31);
            this.LblTitle.TabIndex = 3;
            this.LblTitle.Text = " j;slkdaj f;lkasjd f;lksdj ;flkjaoifj sdfh sakdjhflksjdhf ileauffhs jdfh kan asuh" +
    "fkdsjfh lkuallfjshd ufhkea sfdsh fkasehreu fdsja kcsuagui cbb asdj fisadbfasuduf" +
    "";
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Controls.Add(this.LblTitle);
            this.PnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(576, 38);
            this.PnlTitulo.TabIndex = 6;
            // 
            // PnlIcon
            // 
            this.PnlIcon.Controls.Add(this.pictureBox1);
            this.PnlIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlIcon.Location = new System.Drawing.Point(0, 38);
            this.PnlIcon.Name = "PnlIcon";
            this.PnlIcon.Size = new System.Drawing.Size(99, 133);
            this.PnlIcon.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RMessageBoxCustom.Properties.Resources.icons8_ok_64px;
            this.pictureBox1.Location = new System.Drawing.Point(5, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PnlMensaje
            // 
            this.PnlMensaje.Controls.Add(this.LblMensaje);
            this.PnlMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMensaje.Location = new System.Drawing.Point(99, 38);
            this.PnlMensaje.Name = "PnlMensaje";
            this.PnlMensaje.Size = new System.Drawing.Size(477, 133);
            this.PnlMensaje.TabIndex = 8;
            // 
            // LblMensaje
            // 
            this.LblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblMensaje.Location = new System.Drawing.Point(6, 6);
            this.LblMensaje.Name = "LblMensaje";
            this.LblMensaje.Size = new System.Drawing.Size(468, 127);
            this.LblMensaje.TabIndex = 2;
            this.LblMensaje.Text = " j;slkdaj f;lkasjd f;lksdj ;flkjaoifj sdfh sakdjhflksjdhf ileauffhs jdfh kan asuh" +
    "fkdsjfh lkuallfjshd ufhkea sfdsh fkasehreu fdsja kcsuagui cbb asdj fisadbfasuduf" +
    "";
            // 
            // FrmRMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(576, 240);
            this.ControlBox = false;
            this.Controls.Add(this.PnlMensaje);
            this.Controls.Add(this.PnlIcon);
            this.Controls.Add(this.PnlTitulo);
            this.Controls.Add(this.PnlBotones);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.TopMost = true;
            this.PnlBotones.ResumeLayout(false);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnlMensaje.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlBotones;
        private ControlesPersonalizados.RButton btnCancel;
        private ControlesPersonalizados.RButton rButton3;
        private ControlesPersonalizados.RButton rButton2;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Panel PnlTitulo;
        private System.Windows.Forms.Panel PnlIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PnlMensaje;
        private System.Windows.Forms.Label LblMensaje;
    }
}

