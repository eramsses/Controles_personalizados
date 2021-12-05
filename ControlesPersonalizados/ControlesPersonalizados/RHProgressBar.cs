using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ControlesPersonalizados
{

    #region -> Enumeradores

    public enum HorizontalPositionText
    {
        Left,
        Right,
        Center,
        Sliding
    }

    public enum TextVerticalPosition
    {
        Over,
        InSide,
        Under,
        None
    }

    public enum ModeColorHorizontalBar
    {
        Solid,
        Gradient1,
        Gradient2

    }
    #endregion Enumeradores

    public partial class RHProgressBar : UserControl
    {
        #region -> Campos

        private static Color darkText = Color.FromArgb(64, 64, 64);
        private static Color ligthText = Color.FromArgb(220, 220, 220);


        private TextVerticalPosition showTextValue = TextVerticalPosition.Over;
        private HorizontalPositionText horizontalPositionText = HorizontalPositionText.Right;
        private ModeColorHorizontalBar modeColorHorizontalBar = ModeColorHorizontalBar.Gradient1;
        private Color barColor1 = Color.Lime;
        private Color barColor2 = Color.Purple;
        private Color channelColor = Color.LightGray;

        private Color fontColor = Color.FromArgb(64, 64, 64);
        private Font font = new Font("Arial", 12);

        private bool showMaximun = false;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private int minimum = 0;
        private int maximum = 100;
        private int value = 0;
        private int barHeight = 5;
        private int angleColorBar = 0;

        private bool showPercent = false;

        private int sliderWidth = 0;

        private string text = "";

        #endregion Campos

        #region -> Constructor

        public RHProgressBar()
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

        public void Increment(int value = 1)
        {
            this.value += value;
            this.Invalidate();
        }

        [Category("R Control Bar")]
        public int BarHeight
        {
            get
            {
                return barHeight;
            }

            set
            {
                barHeight = value;
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
        public ModeColorHorizontalBar ModeColorHorizontalBar
        {
            get
            {
                return modeColorHorizontalBar;
            }

            set
            {
                modeColorHorizontalBar = value;
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

        [Category("R Control")]
        public Color RBackGroundColor
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

        [Category("R Control Bar")]
        public int AngleColorBar
        {
            get
            {
                return angleColorBar;
            }
            set
            {
                angleColorBar = value;
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
                    UpdateControlHeight();

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
        public HorizontalPositionText HorizontalPositionText
        {
            get
            {
                return horizontalPositionText;
            }

            set
            {
                horizontalPositionText = value;
                this.Invalidate();

            }
        }

        [Category("R Control Text")]
        public TextVerticalPosition ShowText
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
        public Color TextColor
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

        private void RHProgressBar_Paint(object sender, PaintEventArgs e)
        {
            //evitar que reciba valores mayores o menores
            if (this.value > this.maximum)
                this.value = this.maximum;
            else if (this.value < this.minimum)
                this.value = this.minimum;

            int txtHeight = TextRenderer.MeasureText("Text", font).Height + 1;

            if (showTextValue == TextVerticalPosition.InSide && txtHeight > barHeight)
            {
                barHeight = txtHeight;
            }

            Graphics g = e.Graphics;
            double scaleFactor = (((double)this.value - this.minimum) / ((double)this.maximum - this.minimum));
            sliderWidth = (int)(this.Width * scaleFactor);

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
            Size sizeChannel = new Size(this.Width, barHeight);
            Rectangle rectangleChannel = new Rectangle(startPoint, sizeChannel);

            SolidBrush brushChannel = new SolidBrush(channelColor);

            g.FillRectangle(brushChannel, rectangleChannel);


            //Slider
            Size sizeSlider = new Size(sliderWidth, barHeight);
            Rectangle rectangleSlider = new Rectangle(startPoint, sizeSlider);

            switch (modeColorHorizontalBar)
            {
                case ModeColorHorizontalBar.Solid://Fondo Solido

                    using (SolidBrush brushSolidSlider = new SolidBrush(barColor1))
                    {
                        g.FillRectangle(brushSolidSlider, rectangleSlider);
                    }

                    break;

                case ModeColorHorizontalBar.Gradient1://Color que avanza con el slider

                    if (sliderWidth > 0)
                    {
                        using (LinearGradientBrush gradientBrush = new LinearGradientBrush(rectangleSlider, barColor1, barColor2, angleColorBar))
                        {
                            g.FillRectangle(gradientBrush, rectangleSlider);
                        }
                    }

                    break;

                case ModeColorHorizontalBar.Gradient2:// Color ya esta para toda la barra

                    if (sliderWidth > 0)
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

            int txtHeight = TextRenderer.MeasureText("Text", font).Height + 1;

            switch (showTextValue)
            {
                case TextVerticalPosition.Over://Texto sobre la barra
                    p = new Point(0, txtHeight + 1);

                    break;
                case TextVerticalPosition.InSide://Texto dentro de la barra
                    p = new Point(0, 0);

                    break;
                case TextVerticalPosition.Under://Texto bajo la barra
                    p = new Point(0, 0);

                    break;
                case TextVerticalPosition.None:
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


            Point startPoint = new Point(0, 0);
            Size sizeRecText = new Size(this.Width, this.Height);
            Rectangle rectangleText = new Rectangle(startPoint, sizeRecText);

            StringFormat ft = new StringFormat();
            ft.Alignment = StringAlignment.Center;
            ft.LineAlignment = StringAlignment.Center;

            SolidBrush textBrush = new SolidBrush(fontColor);

            switch (showTextValue)
            {
                case TextVerticalPosition.Over://Texto sobre la barra a la izquierda
                    if(fontColor == darkText || fontColor == ligthText)
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
                    ft.LineAlignment = StringAlignment.Near;

                    break;

                case TextVerticalPosition.InSide://Texto dentro a la izquierda
                    if (fontColor == darkText || fontColor == ligthText)
                    {
                        if (HorizontalPositionText == HorizontalPositionText.Sliding)
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
                        else if (HorizontalPositionText == HorizontalPositionText.Left)
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
                        else if (HorizontalPositionText == HorizontalPositionText.Right)
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
                        else if (HorizontalPositionText == HorizontalPositionText.Center)
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
                    ft.LineAlignment = StringAlignment.Center;

                    break;

                case TextVerticalPosition.Under://Texto abajo a la izquierda
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
                    ft.LineAlignment = StringAlignment.Far;

                    break;

                case TextVerticalPosition.None://Sin texto
                    text = "";

                    break;
            }

            switch (horizontalPositionText)
            {
                case HorizontalPositionText.Left://Texto a la izquierda

                    ft.Alignment = StringAlignment.Near;

                    break;

                case HorizontalPositionText.Center://Texto centrado

                    ft.Alignment = StringAlignment.Center;

                    break;

                case HorizontalPositionText.Right://Texto a la derecha

                    ft.Alignment = StringAlignment.Far;

                    break;

                case HorizontalPositionText.Sliding:

                    int txtWidth = TextRenderer.MeasureText(this.text, font).Width + 1;
                    int w = sliderWidth;

                    if (sliderWidth < txtWidth)
                        w = txtWidth;

                    ft.Alignment = StringAlignment.Far;
                    sizeRecText = new Size(w, this.Height);
                    rectangleText = new Rectangle(startPoint, sizeRecText);

                    break;
            }

            g.DrawString(this.text, font, textBrush, rectangleText, ft);

            UpdateControlHeight();
        }

        #endregion

        #region -> Metodos para el control
        private void UpdateControlHeight()
        {
            int txtHeight = TextRenderer.MeasureText("Text", font).Height + 1;

            switch (showTextValue)
            {

                case TextVerticalPosition.None:
                    HacerCambio(() => this.Height = barHeight);
                    break;

                case TextVerticalPosition.InSide:

                    if (txtHeight > barHeight)
                    {
                        barHeight = txtHeight;
                    }

                    HacerCambio(() => this.Height = barHeight);

                    break;

                default:

                     HacerCambio(() => this.Height = txtHeight + barHeight);

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
