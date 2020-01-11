using src.core.figures;
using src.core.grid;

namespace src.core.rules
{
    public class MoveAction : ChessAction
    {
        public CellPosition From;
        public CellPosition To;

        public MoveAction(Turn turn) : base(turn.MovedFigure)
        {
            From = turn.MovingFrom;
            To = turn.MovingTo;
        }
        
        public MoveAction(CellPosition from, CellPosition to, Figure movedFigure) : base(movedFigure)
        {
            SortingPower = 1;

            From = from;
            To = to;
        }
    }
}