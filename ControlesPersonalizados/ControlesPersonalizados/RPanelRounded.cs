using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class RPanelRounded : Panel
    {
        #region -> Campos

        private int borderRadius = 0;
        private int borderSize = 0;
        private Color borderColor = Color.DimGray;
        private Color backgroundColor = Color.LightGray;

        #endregion



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
        public Color SetBackColor
        {
            get
            {
                return this.backgroundColor;
            }

            set
            {
                this.backgroundColor = value;
                PintarPanel();
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

        #endregion

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

                using (Pen pen = new Pen(borderColor, borderSize))
                using (var backGroundColor = new SolidBrush(backgroundColor))
                {
                    pen.Alignment = PenAlignment.Inset;

                    if(borderSize > 0)
                    graph.DrawPath(new Pen(borderColor, borderSize), path);

                    graph.FillPath(backGroundColor, path);
                }

            }
            else //Panel cuadrado Normal
            {
                using (var backGroundColor = new SolidBrush(backgroundColor))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;

                    if (borderSize > 0)
                        graph.DrawRectangle(penBorder, rectBorder);


                    graph.FillRectangle(backGroundColor, rectBorder);
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

            if (rect.Width > rect.Height)
            {
                path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
                path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
                path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
                path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            }
            else
            {
                curveSize = radius * 2F;
                path.AddArc(rect.X, rect.Y - 2, rect.Width, rect.Height + 3, 90, 180);//A la izquuierda

            }


            path.CloseFigure();
            return path;
        }
    }
}
