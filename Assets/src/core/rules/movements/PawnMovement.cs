using System;
using src.core.figures;
using src.core.grid;
using UnityEngine;

namespace src.core.rules
{
    public class PawnMovement : FigureMovementType
    {
        public PawnMovement() : base(2)
        {
        }
        
        public override bool PossibleToMove(CellPosition @from, CellPosition to, Board board)
        {
            var mySide = board.GetFigure(from).Side;
            bool hasMadeAnyTurn = mySide == ChessSide.Whites && from.Row != 2
                                  || mySide == ChessSide.Blacks && from.Row != StaticParameters.BOARD_SIZE - 1;
            int sideDirectionSign = mySide == ChessSide.Whites ? 1 : -1;
            
            int diffRow = to.Row - from.Row;
            int diffCol = to.Col - from.Col;
            
            // attacking
            if (Math.Abs(diffCol) == 1 && Math.Abs(diffRow) == 1)
            {
                bool normalAttack = board.HasFigure(to) && !board.AttackingSameTeam(from, to);

                bool takeByPass = false;
                // take by pass
                if (!board.HasFigure(to))
                {
                    Figure possiblePawn = board.GetFigure(new CellPosition(to.Row + sideDirectionSign, to.Col));
                    if (possiblePawn != null && possiblePawn.Name == FigureName.Pawn 
                                             && possiblePawn.PrevPos == new CellPosition(to.Row - sideDirectionSign, to.Col))
                    {
                        takeByPass = true; // todo
                        Debug.Log("Take by pass!");
                    }
                }

                return normalAttack || takeByPass;
            }
            
            // moving
            if (diffCol == 0 && Math.Abs(diffRow) >= 1 && Math.Abs(diffRow) <= 2 && !board.HasFigure(to))
            {
                if (!hasMadeAnyTurn && diffRow * sideDirectionSign == 2 
                                    && !board.HasFigure(new CellPosition(to.Row + -1 * sideDirectionSign, to.Col)))
                    return true;
                if (diffRow * sideDirectionSign == 1)
                    return true;
            }
            return false;
        }
    }
}