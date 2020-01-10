using System;

namespace src.core
{
    public class CellPosition
    {
        public int Row
        {
            set
            {
                if (RowValid(value))
                    _row = value;
                else
                    throw new Exception("Bad row value: " + value);
            }
            
            get => _row;
        }

        public char Col
        {
            set
            {
                if (ColValid(value))
                    _col = char.ToUpper(value);
                else
                    throw new Exception("Bad column value: " + value);
            }
            
            get => _col;
        }
        
        private int _row;
        private char _col;

        private static bool RowValid(int row)
        {
            return row <= StaticParameters.BOARD_SIZE && row >= 1;
        }

        private static bool ColValid(char col)
        {
            char COL = char.ToUpperInvariant(col);
            return COL <= StaticParameters.BOARD_LAST_CHAR && COL >= StaticParameters.BOARD_FIRST_CHAR;
        }
        
        
        
    }
}