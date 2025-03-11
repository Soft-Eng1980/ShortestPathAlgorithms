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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Initialization

        private void Load(object sender, RoutedEventArgs e)
        {
            //foreach (TextBox item in GUIGrid.Children.OfType<TextBox>())
            //{
            //    string[] name = item.Name.Split("_");
            //    RoundedTextBox newChild = new()
            //    {
            //        Name = $"{item.Name}_Panel",
            //        Margin = new Thickness(5),
            //        Hint = $"{name[0]} To {name[1]} Viceversa",
            //        CornerRadius = new CornerRadius(5),
            //        BorderThickness = new Thickness(1),
            //        BorderBrush = new SolidColorBrush(Colors.Black),
            //        TextBoxsTextAlignment = TextAlignment.Center,
            //        TextBlocksTextAlignment = TextAlignment.Center,
            //        IsNumeric = true,
            //        MaxLines = 1,
            //        TextMaxLenght = 3,
            //        MinValue = 1,

            //    };

            //    newChild.SetBinding(RoundedTextBox.TextProperty, new Binding("Text")
            //    {
            //        Source = item,
            //        Mode = BindingMode.TwoWay,
            //        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            //    });

            //    item.SetBinding(TextBox.TextProperty, new Binding("Text")
            //    {
            //        Source = newChild.baseTextBox,
            //        Mode = BindingMode.TwoWay,
            //        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            //    });

            //    PanelStackPanel.Children.Add(newChild);
            //}

            Inception_Point.ItemsSource = Destination_Point.ItemsSource = new List<string>(["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q"]);



        }
        
        #endregion

        #region Operations

        private void OnCalculateButtonClick(object sender, RoutedEventArgs e)
        {

        }

        //----------------------------------------------------------------------------------------------------------------------------\\

        private void OnFakeDataButtonClick(object sender, RoutedEventArgs e)
        {
            Random random = new();
            foreach (RoundedTextBox item in PanelStackPanel.Children.OfType<RoundedTextBox>())
            {
                item.Text = random.Next(1, 999).ToString();
            }
        }
        #endregion

        #region Credits

        private void OnLecturerButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("DR.M.Yadollah Zadeh Tabari");
        }
        //----------------------------------------------------------------------------------------------------------------------------\\
        private void OnCreatorsButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mohammad Baqer Haeri Bazzaz");
        }
        //----------------------------------------------------------------------------------------------------------------------------\\
        private void OnCourseButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Algorithms Design");
        }

        #endregion
    }
}
