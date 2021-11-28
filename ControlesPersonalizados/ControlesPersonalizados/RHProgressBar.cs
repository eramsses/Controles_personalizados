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
        private bool showMaximun = false;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private int minimum = 0;
        private int maximum = 100;
        private int value = 0;
        private int barHeight = 5;
        private int angleColorBar = 0;

        #endregion Campos

        #region -> Constructor

        public RHProgressBar()
        {
            InitializeComponent();
            ShowValueText();
            this.Resize += new EventHandler(ProgressBar_Resize);

        }

        private void ProgressBar_Resize(object sender, EventArgs e)
        {
            SetSliderValue();
            ShowValueText();
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
                SetSliderValue();
                ShowValueText();
            }
        }

        public void Increment(int value = 1)
        {
            this.value = this.value + value;
            SetSliderValue();
            ShowValueText();
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
                SetSliderValue();
                UpdateControlHeight();
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
                SetSliderValue();
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
                SetSliderValue();
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
                SetSliderValue();
                this.Invalidate();

            }
        }

        [Category("R Control Bar")]
        public Color BackgroundBarColor
        {
            get
            {
                return PnlChannel.BackColor;
            }

            set
            {
                PnlChannel.BackColor = value;
                SetSliderValue();
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
                SetSliderValue();
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
                SetFont(value);
                if (this.DesignMode)
                    UpdateControlHeight();

                ShowValueText();
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
                ShowValueText();
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
                ShowValueText();
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
                ShowValueText();
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
                ShowValueText();
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
                ShowValueText();
                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public Color BackgroundTextColor
        {
            get
            {
                return LblTextO.BackColor;
            }

            set
            {
                LblTextO.BackColor = value;
                LblTextI.BackColor = value;
                LblTextU.BackColor = value;

                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public Color TextColor
        {
            get
            {
                return LblTextO.ForeColor;
            }

            set
            {
                LblTextO.ForeColor = value;
                LblTextI.ForeColor = value;
                LblTextU.ForeColor = value;

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
            int sliderWidth = (int)(PnlChannel.Width * scaleFactor);

            HacerCambio(() => PnlSlider.Width = sliderWidth);

            SetBackColorBar();


        }

        private void SetBackColorBar()
        {
            Graphics g = this.PnlSlider.CreateGraphics();
            switch (modeColorHorizontalBar)
            {
                case ModeColorHorizontalBar.Solid://Fondo Solido
                    HacerCambio(() => this.PnlSlider.BackColor = barColor1);
                    break;

                case ModeColorHorizontalBar.Gradient1://Color que avanza con el slider
                    double scaleFactor = (((double)this.value - this.minimum) / ((double)this.maximum - this.minimum));
                    int sliderWidth = (int)(PnlChannel.Width * scaleFactor);

                    if (sliderWidth > 0)
                    {
                        //Color degradado
                        Point startPoint = new Point(0, 0);
                        Size size = new Size(sliderWidth, barHeight);

                        Rectangle rectangle = new Rectangle(startPoint, size);

                        LinearGradientBrush gradientBrush = new LinearGradientBrush(rectangle, barColor1, barColor2, angleColorBar);

                        g.FillRectangle(gradientBrush, 0, 0, sliderWidth, barHeight);
                    }

                    break;

                case ModeColorHorizontalBar.Gradient2:// Color ya esta  para toda la barra
                    Point startPointG2 = new Point(0, 0);
                    Size sizeG2 = new Size(this.PnlChannel.Width, barHeight);

                    Rectangle rectangleG1 = new Rectangle(startPointG2, sizeG2);

                    LinearGradientBrush gradientBrushG2 = new LinearGradientBrush(rectangleG1, barColor1, barColor2, angleColorBar);

                    g.FillRectangle(gradientBrushG2, 0, 0, this.PnlChannel.Width, barHeight);
                    break;

            }
        }

        #endregion

        #region -> Metodos Texto
        private void SetFont(Font value)
        {
            LblTextO.Font = value;
            LblTextI.Font = value;
            LblTextU.Font = value;
        }

        private void ShowValueText()
        {

            string text = symbolBefore + this.value.ToString() + symbolAfter;
            if (showMaximun) text = text + "/" + symbolBefore + this.maximum.ToString() + symbolAfter;


            //Ocultar las etiquetas
            HacerCambio(() => LblTextO.Visible = false);
            HacerCambio(() => LblTextI.Visible = false);
            HacerCambio(() => LblTextU.Visible = false);

            switch (showTextValue)
            {
                case TextVerticalPosition.Over://Texto sobre la barra
                    //Mostrar la etiqueta que corresponde
                    HacerCambio(() => LblTextO.Visible = true);

                    //Mostrar texto
                    HacerCambio(() => LblTextO.Text = text);

                    //Anclar la barra y el texto
                    HacerCambio(() => this.PnlChannel.Dock = DockStyle.Bottom);
                    SetHorizontalPositionText();

                    break;

                case TextVerticalPosition.InSide://Texto dentro de la barra
                    //Mostrar la etiqueta que corresponde
                    HacerCambio(() => LblTextI.Visible = true);
                    HacerCambio(() => LblTextI.Visible = true);

                    // Mostrar texto
                    HacerCambio(() => LblTextI.Text = text);

                    //Anclar la barra y el texto
                    HacerCambio(() => this.PnlChannel.Dock = DockStyle.Top);
                    SetHorizontalPositionText();

                    break;

                case TextVerticalPosition.Under://Texto bajo la barra
                    //Mostrar la etiqueta que corresponde
                    HacerCambio(() => LblTextU.Visible = true);

                    //Mostrar texto
                    HacerCambio(() => LblTextU.Text = text);

                    //Anclar la barra y el texto
                    this.PnlChannel.Dock = DockStyle.Top;
                    SetHorizontalPositionText();

                    break;

                case TextVerticalPosition.None:

                    HacerCambio(() => LblTextO.Visible = false);
                    HacerCambio(() => LblTextI.Visible = false);
                    HacerCambio(() => LblTextU.Visible = false);

                    this.PnlChannel.Dock = DockStyle.Top;

                    break;
            }
            UpdateControlHeight();
        }

        private void SetHorizontalPositionText()
        {
            int pX = 0;
            int pY = 0;

            switch (horizontalPositionText)
            {
                case HorizontalPositionText.Left://Texto a la izquierda

                    switch (showTextValue)
                    {
                        case TextVerticalPosition.Over://Texto sobre la barra a la izquierda

                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;

                        case TextVerticalPosition.InSide://Texto dentro a la izquierda
                            pY = ((this.PnlSlider.Height - this.LblTextI.Height) / 2);
                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));


                            break;

                        case TextVerticalPosition.Under://Texto abajo a la izquierda
                            pY = this.barHeight + 1;
                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;
                    }

                    break;

                case HorizontalPositionText.Center://Texto centrado

                    switch (showTextValue)
                    {
                        case TextVerticalPosition.Over://Texto sobre la barra a la centrado
                            pX = (this.Width - this.LblTextO.Width) / 2;

                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;

                        case TextVerticalPosition.InSide://Texto dentro a la centrado
                            pX = (this.Width - this.LblTextI.Width) / 2;
                            pY = (this.PnlSlider.Height - this.LblTextI.Height) / 2;
                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;

                        case TextVerticalPosition.Under://Texto abajo a la centrado
                            pX = (this.Width - this.LblTextU.Width) / 2;
                            pY = this.barHeight + 1;
                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;
                    }

                    break;

                case HorizontalPositionText.Right://Texto a la derecha

                    switch (showTextValue)
                    {
                        case TextVerticalPosition.Over://Texto sobre la barra a la derecha
                            pX = (this.Width - this.LblTextO.Width);

                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;

                        case TextVerticalPosition.InSide://Texto dentro a la derecha
                            pX = (this.Width - this.LblTextI.Width);
                            pY = (this.PnlSlider.Height - this.LblTextI.Height) / 2;
                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;

                        case TextVerticalPosition.Under://Texto abajo a la derecha
                            pX = (this.Width - this.LblTextU.Width);
                            pY = this.barHeight + 1;
                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;
                    }

                    break;

                case HorizontalPositionText.Sliding:


                    switch (showTextValue)
                    {
                        case TextVerticalPosition.Over://Texto sobre la barra deslizante
                            pX = (PnlSlider.Width - LblTextO.Width);
                            if (pX < 0)
                                pX = 0;

                            if ((pX + LblTextO.Width) > this.PnlChannel.Width)
                                pX = this.PnlSlider.Width - LblTextO.Width;

                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;

                        case TextVerticalPosition.InSide://Texto dentro a la deslizante
                            pX = (PnlSlider.Width - LblTextI.Width - 2);
                            if (pX < 0)
                                pX = 0;

                            if ((pX + LblTextI.Width) > this.PnlChannel.Width)
                                pX = this.PnlSlider.Width - LblTextI.Width;

                            pY = (this.PnlSlider.Height - this.LblTextI.Height) / 2;
                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));

                            break;

                        case TextVerticalPosition.Under://Texto abajo a la deslizante
                            pX = (PnlSlider.Width - LblTextU.Width);
                            if (pX < 0)
                                pX = 0;

                            if ((pX + LblTextU.Width) > this.PnlChannel.Width)
                                pX = this.PnlSlider.Width - LblTextU.Width;

                            pY = this.barHeight + 1;
                            HacerCambio(() => this.LblTextO.AutoSize = true);
                            HacerCambio(() => this.LblTextO.Location = new Point(pX, pY));


                            break;
                    }
                    break;
            }
        }



        #endregion

        #region -> Metodos para el control
        private void UpdateControlHeight()
        {
            int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;

            //Altura de los textos
            HacerCambio(() => LblTextO.Height = txtHeight);
            HacerCambio(() => LblTextI.Height = txtHeight);
            HacerCambio(() => LblTextU.Height = txtHeight);


            switch (showTextValue)
            {

                case TextVerticalPosition.None:
                    HacerCambio(() => PnlChannel.Height = barHeight);
                    HacerCambio(() => PnlSlider.Height = barHeight);
                    HacerCambio(() => this.Height = barHeight);
                    break;


                case TextVerticalPosition.InSide:

                    if (txtHeight > barHeight)
                    {
                        HacerCambio(() => PnlChannel.Height = txtHeight);
                        HacerCambio(() => PnlSlider.Height = txtHeight);

                    }
                    else
                    {
                        HacerCambio(() => PnlChannel.Height = barHeight);
                        HacerCambio(() => PnlSlider.Height = barHeight);
                    }

                    barHeight = PnlChannel.Height;
                    HacerCambio(() => this.Height = PnlChannel.Height);


                    break;

                default:
                    HacerCambio(() => PnlChannel.Height = barHeight);
                    HacerCambio(() => PnlSlider.Height = barHeight);

                    HacerCambio(() => this.Height = txtHeight + this.Padding.Top + this.Padding.Bottom + barHeight + 1);

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
