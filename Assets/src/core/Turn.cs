using System;
using System.Collections.Generic;
using System.Linq;
using src.core.figures;
using src.core.grid;
using src.core.rules;

namespace src.core
{
    public class Turn
    {
        public List<ChessAction> Actions = new List<ChessAction>();
        
        public Figure MovedFigure;
        public CellPosition MovingFrom;
        public CellPosition MovingTo;
        public Figure KingAttackedBy;
        public bool TurnValid = false;

        // todo to buffered board state
        public Board board;
        
        private Turn(Board board, CellPosition from, CellPosition to)
        {
            this.board = board;
            MovedFigure = board.GetFigure(from);
            MovingFrom = from;
            MovingTo = to;
        }

        public static Turn CreateIfPossible(RulesValidator validator, Board board, CellPosition from, CellPosition to)
        {
            if (board.HasFigure(from) 
                && board.GetFigure(from).Side != validator.WhoseTurn) return null;
            
            Turn turn = new Turn(board, from, to);
            Figure figureFrom = board.GetFigure(from);
            if (figureFrom == null)
            {
                return turn; // not valid 
            }

            
            return validator.ValidateTurn(turn);
        }

        public static Turn NoValidate(Board board, CellPosition from, CellPosition to)
        {
            return new Turn(board, from, to);
        }
    }
}