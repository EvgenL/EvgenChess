using System;

namespace src.core
{
    public struct CellPosition
    {
        public CellPosition(int row, int col) : this()
        {
            Row = row;
            Col = (char) (col + StaticParameters.BOARD_FIRST_CHAR-1);
        }
        public CellPosition(int row, char col) : this()
        {
            Row = row;
            Col = col;
        }
        
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

        public override string ToString()
        {
            return Col + Row.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is CellPosition other)
            {
                return _col == other._col && _row == other._row;
            }
            else
            {
                return false;
            }
        }
        
        public static bool operator == (CellPosition a, CellPosition b)
        {
            return a.Equals(b);
        }
        public static bool operator != (CellPosition a, CellPosition b)
        {
            return !a.Equals(b);
        }
    }
}