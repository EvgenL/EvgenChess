﻿using src.core.grid;

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
        public bool UnderAttack;

        public Figure(ChessSide side, FigureName name)
        {
            Side = side;
            Name = name;
            IsTaken = false;
        }

        public override string ToString()
        {
            return Name.ToString() + ":" + CurrentPos;
        }
    }
}