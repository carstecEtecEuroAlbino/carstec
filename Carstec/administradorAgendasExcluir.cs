using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Carstec
{
    public partial class administradorAgendasExcluir : Form
    {
        public string id = "";

        public administradorAgendasExcluir(string i)
        {
            InitializeComponent();
            id = i;

            try
            {
                // Conectar ao banco de dados
                using (MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD="))
                {
                    conectar.Open();

                    // Consulta para buscar informações da agenda
                    MySqlCommand consulta = new MySqlCommand(@"
                        SELECT 
                            c.nome AS cliente,
                            a.data_inicio AS dataInicio,
                            a.data_fim AS dataFim,
                            a.status AS status
                        FROM agenda a
                        JOIN cliente_agenda ca ON a.id = ca.FK_Agenda_id
                        JOIN cliente c ON ca.FK_Cliente_id = c.id
                        WHERE a.id = @id_agenda", conectar);

                    consulta.Parameters.AddWithValue("@id_agenda", id);

                    using (MySqlDataReader resultado = consulta.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            // Atualizar as labels com os valores retornados
                            label8.Text = resultado["cliente"].ToString();
                            label7.Text = Convert.ToDateTime(resultado["dataInicio"]).ToString("dd/MM/yyyy");
                            label6.Text = Convert.ToDateTime(resultado["dataFim"]).ToString("dd/MM/yyyy");
                            label5.Text = resultado["status"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma agenda encontrada com o ID fornecido.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações da agenda: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Conectar ao banco de dados
                using (MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD="))
                {
                    conectar.Open();

                    // Apagar a agenda pelo ID
                    MySqlCommand comandoExcluir = new MySqlCommand(@"
                        DELETE FROM cliente_agenda WHERE FK_Agenda_id = @id_agenda;
                        DELETE FROM agenda WHERE id = @id_agenda;", conectar);

                    comandoExcluir.Parameters.AddWithValue("@id_agenda", id);

                    int linhasAfetadas = comandoExcluir.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Agenda excluída com sucesso!");
                        this.Close(); // Fecha o formulário após a exclusão
                    }
                    else
                    {
                        MessageBox.Show("Erro: Não foi possível excluir a agenda. Verifique o ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir a agenda: " + ex.Message);
            }
        }
    }
}
