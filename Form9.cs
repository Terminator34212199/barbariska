using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace praktika
{
    public partial class Form9 : Form
    {
        // Замените данными вашей базы данных
        private string connectionString = "Server=localhost;Database=clinic;Uid=root;Pwd=34neverdXe!451219S!;";

        public Form9()
        {
            InitializeComponent();
            LoadServices(); //Неккоректное использование LoadServices()
        }

        private void LoadServices()
        {
            // Пример: Загрузите услуги из таблицы services в базе данных
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Исправленная строка запроса:
                    string query = "SELECT specialnost FROM clinic.vrachi;"; // Предполагается, что у вас есть таблица vrachi
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxVrachi.Items.Add(reader["specialnost"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fio = textBox1.Text;
            string dataa = textBox2.Text;
            string vremya = textBox3.Text;
            string vrachi = comboBoxVrachi.SelectedItem?.ToString(); // Получаем выбранное значение
            if (string.IsNullOrEmpty(vrachi))
            {
                MessageBox.Show("Пожалуйста, выберите врача.");
                return;
            }

            // Исправление: 
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Исправленная строка запроса:
                    string query = "INSERT INTO zapis (fio, dataa, vremya, vrach) VALUES (@fio, @dataa, @vremya, @vrach)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fio", fio);
                    command.Parameters.AddWithValue("@dataa", dataa);
                    command.Parameters.AddWithValue("@vremya", vremya);
                    command.Parameters.AddWithValue("@vrach", vrachi); // Исправлено: "vrach" вместо "vrachi"

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Запись успешно сохранена!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при сохранении записи.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
