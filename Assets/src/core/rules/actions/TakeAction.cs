using src.core.figures;
using src.core.grid;

namespace src.core.rules
{
    public class TakeAction : ChessAction
    {
        public Figure TakenFigure;
        public CellPosition TakenPos;
        
        public TakeAction (Figure takenFigure) : base(takenFigure)
        {
            SortingPower = 0; // take action has to be done firstmost
            
            TakenFigure = takenFigure;
            TakenPos = takenFigure.CurrentPos;
        }
    }
}