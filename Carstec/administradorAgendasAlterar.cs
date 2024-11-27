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
    public partial class administradorAgendasAlterar : Form
    {
        public string id_agenda = "";

        public administradorAgendasAlterar(string i)
        {
            InitializeComponent();
            id_agenda = i;

            // Conectar ao banco de dados
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=carstec;UID=root;PASSWORD=");
            conectar.Open();

            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;

            // Consulta para pegar o nome do cliente associado ao agendamento
            consulta.CommandText = @"
                SELECT c.nome 
                FROM cliente c
                JOIN cliente_agenda ca ON c.id = ca.FK_Cliente_id
                JOIN agenda a ON ca.FK_Agenda_id = a.id
                WHERE a.id = @id_agenda";

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
            conectar.Close();
        }
    }
}
