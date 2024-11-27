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
                string userId;

                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    string checkEmailQuery = "SELECT COUNT(*) FROM cliente WHERE email = @Email";
                    using (MySqlCommand checkEmailCommand = new MySqlCommand(checkEmailQuery, conexao))
                    {
                        checkEmailCommand.Parameters.AddWithValue("@Email", email);
                        int emailCount = Convert.ToInt32(checkEmailCommand.ExecuteScalar());

                        if (emailCount > 0)
                        {
                            MessageBox.Show("Erro: Já existe um cliente com este e-mail.");
                            return;
                        }
                    }

                    string checkCpfQuery = "SELECT COUNT(*) FROM cliente WHERE cpf = @Cpf";
                    using (MySqlCommand checkCpfCommand = new MySqlCommand(checkCpfQuery, conexao))
                    {
                        checkCpfCommand.Parameters.AddWithValue("@Cpf", cpf);
                        int cpfCount = Convert.ToInt32(checkCpfCommand.ExecuteScalar());

                        if (cpfCount > 0)
                        {
                            MessageBox.Show("Erro: Já existe um cliente com este CPF.");
                            return;
                        }
                    }

                    string inserir = "INSERT INTO cliente (nome, email, cpf, senha) VALUES (@Nome, @Email, @Cpf, @Senha)";
                    using (MySqlCommand comandos = new MySqlCommand(inserir, conexao))
                    {
                        comandos.Parameters.AddWithValue("@Nome", nome);
                        comandos.Parameters.AddWithValue("@Email", email);
                        comandos.Parameters.AddWithValue("@Cpf", cpf);
                        comandos.Parameters.AddWithValue("@Senha", senha);
                        comandos.ExecuteNonQuery();
                    }

                    string getIdQuery = "SELECT id FROM cliente WHERE cpf = @Cpf";
                    using (MySqlCommand getIdCommand = new MySqlCommand(getIdQuery, conexao))
                    {
                        getIdCommand.Parameters.AddWithValue("@Cpf", cpf);
                        userId = getIdCommand.ExecuteScalar().ToString();
                    }
                }

                MessageBox.Show($"Cliente cadastrado com sucesso! ID: {userId}");

                clienteHome clienteHome = new clienteHome(userId);
                clienteHome.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
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
                string userId;

                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    string loginQuery = "SELECT id FROM cliente WHERE cpf = @Cpf AND senha = @Senha";
                    using (MySqlCommand loginCommand = new MySqlCommand(loginQuery, conexao))
                    {
                        loginCommand.Parameters.AddWithValue("@Cpf", cpf);
                        loginCommand.Parameters.AddWithValue("@Senha", senha);

                        object result = loginCommand.ExecuteScalar();

                        if (result != null)
                        {
                            userId = result.ToString();
                            MessageBox.Show($"Login realizado com sucesso! ID: {userId}");

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
