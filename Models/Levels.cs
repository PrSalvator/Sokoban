using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Sokoban.Models
{
    public class Levels
    {
        private static int[,] getMatrix(int rowCount, int columnCount) // Заполнение матрицы постоянными элементами
        {
            int[,] matrix = new int[rowCount, columnCount];
            for(int i = 1; i < rowCount; i++)
            {
                matrix[i, 0] = MatrixElements.LeftBorder;
                matrix[i, columnCount - 1] = MatrixElements.RightBorder;
            }
            for (int i = 1; i < columnCount; i++)
            {
                matrix[0, i] = MatrixElements.TopBorder;
                matrix[rowCount - 1, i] = MatrixElements.BottomBorder;
            }
            matrix[0, 0] = MatrixElements.TopLeftCorner;
            matrix[0, columnCount - 1] = MatrixElements.TopRightCorner;
            matrix[rowCount - 1, 0] = MatrixElements.BottomLeftCorner;
            matrix[rowCount - 1, columnCount - 1] = MatrixElements.BottomRightCorner;

            return matrix;
        }

        public static Dictionary<int, Level> levelsDictionary = new Dictionary<int, Level>() // Словарь уровней
        {
            [1] = CreateLevel(() =>
            {
                int[,] matrix = getMatrix(10, 10);
                matrix[3, 3] = MatrixElements.Box;
                matrix[4, 3] = MatrixElements.Character;
                matrix[6, 3] = MatrixElements.Box;
                matrix[6, 2] = MatrixElements.Mark;
                matrix[4, 4] = MatrixElements.Border;
                matrix[4, 5] = MatrixElements.Border;
                matrix[4, 5] = MatrixElements.Mark;
                matrix[6, 5] = MatrixElements.Border;
                matrix[3, 6] = MatrixElements.Border;
                matrix[4, 6] = MatrixElements.Mark;
                matrix[4, 7] = MatrixElements.Box;
                Level level = new Level(matrix);
                return new Level(matrix);
            }),
            [2] = CreateLevel(() =>
            {
                int[,] matrix = getMatrix(9, 8);
                matrix[1, 3] = MatrixElements.Character;
                matrix[1, 6] = MatrixElements.Border;
                matrix[2, 3] = MatrixElements.Border;
                matrix[2, 4] = MatrixElements.Box;
                matrix[3, 3] = MatrixElements.Box;
                matrix[3, 5] = MatrixElements.Box;
                matrix[4, 3] = MatrixElements.Box;
                matrix[5, 1] = MatrixElements.Border;
                matrix[5, 2] = MatrixElements.Border;
                matrix[5, 3] = MatrixElements.Border;
                matrix[5, 5] = MatrixElements.Border;
                matrix[5, 6] = MatrixElements.Border;
                matrix[7, 1] = MatrixElements.Mark;
                matrix[7, 2] = MatrixElements.Mark;
                matrix[7, 3] = MatrixElements.Mark;
                matrix[7, 5] = MatrixElements.Mark;
                return new Level(matrix);
            }),
            [3] = CreateLevel(() =>
            {
                int[,] matrix = getMatrix(9, 8);
                matrix[1, 3] = MatrixElements.Character;
                matrix[2, 3] = MatrixElements.Border;
                matrix[2, 4] = MatrixElements.Box;
                matrix[3, 3] = MatrixElements.Box;
                matrix[3, 5] = MatrixElements.Box;
                matrix[4, 4] = MatrixElements.Box;
                matrix[5, 1] = MatrixElements.Border;
                matrix[5, 2] = MatrixElements.Border;
                matrix[5, 4] = MatrixElements.Border;
                matrix[5, 5] = MatrixElements.Border;
                matrix[5, 6] = MatrixElements.Border;
                matrix[6, 6] = MatrixElements.Border;
                matrix[7, 1] = MatrixElements.Mark;
                matrix[7, 2] = MatrixElements.Mark;
                matrix[7, 3] = MatrixElements.Mark;
                matrix[7, 5] = MatrixElements.Mark;
                return new Level(matrix);
            }),
            [4] = CreateLevel(() =>
            {
                int[,] matrix = getMatrix(9, 13);
                matrix[1, 5] = MatrixElements.Border;
                matrix[1, 6] = MatrixElements.Border;
                matrix[1, 7] = MatrixElements.Border;
                matrix[1, 11] = MatrixElements.Border;
                matrix[2, 5] = MatrixElements.Mark;
                matrix[2, 8] = MatrixElements.Box;
                matrix[2, 9] = MatrixElements.Box;
                matrix[2, 11] = MatrixElements.Border;
                matrix[3, 3] = MatrixElements.Character;
                matrix[3, 5] = MatrixElements.Border;
                matrix[3, 6] = MatrixElements.Border;
                matrix[3, 7] = MatrixElements.Border;
                matrix[3, 11] = MatrixElements.Border;
                matrix[4, 2] = MatrixElements.Mark;
                matrix[4, 3] = MatrixElements.Border;
                matrix[4, 5] = MatrixElements.Border;
                matrix[4, 6] = MatrixElements.Mark;
                matrix[4, 9] = MatrixElements.Border;
                matrix[4, 10] = MatrixElements.Border;
                matrix[4, 11] = MatrixElements.Border;
                matrix[5, 2] = MatrixElements.Border;
                matrix[5, 3] = MatrixElements.Border;
                matrix[5, 5] = MatrixElements.Border;
                matrix[5, 9] = MatrixElements.Border;
                matrix[5, 10] = MatrixElements.Border;
                matrix[5, 11] = MatrixElements.Border;
                matrix[6, 2] = MatrixElements.Box;
                matrix[6, 5] = MatrixElements.Border;
                matrix[6, 6] = MatrixElements.Border;
                matrix[6, 8] = MatrixElements.Box;
                matrix[6, 10] = MatrixElements.Mark;
                matrix[7, 8] = MatrixElements.Border;
                return new Level(matrix);
            }),
        };
        private static Level CreateLevel(Func<Level> action)
        {
            return action();
        }

    }
}
