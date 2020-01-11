using System.Collections.Generic;
using src.core.figures;
using src.core.managers;
using UnityEngine;

namespace src.core.rules.ruleList
{
    public class King : FigureRule
    {
        public King()
        {
            MyFigureName = FigureName.King;
            MovementTypes = new FigureMovementType[]{new LineMovement(1), new DiagonalMovement(1)};
        }
    }
}