using Sokoban.Models;
using Sokoban.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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

namespace Sokoban.Views
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameWindowViewModel vm;
        public GameWindow(Level level)
        {   
            vm = new GameWindowViewModel(level, this);
            DataContext = vm;
            InitializeComponent();
            vm.SetGrid(ref GameGrid);
            vm.DrawGameGrid();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up) { vm.Move("Up"); }
            else if (e.Key == Key.Down) { vm.Move("Down"); }
            else if (e.Key == Key.Right) { vm.Move("Right"); }
            else if (e.Key == Key.Left) { vm.Move("Left"); }
        }
    }
}
