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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clienteCadastroEntrada cadCliente = new clienteCadastroEntrada();
            cadCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            administradorEntrada cadAdministrador = new administradorEntrada();
            cadAdministrador.Show();
        }
    }
}
