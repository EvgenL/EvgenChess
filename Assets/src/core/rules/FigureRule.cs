using System.Collections.Generic;
using System.Linq;
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
            if (MyFigureName != turn.MovedFigure.Name) return false;
            
            bool moveOk = true;
            if (MovementTypes != null)
            {
                moveOk = MovementTypes.Any(move => move.PossibleToMove(turn.MovingFrom, turn.MovingTo, turn.board));
            }

            return !AttackingSameSide(turn)
                   && moveOk;
        }

        public virtual ChessAction[] GetActions(Turn turn)
        {
            Figure figureToTake = turn.board.GetFigure(turn.MovingTo);
            List<ChessAction> actions = new List<ChessAction>();
            if (figureToTake != null)
            {
                actions.Add(new TakeAction(figureToTake));
            }
            actions.Add(new MoveAction(turn));
            return actions.ToArray();
        }

        protected bool AttackingSameSide(Turn turn)
        {
            return turn.board.AttackingSameTeam(turn.MovingFrom, turn.MovingTo);
        }
    }
}