using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    #region -> Enumeradores
    public enum HPositionText
    {
        Left,
        InSide,
        Right,
        None
    }

    public enum VPositionText
    {
        Up,
        Middle,
        Down,
        Sliding
    }

    public enum ModeColorVerticalBar
    {
        Solid,
        Gradient1,
        Gradient2

    }

    #endregion Enumeradores

    public partial class RVProgressBar : UserControl
    {

        #region -> Campos

        private static Color darkText = Color.FromArgb(64, 64, 64);
        private static Color ligthText = Color.FromArgb(220, 220, 220);


        private VPositionText verticalPositionText = VPositionText.Down;
        private HPositionText showTextValue = HPositionText.Right;
        private ModeColorVerticalBar modeColorVerticalBar = ModeColorVerticalBar.Gradient1;
        private Color barColor1 = Color.Lime;
        private Color barColor2 = Color.Purple;
        private bool showMaximun = false;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private int minimum = 0;
        private int maximum = 100;
        private int value = 0;
        private int barWidth = 10;
        private int angleColorBar = 90;

        private Color channelColor = Color.LightGray;

        private Color fontColor = Color.FromArgb(64, 64, 64);
        private Font font = new Font("Arial", 12);

        private int sliderHeight = 0;

        private string text = "";

        private bool showPercent = false;

        #endregion Campos

        #region -> Constructor
        public RVProgressBar()
        {
            InitializeComponent();

            this.Resize += new EventHandler(ProgressBar_Resize);
        }

        private void ProgressBar_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #endregion Constructor

        #region ->  Propiedades de la barra de progreso

        public void Increment(int value = 1)
        {
            this.value += value;
            
            this.Invalidate();
        }

        [Category("R Control Bar")]
        public int Minimum
        {
            get
            {
                return this.minimum;
            }

            set
            {
                this.minimum = value;
                this.Invalidate();
            }
        }

        [Category("R Control Bar")]
        public int Maximum
        {
            get
            {
                return this.maximum;
            }

            set
            {
                this.maximum = value;
                this.Invalidate();
            }
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

                if (value < 1)
                    value = 1;

                this.barWidth = value;
                this.Invalidate();

            }
        }
        [Category("R Control Bar")]
        public Color ProgressBarColor1
        {
            get
            {
                return barColor1;
            }

            set
            {
                barColor1 = value;
                //SetSliderValue();
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
                //SetSliderValue();
                this.Invalidate();
            }
        }


        [Category("R Control Bar")]
        public ModeColorVerticalBar ModeColorVerticalBar
        {
            get
            {
                return modeColorVerticalBar;
            }

            set
            {
                modeColorVerticalBar = value;
                //SetSliderValue();
                this.Invalidate();

            }
        }

        [Category("R Control Bar")]
        public Color BackgroundBarColor
        {
            get
            {
                return channelColor;
            }

            set
            {
                channelColor = value;
                this.Invalidate();
            }
        }


        [Category("R Control Bar")]
        public int AngleColorBar
        {
            get
            {
                return angleColorBar - 90;
            }
            set
            {
                angleColorBar = value + 90;
                //SetSliderValue();
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public Color RBackGrounColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;
                this.Invalidate();
            }
        }


        #endregion

        #region -> Propiedades del texto

        [Category("R Control Text")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                font = value;
                if (this.DesignMode)
                    UpdateControlWidth();

                this.Invalidate();
            }
        }



        [Category("R Control Text")]
        public string SymbolBefore
        {
            get { return symbolBefore; }
            set
            {
                symbolBefore = value;
                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public string SymbolAfter
        {
            get { return symbolAfter; }
            set
            {
                symbolAfter = value;
                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public HPositionText ShowText
        {
            get
            {
                return showTextValue;
            }

            set
            {
                showTextValue = value;
                this.Invalidate();

            }
        }

        [Category("R Control Text")]
        public VPositionText VerticalPositionText
        {
            get
            {
                return verticalPositionText;
            }

            set
            {
                verticalPositionText = value;
                this.Invalidate();

            }
        }

        [Category("R Control Text")]
        public bool ShowMaximun
        {
            get { return showMaximun; }
            set
            {
                showMaximun = value;
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
        public bool ShowPercent
        {
            get
            {
                return showPercent;
            }

            set
            {
                showPercent = value;
                this.Invalidate();
            }
        }


        #endregion

        #region -> Metodos de la barra de progreso

        private void RVProgressBar_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            //evitar que reciba valores mayores o menores
            if (this.value > this.maximum)
                this.value = this.maximum;
            else if (this.value < this.minimum)
                this.value = this.minimum;

            double scaleFactor = (((double)this.value - this.minimum) / ((double)this.maximum - this.minimum));
            sliderHeight = (int)(this.Height * scaleFactor);

            int txtWidth = TextRenderer.MeasureText(text, font).Width + 1;

            if (showTextValue == HPositionText.InSide && txtWidth > barWidth)
            {
                barWidth = txtWidth;
            }

            //preparar el texto
            if (showPercent)
            {
                int vP = (int)(scaleFactor * 100);
                text = vP.ToString() + " %";
            }
            else
            {
                text = symbolBefore + this.value.ToString() + symbolAfter;
                if (showMaximun) text = text + "/" + symbolBefore + this.maximum.ToString() + symbolAfter;
            }


            Point startPoint = GetStartPointBar();

            if (this.Parent.BackColor != null)
            {
                g.Clear(this.Parent.BackColor);
            }
            else
            {
                g.Clear(this.BackColor);
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;

            //Dibujar Channel
            Size sizeChannel = new Size(barWidth, this.Height);
            Rectangle rectangleChannel = new Rectangle(GetStartPointChannel(), sizeChannel);

            SolidBrush brushChannel = new SolidBrush(channelColor);

            g.FillRectangle(brushChannel, rectangleChannel);


            //Slider
            Size sizeSlider = new Size(barWidth, sliderHeight);
            Rectangle rectangleSlider = new Rectangle(startPoint, sizeSlider);




            
            switch (modeColorVerticalBar)
            {
                case ModeColorVerticalBar.Solid://Fondo Solido

                    using(SolidBrush brushSolidSlider = new SolidBrush(barColor1))
                    {
                        g.FillRectangle(brushSolidSlider, rectangleSlider);
                    }

                    break;

                case ModeColorVerticalBar.Gradient1://Color que avanza con el slider



                    if (sliderHeight > 0)
                    {
                        using (LinearGradientBrush gradientBrush = new LinearGradientBrush(rectangleSlider, barColor1, barColor2, angleColorBar))
                        {
                            g.FillRectangle(gradientBrush, rectangleSlider);
                        }   
                    }

                    break;

                case ModeColorVerticalBar.Gradient2:// Color ya esta  para toda la barra
                                                    

                    if (sliderHeight > 0)
                    {
                        using (LinearGradientBrush gradientBrushFull = new LinearGradientBrush(rectangleChannel, barColor1, barColor2, angleColorBar))
                        {
                            g.FillRectangle(gradientBrushFull, rectangleSlider);
                        }
                    }

                    break;

            }

            ShowValueText(g);
        }

        private Point GetStartPointBar()
        {
            Point p = new Point(0, 0);

            int txtWidth = TextRenderer.MeasureText(text, font).Width + 1;

            int posY = this.Height - sliderHeight;

            switch (showTextValue)
            {
                case HPositionText.Left://Texto a la izquierda
                    p = new Point(txtWidth + 1, posY);

                    break;
                case HPositionText.InSide://Texto dentro de la barra
                    p = new Point(0, posY);

                    break;
                case HPositionText.Right://Texto bajo la barra
                    p = new Point(0, posY);

                    break;
                case HPositionText.None:
                    p = new Point(0, posY);

                    break;
            }
            return p;
        }

        private Point GetStartPointChannel()
        {
            Point p = new Point(0, 0);

            int txtWidth = TextRenderer.MeasureText(text, font).Width + 1;

            int posY = this.Height - sliderHeight;

            switch (showTextValue)
            {
                case HPositionText.Left://Texto a la izquierda
                    p = new Point(txtWidth + 1, 0);

                    break;
                case HPositionText.InSide://Texto dentro de la barra
                    p = new Point(0, 0);

                    break;
                case HPositionText.Right://Texto bajo la barra
                    p = new Point(0, 0);

                    break;
                case HPositionText.None:
                    p = new Point(0, 0);

                    break;
            }
            return p;
        }


        #endregion

        #region -> Metodos Texto

        private void ShowValueText(Graphics g)
        {
            double scaleFactor = (((double)this.value - this.minimum) / ((double)this.maximum - this.minimum));

            Point startPoint = new Point(0, 0);
            Size sizeRecText = new Size(this.Width, this.Height);
            Rectangle rectangleText = new Rectangle(startPoint, sizeRecText);

            StringFormat ft = new StringFormat();
            ft.Alignment = StringAlignment.Center;
            ft.LineAlignment = StringAlignment.Center;

            SolidBrush textBrush = new SolidBrush(fontColor);


            switch (showTextValue)
            {
                case HPositionText.Left://Texto a la Izquierda
                    if (fontColor == darkText || fontColor == ligthText)
                    {
                        if (this.BackColor.GetBrightness() >= 0.6F)
                        {
                            this.fontColor = darkText;
                        }
                        else
                        {
                            this.fontColor = ligthText;
                        }
                    }


                    textBrush = new SolidBrush(fontColor);
                    ft.Alignment = StringAlignment.Near;

                    break;

                case HPositionText.InSide://Texto dentro de la barra
                    if (fontColor == darkText || fontColor == ligthText)
                    {
                        if (verticalPositionText == VPositionText.Sliding)
                        {
                            if (scaleFactor >= 0.1)
                            {
                                if (this.barColor2.GetBrightness() >= 0.6F)
                                {
                                    this.fontColor = darkText;
                                }
                                else
                                {
                                    this.fontColor = ligthText;
                                }
                            }
                            else
                            {
                                if (this.channelColor.GetBrightness() >= 0.6F)
                                {
                                    this.fontColor = darkText;
                                }
                                else
                                {
                                    this.fontColor = ligthText;
                                }
                            }
                        }
                        else if (verticalPositionText == VPositionText.Down)
                        {
                            if (scaleFactor >= 0.1)
                            {
                                if (this.barColor1.GetBrightness() >= 0.6F)
                                {
                                    this.fontColor = darkText;
                                }
                                else
                                {
                                    this.fontColor = ligthText;
                                }
                            }
                            else
                            {
                                if (this.channelColor.GetBrightness() >= 0.6F)
                                {
                                    this.fontColor = darkText;
                                }
                                else
                                {
                                    this.fontColor = ligthText;
                                }
                            }
                        }
                        else if (verticalPositionText == VPositionText.Up)
                        {
                            if (scaleFactor >= 0.95)
                            {
                                if (this.barColor2.GetBrightness() >= 0.6F)
                                {
                                    this.fontColor = darkText;
                                }
                                else
                                {
                                    this.fontColor = ligthText;
                                }
                            }
                            else
                            {
                                if (this.channelColor.GetBrightness() >= 0.6F)
                                {
                                    this.fontColor = darkText;
                                }
                                else
                                {
                                    this.fontColor = ligthText;
                                }
                            }
                        }
                        else if (verticalPositionText == VPositionText.Middle)
                        {
                            if (scaleFactor >= 0.5)
                            {
                                if (this.barColor1.GetBrightness() >= 0.6F)
                                {
                                    this.fontColor = darkText;
                                }
                                else
                                {
                                    this.fontColor = ligthText;
                                }
                            }
                            else
                            {
                                if (this.channelColor.GetBrightness() >= 0.6F)
                                {
                                    this.fontColor = darkText;
                                }
                                else
                                {
                                    this.fontColor = ligthText;
                                }
                            }
                        }
                    }

                    textBrush = new SolidBrush(fontColor);
                    ft.Alignment = StringAlignment.Center;
                    break;

                case HPositionText.Right://Texto a la derecha
                    if (fontColor == darkText || fontColor == ligthText)
                    {
                        if (this.BackColor.GetBrightness() >= 0.6F)
                        {
                            this.fontColor = darkText;
                        }
                        else
                        {
                            this.fontColor = ligthText;
                        }
                    }
                    textBrush = new SolidBrush(fontColor);
                    ft.Alignment = StringAlignment.Far;

                    break;

                case HPositionText.None:

                    text = "";

                    break;
            }

            switch (verticalPositionText)
            {
                case VPositionText.Down://Texto abajo

                    ft.LineAlignment = StringAlignment.Far;

                    break;

                case VPositionText.Middle://Texto al medio

                    ft.LineAlignment = StringAlignment.Center;

                    break;

                case VPositionText.Up://Texto arriba

                    ft.LineAlignment = StringAlignment.Near;

                    break;

                case VPositionText.Sliding:

                    int txtHeight = TextRenderer.MeasureText(this.text, font).Height + 1;
                    int h = this.Height - sliderHeight;
                    int hM = this.Height - txtHeight;

                    if (h > hM)
                        h = hM;

                    //if (h < txtHeight)
                    //    h = txtHeight;

                    startPoint.Y = h;
                    ft.LineAlignment = StringAlignment.Near;
                    sizeRecText = new Size(this.Width, txtHeight);
                    rectangleText = new Rectangle(startPoint, sizeRecText);

                    break;
            }

            g.DrawString(this.text, font, textBrush, rectangleText, ft);

            UpdateControlWidth();
        }



        #endregion

        #region Metodos para el control
        private void UpdateControlWidth()
        {
            
            int txtWidth = TextRenderer.MeasureText(this.text, font).Width + 1;

            //Altura de los textos


            switch (showTextValue)
            {

                case HPositionText.None:
                    HacerCambio(() => this.Width = barWidth);

                    break;

                case HPositionText.InSide:

                    if (txtWidth > barWidth)
                    {
                        barWidth = txtWidth;
                    }

                    HacerCambio(() => this.Width = barWidth);

                    break;

                default:
                    
                    HacerCambio(() => this.Width = txtWidth + barWidth + 1);
                    break;


            }
        }

        private void HacerCambio(Action action)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(action);
                }
                else
                {
                    action();
                }
            }
            catch (Exception ex)
            {

            }




        }

        #endregion


    }
}
