using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Notificaciones
{
    /// <summary>
    /// Librería para manejo de alertas para usuarios
    /// 
    /// Desarrollada por: Ing. Erick R. Rodríguez.
    /// </summary>
    public class Notificacion
    {
        #region Atributos
        

        private static int notificacionesActivas = 1;
        private static List<int> listaNotificaciones = new List<int>();
        private static Color colorFondo;
        private static Color colorTexto;
        private static double opacidad = OPACIDAD;
        private static Font FontTitulo;
        private static Font FontMensaje;
        #endregion

        #region Propiedades
        public static List<int> ListaNotificaciones { get => listaNotificaciones; set => listaNotificaciones = value; }
        public static int NotificacionesActivas { get => notificacionesActivas; set => notificacionesActivas = value; }

        //Iconos
        public static Image ICON_OK { get; set; } = Properties.Resources.icons8_ok_64px;
        public static Image ICON_WARNING { get; set; } = Properties.Resources.icons8_warning_64px;
        public static Image ICON_ERROR { get; set; } = Properties.Resources.icons8_error_64px;
        public static Image ICON_INFO { get; set; } = Properties.Resources.icons8_info_64px;
        /// <summary>
        /// Icono personalizable.
        /// </summary>
        public static Image CUSTOM_ICON { get; set; } = Properties.Resources.icons8_info_64px;

        // Colores de fondo
        public static Color COLOR_OK { get; set; } = Color.FromArgb(0,146,14);
        public static Color COLOR_WARNING { get; set; } = Color.FromArgb(221,120,9);
        public static Color COLOR_ERROR { get; set; } = Color.FromArgb(180, 0, 0);
        public static Color COLOR_INFO { get; set; } = Color.FromArgb(0, 80, 200);
        public static Color CUSTOM_COLOR_FONDO { get; set; } = Color.FromArgb(26, 32, 40);

        // Color Texto
        /// <summary>
        /// Color del texto.
        /// </summary>
        public static Color COLOR_TEXT_OK { get; set; } = Color.FromArgb(240, 240, 240);
        public static Color COLOR_TEXT_WARNING { get; set; } = Color.FromArgb(240, 240, 240);
        public static Color COLOR_TEXT_ERROR { get; set; } = Color.FromArgb(240, 240, 240);
        public static Color COLOR_TEXT_INFO { get; set; } = Color.FromArgb(240, 240, 240);
        public static Color CUSTOM_COLOR_TEXT { get; set; } = Color.FromArgb(240, 240, 240);
        public static double OPACIDAD { get; } = 0.95D;
        public static double CUSTOM_OPACIDAD { get; set; } = 0.95D;
        public static Font FONT_TITULO { get; set; } =  new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        public static Font FONT_MENSAJE { get; set; } = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        public static Font CUSTOM_FONT_TITULO { get; set; } = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        public static Font CUSTOM_FONT_MENSAJE { get; set; } = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

        #endregion

        #region Constructor

        #endregion

        #region Métodos
        public static void Mostrar(string mensaje)
        {
            Console.WriteLine(notificacionesActivas);
            FrmNotificaciones frm = new FrmNotificaciones(notificacionesActivas, mensaje, opacidad, FontTitulo, FontMensaje);
            frm.Show();
        }

        public static void Mostrar(string mensaje, string titulo)
        {
            FrmNotificaciones frm = new FrmNotificaciones(notificacionesActivas, mensaje, titulo, opacidad, FontTitulo, FontMensaje);
            frm.Show();
        }

        public static void Mostrar(string mensaje, string titulo, int tipo)
        {
            FrmNotificaciones frm = new FrmNotificaciones(notificacionesActivas, mensaje, titulo, ObtenerIcono(tipo), colorFondo, colorTexto, opacidad, FontTitulo, FontMensaje) ;
            frm.Show();
        }

        public static void Mostrar(string mensaje, string titulo, Image tipo)
        {
            FrmNotificaciones frm = new FrmNotificaciones(notificacionesActivas, mensaje, titulo, tipo, ObtenerColor(tipo), colorTexto, opacidad, FontTitulo, FontMensaje);
            frm.Show();
        }

        public static void Mostrar(string mensaje, string titulo, int tipo, bool autoCerrar)
        {
            FrmNotificaciones frm = new FrmNotificaciones(notificacionesActivas, mensaje, titulo, ObtenerIcono(tipo), colorFondo, colorTexto, autoCerrar, opacidad, FontTitulo, FontMensaje);
            frm.Show();
        }

        /// <summary>
        /// Muestra un mensaje con título y el icono seleccionado ya sea por defecto o personalizado, también tiene control de cerrado automático.
        /// </summary>
        /// <param name="mensaje">Contenido del mensaje a mostrar.</param>
        /// <param name="titulo">Título del mensaje.</param>
        /// <param name="tipo">Tipo de icono que se va a mostrar, existen Mostrar.ICON_OK, Mostrar.ICON_WARNING, Mostrar.ICON_ERROR, Mostrar.ICON_INFO, Mostrar.CUSTOM_ICON </param>
        /// <param name="autoCerrar">Controla si se va a cerrar automáticamente o no, true se cierra automáticamente, false permanese hasta que el usuario la cierra.</param>
        public static void Mostrar(string mensaje, string titulo, Image tipo, bool autoCerrar)
        {
            FrmNotificaciones frm = new FrmNotificaciones(notificacionesActivas, mensaje, titulo, tipo, ObtenerColor(tipo), colorTexto, autoCerrar, opacidad, FontTitulo, FontMensaje);
            frm.Show();
        }

        

        

        private static Image ObtenerIcono(int tipo)
        {
            
            if (tipo == 1)
            {
                opacidad = OPACIDAD;
                colorFondo = COLOR_OK;
                colorTexto = COLOR_TEXT_OK;
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return Properties.Resources.icons8_ok_64px;
            }
            else if(tipo == 2)
            {
                opacidad = OPACIDAD;
                colorFondo = COLOR_WARNING;
                colorTexto = COLOR_TEXT_WARNING;
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return Properties.Resources.icons8_warning_64px;
            }
            else if (tipo == 3)
            {
                opacidad = OPACIDAD;
                colorFondo = COLOR_ERROR;
                colorTexto = COLOR_TEXT_ERROR;
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return Properties.Resources.icons8_error_64px;
            }
            else if (tipo == 4)
            {
                opacidad = OPACIDAD;
                colorFondo = COLOR_INFO;
                colorTexto = COLOR_TEXT_INFO;
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return Properties.Resources.icons8_info_64px;
            }
            else if (tipo == 5)
            {
                opacidad = CUSTOM_OPACIDAD;
                colorFondo = CUSTOM_COLOR_FONDO;
                colorTexto = CUSTOM_COLOR_TEXT;
                FontTitulo = CUSTOM_FONT_TITULO;
                FontMensaje = CUSTOM_FONT_MENSAJE;
                return CUSTOM_ICON;
            }
            else 
            {

                opacidad = OPACIDAD;
                colorTexto = Color.FromArgb(240, 240, 240);
                colorFondo = Color.FromArgb(26, 32, 40);
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return null;
            }
        }

        private static Color ObtenerColor(Image tipo)
        {

            if (tipo == ICON_OK)
            {
                opacidad = OPACIDAD;
                colorTexto = COLOR_TEXT_OK;
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return COLOR_OK;
            }
            else if (tipo == ICON_WARNING)
            {
                opacidad = OPACIDAD;
                colorTexto = COLOR_TEXT_WARNING;
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return COLOR_WARNING;
            }
            else if (tipo == ICON_ERROR)
            {
                opacidad = OPACIDAD;
                colorTexto = COLOR_TEXT_ERROR;
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return COLOR_ERROR;
            }
            else if (tipo == ICON_INFO)
            {
                opacidad = OPACIDAD;
                colorTexto = COLOR_TEXT_INFO;
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return COLOR_INFO;
            }
            else if (tipo == CUSTOM_ICON)
            {
                opacidad = CUSTOM_OPACIDAD;
                colorTexto = CUSTOM_COLOR_TEXT;
                FontTitulo = CUSTOM_FONT_TITULO;
                FontMensaje = CUSTOM_FONT_MENSAJE;
                return CUSTOM_COLOR_FONDO;
            }
            else
            {
                opacidad = OPACIDAD;
                colorTexto = Color.FromArgb(240, 240, 240);
                FontTitulo = FONT_TITULO;
                FontMensaje = FONT_MENSAJE;
                return Color.FromArgb(26, 32, 40);
            }
        }

        #endregion
    }
}
