using System.Collections.Generic;
using src.core.figures;
using UnityEngine.UI;

namespace src.core.rules
{
    public abstract class FigureRule : Rule
    {
        protected FigureName MyFigureName;
        protected FigureMovementType[] MovementTypes;
        
        public virtual bool CanDoTurn(Turn turn)
        {
            return MyFigureName == turn.MovedFigure.Name
                && !AttackingSameSide(turn);
        }

        public virtual ChessAction[] GetActions(Turn turn)
        {
            return new ChessAction[] { new MoveAction(turn) };
        }

        protected bool AttackingSameSide(Turn turn)
        {
            return turn.board.GetFigure(turn.MovedTo)?.Side == turn.MovedFigure.Side;
        }
    }
}