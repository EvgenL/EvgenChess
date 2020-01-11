using System.Collections.Generic;
using src.core.figures;
using src.core.grid;

namespace src.core.rules.ruleList
{
    public class Rook : FigureRule
    {
        public Rook()
        {
            MyFigureName = FigureName.Rook;
        }
        
        public override bool CanDoTurn(Turn turn)
        {
            if (!base.CanDoTurn(turn)) return false;

            CellPosition target = turn.MovedTo;
            
            //turn.board.LineMovementPossible
            
            // if cell is too far
            
            return true;
        }

        public override ChessAction[] GetActions(Turn turn)
        {
            Figure figureToTake = turn.board.GetFigure(turn.MovedTo);
            List<ChessAction> actions = new List<ChessAction>();
            if (figureToTake != null)
            {
                actions.Add(new TakeAction(turn));
            }
            actions.AddRange(base.GetActions(turn));
            return actions.ToArray();
        }
    }
}