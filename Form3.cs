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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e) //пустой метод
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 sv = new Form7();
            sv.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 vr = new Form8();
            vr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 za = new Form9();
            za.ShowDialog();
        }
    }
}
