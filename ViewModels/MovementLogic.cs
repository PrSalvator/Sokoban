using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Models;

namespace Sokoban.ViewModels
{
    public class MovementLogic
    {
        private Position position = new Position();
        public int[,] Matrix { get; set;}

        private int nextCell1;
        private int nextCell2;
        private int curCell;

        public MovementLogic(Level level)
        {
            Matrix = (int[,])level.Matrix.Clone();
            position = level.StartPosition;
        }
        public void Move(string direction)
        {
            int border = DictBorder[direction];
            Position p = DictMooving[direction];
            nextCell1 = Matrix[position.Row + p.Row, position.Column + p.Column];
            curCell = Matrix[position.Row, position.Column];
            if (nextCell1 == MatrixElements.Box || nextCell1==MatrixElements.CorrectPosition) // Если следующая ячейка коробка
            {
                nextCell2 = Matrix[position.Row + p.Row*2, position.Column + p.Column*2];
                if (nextCell2 != MatrixElements.Box && nextCell2 != border 
                    && nextCell2 != MatrixElements.Border && nextCell2 != MatrixElements.CorrectPosition) // Если следующая ячейка не коробка или стена
                {
                    Matrix[position.Row, position.Column] = curCell == MatrixElements.CharacterOnMark ? MatrixElements.Mark : MatrixElements.Empty;
                    Matrix[position.Row + p.Row, position.Column + p.Column] = nextCell1 == MatrixElements.CorrectPosition ? MatrixElements.CharacterOnMark : MatrixElements.Character;
                    Matrix[position.Row + p.Row*2, position.Column +p.Column*2] = nextCell2 == MatrixElements.Mark ? MatrixElements.CorrectPosition : MatrixElements.Box;
                    position.Column += p.Column;
                    position.Row += p.Row;
                }
                return;
            }
            if(nextCell1 == MatrixElements.Mark) //Если следующая ячейка - место коробки
            {
                Matrix[position.Row, position.Column] = curCell == MatrixElements.CharacterOnMark ? MatrixElements.Mark : MatrixElements.Empty;
                Matrix[position.Row + p.Row, position.Column + p.Column] = MatrixElements.CharacterOnMark;
                position.Column += p.Column;
                position.Row += p.Row;
                return;
            }
            if (nextCell1 != border && nextCell1 != MatrixElements.Border) // Если следующая ячейка не стена
            {
                Matrix[position.Row, position.Column] = curCell == MatrixElements.CharacterOnMark ? MatrixElements.Mark : MatrixElements.Empty;
                Matrix[position.Row + p.Row, position.Column + p.Column] = MatrixElements.Character;
                position.Column += p.Column;
                position.Row += p.Row;
                return;
            }
            
        }
        private Dictionary<string, Position> DictMooving = new Dictionary<string, Position>()
        {
            ["Left"] = new Position(0, -1),
            ["Right"] = new Position(0, 1),
            ["Up"] = new Position(-1, 0),
            ["Down"] = new Position(1, 0)
        };

        private Dictionary<string, int> DictBorder = new Dictionary<string, int>() 
        {
            ["Left"] = MatrixElements.LeftBorder,
            ["Right"] = MatrixElements.RightBorder,
            ["Up"] = MatrixElements.TopBorder,
            ["Down"] = MatrixElements.BottomBorder
        };
    }
}
