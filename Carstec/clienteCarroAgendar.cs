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
    public partial class clienteCarroAgendar : Form
    {
        public string id_carro = "";
        public clienteCarroAgendar(string i)
        {
            InitializeComponent();
            id_carro = i;
        }
    }
}
