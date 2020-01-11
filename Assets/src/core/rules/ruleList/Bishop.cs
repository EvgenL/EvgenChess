using src.core.figures;

namespace src.core.rules.ruleList
{
    public class Bishop : FigureRule
    {
        public Bishop()
        {
            MyFigureName = FigureName.Bishop;
            MovementTypes = new FigureMovementType[]{new DiagonalMovement()};
        }
    }
}