using System;

namespace src.core.grid
{
    public struct CellPosition
    {
        public CellPosition(int row, int col) : this()
        {
            Row = row;
            Col = col;
        }
        public CellPosition(int row, char col) : this()
        {
            Row = row;
            Col = (int)(char.ToUpper(col) - StaticParameters.BOARD_FIRST_CHAR);
        }

        public int Row;
        public int Col;

        private static bool InBounds(int pos)
        {
            return pos <= StaticParameters.BOARD_SIZE && pos >= 1;
        }

        public override string ToString()
        {
            return (char)(Col + StaticParameters.BOARD_FIRST_CHAR) + Row.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is CellPosition other)
            {
                return Col == other.Col && Row == other.Row;
            }

            return false;
        }

        public static bool operator == (CellPosition a, CellPosition b)
        {
            return a.Equals(b);
        }
        public static bool operator != (CellPosition a, CellPosition b)
        {
            return !a.Equals(b);
        }

        public bool Valid()
        {
            return InBounds(Row) && InBounds(Col);
        }
        
    }
}