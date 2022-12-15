using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AngouriMath;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Entity formula;

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

        public double ResFormula(double x)
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
            double minY = ResFormula(a);
            double maxY = ResFormula(a);
            for (double i = a; i <= b; i+=0.1)
            {
                var y = ResFormula(i);
                chart.Series[0].Points.AddXY(i, y);
                if (y > maxY)
                    maxY = y;
                if (y < minY)
                    minY = y;
            }
            chart.Series[1].Points.AddXY(a, minY);
            chart.Series[1].Points.AddXY(a, maxY);

            chart.Series[2].Points.AddXY(b, minY);
            chart.Series[2].Points.AddXY(b, maxY);
            chart.Series[0].Points.AddXY(b, ResFormula(b));
        }
        private void Persona4Golden(double a, double b, int eps)
        {
            try
            {
                double x = (a + b) / 2;
                double dx = 1 / (Math.Pow(10, eps));
                double dxe = dx;
                double z = (3 - Math.Sqrt(5)) / 2;
                double x1 = a + z * (b - a), 
                    x2 = b - z * (b - a);
                while (Math.Abs(b - a) > dxe)
                {
                    if (ResFormula(x1) > ResFormula(x2))
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
                chart.Series[3].Points.AddXY(x, ResFormula(x));
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

                    for (int i = 0; i < 4; ++i)
                    {
                        chart.Series[i].Points.Clear();
                    }

                    double.TryParse(TextA.Text, out var ax);
                    double.TryParse(TextB.Text, out var bx);
                    int.TryParse(TextPresicion.Text, out var eps);

                    double dx = (bx - ax) / 100;
                    double a = ResFormula(ax);
                    double b = ResFormula(bx);
                    while (a.Equals(double.NaN) || double.IsInfinity(a))
                    {
                        ax += dx;
                        a = ResFormula(ax);
                    }
                    while (b.Equals(double.NaN) || double.IsInfinity(b))
                    {
                        bx -= dx;
                        b = ResFormula(bx);
                    }

                    Draw(ax, bx, eps);
                    Persona4Golden(ax, bx, eps);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("lol.try again");
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            chart.Series[2].Points.Clear();
            chart.Series[3].Points.Clear();
            TextA.Clear();
            TextB.Clear();
            TextPresicion.Clear();
            TextFunc.Clear();
            TextAnswer.Clear();
        }

        private void TextPresicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
