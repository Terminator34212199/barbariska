using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //пустой метод
        {

        }

        private void label1_Click(object sender, EventArgs e) //пустой метод
        {
            // Пусто
        }

        private void button1_Click(object sender, EventArgs e) //Отсутствие обработки ошибок
        {
            Form2 registrationForm = new Form2();
            registrationForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) //Отсутствие обработки ошибок
        {
            Form4 avtorpatientForm = new Form4();
            avtorpatientForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) //Отсутствие обработки ошибок
        {
            Form5 avtordoctorForm = new Form5();
            avtordoctorForm.ShowDialog();
        }
    }
}
