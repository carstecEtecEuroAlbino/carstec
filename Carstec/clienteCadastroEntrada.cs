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
    public partial class clienteCadastroEntrada : Form
    {
        public clienteCadastroEntrada()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clienteHome cadCliente = new clienteHome();
            cadCliente.Show();
        }
    }
}
