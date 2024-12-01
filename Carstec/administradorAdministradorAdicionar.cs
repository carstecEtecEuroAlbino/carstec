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
    public partial class administradorAdministradorAdicionar : Form
    {
        public string id = "";
        public administradorAdministradorAdicionar(string i)
        {
            InitializeComponent();
            id = i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=;";

            // Capturar os dados do formulário
            string nome = textBox6.Text;  // Nome do administrador
            string email = textBox5.Text; // Email do administrador
            string senha = textBox1.Text; // Senha do administrador

            // Validação básica dos campos
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    // Verificar se o email já existe no banco de dados
                    string checkQuery = "SELECT COUNT(*) FROM administrador WHERE email = @Email";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, conexao))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Erro: Já existe um administrador com este email.");
                            return;
                        }
                    }

                    // Inserir o novo administrador
                    string inserir = "INSERT INTO administrador (nome, email, senha) VALUES (@Nome, @Email, @Senha)";
                    using (MySqlCommand comandos = new MySqlCommand(inserir, conexao))
                    {
                        comandos.Parameters.AddWithValue("@Nome", nome);
                        comandos.Parameters.AddWithValue("@Email", email);
                        comandos.Parameters.AddWithValue("@Senha", senha);

                        comandos.ExecuteNonQuery();
                        MessageBox.Show("Administrador cadastrado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar administrador: {ex.Message}");
            }
           
        }

        private void administradorAdministradorAdicionar_Load(object sender, EventArgs e)
        {

        }
    }
}
