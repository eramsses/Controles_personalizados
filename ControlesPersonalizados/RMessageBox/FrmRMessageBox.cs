using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMessageBoxCustom
{
    public partial class FrmRMessageBox : Form
    {
        public FrmRMessageBox()
        {
            InitializeComponent();

            
        }

        public RDialogResult ShowCore()
        {

            return RDialogResult.OK;
        }

    }
}
