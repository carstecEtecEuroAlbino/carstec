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
    public partial class clienteClienteAlterar : Form
    {
        public string id = "";
        public clienteClienteAlterar(string i)
        {
            InitializeComponent();
            id = i;
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "SELECT * FROM cliente WHERE cliente.id = " + id;
            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    textBox2.Text = resultado["email"].ToString();
                    textBox4.Text = resultado["senha"].ToString();
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro foi encontrado!");
            }
            conectar.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection();
            conexao.ConnectionString = ("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
            conexao.Open();
            string inserir = "UPDATE cliente SET email = '" + textBox2.Text + "', senha = '" + textBox4.Text + "' WHERE cliente.id = " + id;
            MySqlCommand comandos = new MySqlCommand(inserir, conexao);
            comandos.ExecuteNonQuery();
            conexao.Close();
            MessageBox.Show("Cliente atualizado com sucesso!");
            this.Close();
        }
    }
}
