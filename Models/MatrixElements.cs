using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Models
{
    public class MatrixElements
    {
        public static int Empty = 0;
        public static int TopLeftCorner = 1;
        public static int TopRightCorner = 2;
        public static int BottomLeftCorner = 3;
        public static int BottomRightCorner = 4;
        public static int TopBorder = 5;
        public static int LeftBorder = 8;
        public static int BottomBorder = 7;
        public static int RightBorder = 6;
        public static int Border = 9;
        public static int Box = 10;
        public static int Mark = 11;
        public static int Character = 12;
        public static int CharacterOnMark = 13;
        public static int CorrectPosition = 14;
    }
}
