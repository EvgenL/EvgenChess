namespace src.core.rules
{
    public class MoveAction : ChessAction
    {
        public MoveAction (Turn turn) : base(turn.MovedFigure, turn.MovedFrom, turn.MovedTo)
        {
            SortingPower = 1; // move action has to me done after take action and before replace action
        }
    }
}