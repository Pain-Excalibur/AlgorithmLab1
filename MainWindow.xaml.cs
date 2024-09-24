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
        public MainWindow()
        {
            InitializeComponent();
            InitializeGraph();
        }

        private void InitializeGraph()
        {
            // NOTE: возможно вынесу все методы графиков в отдельный класс.
            PlotModel plotModel = new();

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

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            // NOTE: это метод для обработки кнопки и запуска алгоритма.
            // Возможно тут можно сделать более продвинутую проверку, которая бы говорила что мы вводим не так, но мне лень. Может быть потом сделаю.
            if (AlgSelector.SelectedItem != null)
            {
                if (Int32.TryParse(InputBoxN.Text, out int n) && Int32.TryParse(InputBoxM.Text, out int m) && n > 0 && m > 0 && n < 2000)
                {
                    // Заглушка, потом уберу.
                    MessageBox.Show("Всё выбрано правильно. Возьми печеньку 🍪", "ЗАГЛУШКА", MessageBoxButton.OK, MessageBoxImage.Information);
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