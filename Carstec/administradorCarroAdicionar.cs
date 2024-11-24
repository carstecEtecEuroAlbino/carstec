using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carstec
{
    public partial class administradorCarroAdicionar : Form
    {
        public string id = "";
        public administradorCarroAdicionar(string i)
        {
            InitializeComponent();
            id = i;
        }

        private void administradorCarroAdicionar_Load(object sender, EventArgs e)
        {

        }
    }
}
