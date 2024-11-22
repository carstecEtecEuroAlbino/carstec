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
    public partial class clienteCadastroEntrada : Form
    {
        public clienteCadastroEntrada()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Conexão com o banco de dados
            string connectionString = "SERVER=127.0.0.1; DATABASE=carstectop; UID=root; PASSWORD=;";

            // Valores dos campos do formulário
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string cpf = textBox3.Text;   // Certifique-se de que esse campo está preenchido
            string senha = textBox4.Text; // Certifique-se de que esse campo está preenchido

            // Validação básica de campos
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    // Verificar duplicatas pelo campo email
                    string checkQuery = "SELECT COUNT(*) FROM cliente WHERE email = @Email";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, conexao))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Erro: Já existe um cliente com este e-mail.");
                            return;
                        }
                    }

                    // Inserir novo registro
                    string inserir = "INSERT INTO cliente (nome, email, cpf, senha) VALUES (@Nome, @Email, @Cpf, @Senha)";
                    using (MySqlCommand comandos = new MySqlCommand(inserir, conexao))
                    {
                        comandos.Parameters.AddWithValue("@Nome", nome);
                        comandos.Parameters.AddWithValue("@Email", email);
                        comandos.Parameters.AddWithValue("@Cpf", cpf);
                        comandos.Parameters.AddWithValue("@Senha", senha);

                        comandos.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente cadastrado com sucesso!");

                // Abrir o novo formulário e fechar o atual
                clienteHome clienteHome = new clienteHome();
                clienteHome.Show();
                this.Close(); // Fecha o formulário atual
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Conexão com o banco de dados
            string connectionString = "SERVER=127.0.0.1; DATABASE=carstectop; UID=root; PASSWORD=;";

            // Valores dos campos do formulário
            string cpf = textBox5.Text;
            string senha = textBox6.Text;

            // Validação básica de campos
            if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha CPF e Senha para entrar.");
                return;
            }

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    // Query para verificar CPF e senha
                    string loginQuery = "SELECT COUNT(*) FROM cliente WHERE cpf = @Cpf AND senha = @Senha";
                    using (MySqlCommand loginCommand = new MySqlCommand(loginQuery, conexao))
                    {
                        // Adicionar os parâmetros na query
                        loginCommand.Parameters.AddWithValue("@Cpf", cpf);
                        loginCommand.Parameters.AddWithValue("@Senha", senha);

                        // Executar a consulta
                        int count = Convert.ToInt32(loginCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Login realizado com sucesso!");

                            // Abrir o próximo formulário (exemplo: página inicial do cliente)
                            clienteHome clienteHome = new clienteHome();
                            clienteHome.Show();
                            this.Close(); // Fecha o formulário atual
                        }
                        else
                        {
                            MessageBox.Show("CPF ou Senha incorretos. Tente novamente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void clienteCadastroEntrada_Load(object sender, EventArgs e)
        {

        }
    }
}
