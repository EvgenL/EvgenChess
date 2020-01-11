using System;
using src.core.grid;

namespace src.core.rules
{
    public class DiagonalMovement : FigureMovementType
    {
        public DiagonalMovement(int range = StaticParameters.BOARD_SIZE) : base(range)
        {
        }

        public override bool PossibleToMove(CellPosition @from, CellPosition to, Board board)
        {
            int diffRow = to.Row - from.Row;
            int diffCol = to.Col - from.Col;

            // in board
            if (!CellPosition.Valid(from.Row + diffRow, from.Col + diffCol)) return false;
            // in range (for king)
            if (Math.Abs(diffCol) > Range || Math.Abs(diffRow) > Range) return false;
            
            int signRow = Math.Sign(diffRow);
            int signCol = Math.Sign(diffCol);

            // even moved
            if (signCol == 0 || signRow == 0) return false;
                

            for (int col = from.Col + signCol, row = from.Row + signRow;; col += signCol, row += signRow)
            {
                if (!CellPosition.Valid(row, col))
                    return false;
                if (col == to.Col && row == to.Row)
                    return true;
                if (board.HasFigure(new CellPosition(row, col)))
                    return false;
            }
        }
    }
}