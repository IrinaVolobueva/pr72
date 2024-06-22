using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace пр72
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double sideA, sideB, sideC;

        private bool perimeter, area, median;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Input input = new Input();
            if (input.ShowDialog() == true)
            {
                sideA = input.SideA;
                sideB = input.SideB;
                sideC = input.SideC;
                perimeter = input.Perimeter;
                area = input.Area;
                median = input.Median;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (sideA == 0 && sideB == 0 && sideC == 0)
            {
                MessageBox.Show("Please input the sides of the triangle first.");
                return;
            }

            Result resultWindow = new Result();
            resultWindow.PerimeterTextBox.Text = perimeter ? Perimeter().ToString() : "Not calculated";
            resultWindow.AreaTextBox.Text = area ? Area().ToString() : "Not calculated";
            resultWindow.MedianTextBox.Text = median ? Median().ToString() : "Not calculated";

            resultWindow.ShowDialog();  
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Method Perimeter() to calculate the perimeter
        /// </summary>
        /// <returns></returns>
        private double Perimeter()
        {
            return Math.Round(sideA + sideB + sideC, 3);
        }
        /// <summary>
        /// Method Area() to calculate the area
        /// </summary>
        /// <returns></returns>
        private double Area()
        {
            double half_Perimeter = (sideA + sideB + sideC) / 2;
            return Math.Round(Math.Sqrt(half_Perimeter * (half_Perimeter - sideA) * (half_Perimeter - sideB) * (half_Perimeter - sideC)), 3);
        }
        /// <summary>
        /// Method Median() to calculate the median
        /// </summary>
        /// <returns></returns>
        private double Median()
        {
            return Math.Round(Math.Sqrt(2 * (sideA * sideA + sideB * sideB) - sideC * sideC) / 2, 3);
        }

    }
}
