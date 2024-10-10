using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace praktika
{
    public partial class Form6 : Form
    {
        MySqlConnection connection;
        string currentTableName; // Хранит имя текущей таблицы
        TabPage currentTabPage; // Хранит текущую вкладку
        DataGridView currentDataGridView; // Хранит ссылку на текущий DataGridView



        public Form6()
        {
            InitializeComponent();

            // Настройка подключения к базе данных
            string connectionString = "server=localhost;database=clinic;Uid=root;Pwd=34neverdXe!451219S!;";
            connection = new MySqlConnection(connectionString);
            connection.Open(); // Нет обработчика ошибок для проверки подключения к БД

            // Отображение данных таблицы appointments на tabPage1
            DisplayDataInTab("SELECT * FROM clinic.users;", tabPage1);
            // Отображение данных таблицы freetime на tabPage2
            DisplayDataInTab("SELECT * FROM clinic.time;", tabPage2);
            // Отображение данных таблицы services на tabPage3
            DisplayDataInTab("SELECT * FROM clinic.vrachi;", tabPage3);
            // Отображение данных таблицы users на tabPage4
            DisplayDataInTab("SELECT * FROM  clinic.zapis;", tabPage4);
        }
        private void DisplayDataInTab(string query, TabPage tabPage)
        {
            // Создание DataGridView для каждой вкладки
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackgroundColor = Color.LavenderBlush,
                ColumnHeadersDefaultCellStyle = { BackColor = Color.LavenderBlush },
                DefaultCellStyle = { SelectionBackColor = Color.Snow, BackColor = Color.Snow }
            };

            // Выполнение запроса к базе данных
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Привязка данных к DataGridView
            dataGridView.DataSource = dataTable;

            // Добавление DataGridView на вкладку
            tabPage.Controls.Add(dataGridView);

            // Добавление TextBox для ввода запроса
            TextBox textBox = new TextBox
            {
                Dock = DockStyle.Top,
                Height = 30,
                Multiline = true,
                Text = "Введите SQL-запрос..."
            };
            tabPage.Controls.Add(textBox);

            // Добавление кнопок "Удалить", "Изменить", "Добавить"
            Button deleteButton = new Button { Text = "Удалить", Dock = DockStyle.Right, Width = 100 };
            Button updateButton = new Button { Text = "Изменить", Dock = DockStyle.Right, Width = 100 };
            Button insertButton = new Button { Text = "Добавить", Dock = DockStyle.Right, Width = 100 };
            tabPage.Controls.Add(deleteButton);
            tabPage.Controls.Add(updateButton);
            tabPage.Controls.Add(insertButton);

            // Обработчики событий для кнопок
            deleteButton.Click += (sender, e) =>
            {
                ExecuteQuery(textBox.Text, tabPage, dataGridView);
            };
            updateButton.Click += (sender, e) =>
            {
                ExecuteQuery(textBox.Text, tabPage, dataGridView);
            };
            insertButton.Click += (sender, e) =>
            {
                ExecuteQuery(textBox.Text, tabPage, dataGridView);
            };
// Сохранение имени текущей таблицы и вкладки
            currentTableName = query.Split(' ')[2].Replace(";", ""); // Получение имени таблицы из запроса
            currentTabPage = tabPage;
        }

        private void ExecuteQuery(string query, TabPage tabPage, DataGridView dataGridView)
        {
            try
            {
                // Выполнение запроса к базе данных
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                // Обновление данных в DataGridView
                DisplayDataInTab($"SELECT * FROM {currentTableName};", currentTabPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Правильное выполнения запроса", "Успешно");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
 }
