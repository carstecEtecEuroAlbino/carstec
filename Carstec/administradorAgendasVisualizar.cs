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


            while (resultado.Read())
            {
                string colunaNome = resultado["Field"].ToString();
                dataGridView1.Columns.Add(colunaNome, colunaNome);
                comboBox1.Items.Add(resultado["Field"].ToString());
            }

            resultado.Close();

            consulta.CommandText = "SELECT * FROM agenda";
            resultado = consulta.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    object[] rowValues = new object[dataGridView1.Columns.Count];
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
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
            consulta.CommandText = "SELECT * FROM agenda WHERE " + campo + " LIKE '%" + nomecampo + "%'";
            dataGridView1.Rows.Clear();
            MySqlDataReader resultado = consulta.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    object[] rowValues = new object[dataGridView1.Columns.Count];
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
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
