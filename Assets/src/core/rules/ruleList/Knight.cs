using System.Collections.Generic;
using src.core.figures;

namespace src.core.rules.ruleList
{
    public class Knight : FigureRule
    {
        public Knight()
        {
            MyFigureName = FigureName.Knight;
            MovementTypes = new FigureMovementType[]{new KnightMovement()};
        }
    }
}