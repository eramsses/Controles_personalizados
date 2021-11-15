using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ControlesPersonalizados
{

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

    public partial class RHProgressBar : UserControl
    {
        private static Color darkText = Color.FromArgb(64, 64, 64);
        private static Color ligthText = Color.FromArgb(220, 220, 220);
        
        
        private TextVerticalPosition showTextValue = TextVerticalPosition.Over;
        private HorizontalPositionText horizontalPositionText = HorizontalPositionText.Right;
        private bool showMaximun = false;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private int minimum = 0;
        private int maximum = 100;
        private int value = 0;
        private int barHeight = 5;


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
           
        }

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
                ShowValueText();
                UpdateControlHeight();
            }
        }

        [Category("R Control Bar")]
        public Color ProgressBarColor
        {
            get
            {
                return PnlSlider.BackColor;
            }

            set
            {
                PnlSlider.BackColor = value;
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

                
                if (value.GetBrightness() >= 0.8F)
                {
                    LblTextO.ForeColor = darkText;
                    LblTextI.ForeColor = darkText;
                    LblTextU.ForeColor = darkText;
                }
                else
                {
                    LblTextO.ForeColor = ligthText;
                    LblTextI.ForeColor = ligthText;
                    LblTextU.ForeColor = ligthText;
                }

                this.Invalidate();
            }
        }

        [Category("R Control Text")]
        public Color BackgroundForeColor
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

            PnlSlider.Width = sliderWidth;
               
        }

        #endregion


        #region Metodos Texto
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
            LblTextO.Visible = false;
            LblTextI.Visible = false;
            LblTextU.Visible = false;

            switch (showTextValue)
            {
                case TextVerticalPosition.Over://Texto sobre la barra
                    //Mostrar la etiqueta que corresponde
                    LblTextO.Visible = true;

                    //Mostrar texto
                    LblTextO.Text = text;


                    //Anclar la barra y el texto
                    this.PnlChannel.Dock = DockStyle.Bottom;
                    SetHorizontalPositionText();

                    break;

                case TextVerticalPosition.InSide://Texto dentro de la barra
                    //Mostrar la etiqueta que corresponde
                    LblTextI.Visible = true;

                    // Mostrar texto
                    LblTextI.Text = text;


                    //Anclar la barra y el texto
                    this.PnlChannel.Dock = DockStyle.Top;
                    SetHorizontalPositionText();

                    break;

                case TextVerticalPosition.Under://Texto bajo la barra
                    //Mostrar la etiqueta que corresponde
                    LblTextU.Visible = true;

                    //Mostrar texto
                    LblTextU.Text = text;

                    //Anclar la barra y el texto
                    this.PnlChannel.Dock = DockStyle.Top;
                    SetHorizontalPositionText();

                    break;

                case TextVerticalPosition.None:

                    LblTextO.Visible = false;
                    LblTextI.Visible = false;
                    LblTextU.Visible = false;
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
                            
                            this.LblTextO.AutoSize = true;
                            this.LblTextO.Location = new Point( pX, pY);

                            break;

                        case TextVerticalPosition.InSide://Texto dentro a la izquierda
                            pY = ((this.PnlSlider.Height - this.LblTextI.Height) / 2);
                            this.LblTextI.AutoSize = true;
                            this.LblTextI.Location = new Point(pX, pY);
                            

                            break;

                        case TextVerticalPosition.Under://Texto abajo a la izquierda
                            pY = this.barHeight + 1;
                            this.LblTextU.AutoSize = true;
                            this.LblTextU.Location = new Point(pX, pY);

                            break;
                    }

                    break;

                case HorizontalPositionText.Center://Texto centrado
                    
                    switch (showTextValue)
                    {
                        case TextVerticalPosition.Over://Texto sobre la barra a la centrado
                            pX = (this.Width - this.LblTextO.Width) / 2;

                            this.LblTextO.AutoSize = true;
                            this.LblTextO.Location = new Point(pX, pY);

                            break;

                        case TextVerticalPosition.InSide://Texto dentro a la centrado
                            pX = (this.Width - this.LblTextI.Width) / 2;
                            pY = (this.PnlSlider.Height - this.LblTextI.Height) / 2;
                            this.LblTextI.AutoSize = true;
                            this.LblTextI.Location = new Point(pX, pY);

                            break;

                        case TextVerticalPosition.Under://Texto abajo a la centrado
                            pX = (this.Width - this.LblTextU.Width) / 2;
                            pY = this.barHeight + 1;
                            this.LblTextU.AutoSize = true;
                            this.LblTextU.Location = new Point(pX, pY);

                            break;
                    }

                    break;

                case HorizontalPositionText.Right://Texto a la derecha
                    
                    switch (showTextValue)
                    {
                        case TextVerticalPosition.Over://Texto sobre la barra a la derecha
                            pX = (this.Width - this.LblTextO.Width);

                            this.LblTextO.AutoSize = true;
                            this.LblTextO.Location = new Point(pX, pY);

                            break;

                        case TextVerticalPosition.InSide://Texto dentro a la derecha
                            pX = (this.Width - this.LblTextI.Width);
                            pY = (this.PnlSlider.Height - this.LblTextI.Height) / 2;
                            this.LblTextI.AutoSize = true;
                            this.LblTextI.Location = new Point(pX, pY);

                            break;

                        case TextVerticalPosition.Under://Texto abajo a la derecha
                            pX = (this.Width - this.LblTextU.Width);
                            pY = this.barHeight + 1;
                            this.LblTextU.AutoSize = true;
                            this.LblTextU.Location = new Point(pX, pY);

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

                            this.LblTextO.AutoSize = true;
                            this.LblTextO.Location = new Point(pX, pY);

                            break;

                        case TextVerticalPosition.InSide://Texto dentro a la deslizante
                            pX = (PnlSlider.Width - LblTextI.Width - 2);
                            if (pX < 0)
                                pX = 0;

                            if ((pX + LblTextI.Width) > this.PnlChannel.Width)
                                pX = this.PnlSlider.Width - LblTextI.Width;

                            pY = (this.PnlSlider.Height - this.LblTextI.Height) / 2;
                            this.LblTextI.AutoSize = true;
                            this.LblTextI.Location = new Point(pX, pY);

                            break;

                        case TextVerticalPosition.Under://Texto abajo a la deslizante
                            pX = (PnlSlider.Width - LblTextU.Width);
                            if (pX < 0)
                                pX = 0;

                            if ((pX + LblTextU.Width) > this.PnlChannel.Width)
                                pX = this.PnlSlider.Width - LblTextU.Width;

                            pY = this.barHeight + 1;
                            this.LblTextU.AutoSize = true;
                            this.LblTextU.Location = new Point(pX, pY);

                            break;
                    }
                    break;
            }
        }



        #endregion


        #region Metodos para el control
        private void UpdateControlHeight()
        {
            int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height +1;

            //Altura de los textos
            LblTextO.Height = txtHeight;
            LblTextI.Height = txtHeight;
            LblTextU.Height = txtHeight;
            
            switch (showTextValue)
            {

                case TextVerticalPosition.None:
                    PnlChannel.Height = barHeight;
                    PnlSlider.Height = barHeight;
                    this.Height = barHeight + 2;
                    break;


                case TextVerticalPosition.InSide:

                    if (txtHeight > barHeight)
                    {
                        PnlChannel.Height = txtHeight;
                        PnlSlider.Height = txtHeight;
                    }
                    else
                    {
                        PnlChannel.Height = barHeight;
                        PnlSlider.Height = barHeight;
                    }

                    barHeight = PnlChannel.Height;
                    this.Height = PnlChannel.Height + 2;


                    break;

                default:
                    PnlChannel.Height = barHeight;
                    PnlSlider.Height = barHeight;

                    this.Height = txtHeight + this.Padding.Top + this.Padding.Bottom + barHeight + 2;
                    break;


            }
        }

        #endregion





    }
}
