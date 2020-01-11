using System.Collections.Generic;
using src.core.figures;
using src.core.grid;

namespace src.core.rules.ruleList
{
    public class Rook : FigureRule
    {
        public Rook()
        {
            MyFigureName = FigureName.Rook;
            MovementTypes = new FigureMovementType[]{new LineMovement()};
        }
    }
}