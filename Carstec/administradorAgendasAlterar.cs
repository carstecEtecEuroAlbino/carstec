using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Carstec
{
    public partial class administradorAgendasAlterar : Form
    {
        public string id_agenda = "";

        public administradorAgendasAlterar(string i)
        {
            InitializeComponent();
            id_agenda = i;

            try
            {
                // Conectar ao banco de dados
                using (MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD="))
                {
                    conectar.Open();

                    MySqlCommand consulta = new MySqlCommand(@"
                        SELECT c.nome 
                        FROM cliente c
                        JOIN cliente_agenda ca ON c.id = ca.FK_Cliente_id
                        JOIN agenda a ON ca.FK_Agenda_id = a.id
                        WHERE a.id = @id_agenda", conectar);

                    // Usar parâmetros para evitar SQL Injection
                    consulta.Parameters.AddWithValue("@id_agenda", id_agenda);

                    MySqlDataReader resultado = consulta.ExecuteReader();

                    if (resultado.Read())
                    {
                        // Substituir o texto da label com o nome do cliente
                        label4.Text = resultado["nome"].ToString();
                    }
                    else
                    {
                        // Caso o cliente não seja encontrado
                        label4.Text = "Nenhum cliente encontrado";
                    }

                    resultado.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Pegar as datas selecionadas no MonthCalendar
            DateTime dataInicio = monthCalendar1.SelectionStart;
            DateTime dataFim = monthCalendar2.SelectionStart;
            DateTime dataAtual = DateTime.Now.Date;

            // Validar se as datas são coerentes
            if (dataFim < dataInicio)
            {
                MessageBox.Show("A data de fim não pode ser anterior à data de início.");
                return;
            }

            try
            {
                // Atualizar as datas no banco de dados
                using (MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD="))
                {
                    conectar.Open();

                    // Definir o status com base na data
                    string novoStatus = dataInicio == dataAtual ? "em andamento" : "não iniciado";

                    MySqlCommand comandoAtualizar = new MySqlCommand(@"
                        UPDATE agenda 
                        SET data_inicio = @dataInicio, data_fim = @dataFim, status = @status
                        WHERE id = @id_agenda", conectar);

                    // Adicionar os parâmetros
                    comandoAtualizar.Parameters.AddWithValue("@dataInicio", dataInicio.ToString("yyyy-MM-dd"));
                    comandoAtualizar.Parameters.AddWithValue("@dataFim", dataFim.ToString("yyyy-MM-dd"));
                    comandoAtualizar.Parameters.AddWithValue("@status", novoStatus);
                    comandoAtualizar.Parameters.AddWithValue("@id_agenda", id_agenda);

                    int linhasAfetadas = comandoAtualizar.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Datas atualizados com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro: Nenhuma linha foi atualizada. Verifique o ID da agenda.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar a agenda: " + ex.Message);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Lógica adicional (se necessário) ao alterar a data no MonthCalendar1
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Lógica adicional (se necessário) ao alterar a data no MonthCalendar2
        }
    }
}
