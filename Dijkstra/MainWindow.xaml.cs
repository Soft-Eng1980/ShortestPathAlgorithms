using Dijkstra.CustomControls;
using System;
using System.Collections;
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
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Dijkstra
{
    public partial class MainWindow : Window
    {
        private static readonly Hashtable _edges = [];

        /// <summary>
        /// WVs is abbreviation of Weighted Vertices
        /// </summary>
        private static readonly Dictionary<char, IDictionary<char, IDictionary<bool, int?>>> WVs = [];

        /// <summary>
        /// Contain List of Vertices
        /// </summary>
        private static readonly List<char> Vertices = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q'];



        public MainWindow()
        {
            InitializeComponent();
        }

        #region Initialization
        private static int? ToNullableInt(string s)
        {
            if (int.TryParse(s, out int i))
            {
                return i;
            }

            return null;
        }

        private void Load(object sender, RoutedEventArgs e)
        {

            foreach (char edge in Vertices)
            {
                WVs.Add(edge, new Dictionary<char, IDictionary<bool, int?>>());
            }


            foreach (RoundedTextBox item in GUIGrid.Children.OfType<RoundedTextBox>())
            {
                #region Mapping

                char from = item.Name[0];

                char to = item.Name[1];

                WVs[from].Add(to, new Dictionary<bool, int?> { { true, null } });

                #endregion




                RoundedTextBox newChild = new()
                {
                    Name = $"{item.Name}_Panel",
                    Margin = new Thickness(5),
                    Hint = item.Hint,
                    CornerRadius = new CornerRadius(5),
                    BorderThickness = new Thickness(1),
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    TextBoxsTextAlignment = TextAlignment.Center,
                    TextBlocksTextAlignment = TextAlignment.Center,
                    IsNumeric = true,
                    MaxLines = 1,
                    TextMaxLenght = 3,
                    MinValue = 1,

                };



                #region Text Binding

                item.SetBinding(RoundedTextBox.TextProperty, new Binding("Text")
                {
                    Source = newChild.baseTextBox,
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });


                newChild.SetBinding(RoundedTextBox.TextProperty, new Binding("Text")
                {
                    Source = item,
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

                #endregion

                #region Being Available Binding

                item.SetBinding(RoundedTextBox.IsAvailbleProperty, new Binding("IsAvailble")
                {
                    Source = newChild.baseTextBox,
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

                newChild.SetBinding(RoundedTextBox.IsAvailbleProperty, new Binding("IsAvailble")
                {
                    Source = item,
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

                #endregion

                PanelStackPanel.Children.Add(newChild);
            }

            Inception_Point.ItemsSource = Destination_Point.ItemsSource = Vertices;



        }

        //Kepping weighted edges dictionary update upon changes
        private void OnEdgesWeightsChanged(object? sender, EventArgs e)
        {
            var roundedTextBox = sender as RoundedTextBox;
            if (roundedTextBox is not null)
            {
                char from = roundedTextBox.Name[0];

                char to = roundedTextBox.Name[1];

                bool key = WVs[from][to].Keys.First();

                WVs[from][to][key] = ToNullableInt(roundedTextBox.Text);

            }
        }

        private void OnEdgeAvailabilityChanged(object? sender, EventArgs e)
        {
            var roundedTextBox = sender as RoundedTextBox;

            if (roundedTextBox is not null)
            {
                char from = roundedTextBox.Name[0];

                char to = roundedTextBox.Name[1];

                bool key = WVs[from][to].Keys.First();

                int? keepdValue = WVs[from][to][key];

                WVs[from][to].Remove(key);

                WVs[from][to].Add(roundedTextBox.baseTextBox.IsEnabled, keepdValue);
            }
        }


        private void OnCloseLableClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void OnBorderDraging(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #endregion

        #region Operations

        private void OnCalculateButtonClick(object sender, RoutedEventArgs e)
        {
            if (Inception_Point.SelectedIndex < 1 || Destination_Point.SelectedIndex < 1)
            {
                return;
            }

            InputPanel.IsHitTestVisible = false;
            GUIBorder.IsHitTestVisible = false;

            Dijkstra((char)Inception_Point.SelectedValue, (char)Destination_Point.SelectedValue);



            InputPanel.IsHitTestVisible = true;
            GUIBorder.IsHitTestVisible = true;
        }

        private void Dijkstra(char startEdge, char destinationEdge)
        {
            IDictionary<char, List> VerticesTable = new Dictionary<char,List>();

            foreach (char vertice in Vertices)
            {
                VerticesTable.Add(vertice, new List());
            }





        }


        private static char FindMinimum(Dictionary<char, int?> inputDictionary)
        {
            int minValue = int.MaxValue;
            char selectedEdge = new();

            foreach (var edge in inputDictionary)
            {
                // null here means 0 which mean shortest path
                if (edge.Value is null || edge.Value.GetValueOrDefault() == 0)
                {
                    return edge.Key;
                }

                if (edge.Value.GetValueOrDefault() < minValue)
                {
                    minValue = edge.Value.GetValueOrDefault();
                    selectedEdge = edge.Key;
                }
            }
            return selectedEdge;
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
