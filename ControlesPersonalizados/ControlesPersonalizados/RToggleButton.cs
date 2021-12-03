using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class RToggleButton : CheckBox
    {
        #region -> Campos
        private Color onBackColor = Color.Lime;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        #endregion Campos

        #region -> Propiedades

        [Category("R Control")]
        public Color OnBackColor
        {
            get
            {
                return onBackColor;
            }
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public Color OnToggleColor
        {
            get
            {
                return onToggleColor;
            }

            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public Color OffBackColor
        {
            get
            {
                return offBackColor;
            }
            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }

        [Category("R Control")]
        public Color OffToggleColor
        {
            get
            {
                return offToggleColor;
            }
            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }


        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {

            }
        }

        [Category("R CheckBox")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get
            {
                return solidStyle;
            }
            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }

        #endregion Propiedades

        #region -> Constructor
        public RToggleButton()
        {
            this.MinimumSize = new Size(40, 22);

        }

        #endregion Constructor

        #region -> Métodos
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);

            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            pevent.Graphics.Clear(this.Parent.BackColor);


            //try
            //{

            //    if (this.Parent.GetType() == typeof(RPanelRounded))
            //    {

            //        RPanelRounded panelPadre = (RPanelRounded)this.Parent;
            //        this.BackColor = panelPadre.BackColor1;
            //    }



            //    else
            //    {
            //        this.BackColor = this.Parent.BackColor;
            //    }

            //}
            //catch (Exception e)
            //{
            //    pevent.Graphics.Clear(this.Parent.BackColor);
            //}



            if (this.Checked)//Control encendido
            {
                //Dibujar la superficie del control según el estilo
                if (solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(onBackColor), GetFigurePath());
                }
                //Dibujar el control
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else//Contro apagado
            {
                //Dibujar la superficie del control según el estilo
                if (solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(offBackColor), GetFigurePath());
                }
                //Dibujar el control
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }

        #endregion Métodos
    }
}

