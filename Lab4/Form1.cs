using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private int[] _bubbleList = { 8, 3, 4, 7, 9, 2, 28, 11, 14, 6, 1, 15 };
        private int[] _fastList = { 8, 3, 7, 2, 28, 11, 14, 6, 1, 15 };
        private int[] _insertList = { 3, 4, 7, 9, 2, 2, 14, 6, 1, 15 };
        private int[] _shakerList = { 8, 3, 4, 7, 9, 2, 28, 6, 1, 15 };
        private int[] _bogoList = { 8, 3, 7, 9, 2, 28, 6, 1, 15 };
        private List<Task> _tasks = new List<Task>();
        private CancellationTokenSource cancelTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private async void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {


            cancelTokenSource = new CancellationTokenSource();
            if (checkRandom.Checked)
            {
                if (string.IsNullOrEmpty(TextLength.Text))
                {
                    MessageBox.Show("Empty length");
                    return;
                }

                SetRandomArray(int.Parse(TextLength.Text));
            }
            else
            {
                int countData = dataGridView1.Rows.Count;
                if (countData > 1)
                {
                    SetArray(countData);
                }
                else
                {
                    MessageBox.Show("Ничего не введено.");
                    return;
                }
            }

            if (checkBubble.Checked)
            {
                var timer = new Stopwatch();
                timer.Start();

                var task = Task.Run(BubbleSort);
                _tasks.Add(task);
                await task;

                timer.Stop();
                TextTimerBubble.Text = timer.ElapsedMilliseconds + " ms";
            }

            if (checkShaker.Checked)
            {
                var timer = new Stopwatch();
                timer.Start();

                var task = Task.Run(ShakerSort);
                _tasks.Add(task);
                await task;

                timer.Stop();
                TextTimerShaker.Text = timer.ElapsedMilliseconds + " ms";
            }

            if (checkQuick.Checked)
            {
                var timer = new Stopwatch();
                timer.Start();

                var task = Task.Run(() => QuickSort(_fastList, 0, _fastList.Length - 1));
                _tasks.Add(task);
                await task;

                timer.Stop();
                TextTimerQuick.Text = timer.ElapsedMilliseconds + " ms";
            }

            if (checkInsert.Checked)
            {
                var timer = new Stopwatch();
                timer.Start();

                var task = Task.Run(InsertSort);
                _tasks.Add(task);
                await task;

                timer.Stop();
                TextTimerInsert.Text = timer.ElapsedMilliseconds + " ms";
            }

            if (checkBogo.Checked)
            {
                var timer = new Stopwatch();
                timer.Start();

                var task = Task.Run(BogoSort);
                _tasks.Add(task);
                await task;

                timer.Stop();
                TextTimerBogo.Text = timer.ElapsedMilliseconds + " ms";
            }
        }

        private void SetArray(int countData)
        {
            try
            {
                List<int> DataElems = new List<int>();

                for (int i = 0; i < countData - 1; i++)
                {
                    DataElems.Add(Convert.ToInt32(dataGridView1[0, i].Value));
                }
                /*for (int i = 0; i < countData - 1; i++)
                {
                    MessageBox.Show(DataElems[i].ToString());
                }*/
                _bubbleList = DataElems.ToArray();
                _fastList = DataElems.ToArray();
                _insertList = DataElems.ToArray();
                _shakerList = DataElems.ToArray();
                _bogoList = DataElems.ToArray();
                SetList(ChartBubble, _bubbleList);
                SetList(ChartQuick, _fastList);
                SetList(ChartInsert, _insertList);
                SetList(ChartBogo, _bogoList);
                SetList(ChartShaker, _shakerList);
            }
            catch (Exception)
            {
                MessageBox.Show("Чето с вводом в DataGrid. Числа пж. Целые");
            }
        }
        private void SetRandomArray(int arrayLength)
        {
            var nums = Enumerable.Range(0, arrayLength).ToArray();
            var rnd = new Random();
            for (int i = 0; i < nums.Length; ++i)
            {
                int randomIndex = rnd.Next(nums.Length);
                (nums[randomIndex], nums[i]) = (nums[i], nums[randomIndex]);
            }

            _bubbleList = nums.Clone() as int[];
            _insertList = nums.Clone() as int[];
            _bogoList = nums.Clone() as int[];
            _shakerList = nums.Clone() as int[];
            _fastList = nums.Clone() as int[];

            SetList(ChartBubble, _bubbleList);
            SetList(ChartQuick, _fastList);
            SetList(ChartInsert, _insertList);
            SetList(ChartBogo, _bogoList);
            SetList(ChartShaker, _shakerList);
        }

        private void SetList(Chart chart, int[] list)
        {
            chart.Series.Clear();
            var series = new Series(chart.Name);
            for ((int index, int x) = (0, 0); index < list.Length; index++, x++)
            {
                var height = list[index];
                series.Points.Add(new DataPoint(x, height));
            }

            chart.Series.Add(series);
        }

        private void BubbleSort()
        {
            int temp;
            for (int i = 0; i < _bubbleList.Length; i++)
            {
                for (int j = i + 1; j < _bubbleList.Length; j++)
                {
                    if (_bubbleList[i] > _bubbleList[j])
                    {
                        temp = _bubbleList[i];
                        _bubbleList[i] = _bubbleList[j];
                        _bubbleList[j] = temp;

                        Invoke(new Action(() => SetList(ChartBubble, _bubbleList)));

                        if (cancelTokenSource.Token.IsCancellationRequested) return;
                    }
                }
            }
        }

        /*private void BubbleSort()
        {
            for (int i = 0; i < _bubbleList.Length; i++)
            {
                for (int j = 0; j < _bubbleList.Length - 1 - i; j++)
                {
                    if (_bubbleList[j] > _bubbleList[j + 1])
                    {
                        (_bubbleList[j + 1], _bubbleList[j]) = (_bubbleList[j], _bubbleList[j + 1]);
                        Invoke(new Action(() => SetList(ChartBubble, _bubbleList)));
                        if (cancelTokenSource.Token.IsCancellationRequested) return;
                    }
                }
            }
        }*/

        private void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    Invoke(new Action(() => SetList(ChartQuick, _fastList)));

                    i++;
                    j--;
                    if (cancelTokenSource.Token.IsCancellationRequested) return;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j);

            if (i < rightIndex)
                QuickSort(array, i, rightIndex);

            _fastList = array;
        }

        private void ShakerSort()
        {
            for (var i = 0; i < _shakerList.Length / 2; i++)
            {
                var swapFlag = false;

                for (var j = i; j < _shakerList.Length - i - 1; j++)
                {
                    if (_shakerList[j] > _shakerList[j + 1])
                    {
                        Swap(ref _shakerList[j], ref _shakerList[j + 1]);
                        Invoke(new Action(() => SetList(ChartShaker, _shakerList)));
                        swapFlag = true;

                        if (cancelTokenSource.Token.IsCancellationRequested) return;
                    }
                }

                for (var j = _shakerList.Length - 2 - i; j > i; j--)
                {
                    if (_shakerList[j - 1] > _shakerList[j])
                    {
                        Swap(ref _shakerList[j - 1], ref _shakerList[j]);
                        Invoke(new Action(() => SetList(ChartShaker, _shakerList)));

                        swapFlag = true;

                        if (cancelTokenSource.Token.IsCancellationRequested) return;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }
        }

        private void InsertSort()
        {
            int n = _insertList.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = _insertList[i];
                int j = i - 1;
                while (j >= 0 && _insertList[j] > key)
                {
                    _insertList[j + 1] = _insertList[j];
                    j = j - 1;
                }

                _insertList[j + 1] = key;
                Invoke(new Action(() => SetList(ChartInsert, _insertList)));

                if (cancelTokenSource.Token.IsCancellationRequested) return;
            }
        }

        private void BogoSort()
        {
            int[] arr = _bogoList;
            while (!IsSorted(arr))
            {
                arr = Shuffle(_bogoList);
                Invoke(new Action(() => SetList(ChartBogo, arr)));

                if (cancelTokenSource.Token.IsCancellationRequested) return;
            }
        }

        static bool IsSorted(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        static int[] Shuffle(int[] numbers)
        {
            Random r = new Random();
            //Step 1: For each unshuffled item in the collection
            for (int n = numbers.Length - 1; n > 0; --n)
            {
                //Step 2: Randomly pick an item which has not been shuffled
                int k = r.Next(n + 1);

                //Step 3: Swap the selected item 
                //        with the last "unstruck" item in the collection
                (numbers[n], numbers[k]) = (numbers[k], numbers[n]);
            }

            return numbers;
        }

        private void Swap(ref int e1, ref int e2)
        {
            (e1, e2) = (e2, e1);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        private void TextLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}