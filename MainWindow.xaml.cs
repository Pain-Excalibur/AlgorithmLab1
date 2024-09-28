using AlgoritmLab1.algorithms;
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
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGraph();
        }

        private void InitializeGraph()
        {
            // NOTE: возможно вынесу все методы графиков в отдельный класс.
            plotModel = new PlotModel();

            LinearAxis dimensionAxis = new()
            {
                Position = AxisPosition.Bottom,
                AbsoluteMaximum = 2000,
                AbsoluteMinimum = 0,
                Title = "Размерность"
            };

            LinearAxis timeAxis = new()
            {
                Position = AxisPosition.Left,
                AbsoluteMinimum = 0,
                Title = "Секунды"
            };

            plotModel.Axes.Add(dimensionAxis);
            plotModel.Axes.Add(timeAxis);

            AlgGraph.Model = plotModel;
        }

        private void DrawGraph(double[] data)
        {
            plotModel.Series.Clear();

            LineSeries lineSeries = new();

            // Заполнение серии данными
            for (int i = 0; i < data.Length; i++)
            {
                lineSeries.Points.Add(new DataPoint(i + 1, data[i]));
            }

            // Добавление серии в модель графика
            plotModel.Series.Add(lineSeries);

            // Обновление модели графика
            AlgGraph.InvalidatePlot(true);
        }


        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            // NOTE: это метод для обработки кнопки и запуска алгоритма.
            // Возможно тут можно сделать более продвинутую проверку, которая бы говорила что мы вводим не так, но мне лень. Может быть потом сделаю.
            if (AlgSelector.SelectedItem != null)
            {
                if (uint.TryParse(InputBoxN.Text, out uint n) && uint.TryParse(InputBoxM.Text, out uint m) && n <= 2000)
                {
                    // Всё ещё заглушка.
                    QuickSort quickSort = new();
                    double[] result = quickSort.StartTesting(n, m);
                    DrawGraph(result);
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