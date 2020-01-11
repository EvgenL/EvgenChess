using src.core.figures;

namespace src.core
{
    public class Board
    {
        public FiguresSetup CurrentSetup;

        public Board(Player whites, Player blacks)
        {
            CurrentSetup = FiguresSetup.GetBasicSetup();
        }
    }
}