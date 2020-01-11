using src.core.figures;
using src.core.grid;

namespace src.core.rules
{
    public abstract class ChessAction
    {
        public readonly Figure Fig;
        public readonly CellPosition From;
        public readonly CellPosition To;
        public int SortingPower;

        protected ChessAction(Figure fig, CellPosition from, CellPosition to)
        {
            Fig = fig;
            From = from; 
            To = to; 
        }
    }
}