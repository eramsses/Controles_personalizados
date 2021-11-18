using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMessageBoxCustom
{

    public class RMessageBoxIcon
    {
        private Image none = null;
        private Image ok = Properties.Resources.icons8_ok_64px;
        private Image error = Properties.Resources.icons8_error_64px;
        private Image info = Properties.Resources.icons8_info_64px;
        private Image warning = Properties.Resources.icons8_warning_64px;

        public Image NONE => none;
        public Image OK
        {
            get => ok;

            set => ok = value;
        }

        public Image ERROR
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }

        public Image INFO
        {
            get
            {
                return info;
            }

            set
            {
                info = value;
            }
        }

        public Image WARNING
        {
            get
            {
                return warning;
            }

            set
            {
                warning = value;
            }
        }
    }
}
