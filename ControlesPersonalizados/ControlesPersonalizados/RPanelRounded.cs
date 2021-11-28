using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class RPanelRounded : Panel
    {
        #region -> Campos

        private int borderRadius = 0;
        private int borderSize = 0;
        private Color borderColor = Color.DimGray;
        private Color backgroundColor1 = Color.LightGray;
        private Color backgroundColor2 = Color.LightGray;
        private int angleColor = 0;

        #endregion

        #region -> Constructores

        public RPanelRounded()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
            this.Resize += new EventHandler(Panel_Resize);
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            ValidarRadioMinimo(borderRadius);
            this.Invalidate();
        }

        public RPanelRounded(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion Constructores

        #region -> Propiedades

        [Category("R Control")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }

            set
            {
                borderRadius = value;
                ValidarRadioMinimo(borderRadius);
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }

            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }


        [Category("R Control")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }

            set
            {
                borderSize = value;
                PintarPanel();
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public Color BackColor1
        {
            get
            {
                return this.backgroundColor1;
            }

            set
            {
                this.backgroundColor1 = value;
                PintarPanel();
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public Color BackColor2
        {
            get
            {
                return backgroundColor2;
            }

            set
            {
                backgroundColor2 = value;
                PintarPanel();
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public int AngleColor
        {
            get
            {
                return angleColor;
            }

            set
            {
                angleColor = value;
                PintarPanel();
                this.Invalidate();
            }
        }

        #endregion

        #region -> Métodos

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PintarPanel();

        }

        private void PintarPanel()
        {
            Graphics graph = this.CreateGraphics();
            var rectBorderSmooth = this.ClientRectangle;
            var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);

            if (borderRadius > 1)//Panel redondeado
            {
                GraphicsPath path = GetFigurePath(rectBorder, borderRadius);
                graph.SmoothingMode = SmoothingMode.AntiAlias;


                //TextureBrush brush = new TextureBrush(Properties.Resources.Asterisk_dark_50px) 

                using (LinearGradientBrush gradientBrush = new LinearGradientBrush(rectBorder, backgroundColor1, backgroundColor2, angleColor, true))
                using (Pen pen = new Pen(borderColor, borderSize))
                using (var backGroundColor = new SolidBrush(backgroundColor1))
                {
                    pen.Alignment = PenAlignment.Inset;

                    graph.FillPath(gradientBrush, path);

                    if (borderSize > 0)
                        graph.DrawPath(new Pen(borderColor, borderSize), path);


                }

            }
            else //Panel cuadrado Normal
            {
                using (LinearGradientBrush gradientBrush = new LinearGradientBrush(rectBorder, backgroundColor1, backgroundColor2, angleColor, true))
                using (var backGroundColor = new SolidBrush(backgroundColor1))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //penBorder.Alignment = PenAlignment.Inset;

                    graph.FillRectangle(gradientBrush, rectBorder);

                    if (borderSize > 0)
                        graph.DrawRectangle(penBorder, rectBorder);



                }
            }
        }

        private void ValidarRadioMinimo(int value)
        {
            if (value < this.Height && value < this.Width)
            {
                int v = value;
                if (v < 0)
                    v = 0;

                borderRadius = v;
            }
            else
            {
                if (this.Width > this.Height)
                {
                    int v = this.Height;
                    if (v < 0)
                        v = 0;

                    borderRadius = v;
                }

                else
                {
                    int v = this.Width;
                    if (v < 0)
                        v = 0;

                    borderRadius = v;
                }
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius;
            path.StartFigure();

            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);

            path.CloseFigure();
            return path;
        }

        #endregion Métodos
    }
}
