using src.core.figures;
using src.core.grid;

namespace src.core.rules
{
    public class TakeAction : ChessAction
    {
        public Figure TakenFigure;
        public CellPosition TakenPos;
        
        public TakeAction (Turn turn) : base(turn.MovedFigure, turn.MovedFrom, turn.MovedTo)
        {
            SortingPower = 0; // take action has to be done firstmost
            
            TakenFigure = turn.board.GetFigure(turn.MovedTo);
            TakenPos = turn.MovedTo;
        }
    }
}