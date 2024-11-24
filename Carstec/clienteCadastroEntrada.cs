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
            string connectionString = "SERVER=localhost; DATABASE=carstec; UID=root; PASSWORD=;";
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string cpf = textBox3.Text;
            string senha = textBox4.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            try
            {
                string userId; // Variável para armazenar o ID do usuário como string

                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    // Verificar duplicidade de email
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

                    // Inserir novo cliente
                    string inserir = "INSERT INTO cliente (nome, email, cpf, senha) VALUES (@Nome, @Email, @Cpf, @Senha)";
                    using (MySqlCommand comandos = new MySqlCommand(inserir, conexao))
                    {
                        comandos.Parameters.AddWithValue("@Nome", nome);
                        comandos.Parameters.AddWithValue("@Email", email);
                        comandos.Parameters.AddWithValue("@Cpf", cpf);
                        comandos.Parameters.AddWithValue("@Senha", senha);
                        comandos.ExecuteNonQuery();
                    }

                    // Recuperar o ID do usuário recém-cadastrado
                    string getIdQuery = "SELECT id FROM cliente WHERE cpf = @Cpf";
                    using (MySqlCommand getIdCommand = new MySqlCommand(getIdQuery, conexao))
                    {
                        getIdCommand.Parameters.AddWithValue("@Cpf", cpf);
                        userId = getIdCommand.ExecuteScalar().ToString(); // Convertendo para string
                    }
                }

                MessageBox.Show($"Cliente cadastrado com sucesso! ID: {userId}");

                // Agora você pode abrir a próxima tela ou usar o ID conforme necessário
                clienteHome clienteHome = new clienteHome(userId);
                clienteHome.Show();
                this.Close();
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
            string connectionString = "SERVER=localhost; DATABASE=carstec; UID=root; PASSWORD=;";
            string cpf = textBox5.Text;
            string senha = textBox6.Text;

            if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha CPF e Senha para entrar.");
                return;
            }

            try
            {
                string userId; // Variável para armazenar o ID do usuário como string

                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    // Verificar as credenciais e obter o ID do usuário
                    string loginQuery = "SELECT id FROM cliente WHERE cpf = @Cpf AND senha = @Senha";
                    using (MySqlCommand loginCommand = new MySqlCommand(loginQuery, conexao))
                    {
                        loginCommand.Parameters.AddWithValue("@Cpf", cpf);
                        loginCommand.Parameters.AddWithValue("@Senha", senha);

                        object result = loginCommand.ExecuteScalar();

                        if (result != null)
                        {
                            userId = result.ToString(); // Recupera o ID do usuário como string
                            MessageBox.Show($"Login realizado com sucesso! ID: {userId}");

                            // Agora você pode abrir a próxima tela ou usar o ID conforme necessário
                            clienteHome clienteHome = new clienteHome(userId);
                            clienteHome.Show();
                            this.Close();
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
