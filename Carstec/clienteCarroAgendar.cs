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
    public partial class clienteCarroAgendar : Form
    {
        public string id_carro = "";
        public string id_cliente = "";
        public int valor_carro = 0;
        public clienteCarroAgendar(string i_carro, string i_cliente)
        {
            InitializeComponent();
            id_carro = i_carro;
            id_cliente = i_cliente;

            // Conectar ao banco de dados para pegar o valor da diária do carro
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "SELECT valor_diaria FROM carro WHERE carro.id = " + id_carro;
            MySqlDataReader resultado = consulta.ExecuteReader();

            // Verificar se a consulta retornou algum valor
            if (resultado.Read())
            {
                valor_carro = Convert.ToInt32(resultado["valor_diaria"]);
            }

            resultado.Close();
            conectar.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = monthCalendar1.SelectionStart;
            DateTime dataFim = monthCalendar2.SelectionStart;
            DateTime dataAtual = DateTime.Now;

            if (dataInicio < dataAtual)
            {
                MessageBox.Show("A data de início deve ser posterior ou igual à data atual.");
                return;
            }
            else
            {
                TimeSpan diferencaDias = dataFim - dataInicio;
                int dias = diferencaDias.Days;

                if (dias < 0)
                {
                    MessageBox.Show("A data de fim não pode ser anterior à data de início.");
                    return;
                }
                else if (dias == 0)
                {
                    dias = 1;
                }

                int valorTotal = valor_carro * dias;

                label4.Text = valorTotal.ToString("F2");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Validação dos dados (datas)
            DateTime dataInicio = monthCalendar1.SelectionStart;
            DateTime dataFim = monthCalendar2.SelectionStart;
            DateTime dataAtual = DateTime.Now;

            if (dataInicio < dataAtual)
            {
                MessageBox.Show("A data de início deve ser posterior ou igual à data atual.");
                return;
            }

            TimeSpan diferencaDias = dataFim - dataInicio;
            int dias = diferencaDias.Days;

            if (dias < 0)
            {
                MessageBox.Show("A data de fim não pode ser anterior à data de início.");
                return;
            }
            else if (dias == 0)
            {
                dias = 1;
            }

            int valorTotal = valor_carro * dias;
            label4.Text = valorTotal.ToString("F2");

            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
            try
            {
                conectar.Open();

                MySqlCommand comandoAgenda = new MySqlCommand();
                comandoAgenda.Connection = conectar;
                comandoAgenda.CommandText = "INSERT INTO Agenda (data_inicio, data_fim, valor, FK_Carro_id, status) " +
                                            "VALUES (@dataInicio, @dataFim, @valor, @FK_Carro_id, 'não iniciado')";
                comandoAgenda.Parameters.AddWithValue("@dataInicio", dataInicio.ToString("yyyy-MM-dd"));
                comandoAgenda.Parameters.AddWithValue("@dataFim", dataFim.ToString("yyyy-MM-dd"));
                comandoAgenda.Parameters.AddWithValue("@valor", valorTotal.ToString("F2"));
                comandoAgenda.Parameters.AddWithValue("@FK_Carro_id", id_carro);

                comandoAgenda.ExecuteNonQuery();

                int idAgenda = (int)comandoAgenda.LastInsertedId;

                MySqlCommand comandoClienteAgenda = new MySqlCommand();
                comandoClienteAgenda.Connection = conectar;
                comandoClienteAgenda.CommandText = "INSERT INTO cliente_agenda (FK_Cliente_id, FK_Agenda_id) " +
                                                  "VALUES (@FK_Cliente_id, @FK_Agenda_id)";
                comandoClienteAgenda.Parameters.AddWithValue("@FK_Cliente_id", id_cliente);
                comandoClienteAgenda.Parameters.AddWithValue("@FK_Agenda_id", idAgenda);

                comandoClienteAgenda.ExecuteNonQuery();

                MessageBox.Show("Reserva agendada com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao agendar: " + ex.Message);
            }
            finally
            {
                conectar.Close();
            }
        }
    }
}
