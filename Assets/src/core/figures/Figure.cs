using System.Collections.Generic;
using src.core.grid;

namespace src.core.figures
{
    public class Figure
    {
        public ChessSide Side;
        public FigureName Name;
        public CellPosition CurrentPos;
        public CellPosition PrevPos; // position on previous turn
        public bool IsTaken;

        public bool EverMoved;
        
        public List<Figure> _attackedBy = new List<Figure>();
        public bool UnderAttack => _attackedBy.Count > 0;

        public Figure(ChessSide side, FigureName name)
        {
            Side = side;
            Name = name;
            IsTaken = false;
        }

        public override string ToString()
        {
            return Name + ":" + CurrentPos;
        }
    }
}