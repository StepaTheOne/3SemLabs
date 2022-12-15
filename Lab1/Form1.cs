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

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Entity formula;

        void Draw(double a, double b, int eps)
        {
            double minY = Formula(b+a/2);
            double maxY = Formula(b+a/2);
            for (double i = a; i <= b; i+=0.01)
            {
                double y = Formula(i);
                chart.Series[0].Points.AddXY(i, y);
                if (y > maxY)
                    maxY = y;
                if (y < minY)
                    minY = y;
            }
            chart.Series[2].Points.AddXY(a, minY);
            chart.Series[2].Points.AddXY(a, maxY);

            chart.Series[3].Points.AddXY(b, minY);
            chart.Series[3].Points.AddXY(b, maxY);
        }

        public bool Check()
        {
            if (AText.Text == "" || BText.Text == "" || TextFunc.Text == ""
                || EText.Text =="")
            {
                MessageBox.Show("Cringe. Поля пусты.");
                return false;
            }
            if(Convert.ToDecimal(EText.Text) < 0 || Convert.ToDecimal(EText.Text) >9)
            {
                MessageBox.Show("Точность не может быть ниже нуля. А больше 9 куда ");
                return false;
            }
            if(Convert.ToDouble(AText.Text) >= Convert.ToDouble(BText.Text))
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

        /*private double Dichotomy(double a, double b,int eps)
        {
            double avgX = (a + b) / 2;
            double dx = double.MaxValue;
            while(Math.Abs(dx) > 1e-13)
            {
                if((Formula(b) * Formula(avgX)) == 0)
                {
                    return avgX;
                }
                if (Formula(b)*Formula(avgX) < 0)
                {
                    a = avgX;
                }
                else
                {
                    b = avgX;
                }
                avgX = (a + b) / 2;
                dx = (b - a);
            }

            return Math.Round(avgX, eps, MidpointRounding.AwayFromZero);
        }*/
        private void Dichotomy(double a, double b, int eps)
        {
            try
            {
                double x = (a + b) / 2;
                double dx = 1/(Math.Pow(10,eps));
                while(Math.Abs(b-a) > 1 / Math.Pow(10, eps))
                {
                    x = (a + b) / 2;
                    double f1 = Formula(x - dx);
                    double f2 = Formula(x + dx);
                    if (f1 > f2)
                    {
                        a = x - dx;
                    }
                    else
                    {
                        b = x + dx;
                    }
                    dx /= 2;

                }
                dx = 1 / (Math.Pow(10, eps));
                /*double minCheck = Formula(x);
                double minCheck2 = Formula(x + dx);
                double minCheck3 = Formula(x - dx);
                if (minCheck2 >= minCheck && minCheck3 >= minCheck)
                   && !double.IsNaN(Formula(x + dx)) && !double.IsNaN(Formula(x - dx)))
                {
                    double res = Math.Round(x, eps, MidpointRounding.AwayFromZero);
                    chart.Series[1].Points.AddXY(x, Formula(x));
                    ResText.Text = res.ToString();
                }
                else
                {
                    ResText.Text = "";
                    MessageBox.Show("Не найдено точек минимума. Видимо функция таких не имеет.");
                }*/
                double res = Math.Round(x, eps, MidpointRounding.AwayFromZero);
                chart.Series[1].Points.AddXY(x, Formula(x));
                ResText.Text = res.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

       

        private void CalculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {
                    chart.ChartAreas[0].AxisX.RoundAxisValues();

                    formula = Convert.ToString(TextFunc.Text);
                    string checkForm = formula.Simplify().ToString();
                    if(checkForm.Contains("tan") || checkForm.Contains("cot"))
                    {
                        MessageBox.Show("Тангенс и его брат не содержат экстремумов.\nТак ещё и содержат миллион бесконечностей");
                        return;
                    }
                    for (int i = 0; i < 4; ++i)
                    {
                        chart.Series[i].Points.Clear();
                    }

                    double.TryParse(AText.Text, out var ax);
                    double.TryParse(BText.Text, out var bx);
                    int.TryParse(EText.Text, out var eps);
                    double y;
                    bool check = true;

                    for(double i = ax; i <= bx; i+=0.001)
                    {
                        y = Formula(i);
                        if (double.IsNaN(y) || y.Equals(double.PositiveInfinity) || y.Equals(double.NegativeInfinity))
                        {
                            check = false;
                            break;
                        }
                        
                    }
                    if (check)
                    {
                        Draw(ax, bx, eps);
                        Dichotomy(ax, bx, eps);
                    }
                    else
                    {
                        MessageBox.Show("На интервале не должно быть разрывов или бесконечности.\nВыберите другой интервал");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("lol.try again.");
            }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            chart.Series[2].Points.Clear();
            chart.Series[3].Points.Clear();
            AText.Clear();
            BText.Clear();
            EText.Clear();
            TextFunc.Clear();
            ResText.Clear();
        }
    }
}
