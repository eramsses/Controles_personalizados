using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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

    public partial class RProgressBar : UserControl
    {
        private static Color darkText = Color.FromArgb(64, 64, 64);
        private static Color ligthText = Color.FromArgb(220, 220, 220);
        private Color barColor = Color.DarkOrange;
        
        private TextVerticalPosition showTextValue = TextVerticalPosition.Over;
        private HorizontalPositionText horizontalPositionText = HorizontalPositionText.Right;
        private bool showMaximun = false;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private int minimum = 100;
        private int maximum = 0;
        private int value = 0;
        private int barHeight = 5;
        private Color progressBarColor = Color.Lime;
        private Color backgroundBarColor = Color.Gainsboro;



        public RProgressBar()
        {
            InitializeComponent();
            UpdateControlHeight();
            
            
        }

        #region Propiedades de la barra de progreso
        [Category("R Control")]
        public int Minimum
        {
            get
            {
                return this.minimum;
            }

            set
            {
                this.minimum = value;
            }
        }

        [Category("R Control")]
        public int Maximum
        {
            get
            {
                return this.maximum;
            }

            set
            {
                this.maximum = value;
            }
        }

        [Category("R Control")]
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

        [Category("R Control")]
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

        #endregion

        #region Propiedades del texto
        [Category("R Control")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                SetFont(value);
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        

        [Category("R Control")]
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

        [Category("R Control")]
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

        [Category("R Control")]
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

        [Category("R Control")]
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

        [Category("R Control")]
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

        #endregion

        #region Metodos de la barra de progreso
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

            LblText.Text = text;

            //Ocultar las etiquetas
            LblTextO.Visible = false;
            LblTextI.Visible = false;
            LblTextU.Visible = false;

            switch (showTextValue)
            {
                case TextVerticalPosition.Over://Texto sobre la barra
                    //Mostrar la etiqueta que corresponde
                    LblTextO.Visible = true;
                    

                    //Anclar la barra y el texto
                    this.PnlChannel.Dock = DockStyle.Bottom;
                    SetHorizontalPositionText();


                    //Mostrar texto
                    LblTextO.Text = text;
                    break;

                case TextVerticalPosition.InSide://Texto dentro de la barra
                    //Mostrar la etiqueta que corresponde
                    LblTextI.Visible = true;
                    

                    //Anclar la barra y el texto
                    this.PnlChannel.Dock = DockStyle.Top;
                    SetHorizontalPositionText();


                    //Mostrar texto
                    LblTextI.Text = text;
                    break;

                case TextVerticalPosition.Under://Texto bajo la barra
                    //Mostrar la etiqueta que corresponde
                    LblTextU.Visible = true;

                    //Anclar la barra y el texto
                    this.PnlChannel.Dock = DockStyle.Top;
                    SetHorizontalPositionText();


                    //Mostrar texto
                    LblTextU.Text = text;
                    break;

                case TextVerticalPosition.None:
                    
                    //Anclar la barra y el texto
                    this.PnlChannel.Dock = DockStyle.Top;
                    

                    //rectText.X = sliderWidth - textSize.Width;
                    //textFormat.Alignment = StringAlignment.Center;
                    ////Clean previous text surface
                    //using (var brushClear = new SolidBrush(this.Parent.BackColor))
                    //{
                    //    var rect = rectSlider;
                    //    rect.Y = rectText.Y;
                    //    rect.Height = rectText.Height;
                    //    graph.FillRectangle(brushClear, rect);
                    //}
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
                            pY = (this.PnlSlider.Height - this.LblTextI.Height) / 2;
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

                case HorizontalPositionText.Center://Texto Centrado
                    switch (showTextValue)
                    {
                        case TextVerticalPosition.Over://Texto sobre la barra Centrado
                            pX = (this.PnlSlider.Height - this.LblTextO.Height) / 2;
                            pY = (this.PnlSlider.Height - this.LblTextO.Height) / 2;
                            this.LblTextO.AutoSize = true;
                            this.LblTextO.Location = new Point(pX, pY);

                            break;

                        case TextVerticalPosition.InSide://Texto dentro Centrado
                            pY = (this.PnlSlider.Height - this.LblTextO.Height) / 2;
                            this.LblTextO.AutoSize = true;
                            this.LblTextO.Location = new Point(pX, pY);

                            break;

                        case TextVerticalPosition.Under://Texto abajo Centrado
                            pY = this.barHeight;
                            this.LblTextO.AutoSize = true;
                            this.LblTextO.Location = new Point(pX, pY);

                            break;
                    }

                    break;

                case HorizontalPositionText.Right://Texto bajo la barra
                    //Ocultar las etiquetas sobrantes
                    LblTextO.Visible = false;
                    LblTextI.Visible = false;
                    LblTextU.Visible = true;

                    //Anclar la barra y el texto
                    this.PnlChannel.Dock = DockStyle.Top;


                    break;

                case HorizontalPositionText.Sliding:
                    
                    //rectText.X = sliderWidth - textSize.Width;
                    //textFormat.Alignment = StringAlignment.Center;
                    ////Clean previous text surface
                    //using (var brushClear = new SolidBrush(this.Parent.BackColor))
                    //{
                    //    var rect = rectSlider;
                    //    rect.Y = rectText.Y;
                    //    rect.Height = rectText.Height;
                    //    graph.FillRectangle(brushClear, rect);
                    //}
                    break;
            }
        }



        #endregion


        #region Metodos para el control
        private void UpdateControlHeight()
        {
            int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 2;

            switch (showTextValue)
            {

                case TextVerticalPosition.None:
                    PnlChannel.Height = barHeight;
                    PnlSlider.Height = barHeight;
                    this.Height = barHeight;
                    break;


                case TextVerticalPosition.InSide:
                    
                    if (barHeight < txtHeight)
                    {
                        PnlChannel.Height = txtHeight;
                        PnlSlider.Height = txtHeight;
                    }
                    else
                    {
                        PnlChannel.Height = barHeight;
                        PnlSlider.Height = barHeight;
                    }

                    //Altura de los textos
                    LblTextO.Height = txtHeight;
                    LblTextI.Height = txtHeight;
                    LblTextU.Height = txtHeight;
                    LblText.Height = txtHeight;

                    break;

                default:
                    PnlChannel.Height = barHeight;
                    PnlSlider.Height = barHeight;

                    this.Height = txtHeight + this.Padding.Top + this.Padding.Bottom + barHeight;
                    break;


            }
        }

        #endregion





    }
}
