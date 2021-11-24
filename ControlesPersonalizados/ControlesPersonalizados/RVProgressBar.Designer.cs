namespace ControlesPersonalizados
{
    partial class RVProgressBar
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblTextL = new System.Windows.Forms.Label();
            this.LblTextC = new System.Windows.Forms.Label();
            this.LblTextR = new System.Windows.Forms.Label();
            this.PnlChannel = new System.Windows.Forms.Panel();
            this.PnlSlider = new System.Windows.Forms.Panel();
            this.PnlChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTextL
            // 
            this.LblTextL.AutoSize = true;
            this.LblTextL.Location = new System.Drawing.Point(3, 276);
            this.LblTextL.Name = "LblTextL";
            this.LblTextL.Size = new System.Drawing.Size(13, 13);
            this.LblTextL.TabIndex = 0;
            this.LblTextL.Text = "0";
            this.LblTextL.Visible = false;
            // 
            // LblTextC
            // 
            this.LblTextC.AutoSize = true;
            this.LblTextC.Location = new System.Drawing.Point(38, 196);
            this.LblTextC.Name = "LblTextC";
            this.LblTextC.Size = new System.Drawing.Size(13, 13);
            this.LblTextC.TabIndex = 1;
            this.LblTextC.Text = "0";
            // 
            // LblTextR
            // 
            this.LblTextR.AutoSize = true;
            this.LblTextR.Location = new System.Drawing.Point(143, 276);
            this.LblTextR.Name = "LblTextR";
            this.LblTextR.Size = new System.Drawing.Size(13, 13);
            this.LblTextR.TabIndex = 2;
            this.LblTextR.Text = "0";
            // 
            // PnlChannel
            // 
            this.PnlChannel.BackColor = System.Drawing.Color.Gainsboro;
            this.PnlChannel.Controls.Add(this.LblTextC);
            this.PnlChannel.Controls.Add(this.PnlSlider);
            this.PnlChannel.Location = new System.Drawing.Point(44, 0);
            this.PnlChannel.Name = "PnlChannel";
            this.PnlChannel.Size = new System.Drawing.Size(93, 289);
            this.PnlChannel.TabIndex = 3;
            // 
            // PnlSlider
            // 
            this.PnlSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PnlSlider.Location = new System.Drawing.Point(0, 223);
            this.PnlSlider.Name = "PnlSlider";
            this.PnlSlider.Size = new System.Drawing.Size(93, 66);
            this.PnlSlider.TabIndex = 0;
            // 
            // RVProgressBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.PnlChannel);
            this.Controls.Add(this.LblTextR);
            this.Controls.Add(this.LblTextL);
            this.DoubleBuffered = true;
            this.Name = "RVProgressBar";
            this.Size = new System.Drawing.Size(177, 292);
            this.PnlChannel.ResumeLayout(false);
            this.PnlChannel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTextL;
        private System.Windows.Forms.Label LblTextC;
        private System.Windows.Forms.Label LblTextR;
        private System.Windows.Forms.Panel PnlChannel;
        private System.Windows.Forms.Panel PnlSlider;
    }
}
