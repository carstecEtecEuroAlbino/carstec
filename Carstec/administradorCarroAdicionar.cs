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
    public partial class administradorCarroAdicionar : Form
    {
        public string id = "";
        public administradorCarroAdicionar(string i)
        {
            InitializeComponent();
            id = i;
        }

        private void administradorCarroAdicionar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                string connectionString = "SERVER=localhost; DATABASE=carstec; UID=root; PASSWORD=;";
                string marca = textBox6.Text.Trim();
                string modelo = textBox5.Text.Trim();
                string ano = textBox4.Text.Trim();
                string quantidade = textBox1.Text.Trim();
                string valorDiaria = textBox3.Text.Trim();

                // Validação dos campos obrigatórios
                if (string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(modelo) ||
                    string.IsNullOrWhiteSpace(ano) || string.IsNullOrWhiteSpace(quantidade) ||
                    string.IsNullOrWhiteSpace(valorDiaria))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                    return;
                }

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(connectionString))
                    {
                        conexao.Open();

                        // Validação se já existe um carro com a mesma marca e modelo
                        string checkCarroQuery = "SELECT COUNT(*) FROM carro WHERE marca = @marca AND modelo = @modelo";
                        using (MySqlCommand checkCarroCommand = new MySqlCommand(checkCarroQuery, conexao))
                        {
                            checkCarroCommand.Parameters.AddWithValue("@marca", marca);
                            checkCarroCommand.Parameters.AddWithValue("@modelo", modelo);
                            int carroCount = Convert.ToInt32(checkCarroCommand.ExecuteScalar());

                            if (carroCount > 0)
                            {
                                MessageBox.Show("Erro: Já existe um carro com este modelo.");
                                return;
                            }
                        }

                        // Inserção do novo carro na tabela
                        string inserir = "INSERT INTO carro (marca, modelo, ano, quantidade, valor_diaria) " +
                                         "VALUES (@marca, @modelo, @ano, @quantidade, @valor_diaria)";
                        using (MySqlCommand comandos = new MySqlCommand(inserir, conexao))
                        {
                            comandos.Parameters.AddWithValue("@marca", marca);
                            comandos.Parameters.AddWithValue("@modelo", modelo);
                            comandos.Parameters.AddWithValue("@ano", int.Parse(ano)); // Conversão para inteiro
                            comandos.Parameters.AddWithValue("@quantidade", int.Parse(quantidade)); // Conversão para inteiro
                            comandos.Parameters.AddWithValue("@valor_diaria", decimal.Parse(valorDiaria)); // Conversão para decimal
                            comandos.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Carro cadastrado com sucesso!");

                    // Limpa os campos após o cadastro
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox4.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Erro no formato dos valores: {ex.Message}");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erro ao cadastrar carro no banco de dados: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro inesperado: {ex.Message}");
                }
            }

        }
    }

