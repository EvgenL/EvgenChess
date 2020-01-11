using src.core.figures;
using src.core.grid;
using UnityEngine;

namespace src.core.rules.ruleList
{
    public class Castelling : FigureRule
    {
        public Castelling()
        {
            MovementTypes = new FigureMovementType[]{new LineMovement(4)};
        }

        public override bool CanDoTurn(Turn turn)
        {
            if (!MovementTypes[0].PossibleToMove(turn.MovingFrom, turn.MovingTo, turn.board)) return false;
            
            Figure fromFig = turn.board.GetFigure(turn.MovingFrom);
            Figure toFig = turn.board.GetFigure(turn.MovingTo);

            if (fromFig == null || toFig == null) return false;

            if (fromFig.Name == FigureName.King && toFig.Name == FigureName.Rook
                || fromFig.Name == FigureName.Rook && toFig.Name == FigureName.King)
            {
                return !fromFig.EverMoved && !toFig.EverMoved;
            }

            return false;
        }

        public override ChessAction[] GetActions(Turn turn)
        {
            Figure fromFig = turn.board.GetFigure(turn.MovingFrom);
            Figure king;
            Figure rook;
            if (fromFig.Name == FigureName.King)
            {
                king = fromFig;
                rook = turn.board.GetFigure(turn.MovingTo);
            }
            else
            {
                king = turn.board.GetFigure(turn.MovingTo);
                rook = fromFig;
            }
            
            // there's two types of castelling

            bool longCastelling = rook.CurrentPos.Col == 1;
            CellPosition newKingPos;
            CellPosition newRookPos;
            // long
            if (longCastelling)
            {
                newKingPos = new CellPosition(king.CurrentPos.Row, 3);
                newRookPos = new CellPosition(rook.CurrentPos.Row, 4);
            }
            else
            {
                // short
                newKingPos = new CellPosition(king.CurrentPos.Row, 7);
                newRookPos = new CellPosition(rook.CurrentPos.Row, 6);
            }
            
            return new ChessAction[]{ new MoveAction(king.CurrentPos, newKingPos, king),
                new MoveAction(rook.CurrentPos, newRookPos, rook) };
        }
    }
}