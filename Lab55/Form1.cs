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
using OxyPlot;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using OxyPlot.Annotations;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Entity formula;
        //List<List<List<double>>> Figures = new List<List<List<double>>>();
        List<List<List<List<double>>>> history = new List<List<List<List<double>>>>();
        int historyCount = 0;
        double globalA, globalB, globalN;

        public bool Check()
        {
            if (TextA.Text == "" || TextB.Text == "" || TextFunc.Text == ""
                || TextPresicion.Text == "")
            {
                MessageBox.Show("Cringe");
                return false;
            }
            if (Convert.ToDouble(TextPresicion.Text) < 0 || Convert.ToDouble(TextPresicion.Text) > 5)
            {
                MessageBox.Show("Точность не может быть ниже нуля или больше 5. Куда столько ?");
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
                return (double)(formula.Substitute("x", x).EvalNumerical());
            }
            catch (Exception)
            {

                return double.NaN;
            }
        }

        void Draw(double a, double b, List<List<List<double>>> Figures)
        {
            PlotModel Model = new PlotModel();
            FunctionSeries FuncLine = new FunctionSeries { Color = OxyColors.Black };
            LineAnnotation BottomBorderLine = new LineAnnotation() { Y = 0, Color = OxyColors.Blue };
            LineAnnotation LeftBorderLine = new LineAnnotation() { X = a, Color = OxyColors.Blue, Type = LineAnnotationType.Vertical };
            LineAnnotation RightBorderLine = new LineAnnotation() { X = b, Color = OxyColors.Blue, Type = LineAnnotationType.Vertical };
            double h = (b - a) / 100;
            for (double i = a; i <= b; i += h)
            {
                var y = Formula(i);
                if (y < -99999 || y > 99999 || double.IsNaN(y))
                {
                    continue;
                }
                else
                {
                    FuncLine.Points.Add(new OxyPlot.DataPoint(i, y));
                }

            }
            foreach(List<List<double>> Figure in Figures)
            {
                var Event = new PolygonAnnotation();

                Event.Layer = AnnotationLayer.BelowAxes;
                Event.StrokeThickness = 1;
                Event.Stroke = OxyColor.FromRgb(0, 0, 255);
                Event.LineStyle = LineStyle.Automatic;

                Event.Points.Add(new DataPoint(Figure[2][0], Figure[2][1]));
                Event.Points.Add(new DataPoint(Figure[3][0], Figure[3][1]));
                Event.Points.Add(new DataPoint(Figure[1][0], Figure[1][1]));
                Event.Points.Add(new DataPoint(Figure[0][0], Figure[0][1]));

                Model.Annotations.Add(Event);
            }
            Model.Annotations.Add(BottomBorderLine);
            Model.Annotations.Add(LeftBorderLine);
            Model.Annotations.Add(RightBorderLine);
            Model.Series.Add(FuncLine);
            plotView.Model = Model;
        }
        #region GetPoints
        private List<List<List<double>>> PointsRiemann(double a, double b, int n)
        {
            List<List<List<double>>> Figures = new List<List<List<double>>>();

            double h = (b - a) / n;

            double X0 = a;
            double X1, Y0, Y1;

            for (int StepIndex = 0; StepIndex < n; StepIndex++)
            {
                List<List<double>> Figure = new List<List<double>>();

                X1 = X0 + h;
                Y1 = Formula((X1+X0)/2);

                List<double> PointLeftBottom = new List<double>();
                PointLeftBottom.Add(X0);
                PointLeftBottom.Add(0);

                List<double> PointRightBottom = new List<double>();
                PointRightBottom.Add(X1);
                PointRightBottom.Add(0);

                List<double> PointLeftTop = new List<double>();
                PointLeftTop.Add(X0);
                PointLeftTop.Add(Y1);

                List<double> PointRightTop = new List<double>();
                PointRightTop.Add(X1);
                PointRightTop.Add(Y1);

                Figure.Add(PointLeftTop);
                Figure.Add(PointRightTop);
                Figure.Add(PointLeftBottom);
                Figure.Add(PointRightBottom);

                Figures.Add(Figure);

                X0 += h;
            }
            return Figures;
        }

        private List<List<List<double>>> PointsTrapezia(double a, double b, int n)
        {
            List<List<List<double>>> Figures = new List<List<List<double>>>();

            double h = (b - a) / n;

            double X0 = a;
            double X1, Y0, Y1;
            for (int StepIndex = 0; StepIndex < n; StepIndex++)
            {
                List<List<double>> Figure = new List<List<double>>();

                X1 = X0 + h;
                Y0 = Formula(X0);
                Y1 = Formula(X1);

                List<double> PointLeftBottom = new List<double>();
                PointLeftBottom.Add(X0);
                PointLeftBottom.Add(0);

                List<double> PointRightBottom = new List<double>();
                PointRightBottom.Add(X1);
                PointRightBottom.Add(0);

                List<double> PointLeftTop = new List<double>();
                PointLeftTop.Add(X0);
                PointLeftTop.Add(Y0);

                List<double> PointRightTop = new List<double>();
                PointRightTop.Add(X1);
                PointRightTop.Add(Y1);

                Figure.Add(PointLeftTop);
                Figure.Add(PointRightTop);
                Figure.Add(PointLeftBottom);
                Figure.Add(PointRightBottom);

                Figures.Add(Figure);

                X0 += h;
            }
            return Figures;
        }

        #endregion
        #region Calculations
        private double CalcRiemann(double a, double b, int n)
        {
            double sum = 0, h = (b - a) / n;

            for (int i = 0; i < n; i++)
            {
                sum += Math.Abs(Formula(a + h / 2 + i * h));
            }

            sum *= h;

            return sum;
        }

        private double CalcTrapezia(double a, double b, int n)
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


            }
            sum +=(Math.Abs(Formula(a))+Math.Abs(Formula(b)))/2;

            sum *= h;

            return sum;
        }

        private double CalcSimp(double a, double b, int n)
        {
            var h = (b - a) / n;
            var sum1 = 0d;
            var sum2 = 0d;
            //chart.Series[1].Points.AddXY(a, Formula(a));
            for (var k = 1; k <= n; k++)
            {
                var xk = a + k * h;
                //chart.Series[1].Points.AddXY(xk, Formula(xk));
                if (k <= n - 1)
                {
                    sum1 += Math.Abs(Formula(xk));
                }

                var xk_1 = a + (k - 1) * h;
                //chart.Series[1].Points.AddXY(xk_1, Formula(xk_1));
                sum2 += Math.Abs(Formula((xk + xk_1) / 2));
            }

            var result = h / 3d * (1d / 2d * Math.Abs(Formula(a)) + sum1 + 2 * sum2 + 1d / 2d * Math.Abs(Formula(b)));
            
            //TextAnswer.Text = Math.Round(result, eps, MidpointRounding.AwayFromZero).ToString();
            return result;
        }
        #endregion

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {

                    formula = Convert.ToString(TextFunc.Text);

                    double.TryParse(TextA.Text, out var ax);
                    double.TryParse(TextB.Text, out var bx);
                    int.TryParse(TextPresicion.Text, out var eps);

                    globalA = ax;
                    globalB = bx;

                    bool checkBoxes = false;
                    int n = 5;
                    double delta, res1,res2;
                    if(checkedListBox1.SelectedIndex == 0)
                    {
                        List<List<List<double>>> Points = new List<List<List<double>>>();
                        Points = PointsRiemann(ax, bx,n);
                        history.Add(Points);
                        res1 = CalcRiemann(ax,bx,n);
                        res2 = CalcRiemann(ax, bx, 2 * n);
                        delta = Math.Abs(res2 - res1);
                        while(delta/3 > Math.Pow(0.1,eps))
                        {
                            Points = PointsRiemann(ax, bx, n);
                            history.Add(Points);
                            n *= 2;
                            res1 = CalcRiemann(ax, bx, n);
                            res2 = CalcRiemann(ax, bx, 2 * n);
                            delta = Math.Abs(res2 - res1);
                        }
                        TextAnswer.Text = Math.Round(res1, eps, MidpointRounding.AwayFromZero).ToString();
                        checkBoxes = true;
                    }
                    if(checkedListBox1.SelectedIndex == 1)
                    {
                        List<List<List<double>>> Points = new List<List<List<double>>>();

                        res1 = CalcTrapezia(ax, bx, n);
                        res2 = CalcTrapezia(ax, bx, 2 * n);
                        Points = PointsTrapezia(ax, bx, n);
                        history.Add(Points);
                        delta = Math.Abs(res2 - res1);
                        while (delta/3 > Math.Pow(0.1, eps))
                        {
                            Points = PointsTrapezia(ax, bx, n);
                            history.Add(Points);
                            n *= 2;
                            res1 = CalcTrapezia(ax, bx, n);
                            res2 = CalcTrapezia(ax, bx, 2 * n);
                            delta = Math.Abs(res2 - res1);
                        }
                        TextAnswer.Text = Math.Round(res1, eps, MidpointRounding.AwayFromZero).ToString();
                        checkBoxes = true;
                    }
                    if(checkedListBox1.SelectedIndex == 2)
                    {
                        res1 = CalcSimp(ax, bx, n);
                        res2 = CalcSimp(ax, bx, 2 * n);
                        delta = Math.Abs(res2 - res1);
                        while (delta/3 > Math.Pow(0.1, eps))
                        {

                            n *= 2;
                            res1 = CalcSimp(ax, bx, n);
                            res2 = CalcSimp(ax, bx, 2 * n);
                            delta = Math.Abs(res2 - res1);
                        }
                        TextAnswer.Text = Math.Round(res1, eps, MidpointRounding.AwayFromZero).ToString();
                        checkBoxes = true;
                    }
                    historyCount = history.Count;
                    if (!checkBoxes)
                    {
                        MessageBox.Show("Ничего не выбрано.");
                    }
                    else
                    {
                        Draw(ax, bx,history[historyCount-1]);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте корректность ввода.\nТак же в границах интервала не должно быть разрывов");
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history.Clear();

            PlotModel Model = new PlotModel();
            FunctionSeries Series = new FunctionSeries();
            Model.Series.Add(Series);
            plotView.Model = Model;

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

        private void stepForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyCount < history.Count-1 && history.Count > 0)
            {
                historyCount++;
                Draw(globalA, globalB, history[historyCount]);
            }
            else
            {
                MessageBox.Show("Дальше некуда");
            }
        }

        private void stepBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(historyCount > 0 && history.Count > 0)
            {
                historyCount--;
                Draw(globalA, globalB, history[historyCount]);
            }
            else
            {
                MessageBox.Show("Дальше некуда");
            }
        }
    }
}
