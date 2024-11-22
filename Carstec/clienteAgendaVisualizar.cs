using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Carstec
{
    public partial class clienteCarroVisualizar : Form
    {
        public string id_cliente = "";

        public clienteCarroVisualizar(string i)
        {
            InitializeComponent();
            id_cliente = i;
            dataGridView1.ReadOnly = false;

            try
            {
                MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
                conectar.Open();

                MySqlCommand consulta = new MySqlCommand();
                consulta.Connection = conectar;

                // Consulta para trazer o histórico de agenda do cliente
                consulta.CommandText = @"
                    SELECT 
                        Agenda.id AS 'ID Agenda',
                        Carro.marca AS 'Marca',
                        Carro.modelo AS 'Modelo',
                        Agenda.data_inicio AS 'Data Início',
                        Agenda.data_fim AS 'Data Fim',
                        Agenda.valor AS 'Valor',
                        Agenda.status AS 'Status'
                    FROM 
                        cliente_agenda
                    INNER JOIN 
                        Agenda ON cliente_agenda.FK_Agenda_id = Agenda.id
                    INNER JOIN 
                        Carro ON Agenda.FK_Carro_id = Carro.id
                    WHERE 
                        cliente_agenda.FK_Cliente_id = @id_cliente";

                consulta.Parameters.AddWithValue("@id_cliente", id_cliente);

                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o histórico: " + ex.Message);
            }

            dataGridView1.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = row.Cells["ID Agenda"].Value.ToString();

                // Como não há foto na tabela Agenda, nada será carregado no PictureBox
                pictureBox1.Image = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string campo = Convert.ToString(comboBox1.Text);
            string nomecampo = Convert.ToString(textBox1.Text);

            try
            {
                MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
                conectar.Open();

                MySqlCommand consulta = new MySqlCommand();
                consulta.Connection = conectar;

                // Busca por campo específico no histórico
                consulta.CommandText = @"
                    SELECT 
                        Agenda.id AS 'ID Agenda',
                        Carro.marca AS 'Marca',
                        Carro.modelo AS 'Modelo',
                        Agenda.data_inicio AS 'Data Início',
                        Agenda.data_fim AS 'Data Fim',
                        Agenda.valor AS 'Valor',
                        Agenda.status AS 'Status'
                    FROM 
                        cliente_agenda
                    INNER JOIN 
                        Agenda ON cliente_agenda.FK_Agenda_id = Agenda.id
                    INNER JOIN 
                        Carro ON Agenda.FK_Carro_id = Carro.id
                    WHERE 
                        cliente_agenda.FK_Cliente_id = @id_cliente
                        AND " + campo + " LIKE @nomecampo";

                consulta.Parameters.AddWithValue("@id_cliente", id_cliente);
                consulta.Parameters.AddWithValue("@nomecampo", "%" + nomecampo + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar registros: " + ex.Message);
            }
        }
    }
}
