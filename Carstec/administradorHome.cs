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
    public partial class administradorHome : Form
    {
        public administradorHome()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            administradorClientesVisualizar administradorClientesVisualizar = new administradorClientesVisualizar();
            administradorClientesVisualizar.Show();
        }

        private void carroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            administradorCarroVisualizar administradorCarroVisualizar = new administradorCarroVisualizar();
            administradorCarroVisualizar.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            administradorAgendasVisualizar administradorAgendasVisualizar = new administradorAgendasVisualizar();
            administradorAgendasVisualizar.Show();
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            administradorAdministradorVisualizar administradorAdministradorVisualizar = new administradorAdministradorVisualizar();
            administradorAdministradorVisualizar.Show();
        }
    }
}
