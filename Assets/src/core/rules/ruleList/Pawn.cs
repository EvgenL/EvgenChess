using System;
using System.Collections.Generic;
using src.core.figures;

namespace src.core.rules.ruleList
{
    public class Pawn : FigureRule
    {
        public Pawn()
        {
            MyFigureName = FigureName.Pawn;
            MovementTypes = new FigureMovementType[] { new PawnMovement() };
        }

        public override ChessAction[] GetActions(Turn turn)
        {
            // promotion
            if (turn.MovingTo.Row == StaticParameters.BOARD_SIZE || turn.MovingTo.Row == 1)
            {
                return new ChessAction[]
                {
                    new TakeAction(turn.MovedFigure),
                    new PromoteAction(turn.MovingTo, turn.MovedFigure.Side, turn.MovedFigure) 
                };
            }

            return base.GetActions(turn);
        }
    }
}