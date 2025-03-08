using Dijkstra.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Dijkstra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //----------------------------------------------------------------------------------------------------------------------------\\
        public MainWindow()
        {
            InitializeComponent();
        }
        //----------------------------------------------------------------------------------------------------------------------------\\
        private void btn_Lecturer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("DR.M.Yadollah Zadeh Tabari");
        }
        //----------------------------------------------------------------------------------------------------------------------------\\
        private void btn_Creators_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mahdi JafariPour && Mohammad Baqer Haeri Bazzaz");
        }
        //----------------------------------------------------------------------------------------------------------------------------\\
        private void btn_Course_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Algorithms Design");
        }
        //----------------------------------------------------------------------------------------------------------------------------\\
        private void btn_calc_Click(object sender, RoutedEventArgs e)
        {

        }
        //----------------------------------------------------------------------------------------------------------------------------\\
        private void Load(object sender, RoutedEventArgs e)
        {
            foreach (TextBox item in GUIGrid.Children.OfType<TextBox>())
            {
                string[] name = item.Name.Split("_");
                PanelStackPanel.Children.Add(new RoundedTextBox()
                {
                    Name = $"{item.Name}_Panel",
                    Margin = new Thickness(5),
                    Hint = $"{name[0]} To {name[1]} Viceversa",
                    CornerRadius = new CornerRadius(5),
                    BorderThickness = new Thickness(1),
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    TextBoxsTextAlignment = TextAlignment.Center,
                    TextBlocksTextAlignment  = TextAlignment.Center,
                    IsNumeric = true,
                    MaxLines = 1,
                    TextMaxLenght = 3,
                    MinValue = 1,

                });
            }

            Inception_Point.Items.Add("A");
            Inception_Point.Items.Add("B");
            Inception_Point.Items.Add("C");
            Inception_Point.Items.Add("D");
            Inception_Point.Items.Add("E");
            Inception_Point.Items.Add("F");
            Inception_Point.Items.Add("G");
            Inception_Point.Items.Add("H");
            Inception_Point.Items.Add("I");
            Inception_Point.Items.Add("J");
            Inception_Point.Items.Add("K");
            Inception_Point.Items.Add("L");
            Inception_Point.Items.Add("M");
            Inception_Point.Items.Add("N");
            Inception_Point.Items.Add("O");
            Inception_Point.Items.Add("P");
            Inception_Point.Items.Add("Q");
        }
        //----------------------------------------------------------------------------------------------------------------------------\\
    }
    //----------------------------------------------------------------------------------------------------------------------------\\
}
