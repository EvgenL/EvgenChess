using src.core.figures;

namespace src.core.rules.ruleList
{
    public class Queen : FigureRule
    {
        public Queen()
        {
            MyFigureName = FigureName.Queen;
            MovementTypes = new FigureMovementType[]{new LineMovement(), new DiagonalMovement()};
        }
    }
}