using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ControlesPersonalizados
{
    public partial class ERButton : Button
    {

        //Campos
        private static Color darkText = Color.FromArgb(64, 64, 64);
        private static Color ligthText = Color.FromArgb(220, 220, 220);
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;
        

        [Category("ER Control")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }

            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("ER Control")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                ValidarRadioMinimo(value);
                this.Invalidate();
            }
        }

        private void ValidarRadioMinimo(int value)
        {

            if(value < this.Height && value < this.Width)
            {
                borderRadius = value;
            }
            else
            {
                if(this.Width > this.Height)
                    borderRadius = this.Height;
                else
                    borderRadius = this.Width;
               
            }

        }

        [Category("ER Control")]
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

        [Category("ER Control")]
        public Color BackGroundColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;

                if (this.BackColor.GetBrightness() >= 0.6F)
                {
                    this.ForeColor = darkText;
                }
                else
                {
                    this.ForeColor = ligthText;
                }
            }
        }

        [Category("ER Control")]
        public Color TextColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }


        public ERButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.DarkOrange;
            this.ForeColor = ligthText;

            this.Resize += new EventHandler(Button_Resize);

        }

        private void Button_Resize(object sender, EventArgs e)
        {
            //if(borderRadius > this.Height)
            //{
            //    borderRadius = this.Height;
            //}

            //if (borderRadius > this.Width)
            //{
            //    borderRadius = this.Width;
            //}
            ValidarRadioMinimo(borderRadius);
        }

        //metodos
        private GraphicsPath GetConfigurePath (RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);

            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF superficieRectangulo = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF bordeRectangulo = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if(borderRadius >2)//Boton redondeado
            {
                using (GraphicsPath rutaSuperficie = GetConfigurePath(superficieRectangulo, borderRadius)) 
                using(GraphicsPath  rutaBorde = GetConfigurePath(bordeRectangulo, borderRadius - 1F))
                using(Pen superficiePen = new Pen(this.Parent.BackColor, 2))
                using(Pen bordePen = new Pen(borderColor, borderSize))
                {
                    bordePen.Alignment = PenAlignment.Inset;
                    this.Region = new Region(rutaSuperficie);
                    //Dibujar superficie
                    pevent.Graphics.DrawPath(superficiePen, rutaSuperficie);
                    //Dibujar borde
                    if(borderSize >= 1)
                    {
                        pevent.Graphics.DrawPath(bordePen, rutaBorde);
                    }

                }

            }
            else//Boton cuadrado
            {
                this.Region = new Region(superficieRectangulo);
                if(borderSize >= 1)
                {
                    using(Pen bordePen = new Pen(borderColor, borderSize))
                    {
                        bordePen.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(bordePen, 0, 0, this.Width - 1, this.Width - 1);
                    }
                }

            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnDockChanged(e);
            this.Parent.BackColorChanged += new EventHandler(Conteiner_BackColorChanged);
        }

        private void Conteiner_BackColorChanged(object sender, EventArgs e)
        {
            if(this.DesignMode)
            {
                this.Invalidate();
            }
        }
    }
}
