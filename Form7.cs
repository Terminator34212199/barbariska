using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace praktika
{
    public partial class Form7 : Form
    {
        private MySqlConnection Collection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Form7()
        {
            InitializeComponent();
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            server = "localhost";
            database = "clinic";
            uid = "root";
            password = "34neverdXe!451219S!";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            Collection = new MySqlConnection(connectionString);
            LoadData1();
            //LoadData2();
            //LoadData3();
        }

        private void LoadData1()
        {
            string connectionString = "Server=localhost;Database=clinic;User ID=root;Password=34neverdXe!451219S!;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM time";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Устанавливаем источник данных
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e) //Пустой метод
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();   
        }

        private void Form7_Load_1(object sender, EventArgs e) //Пустой метод
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //Пустой метод
        {

        }
    }
}
