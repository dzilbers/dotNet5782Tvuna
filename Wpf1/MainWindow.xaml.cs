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

namespace Wpf1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnShalom.Content = "SHALOM";
            btnShalom.MouseRightButtonUp += btnShalom_RightClick;
        }

        private void btnShalom_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Colors.Aquamarine);
            var result = MessageBox.Show("Chanuccah is coming!", "IMPORTANT",MessageBoxButton.YesNoCancel,
                MessageBoxImage.Exclamation,MessageBoxResult.Cancel,MessageBoxOptions.RightAlign);
        }

        private void btnShalom_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Colors.Red);
            e.Handled = true;
        }

        private void btnShalom_RightClick(object sender, MouseButtonEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Colors.Green);
        }

        static Random random = new Random();
        private void btnShalom_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Size size = (btn.Parent as Grid).RenderSize;
            Thickness margin = btn.Margin;
            margin.Left = random.NextDouble() * (size.Width - btn.ActualWidth);
            margin.Top = random.NextDouble() * (size.Height - btn.ActualHeight);
            btn.Margin = margin;

        }
    }
}
