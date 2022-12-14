using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngouriMath;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
        }

        AngouriMath.Entity formula;

        int countList = 0;
        double x;
        List<double> x1_all = new List<double>();
        List<double> x2_all = new List<double>();
        public bool Check()
        {
            if (TextA.Text == "" || TextB.Text == "" || TextFunc.Text == ""
                || TextPresicion.Text == "")
            {
                MessageBox.Show("Cringe");
                return false;
            }
            if (Convert.ToDouble(TextPresicion.Text) < 0 || Convert.ToDouble(TextPresicion.Text) > 9)
            {
                MessageBox.Show("Точность не может быть ниже нуля или больше 9. Куда столько ?");
                return false;
            }
            if (Convert.ToDouble(TextA.Text) >= Convert.ToDouble(TextB.Text))
            {
                MessageBox.Show("Границы выставлены кринжово...\n A не может быть больше или равно B");
                return false;
            }
            return true;
        }

        public double Formula(double x)
        {
            try
            {
                return (double)(formula.Simplify().Substitute("x", x).EvalNumerical());
            }
            catch (Exception)
            {

                return double.NaN;
            }
        }

        void Draw(double a, double b, int eps)
        {
            for (double i = a; i <= b; i += 0.1)
            {
                var y = Formula(i);
                chart.Series[0].Points.AddXY(i, y);
            }
        }
        private void Persona4Golden(double a, double b, int eps)
        {
            try
            {

                x = (a + b) / 2;
                double dx = 1 / (Math.Pow(10, eps));
                double dxe = dx;
                double z = (3 - Math.Sqrt(5)) / 2;
                double x1 = a + z * (b - a),
                    x2 = b - z * (b - a);
                while (Math.Abs(b - a) > dxe)
                {
                    x1_all.Add(x1);
                    x2_all.Add(x2);
                    if (Formula(x1) > Formula(x2))
                    {
                        a = x1;
                        x1 = x2;
                        x2 = a + b - x1;
                    }
                    else
                    {
                        b = x2;
                        x2 = x1;
                        x1 = a + b - x2;
                    }
                    x = (a + b) / 2;
                    //dx /= 2;
                }
                /*if(ResFormula(x+dx) > ResFormula(x) && ResFormula(x-dx) > ResFormula(x) && !double.IsNaN(ResFormula(x+dx))
                    && !double.IsNaN(ResFormula(x - dx)))
                {
                    double res = Math.Round(x, eps, MidpointRounding.AwayFromZero);
                    chart.Series[3].Points.AddXY(x, ResFormula(x));
                    TextAnswer.Text = res.ToString();
                }
                else
                {
                    MessageBox.Show("Не найдено точки минимума. Скорее всего на отрезке нет таких.");
                    TextAnswer.Text = "";
                }*/
                double res = Math.Round(x, eps, MidpointRounding.AwayFromZero);
                TextAnswer.Text = res.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {
                    chart.ChartAreas[0].AxisX.RoundAxisValues();
                    formula = Convert.ToString(TextFunc.Text);

                    chart.Series[0].Points.Clear();

                    double.TryParse(TextA.Text, out var ax);
                    double.TryParse(TextB.Text, out var bx);
                    int.TryParse(TextPresicion.Text, out var eps);
                    
                    double dx = (bx - ax) / 100;
                    
                    for(double i = ax; i <= bx; i+=dx)
                    {
                        if(double.IsNaN(Formula(i)) || double.IsInfinity(Formula(i)))
                        {
                            MessageBox.Show("На отрезке не должно быть разрывов любого рода.");
                            return;
                        }
                    }
                    x1_all.Clear();
                    x2_all.Clear();
                    Draw(ax, bx, eps);
                    Persona4Golden(ax, bx, eps);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("lol.try again");
            }
        }

        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (x1_all.Count > countList && x2_all.Count > countList)
            {
                chart.Series[3].Points.Clear();
                chart.Series[3].Points.AddXY(x1_all[countList], Formula(x1_all[countList]));
                chart.Series[3].Points.AddXY(x2_all[countList], Formula(x2_all[countList]));
                countList++;
            }
            else
            {
                MessageBox.Show("Больше нету.");
            }
        }

        private void stepBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (countList > 0 && x1_all.Count > 0 && x2_all.Count > 0)
            {
                countList--;
                chart.Series[3].Points.Clear();
                chart.Series[3].Points.AddXY(x1_all[countList], Formula(x1_all[countList]));
                chart.Series[3].Points.AddXY(x2_all[countList], Formula(x2_all[countList]));
            }
            else
            {
                MessageBox.Show("Дальше некуда.");
            }
        }

        private void clearToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            chart.Series[0].Points.Clear();
            TextA.Clear();
            TextB.Clear();
            TextPresicion.Clear();
            TextFunc.Clear();
            TextAnswer.Clear();
        }

        private void TextPresicion_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
