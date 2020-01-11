using src.core.grid;

namespace src.core.rules
{
    public abstract class FigureMovementType
    {
        protected int Range;
        
        public FigureMovementType(int range = StaticParameters.BOARD_SIZE)
        {
            Range = range;
        }

        public abstract bool PossibleToMove(CellPosition from, CellPosition to, Board board);
    }
}