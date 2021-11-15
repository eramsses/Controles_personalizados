using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ControlesPersonalizados
{
    [DefaultEvent("_TextChanged")]
    public partial class RTextBox : UserControl
    {
        #region -> Fields
        //Fields
        private static Color darkText = Color.FromArgb(64, 64, 64);
        private static Color ligthText = Color.FromArgb(220, 220, 220);
        private Color borderColor = Color.MediumSlateBlue;
        private Color borderFocusColor = Color.HotPink;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private bool isFocused = false;

        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;
        //private char passChar = '';


        //Events
        public event EventHandler _TextChanged;

        #endregion

        //-> Constructor
        public RTextBox()
        {
            //Created by designer
            InitializeComponent();

            this.Resize += new EventHandler(TextBox_Resize);
        }

        private void TextBox_Resize(object sender, EventArgs e)
        {
            ValidarRadioMinimo(borderRadius);
        }

        #region -> Properties
        [Category("R Control")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                var borderColorFocusLight = ControlPaint.Light(value, 0.7F);
                var borderColorFocusLight2 = ControlPaint.LightLight(value);
                var borderColorFocusDark = ControlPaint.Dark(value, 0.7F);
                var borderColorFocusDark2 = ControlPaint.DarkDark(value);

                if (value.GetBrightness() >= 0.6F)
                {
                    this.ForeColor = darkText;
                    borderFocusColor = borderColorFocusDark;
                }
                else
                {
                    borderFocusColor = borderColorFocusLight;
                }
                
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Category("R Control")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value >= 1)
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }
        }

        [Category("R Control")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        

        [Category("R Control")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("R Control")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;

                if (this.BackColor.GetBrightness() >= 0.6F)
                {
                    base.ForeColor = darkText;
                    textBox1.ForeColor = darkText;
                }
                else
                {
                    base.ForeColor = ligthText;
                    textBox1.ForeColor = ligthText;
                }
            }
        }

        [Category("R Control")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("R Control")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("R Control")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                else return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        public void AppendTexts (string value)
        {
               textBox1.AppendText(value);
        }

        [DefaultValue("Both")]
        [Category("R Control")]
        public ScrollBars ScrollBar 
        { 
            get
            {
                return textBox1.ScrollBars;
            }
            set
            {
                textBox1.ScrollBars = value;    
            }
        }

        [Category("R Control")]
        public HorizontalAlignment TextsAlign
        {
            get
            {
                return textBox1.TextAlign;
            }
            set
            {
                textBox1.TextAlign = value;
            }
        }

        [Category("R Control")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    ValidarRadioMinimo(value);
                    this.Invalidate();//Redraw control
                }
            }
        }

        [Category("R Control")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    textBox1.ForeColor = value;
            }
        }

        [Category("R Control")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                if(value != "")
                {
                    placeholderText = value;
                    textBox1.Text = "";
                    SetPlaceholder();
                }
                else
                {
                    placeholderText = value;
                    SetPlaceholder();
                }
                
            }
        }
        #endregion

        #region -> Propiedades de comportamiento

        [Category("R Comportamiento")]
        public bool AcceptReturn
        {
            get
            {
                return textBox1.AcceptsReturn;
            }
            set
            {
                textBox1.AcceptsReturn = value;
            }
        }

        [Category("R Comportamiento")]
        public bool AcceptTab
        {
            get
            {
                return textBox1.AcceptsTab;
            }
            set
            {
                textBox1.AcceptsTab = value;
            }
        }

        [Category("R Comportamiento")]
        public bool AllowDrops
        {
            get
            {
                return textBox1.AllowDrop;
            }
            set
            {
                textBox1.AllowDrop = value;
            }
        }

        [Category("R Comportamiento")]
        public CharacterCasing CharactersCasing
        {
            get
            {
                return textBox1.CharacterCasing;
            }
            set
            {
                textBox1.CharacterCasing = value;
            }
        }

        [Category("R Comportamiento")]
        public ContextMenuStrip ContextMenuStrips
        {
            get
            {
                return textBox1.ContextMenuStrip;
            }
            set
            {
                textBox1.ContextMenuStrip = value;
            }
        }

        [Category("R Comportamiento")]
        public bool Enable
        {
            get
            {
                return textBox1.Enabled;
            }
            set
            {
                textBox1.Enabled = value;
            }
        }

        [Category("R Comportamiento")]
        public bool HideSelections
        {
            get
            {
                return textBox1.HideSelection;
            }
            set
            {
                textBox1.HideSelection = value;
            }
        }

        [Category("R Comportamiento")]
        public bool ReadsOnly
        {
            get
            {
                return textBox1.ReadOnly;
            }
            set
            {
                textBox1.ReadOnly = value;
            }
        }

        
        [Category("R Comportamiento")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                if (!isPlaceholder)
                    textBox1.UseSystemPasswordChar = value;
            }
        }

        [Category("R Comportamiento")]
        public bool VisibleEr
        {
            get
            {
                return textBox1.Visible;
            }
            set
            {
                textBox1.Visible = value;
            }
        }

        [Category("R Comportamiento")]
        public bool WordWrapEr
        {
            get
            {
                return textBox1.WordWrap;
            }
            set
            {
                textBox1.WordWrap = value;
            }
        }

        

        #endregion

        #region -> Overridden methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1)//Rounded TextBox
            {
                //-Fields
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //-Drawing
                    this.Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl
                    if (borderRadius > 15) SetTextBoxRoundedRegion();//Set the rounded region of TextBox component
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle) //Line Style
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else //Normal Style
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else //Square/Normal TextBox
            {
                //Draw border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle) //Line Style
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else //Normal Style
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }
        #endregion

        #region -> Private methods
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                isPlaceholder = false;
                //textBox1.Text = placeholderText;
                textBox1.ForeColor = base.ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }

        private void ValidarRadioMinimo(int value)
        {

            if (value < this.Height && value < this.Width)
            {
                int v = value - BorderSize;
                if (v < 0)
                    v = 0;

                borderRadius = v;
            }
            else
            {
                if (this.Width > this.Height)
                {
                    int v = this.Height - BorderSize;
                    if (v < 0)
                        v = 0;

                    borderRadius = v;
                }

                else
                {
                    int v = this.Width - BorderSize;
                    if (v < 0)
                        v = 0;

                    borderRadius = v;
                }

                    

            }

        }
        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }
            pathTxt.Dispose();
        }
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }
        #endregion

        #region -> TextBox events
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
        ///::::+
        #endregion
    }
}
