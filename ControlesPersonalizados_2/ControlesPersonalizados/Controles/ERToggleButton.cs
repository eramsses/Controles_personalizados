using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ControlesPersonalizados.Controles
{
    class ERToggleButton : CheckBox
    {
        //Campos
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;


        //Constructor
        public ERToggleButton()
        {
            this.MinimumSize = new Size(45, 22);

        }

        //Metodos
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

            if (this.Checked)//Control encendido
            {
                //Dibujar la superficie del control
                pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                //Dibujar el control
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else//Contro apagado
            {
                //Dibujar la superficie del control
                pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                //Dibujar el control
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
