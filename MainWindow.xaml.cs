using Sokoban.Views;
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

namespace Sokoban
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private RowDefinition rowDefinition;
        //private ColumnDefinition columnDefinition;
        //private Grid g = new Grid();
        //ViewModels.MainViewModel viewModel = new ViewModels.MainViewModel(Models.Levels.LevelsDictionary[1]);
        public MainWindow()
        {
            ViewModels.MainWindowViewModel vm = new ViewModels.MainWindowViewModel();
            DataContext = vm;
            InitializeComponent();
        }
    }
}
