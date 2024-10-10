using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Добавьте эту строку

namespace praktika
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string medkarta = textBox1.Text;
            string password = textBox2.Text;

            // Строка подключения к MySQL
            string connectionString = "server=localhost;database=clinic;Uid=root;Pwd=34neverdXe!451219S!;";

            // Проверка авторизации
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM users WHERE Medkarta = @medkarta AND Parol = @password";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@medkarta", medkarta);
                        command.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Пользователь найден, проверяем тип
                                string role = reader["Kodovoeslovo"].ToString(); //Неявное преобразование в string, можно заменить на reader.GetString()

                                if (role == "Администратор")
                                {
                                    MessageBox.Show("Авторизация успешна! Добро пожаловать, Администратор!", "Авторизация");
                                    // Открыть форму для администратора
                                    Form6 newForm = new Form6();
                                    newForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Ошибка: Неверный тип пользователя!", "Авторизация");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ошибка: Неверный логин или пароль!", "Авторизация");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message, "Ошибка");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
