namespace ControlesPersonalizados
{
    partial class RProgressBar
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
            this.LblText = new System.Windows.Forms.Label();
            this.PnlChannel = new System.Windows.Forms.Panel();
            this.PnlSlider = new System.Windows.Forms.Panel();
            this.LblTextI = new System.Windows.Forms.Label();
            this.LblTextU = new System.Windows.Forms.Label();
            this.LblTextO = new System.Windows.Forms.Label();
            this.PnlChannel.SuspendLayout();
            this.PnlSlider.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblText
            // 
            this.LblText.BackColor = System.Drawing.Color.Gray;
            this.LblText.Location = new System.Drawing.Point(70, 141);
            this.LblText.Name = "LblText";
            this.LblText.Size = new System.Drawing.Size(350, 17);
            this.LblText.TabIndex = 1;
            // 
            // PnlChannel
            // 
            this.PnlChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlChannel.BackColor = System.Drawing.Color.Gainsboro;
            this.PnlChannel.Controls.Add(this.PnlSlider);
            this.PnlChannel.Location = new System.Drawing.Point(0, 23);
            this.PnlChannel.Name = "PnlChannel";
            this.PnlChannel.Size = new System.Drawing.Size(539, 48);
            this.PnlChannel.TabIndex = 2;
            // 
            // PnlSlider
            // 
            this.PnlSlider.BackColor = System.Drawing.Color.Lime;
            this.PnlSlider.Controls.Add(this.LblTextI);
            this.PnlSlider.Location = new System.Drawing.Point(0, 0);
            this.PnlSlider.Name = "PnlSlider";
            this.PnlSlider.Size = new System.Drawing.Size(203, 48);
            this.PnlSlider.TabIndex = 3;
            // 
            // LblTextI
            // 
            this.LblTextI.BackColor = System.Drawing.Color.Gray;
            this.LblTextI.Location = new System.Drawing.Point(3, 10);
            this.LblTextI.Name = "LblTextI";
            this.LblTextI.Size = new System.Drawing.Size(37, 20);
            this.LblTextI.TabIndex = 8;
            // 
            // LblTextU
            // 
            this.LblTextU.BackColor = System.Drawing.Color.Gray;
            this.LblTextU.Location = new System.Drawing.Point(3, 74);
            this.LblTextU.Name = "LblTextU";
            this.LblTextU.Size = new System.Drawing.Size(37, 20);
            this.LblTextU.TabIndex = 4;
            // 
            // LblTextO
            // 
            this.LblTextO.BackColor = System.Drawing.Color.Gray;
            this.LblTextO.Location = new System.Drawing.Point(3, 0);
            this.LblTextO.Name = "LblTextO";
            this.LblTextO.Size = new System.Drawing.Size(37, 20);
            this.LblTextO.TabIndex = 7;
            // 
            // RProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LblTextO);
            this.Controls.Add(this.LblTextU);
            this.Controls.Add(this.PnlChannel);
            this.Controls.Add(this.LblText);
            this.Name = "RProgressBar";
            this.Size = new System.Drawing.Size(539, 262);
            this.PnlChannel.ResumeLayout(false);
            this.PnlSlider.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LblText;
        private System.Windows.Forms.Panel PnlChannel;
        private System.Windows.Forms.Panel PnlSlider;
        private System.Windows.Forms.Label LblTextU;
        private System.Windows.Forms.Label LblTextO;
        private System.Windows.Forms.Label LblTextI;
    }
}
