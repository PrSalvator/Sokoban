using Sokoban.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sokoban.Models
{
    public class Level : INotifyPropertyChanged
    {
        private bool isComplete = false;
        private Position startPosition = new Position(0, 0); 
        public int[,] Matrix { get;}
        public int BoxCount { get;}
        public Position StartPosition // Позиция персонажа при старте
        { 
            get { return startPosition; }
        }
        public bool IsComplete
        {
            get
            {
                return isComplete;
            }
            set
            {
                isComplete = value;
                OnPropertyChanged("IsComplete");
            }
        }
        public Level(int[,] matrix) // Находим где находится персонаж при инициализации
        {
            Matrix = matrix;
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == MatrixElements.Character)
                    {
                        startPosition.Row = i;
                        startPosition.Column = j;
                    }
                    else if (matrix[i,j] == MatrixElements.Box)
                    {
                        BoxCount += 1;
                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
