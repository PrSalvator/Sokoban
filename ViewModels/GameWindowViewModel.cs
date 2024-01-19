using Sokoban.Commands;
using Sokoban.Models;
using Sokoban.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Sokoban.ViewModels
{
    public class GameWindowViewModel
    {
        private Grid gameGrid;
        private int columnCount = 0;
        private int rowCount = 0;
        private RowDefinition rowDefinition;
        private ColumnDefinition columnDefinition;
        private MovementLogic movementLogic;
        private Command restartCommand;
        private Command menuCommand;
        private Level level;
        private Window window;
        private int count;
        private string gameState;
        public GameWindowViewModel(Models.Level level, Window window)
        {
            this.window = window;
            columnCount = level.Matrix.GetLength(1);
            rowCount = level.Matrix.GetLength(0);
            movementLogic = new MovementLogic(level);
            this.level = level;
        }
        public void SetGrid(ref Grid grid)
        {
            gameGrid = grid;
        }
        public async Task DrawGameGrid()
        {
            count = 0;
            gameGrid.Children.Clear();
            gameGrid.RowDefinitions.Clear();
            gameGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < columnCount; i++)
            {
                columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(1, GridUnitType.Star);
                gameGrid.ColumnDefinitions.Add(columnDefinition);
            }
            for (int i = 0; i < rowCount; i++)
            {
                rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(1, GridUnitType.Star);
                gameGrid.RowDefinitions.Add(rowDefinition);
                for (int j = 0; j < columnCount; j++)
                {
                    Button button = new Button();
                    button.Background = Brushes.Transparent;
                    Binding binding = new Binding();
                    button.Tag = movementLogic.Matrix[i, j];
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    gameGrid.Children.Add(button);

                    if (movementLogic.Matrix[i, j] == MatrixElements.CorrectPosition) count++;
                }
            }
            if (count == level.BoxCount)
            {
                await Task.Delay(1000);
                window.DialogResult = true;
                window.Close();
            }
        }

        public void Move(string direction)
        {
            movementLogic.Move(direction);
            DrawGameGrid();
        }
        public Command RestartCommand
        {
            get
            {
                return restartCommand ??
                  (restartCommand = new Command(obj =>
                  {
                      movementLogic = new MovementLogic(level);
                      DrawGameGrid();
                  }));
            }
        }
        public Command MenuCommand
        {
            get
            {
                return menuCommand ??
                  (menuCommand = new Command(obj =>
                  {
                      window.DialogResult = false;
                      window.Close();  
                  }));
            }
        }
    }
}
