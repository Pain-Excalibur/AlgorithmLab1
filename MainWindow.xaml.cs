using AlgoritmLab1.algorithms.algorithms;
using AlgoritmLab1.algorithms.matrix;
using AlgoritmLab1.algorithms.powAlgs;
using AlgoritmLab1.algorithms.templates;
using MathNet.Numerics;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlgorithmLab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private PlotModel plotModel;
        private readonly Dictionary<string, Testing> algorithms = new()
        {
            { "Постоянная функция", new ConstantFunction() },
            { "Сумма элементов", new SumFunction() },
            { "Произведение элементов", new ProductFunction() },
            { "Вычисление полинома", new NaivePolinomial() },
            { "Вычисление полинома\n(Метод Горнера)", new HornerPolynomial() },
            { "Bubble sort", new BubbleSort() },
            { "Quick sort", new QuickSort() },
            { "Timsort", new Timsort() },
            { "Произведение матриц", new MatrixMultiplication() },
            { "Возведение в степень", new NaivePow() },
            { "Возведение в степень\n(рекурсия)", new RecPow() },
            { "Возведение в степень\n(QuickPow)", new QuickPow() },
            { "Возведение в степень\n(Classic QuickPow)", new ClassicQuickPow() },
            { "Cycle sort", new CycleSort() },
            { "Gnome sort", new GnomeSort() },
            { "Merge sort", new MergeSort() },
            { "Counting sort", new CountingSort() },
        };

        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeGraph();
        }

        private void InitializeComboBox() 
        {
            foreach (string algorithm in algorithms.Keys) 
            { 
                AlgSelector.Items.Add(algorithm);
            }
        }

        private void InitializeGraph()
        {
            // NOTE: возможно вынесу все методы графиков в отдельный класс.
            plotModel = new PlotModel();

            LinearAxis dimensionAxis = new()
            {
                Position = AxisPosition.Bottom,
                AbsoluteMaximum = 100000,
                AbsoluteMinimum = 0,
                Title = "Размерность"
            };

            LinearAxis timeAxis = new()
            {
                Position = AxisPosition.Left,
                AbsoluteMinimum = 0,
            };

            plotModel.Axes.Add(dimensionAxis);
            plotModel.Axes.Add(timeAxis);

            AlgGraph.Model = plotModel;
        }

        private void DrawGraph(double[] data)
        {
            plotModel.Series.Clear();

            LineSeries lineSeries = new()
            {
                Title = "Экспериментальные значения",
                Color = OxyColors.Green
            };

            for (int i = 0; i < data.Length; i++)
            {
                lineSeries.Points.Add(new DataPoint(i + 1, data[i]));
            }

            plotModel.Series.Add(lineSeries);
            AlgGraph.InvalidatePlot(true);
        }

        private void DrawApproximation(double[] data)
        {
            int length = data.Length;
            double[] elements = new double[length];

            for (int i = 0; i < length; i++)
            {
                elements[i] = i + 1;
            }

            // TODO: наверное нужна более подробная аппроксимация, потому не везде подходит вторая степень.
            var coefficients = Fit.Polynomial(elements, data, 2);

            LineSeries lineSeries = new()
            {
                Title = "Аппроксимация",
                Color = OxyColors.Red
            };

            for (int i = 0; i < data.Length; i++)
            {
                double value = coefficients[0] + coefficients[1] * (i + 1) + coefficients[2] * Math.Pow(i + 1, 2);
                lineSeries.Points.Add(new DataPoint(i + 1, value));
            }

            plotModel.Series.Add(lineSeries);
            AlgGraph.InvalidatePlot(true);
        }


        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            // NOTE: это метод для обработки кнопки и запуска алгоритма.
            // Возможно тут можно сделать более продвинутую проверку, которая бы говорила что мы вводим не так, но мне лень. Может быть потом сделаю.
            if (AlgSelector.SelectedItem != null)
            {
                if (uint.TryParse(InputBoxN.Text, out uint n) && uint.TryParse(InputBoxM.Text, out uint m) && n <= 100000)
                {
                    string selectedAlgorithmName = AlgSelector.SelectedItem.ToString();
                    Testing selectedAlgorithm = algorithms[selectedAlgorithmName];
                    double[] result = selectedAlgorithm.GetResults(n, m);

                    if (selectedAlgorithm is NaivePow || selectedAlgorithm is RecPow || selectedAlgorithm is QuickPow || selectedAlgorithm is ClassicQuickPow)
                    {
                        plotModel.Axes[1].Title = "Шаги";
                    }
                    else
                    {
                        plotModel.Axes[1].Title = "Секунды";
                    }

                    DrawGraph(result);
                    DrawApproximation(result);
                }
                else
                {
                    MessageBox.Show("Введены некорректные параметры, повторите ввод.", "ОШИБКА: НЕКОРРЕТНЫЕ ПАРАМЕТРЫ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Перед началом необходимо выбрать алгоритм.", "ОШИБКА: НЕ ВЫБРАН АЛГОРИТМ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AlgSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // NOTE: это метод для обработки cмены алгоритма (пригодится для графиков и описания).
        }
    }
}