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
    public partial class clienteHome : Form
    {
        public string id = "";
        public clienteHome(string i)
        {
            InitializeComponent();
            id = i;
        }

        private void carrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clienteCarroVisualizarc carCliente = new clienteCarroVisualizarc();
            carCliente.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clienteAgendaVisualizarc carCliente = new clienteAgendaVisualizarc(id);
            carCliente.Show();
        }
    }
}
