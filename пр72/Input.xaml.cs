using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace пр72
{
    /// <summary>
    /// Логика взаимодействия для Input.xaml
    /// </summary>
    public partial class Input : Window
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public bool Perimeter { get; set; }
        public bool Area { get; set; }
        public bool Median { get; set; }

        public Input()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (Double.TryParse(SideAtext.Text, out double sideA) && Double.TryParse(SideBtext.Text, out double sideB) && Double.TryParse(SideCtext.Text, out double sideC))
            {
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
                if (sideA > sideB + sideC || sideB > sideA + sideC || sideC > sideA + sideB)
                {
                    MessageBox.Show("The sum of the two sides cannot be less than the length of the third side", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    SideCtext.Clear();
                    SideCtext.Clear();
                    SideCtext.Clear();
                    PerimeterCheckBox.IsChecked = false;
                    AreaCheckBox.IsChecked = false;
                    MedianCheckBox.IsChecked = false;
                }
                else if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                {
                    MessageBox.Show("The value cannot be negative or equal to zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    SideAtext.Clear();
                    SideBtext.Clear();
                    SideCtext.Clear();
                    PerimeterCheckBox.IsChecked = false;
                    AreaCheckBox.IsChecked = false;
                    MedianCheckBox.IsChecked = false;
                }
            }
            else
            {
                MessageBox.Show("Incorrect input of the sides of the triangle.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                SideAtext.Clear();
                SideBtext.Clear();
                SideCtext.Clear();
                PerimeterCheckBox.IsChecked = false;
                AreaCheckBox.IsChecked = false;
                MedianCheckBox.IsChecked = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Perimeter = PerimeterCheckBox.IsChecked ?? false;
            Area = AreaCheckBox.IsChecked ?? false;
            Median = MedianCheckBox.IsChecked ?? false;

            DialogResult = true;
        }
    }
}
