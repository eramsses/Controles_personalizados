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
        Inside,
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

        #endregion Campos

        #region -> Constructor
        public RVProgressBar()
        {
            InitializeComponent();

            this.Resize += new EventHandler(ProgressBar_Resize);
        }

        private void ProgressBar_Resize(object sender, EventArgs e)
        {
            SetSliderValue();
            //PnlSlider.Location = new Point(0, PnlChannel.Height);
            ShowValueText();

        }

        #endregion Constructor

        #region ->  Propiedades de la barra de progreso

        public void Increment(int value = 1)
        {
            this.value = this.value + value;
            SetSliderValue();
            ShowValueText();
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
                SetSliderValue();
                ShowValueText();
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
                ShowValueText();

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
        public ModeColorVerticalBar ModeColorVerticalBar
        {
            get
            {
                return modeColorVerticalBar;
            }

            set
            {
                modeColorVerticalBar = value;
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
                    UpdateControlWidth();

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
        public HPositionText ShowText
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
        public VPositionText VerticalPositionText
        {
            get
            {
                return verticalPositionText;
            }

            set
            {
                verticalPositionText = value;
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
                return LblTextR.BackColor;
            }

            set
            {
                LblTextL.BackColor = value;
                LblTextC.BackColor = value;
                LblTextR.BackColor = value;

                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public Color BackgroundForeColor
        {
            get
            {
                return LblTextR.ForeColor;
            }

            set
            {
                LblTextL.ForeColor = value;
                LblTextC.ForeColor = value;
                LblTextR.ForeColor = value;

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
            int sliderHeight = (int)(this.Height * scaleFactor);

            HacerCambio(() => PnlSlider.Height = sliderHeight);


            HacerCambio(() => PnlSlider.Location = new Point(0, (this.Height - sliderHeight)));
            SetBackColorBar();
        }

        private void SetBackColorBar()
        {
            Graphics g = this.PnlSlider.CreateGraphics();
            switch (modeColorVerticalBar)
            {
                case ModeColorVerticalBar.Solid://Fondo Solido
                    HacerCambio(() => this.PnlSlider.BackColor = barColor1);
                    break;

                case ModeColorVerticalBar.Gradient1://Color que avanza con el slider
                    double scaleFactor = (((double)this.value - this.minimum) / ((double)this.maximum - this.minimum));
                    int sliderHeight = (int)(this.Height * scaleFactor);

                    if (sliderHeight > 0)
                    {
                        //Color degradado
                        Point startPoint = new Point(0, 0);
                        Size size = new Size(BarWidth, sliderHeight);

                        Rectangle rectangle = new Rectangle(startPoint, size);

                        LinearGradientBrush gradientBrush = new LinearGradientBrush(rectangle, barColor1, barColor2, angleColorBar);

                        g.FillRectangle(gradientBrush, 0, 0, BarWidth, sliderHeight);
                    }

                    break;

                case ModeColorVerticalBar.Gradient2:// Color ya esta  para toda la barra
                    //Color degradado
                    Point startPointG2 = new Point(0, 0);
                    Size sizeG2 = new Size(BarWidth, this.PnlChannel.Height);

                    Rectangle rectangleG1 = new Rectangle(startPointG2, sizeG2);

                    LinearGradientBrush gradientBrushG2 = new LinearGradientBrush(rectangleG1, barColor1, barColor2, angleColorBar);

                    g.FillRectangle(gradientBrushG2, 0, 0, this.PnlChannel.Width, this.PnlChannel.Height);
                    break;

            }
        }

        #endregion

        #region -> Metodos Texto
        private void SetFont(Font value)
        {
            HacerCambio(() => LblTextL.Font = value);
            HacerCambio(() => LblTextC.Font = value);
            HacerCambio(() => LblTextR.Font = value);
        }

        private void ShowValueText()
        {

            string text = symbolBefore + this.value.ToString() + symbolAfter;
            if (showMaximun) text = text + "/" + symbolBefore + this.maximum.ToString() + symbolAfter;


            //Ocultar las etiquetas
            HacerCambio(() => LblTextL.Visible = false);
            HacerCambio(() => LblTextC.Visible = false);
            HacerCambio(() => LblTextR.Visible = false);

            switch (showTextValue)
            {
                case HPositionText.Left://Texto arriba
                    //Mostrar la etiqueta que corresponde
                    HacerCambio(() => LblTextL.Visible = true);

                    //Mostrar texto
                    HacerCambio(() => LblTextL.Text = text);

                    SetVerticalPositionText();

                    break;

                case HPositionText.Inside://Texto dentro de la barra
                    //Mostrar la etiqueta que corresponde
                    HacerCambio(() => LblTextC.Visible = true);

                    // Mostrar texto
                    HacerCambio(() => LblTextC.Text = text);

                    SetVerticalPositionText();

                    break;

                case HPositionText.Right://Texto bajo la barra
                    //Mostrar la etiqueta que corresponde
                    HacerCambio(() => LblTextR.Visible = true);

                    //Mostrar texto
                    HacerCambio(() => LblTextR.Text = text);

                    SetVerticalPositionText();

                    break;

                case HPositionText.None:

                    HacerCambio(() => LblTextL.Visible = false);
                    HacerCambio(() => LblTextC.Visible = false);
                    HacerCambio(() => LblTextR.Visible = false);
                    HacerCambio(() => this.PnlChannel.Dock = DockStyle.Fill);

                    break;
            }
            UpdateControlWidth();
        }

        private void SetVerticalPositionText()
        {
            int pX = 0;
            int pY = 0;

            switch (verticalPositionText)
            {
                case VPositionText.Down://Texto abajo

                    switch (showTextValue)
                    {
                        case HPositionText.Left://Texto abajo a la izquierda
                            pY = this.Height - LblTextL.Height - 1;

                            HacerCambio(() => this.LblTextL.AutoSize = true);
                            HacerCambio(() => this.LblTextL.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Right);
                            break;

                        case HPositionText.Inside://Texto abajo por dentro

                            if (LblTextC.Width > this.Width)
                            {
                                HacerCambio(() => this.Width = LblTextC.Width);
                                HacerCambio(() => PnlChannel.Width = LblTextC.Width);
                                HacerCambio(() => PnlSlider.Width = LblTextC.Width);
                            }

                            pX = ((this.Width - this.LblTextC.Width) / 2);
                            pY = this.Height - LblTextC.Height - 1;
                            HacerCambio(() => this.LblTextC.AutoSize = true);
                            HacerCambio(() => this.LblTextC.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Fill);

                            break;

                        case HPositionText.Right://Texto abajo a la derecha
                            pY = this.Height - LblTextR.Height - 1;
                            pX = this.barWidth + 1;
                            HacerCambio(() => this.LblTextR.AutoSize = true);
                            HacerCambio(() => this.LblTextR.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Left);

                            break;
                    }

                    break;

                case VPositionText.Middle://Texto al medio

                    switch (showTextValue)
                    {
                        case HPositionText.Left://Texto al medio a la izquierda
                            pY = (this.Height - this.LblTextL.Height) / 2;

                            HacerCambio(() => this.LblTextL.AutoSize = true);
                            HacerCambio(() => this.LblTextL.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Right);

                            break;

                        case HPositionText.Inside://Texto al medio por dentro 
                            if (LblTextC.Width > this.Width)
                            {
                                HacerCambio(() => this.Width = LblTextC.Width);
                                HacerCambio(() => PnlChannel.Width = LblTextC.Width);
                                HacerCambio(() => PnlSlider.Width = LblTextC.Width);
                            }

                            pX = (PnlChannel.Width - this.LblTextC.Width) / 2;
                            pY = (this.Height - this.LblTextC.Height) / 2;

                            HacerCambio(() => this.LblTextC.AutoSize = true);
                            HacerCambio(() => this.LblTextC.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Fill);

                            break;

                        case HPositionText.Right://Texto al medio a la derecha
                            pX = PnlChannel.Width + 1;
                            pY = (this.Height - this.LblTextR.Height) / 2;

                            HacerCambio(() => this.LblTextR.AutoSize = true);
                            HacerCambio(() => this.LblTextR.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Left);

                            break;
                    }

                    break;

                case VPositionText.Up://Texto arriba
                    pY = 1;
                    switch (showTextValue)
                    {
                        case HPositionText.Left://Texto arriba a la izquierda

                            HacerCambio(() => this.LblTextL.AutoSize = true);
                            HacerCambio(() => this.LblTextL.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Right);

                            break;

                        case HPositionText.Inside://Texto arriba por dentro
                            if (LblTextC.Width > this.Width)
                            {
                                HacerCambio(() => this.Width = LblTextC.Width);
                                HacerCambio(() => PnlChannel.Width = LblTextC.Width);
                                HacerCambio(() => PnlSlider.Width = LblTextC.Width);
                            }

                            pX = (PnlChannel.Width - this.LblTextC.Width) / 2;

                            HacerCambio(() => this.LblTextC.AutoSize = true);
                            HacerCambio(() => this.LblTextC.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Fill);

                            break;

                        case HPositionText.Right://Texto arriba a la derecha
                            pX = PnlChannel.Width + 1;

                            HacerCambio(() => this.LblTextR.AutoSize = true);
                            HacerCambio(() => this.LblTextR.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Left);

                            break;
                    }

                    break;

                case VPositionText.Sliding:


                    switch (showTextValue)
                    {
                        case HPositionText.Left://Texto deslizante a la izquierda
                            pY = (this.Height - PnlSlider.Height);
                            if (pY > this.Height - LblTextL.Height)
                                pY = this.Height - LblTextL.Height;

                            HacerCambio(() => this.LblTextL.AutoSize = true);
                            HacerCambio(() => this.LblTextL.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Right);

                            break;

                        case HPositionText.Inside://Texto deslizante por dentro
                            if (LblTextC.Width > this.Width)
                            {
                                HacerCambio(() => this.Width = LblTextC.Width);
                                HacerCambio(() => PnlChannel.Width = LblTextC.Width);
                                HacerCambio(() => PnlSlider.Width = LblTextC.Width);
                            }

                            pY = (this.Height - PnlSlider.Height);
                            if (pY > this.Height - LblTextC.Height)
                                pY = this.Height - LblTextC.Height;

                            pX = (PnlChannel.Width - this.LblTextC.Width) / 2;

                            HacerCambio(() => this.LblTextC.AutoSize = true);
                            HacerCambio(() => this.LblTextC.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Fill);

                            break;

                        case HPositionText.Right://Texto deslizante a la derecha
                            pY = (this.Height - PnlSlider.Height);
                            if (pY > this.Height - LblTextR.Height)
                                pY = this.Height - LblTextR.Height;


                            pX = PnlChannel.Width + 1;
                            HacerCambio(() => this.LblTextR.AutoSize = true);
                            HacerCambio(() => this.LblTextR.Location = new Point(pX, pY));

                            //Anclar la barra
                            HacerCambio(() => this.PnlChannel.Dock = DockStyle.Left);

                            break;
                    }
                    break;
            }
        }


        #endregion

        #region Metodos para el control
        private void UpdateControlWidth()
        {

            HacerCambio(() => PnlChannel.Width = barWidth);
            HacerCambio(() => PnlSlider.Width = barWidth);

            int txtWidth = 0;

            if (showTextValue == HPositionText.Left) txtWidth = LblTextL.Width;
            else if (showTextValue == HPositionText.Inside) txtWidth = LblTextC.Width;
            else if (showTextValue == HPositionText.Right) txtWidth = LblTextR.Width;

            //Altura de los textos


            switch (showTextValue)
            {

                case HPositionText.None:
                    HacerCambio(() => PnlChannel.Width = barWidth);
                    HacerCambio(() => PnlSlider.Width = barWidth);
                    HacerCambio(() => this.Width = barWidth);

                    break;


                case HPositionText.Inside:

                    if (txtWidth > barWidth)
                    {
                        HacerCambio(() => PnlChannel.Width = txtWidth);
                        HacerCambio(() => PnlSlider.Width = txtWidth);

                        barWidth = txtWidth;
                        this.Width = txtWidth;
                    }
                    else
                    {
                        HacerCambio(() => PnlChannel.Width = barWidth);
                        HacerCambio(() => PnlSlider.Width = barWidth);

                        this.Width = barWidth;
                    }


                    break;

                default:
                    HacerCambio(() => PnlChannel.Width = barWidth);
                    HacerCambio(() => PnlSlider.Width = barWidth);


                    HacerCambio(() => this.Width = txtWidth + this.Padding.Left + this.Padding.Right + barWidth + 2);
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
