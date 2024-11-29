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
    public partial class administradorCarroExcluir : Form
    {
        public string id = "";
        public administradorCarroExcluir(string i)
        {
            InitializeComponent();
            id = i;
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "SELECT * FROM carro WHERE carro.id = " + id;
            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    textBox1.Text = resultado["id"].ToString();
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
            conexao.ConnectionString = ("SERVER=127.0.0.1; DATABASE=carstec; UID = root; PASSWORD = ; ");
            conexao.Open();
            string inserir = "DELETE FROM carro WHERE carro.id = " + id;
            MySqlCommand comandos = new MySqlCommand(inserir, conexao);
            comandos.ExecuteNonQuery();
            conexao.Close();
            MessageBox.Show("Carro excluido com sucesso!");
            this.Close();
        }
    }
}
