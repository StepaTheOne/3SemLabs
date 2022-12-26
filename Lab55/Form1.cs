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
        //int countList = 0;
        //List<List<double>> n_values = new List<List<double>>();

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
            double minY = Formula(a);
            double maxY = Formula(a);
            for (double i = a; i <= b; i+=0.1)
            {
                var y = Formula(i);
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
            chart.Series[0].Points.AddXY(b, Formula(b));
        }

        private void CalcRiemann(double a, double b, int n,int eps)
        {
            double sum = 0, h = (b - a) / n;

            for (int i = 0; i < n; i++)
            {
                sum += Math.Abs(Formula(a + h / 2 + i * h));
            }

            sum *= h;
            TextAnswer.Text = Math.Round(sum, eps, MidpointRounding.AwayFromZero).ToString();
        }

        private void CalcTrapezia(double a, double b, int n,int eps)
        {
            double sum = 0;
            var h = (b - a) / n;

            for (double i = a+h; i <= b-h; i += h)
            {
                double y1 = Formula(i);


                if (y1 > 1000 || y1 < -1000)
                {
                    MessageBox.Show("Значения 'Y' слишком большие");
                    continue;
                }
                sum += Math.Abs(Formula(i));
                //areaSeries.Points.Add(new DataPoint(x1, y1));
                //areaSeries.Points.Add(new DataPoint(x2, y2));
                //areaSeries.Points.Add(new DataPoint(x2, 0));

            }
            sum +=(Math.Abs(Formula(a))+Math.Abs(Formula(b)))/2;


            sum *= h;
            //_plotModel.Series.Add(areaSeries);
            //SetPlotModel();
            TextAnswer.Text = Math.Round(sum, eps, MidpointRounding.AwayFromZero).ToString();
        }

        private void CalcSimp(double a, double b, int n,int eps)
        {
            var h = (b - a) / n;
            var sum1 = 0d;
            var sum2 = 0d;
            for (var k = 1; k <= n; k++)
            {
                var xk = a + k * h;
                if (k <= n - 1)
                {
                    sum1 += Math.Abs(Formula(xk));
                }

                var xk_1 = a + (k - 1) * h;
                sum2 += Math.Abs(Formula((xk + xk_1) / 2));
            }

            var result = h / 3d * (1d / 2d * Math.Abs(Formula(a)) + sum1 + 2 * sum2 + 1d / 2d * Math.Abs(Formula(b)));
            
            TextAnswer.Text = Math.Round(result, eps, MidpointRounding.AwayFromZero).ToString();
        }
        /*private void Persona4Golden(double a, double b, int eps)
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
                }
                double res = Math.Round(x, eps, MidpointRounding.AwayFromZero);
                chart.Series[3].Points.AddXY(x, ResFormula(x));
                TextAnswer.Text = res.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }*/

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
                    //double dx = Math.Pow(0.1, eps);

                    for(double i = ax; i <= bx; i += 0.1)
                    {
                        if(double.IsNaN(Formula(i)) || double.IsInfinity(Formula(i))){
                            MessageBox.Show("Не должно быть разрывов любого рода");
                            return;
                        }
                    }
                    bool checkBoxes = false;
                    int n = 5;
                    if(checkedListBox1.SelectedIndex == 0)
                    {
                        CalcRiemann(ax,bx,n,eps);
                        checkBoxes = true;
                    }
                    if(checkedListBox1.SelectedIndex == 1)
                    {
                        CalcTrapezia(ax,bx,n,eps);
                        checkBoxes = true;
                    }
                    if(checkedListBox1.SelectedIndex == 2)
                    {
                        CalcSimp(ax,bx,n,eps);
                        checkBoxes = true;
                    }
                    if (checkBoxes)
                    {
                        Draw(ax, bx, eps);
                    }
                    else
                    {
                        MessageBox.Show("Ничего не выбрано.");
                    }
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

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
        }
    }
}
