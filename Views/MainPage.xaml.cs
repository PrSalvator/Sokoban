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

namespace Sokoban.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ViewModels.MainWindowViewModel viewModel = new ViewModels.MainWindowViewModel();
        public MainPage()
        {
            DataContext = viewModel;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           NavigationWindow win = new NavigationWindow();
            win.Content = new GamePage();
            win.Show();
        }
        //private void Window_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Up) { viewModel.Move("Up"); }
        //    else if (e.Key == Key.Down) { viewModel.Move("Down"); }
        //    else if (e.Key == Key.Right) { viewModel.Move("Right"); }
        //    else if (e.Key == Key.Left) { viewModel.Move("Left"); }
        //}
    }
}
