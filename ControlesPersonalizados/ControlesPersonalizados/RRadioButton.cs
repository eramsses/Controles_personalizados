
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System;

namespace ControlesPersonalizados
{
    public partial class RRadioButton : RadioButton
    {
        #region -> Campos
        private Color checkedColor = Color.MediumSlateBlue;
        private Color unCheckedColor = Color.Gray;

        #endregion Campos

        #region -> Propiedades
        [Category("R Control")]
        public Color CheckedColor
        {
            get
            {
                return checkedColor;
            }

            set
            {
                checkedColor = value;
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public Color UnCheckedColor
        {
            get
            {
                return unCheckedColor;
            }

            set
            {
                unCheckedColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region -> Constructor

        public RRadioButton()
        {
            this.MinimumSize = new Size(0, 21);
            //Agregado de padding de 10 a la izquierda para tener espacio entre el texto y el RRadioButton.
            this.Padding = new Padding(10, 0, 0, 0);
            //this.BackColor = Color.FromArgb(0, 255, 255, 255);
        }

        #endregion

        #region Métodos
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;

            

            //Campos

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float rbBorderSize = 18F;
            float rbCheckSize = 12F;
            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y = (this.Height - rbBorderSize) / 2, //Center
                Width = rbBorderSize,
                Height = rbBorderSize
            };
            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2), //Center
                Y = (this.Height - rbCheckSize) / 2, //Center
                Width = rbCheckSize,
                Height = rbCheckSize
            };

            //Dibujando
            using (Pen penBorder = new Pen(checkedColor, 1.6F))
            using (SolidBrush brushRbCheck = new SolidBrush(checkedColor))
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))
            {
                //Dibujado de la superficie
                //graphics.Clear(this.BackColor);

                try
                {
                    if (this.BackColor == Color.Transparent)
                    {
                        if (this.Parent.GetType() == typeof(RPanelRounded))
                        {

                            RPanelRounded panelPadre = (RPanelRounded)this.Parent;
                            graphics.Clear(panelPadre.BackColor1);
                            //this.BackColor = panelPadre.BackColor1;
                        }
                        else
                        {
                            //this.BackColor = this.Parent.BackColor;
                            graphics.Clear(this.Parent.BackColor);
                        }
                    }
                }
                catch (Exception e)
                {
                    graphics.Clear(this.Parent.BackColor);
                }

                //Dibujando Radio Button
                if (this.Checked)
                {
                    graphics.DrawEllipse(penBorder, rectRbBorder);//Circle border
                    graphics.FillEllipse(brushRbCheck, rectRbCheck); //Circle Radio Check
                }
                else
                {
                    penBorder.Color = unCheckedColor;
                    graphics.DrawEllipse(penBorder, rectRbBorder); //Circle border
                }
                //Draw text
                graphics.DrawString(this.Text, this.Font, brushText,
                                rbBorderSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);//Y=Center
            }
        }

        #endregion

    }
}
