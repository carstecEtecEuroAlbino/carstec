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
    public partial class administradorAgendasVisualizar : Form
    {
        public administradorAgendasVisualizar()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = false;
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "DESC agenda";
            dataGridView1.Rows.Clear();
            MySqlDataReader resultado = consulta.ExecuteReader();

            // Adicionar colunas da tabela 'agenda'
            while (resultado.Read())
            {
                string colunaNome = resultado["Field"].ToString();
                dataGridView1.Columns.Add(colunaNome, colunaNome);
                comboBox1.Items.Add(resultado["Field"].ToString());
            }

            // Adicionar coluna para o nome do cliente
            dataGridView1.Columns.Add("cliente_nome", "Cliente");

            resultado.Close();

            // Atualizar a consulta SQL para incluir a tabela 'cliente' usando a tabela intermediária 'cliente_agenda'
            consulta.CommandText = @"SELECT a.*, c.nome AS cliente_nome
                                    FROM agenda a
                                    JOIN cliente_agenda ca ON a.id = ca.FK_Agenda_id
                                    JOIN cliente c ON ca.FK_Cliente_id = c.id";
            resultado = consulta.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    object[] rowValues = new object[dataGridView1.Columns.Count];
                    for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)  // Excluir a coluna do nome do cliente
                    {
                        if (resultado.GetOrdinal(dataGridView1.Columns[i].Name) != -1)
                        {
                            rowValues[i] = resultado.GetValue(resultado.GetOrdinal(dataGridView1.Columns[i].Name));
                        }
                        else
                        {
                            rowValues[i] = DBNull.Value;
                        }
                    }
                    // Preencher o nome do cliente na última coluna
                    rowValues[dataGridView1.Columns.Count - 1] = resultado["cliente_nome"];
                    dataGridView1.Rows.Add(rowValues);
                }

                resultado.Close();
            }
            else
            {
                MessageBox.Show("Nenhum registro foi encontrado!");
            }

            conectar.Close();
            dataGridView1.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = row.Cells["id"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;

            administradorAgendasAlterar administradorAgendasAlterar = new administradorAgendasAlterar(id);
            administradorAgendasAlterar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;

            administradorAgendasExcluir administradorAgendasExcluir = new administradorAgendasExcluir(id);
            administradorAgendasExcluir.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string campo = Convert.ToString(comboBox1.Text);
            string nomecampo = Convert.ToString(textBox1.Text);

            dataGridView1.ReadOnly = false;
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = "SELECT a.*, c.nome AS cliente_nome FROM agenda a " +
                                   "JOIN cliente_agenda ca ON a.id = ca.FK_Agenda_id " +
                                   "JOIN cliente c ON ca.FK_Cliente_id = c.id " +
                                   "WHERE " + campo + " LIKE '%" + nomecampo + "%'";
            dataGridView1.Rows.Clear();
            MySqlDataReader resultado = consulta.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    object[] rowValues = new object[dataGridView1.Columns.Count];
                    for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)  // Excluir a coluna do nome do cliente
                    {
                        if (resultado.GetOrdinal(dataGridView1.Columns[i].Name) != -1)
                        {
                            rowValues[i] = resultado.GetValue(resultado.GetOrdinal(dataGridView1.Columns[i].Name));
                        }
                        else
                        {
                            rowValues[i] = DBNull.Value;
                        }
                    }
                    // Preencher o nome do cliente na última coluna
                    rowValues[dataGridView1.Columns.Count - 1] = resultado["cliente_nome"];
                    dataGridView1.Rows.Add(rowValues);
                }

                resultado.Close();
            }
            else
            {
                MessageBox.Show("Nenhum registro foi encontrado!");
            }

            conectar.Close();
            dataGridView1.ReadOnly = true;
        }
    }
}
