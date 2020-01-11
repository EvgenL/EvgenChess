using System.Collections.Generic;
using src.core.figures;

namespace src.core.rules.ruleList
{
    public class King : FigureRule
    {
        public King()
        {
            MyFigureName = FigureName.King;
            MovementTypes = new FigureMovementType[]{new LineMovement(1), new DiagonalMovement(1)};
        }
        
        public override bool CanDoTurn(Turn turn)
        {
            if (!base.CanDoTurn(turn)) return false;
            
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