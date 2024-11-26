using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Carstec
{
    public partial class administradorAgendasAlterar : Form
    {
        public string id = ""; // ATENÇÇÃO ESSE É O ID DA AGENDA
        public administradorAgendasAlterar(string i)
        {
            InitializeComponent();
            id = i;
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "SELECT nome FROM cliente WHERE cliente.id = " + id;
            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.Read()) 
            {
                label4.Text = resultado["nome"].ToString(); 
            }
            else
            {
                label4.Text = "Nenhum cliente encontrado"; 
            }
        }
    }
}
