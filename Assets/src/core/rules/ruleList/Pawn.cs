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
    }
}