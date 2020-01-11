using src.core.figures;
using src.core.grid;

namespace src.core.rules
{
    public abstract class ChessAction
    {
        public readonly Figure Fig;
        public int SortingPower;

        protected ChessAction(Figure fig)
        {
            Fig = fig;
        }
    }
}