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
            clienteCarroVisualizarc carCliente = new clienteCarroVisualizarc(id);
            carCliente.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clienteAgendaVisualizarc carCliente = new clienteAgendaVisualizarc(id);
            carCliente.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Close();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clienteClienteAlterar clienteClienteAlterar = new clienteClienteAlterar(id);
            clienteClienteAlterar.Show();
        }
    }
}
