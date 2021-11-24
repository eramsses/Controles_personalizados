using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class RCProgressBar : UserControl
    {
        private Color barColor = Color.DarkOrange;
        private Color barColor2 = Color.Purple;
        private Color interiorColor = Color.DimGray;
        private Color interiorColor2 = Color.Gainsboro;
        private Color fontColor = Color.FromArgb(64, 64, 64);

        private Font font = new Font("Arial", 20);

        private int barWidth = 20;
        private int value = 0;
        private int maximum = 100;
        private int minimum = 0;
        private string texto = "";
        private int progress = 10;
        private bool showText = true;
        private int startingAngle = -90;
        private int gradientAngleColorBar = 0;
        private int gradientAngleColorCenter = 0;


        public RCProgressBar()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Control_Resize);
        }

        #region ->  Propiedades de la barra de progreso

        public void Increment(int value = 1)
        {
            this.value += value;
            SetSliderValue();
            this.Invalidate();
        }

        [Category("R Control Bar")]
        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
                
                SetSliderValue();

                this.Invalidate();
            }
        }

        [Category("R Control Bar")]
        public int Maximum
        {
            get
            {
                return maximum;
            }

            set
            {
                maximum = value;
                SetSliderValue();
                this.Invalidate();
            }
        }

        [Category("R Control Bar")]
        public int Minimum
        {
            get
            {
                return minimum;
            }

            set
            {
                minimum = value;
                SetSliderValue();
                this.Invalidate();
            }
        }

        [Category("R Control Bar")]
        public int BarWidth
        {
            get
            {
                return barWidth;
            }

            set
            {
                ValidarGrosorDeBarra(value);
                this.Invalidate();
            }
        }




        [Category("R Control Bar")]
        public Color ProgressBarColor1
        {
            get
            {
                return barColor;
            }

            set
            {
                barColor = value;
                this.Invalidate();
            }
        }
        [Category("R Control Bar")]
        public Color ProgressBarColor2
        {
            get
            {
                return barColor2;
            }

            set
            {
                barColor2 = value;
                this.Invalidate();
            }
        }

        [Category("R Control Bar")]
        public int GradientAngleColorBar
        {
            get
            {
                return this.gradientAngleColorBar;
            }

            set
            {
                this.gradientAngleColorBar = value;

                this.Invalidate();
            }
        }

        [Category("R Control Bar")]
        public int StartingAngle
        {
            get
            {
                return this.startingAngle + 90;
            }

            set
            {
                this.startingAngle = value - 90;

                this.Invalidate();
            }
        }


        #endregion

        #region -> Propiedades del texto
        [Category("R Control Text")]
        public Color InteriorColor1
        {
            get
            {
                return interiorColor;
            }

            set
            {
                interiorColor = value;
                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public Color InteriorColor2
        {
            get
            {
                return interiorColor2;
            }

            set
            {
                interiorColor2 = value;
                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public int GradientAngleColorCenter
        {
            get
            {
                return this.gradientAngleColorCenter;
            }

            set
            {
                this.gradientAngleColorCenter = value;

                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                this.font = value;


                //ShowValueText();
                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public Color FontColor
        {
            get
            {
                return fontColor;
            }

            set
            {
                fontColor = value;
                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public bool ShowText
        {
            get
            {
                return showText;
            }

            set
            {
                showText = value;
                SetSliderValue();
                this.Invalidate();
            }
        }


        #endregion

        #region -> Metodos de la barra de progreso
        private void SetSliderValue()
        {
            //evitar que reciba valores mayores o menores
            if (this.value > this.maximum)
                this.value = this.maximum;
            else if (this.value < this.minimum)
                this.value = this.minimum;

            double scaleFactor = (((double)this.value - this.minimum) / ((double)this.maximum - this.minimum));
            progress = (int)(360 * scaleFactor);

            int valorTexto = (int)(scaleFactor * 100);

            if (this.showText) this.texto = valorTexto.ToString() + " %";
            else this.texto = "";



        }

        private void RCProgressBar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            //e.Graphics.RotateTransform(startingAngle);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle obj_rect = new Rectangle(0 - (this.Height / 2) + 3, 0 - (this.Height / 2) + 3, this.Width - 6, this.Height - 6);
            Rectangle obj_rect_grad = new Rectangle(0 - (this.Height / 2) + 2, 0 - (this.Height / 2) + 2, this.Width - 4, this.Height - 4);

            LinearGradientBrush gradientColorBrush = new LinearGradientBrush(obj_rect_grad, barColor, barColor2, gradientAngleColorBar);

            SolidBrush brush = new SolidBrush(barColor);

            Pen obj_pen = new Pen(gradientColorBrush);
            //Dibujar el Progreso
            e.Graphics.DrawPie(obj_pen, obj_rect, startingAngle, this.progress);
            e.Graphics.FillPie(gradientColorBrush, obj_rect, startingAngle, this.progress);



            //Circulo interior
            gradientColorBrush = new LinearGradientBrush(obj_rect, interiorColor, interiorColor2, gradientAngleColorCenter);
            brush = new SolidBrush(interiorColor);
            obj_pen = new Pen(gradientColorBrush);
            
            obj_rect = new Rectangle(0 - (this.Height / 2) + barWidth + 3, 0 - (this.Height / 2) + barWidth + 3, this.Width - (barWidth * 2) - 6, this.Height - (barWidth * 2) - 6);
            e.Graphics.DrawPie(obj_pen, obj_rect, 0, 360);
            e.Graphics.FillPie(gradientColorBrush, obj_rect, 0, 360);



            //Texto
            //e.Graphics.RotateTransform(-startingAngle);
            StringFormat ft = new StringFormat();
            ft.Alignment = StringAlignment.Center;
            ft.LineAlignment = StringAlignment.Center;

            SolidBrush textBrush = new SolidBrush(fontColor);

            e.Graphics.DrawString(this.texto, font, textBrush, obj_rect, ft);

        }

        private void Control_Resize(object sender, EventArgs e)
        {
            this.Width = this.Height;
            ValidarGrosorDeBarra(this.barWidth);
        }

        private void ValidarGrosorDeBarra(int value)
        {
            if (value < 0)
                BarWidth = 0;
            else if (value > ((this.Width / 2) - 5))
                BarWidth = (this.Width / 2) - 5;
            else
                barWidth = value;
        }

        #endregion

    }
}
