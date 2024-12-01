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
    public partial class administradorEntrada : Form
    {
        public administradorEntrada()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=;";

            // Capturar os dados do formulário
            string email = textBox4.Text; // Email do administrador
            string senha = textBox3.Text; // Senha do administrador

            // Validação básica dos campos
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha o email e a senha.");
                return;
            }

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    // Verificar se o email e senha correspondem a um administrador
                    string loginQuery = "SELECT COUNT(*) FROM administrador WHERE email = @Email AND senha = @Senha";
                    using (MySqlCommand loginCommand = new MySqlCommand(loginQuery, conexao))
                    {
                        loginCommand.Parameters.AddWithValue("@Email", email);
                        loginCommand.Parameters.AddWithValue("@Senha", senha);

                        int count = Convert.ToInt32(loginCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Login realizado com sucesso!");
                            // Abrir o painel de administrador
                            administradorHome cadCliente = new administradorHome();
                            cadCliente.Show();
                            this.Close(); // Fecha o formulário atual
                        }
                        else
                        {
                            MessageBox.Show("Email ou senha incorretos. Tente novamente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar login: {ex.Message}");
            }




          
        }








        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void administradorEntrada_Load(object sender, EventArgs e)
        {

        }
    }
    

}
