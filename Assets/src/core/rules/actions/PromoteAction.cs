using src.core.figures;
using src.core.grid;

namespace src.core.rules
{
    public class PromoteAction : ChessAction
    {
        public CellPosition Pos;
        public ChessSide Side;
        
        public PromoteAction(CellPosition pos, ChessSide side, Figure promotedFigure) : base(promotedFigure)
        {
            SortingPower = 3; // take action has to be done lastmost
            Side = side;
            Pos = pos;
        }
    }
}