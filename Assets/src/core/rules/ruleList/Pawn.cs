﻿using src.core.figures;

namespace src.core.rules.ruleList
{
    public class Pawn : FigureRule
    {
        public Pawn()
        {
            MyFigureName = FigureName.Pawn;
        }
        
        public override bool CanDoTurn(Turn turn)
        {
            if (!base.CanDoTurn(turn)) return false;
            
            
            return true;
        }

        public override ChessAction[] GetActions(Turn turn)
        {
            if (AttackingSameSide(turn))
            {
                return new ChessAction[0];
            }
            
            Figure figureToTake = turn.board.GetFigure(turn.MovedTo);
            
            return new ChessAction[] { new MoveAction(turn) };
        }
    }
}