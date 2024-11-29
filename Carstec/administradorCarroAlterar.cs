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
    public partial class administradorCarroAlterar : Form
    {
        public string id = "";
        public administradorCarroAlterar(string i)
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
                    textBox1.Text = resultado["marca"].ToString();
                    textBox2.Text = resultado["modelo"].ToString();
                    textBox3.Text = resultado["ano"].ToString();
                    textBox4.Text = resultado["quantidade"].ToString();
                    textBox5.Text = resultado["valor_diaria"].ToString();
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
            string inserir = "UPDATE carro SET marca = '" + textBox1.Text + "', modelo = '" + textBox2.Text + "', ano = '" + textBox3.Text + "', quantidade = '" + textBox4.Text + "', valor_diaria = '" + textBox5.Text + "' WHERE carro.id = " + id;
            MySqlCommand comandos = new MySqlCommand(inserir, conexao);
            comandos.ExecuteNonQuery();
            conexao.Close();
            MessageBox.Show("Carro atualizado com sucesso!");
            this.Close();
        } 
        
        
        private void administradorCarroAlterar_Load(object sender, EventArgs e)
        {

        }

    }
}
