using System.Collections.Generic;
using src.core.figures;
using src.core.grid;
using src.core.rules;

namespace src.core
{
    public class Turn
    {
        public List<ChessAction> Actions = new List<ChessAction>();
        
        public Figure MovedFigure;
        public CellPosition MovedFrom;
        public CellPosition MovedTo;

        // todo to buffered board state
        public Board board;
        
        private Turn(Board board, CellPosition from, CellPosition to)
        {
            this.board = board;
            MovedFigure = board.GetFigure(from);
            MovedFrom = from;
            MovedTo = to;
        }

        public static Turn CreateIfPossible(RulesValidator validator, Board _board, CellPosition from, CellPosition to)
        {
            Figure figureFrom = _board.GetFigure(from);
            if (figureFrom == null)
            {
                return null;
            }
            
            Turn turn = new Turn(_board, from, to);
            return validator.ValidateTurn(turn);
        }
    }
}