using src.core.figures;

namespace src.core.rules.ruleList
{
    public class Pawn : FigureRule
    {
        public Pawn()
        {
            MyFigureName = FigureName.Pawn;
            MovementTypes = new FigureMovementType[] {new PawnMovement() };
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
            
            Figure figureToTake = turn.board.GetFigure(turn.MovingTo);
            
            return new ChessAction[] { new MoveAction(turn) };
        }
    }
}