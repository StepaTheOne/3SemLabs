using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(A.Text);
                double b = Convert.ToDouble(B.Text);
                double y11 = Convert.ToDouble(y1.Text);
                double y22 = Convert.ToDouble(y2.Text);
                x1.Text = Convert.ToString((y11 - b) / a);
                x2.Text = Convert.ToString((y22 - b) / a);
                xk.Text = Convert.ToString((Convert.ToDouble(x1.Text) + Convert.ToDouble(x2.Text)) / 2);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void A_TextChanged(object sender, KeyPressEventArgs e)
        {

        }
        private void A_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void B_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void y1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void y2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
