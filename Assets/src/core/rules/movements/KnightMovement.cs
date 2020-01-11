using System;
using src.core.grid;

namespace src.core.rules
{
    public class KnightMovement : FigureMovementType
    {
        public override bool PossibleToMove(CellPosition @from, CellPosition to, Board board)
        {
            int diffRow = to.Row - from.Row;
            int diffCol = to.Col - from.Col;
            int modDiffRow = Math.Abs(diffRow);
            int modDiffCol = Math.Abs(diffCol);

            // in board
            if (!CellPosition.Valid(from.Row + diffRow, from.Col + diffCol)) return false;

            // even moved
            if (diffRow == 0 || diffCol == 0) return false;
                
            CellPosition newPos = new CellPosition(from.Row + diffRow, from.Col + diffCol);
            
            // no same team figures on way
            if (board.AttackingSameTeam(from, newPos)) return false;
            
            // Г - movement
            return (modDiffRow == 1 && modDiffCol == 2 || modDiffRow == 2 && modDiffCol == 1);
        }
    }
}