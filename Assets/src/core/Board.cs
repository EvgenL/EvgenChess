using src.core.figures;
using src.core.grid;
using src.core.rules;

namespace src.core
{
    public class Board
    {
        public Player Whites;
        public Player Blacks;
        public FiguresSetup CurrentSetup;

        private FiguresContainer _container;

        public Board(Player whites, Player blacks, FiguresContainer container)
        {
            Whites = whites;
            Blacks = blacks;
            CurrentSetup = FiguresSetup.GetBasicSetup();
            _container = container;
            _container.SetBoard(this);
        }

        public Figure GetFigure(CellPosition pos)
        {
            return CurrentSetup.GetFigureByPos(pos);
        }

        public bool HasFigure(CellPosition pos)
        {
            return GetFigure(pos) != null;
        }

        public bool AttackingSameTeam(CellPosition from, CellPosition to)
        {
            Figure a = GetFigure(from);
            Figure b = GetFigure(to);

            return a != null && b != null && a.Side == b.Side;
        }

        public void ApplyTurn(Turn turn)
        {
            foreach (var action in turn.Actions)
            {
                ApplyAction(action);
            }    
        }

        private void ApplyAction(ChessAction action)
        {
            if (action is MoveAction)
            {
                // Move in "model"
                CurrentSetup.MoveFigure(action.From, action.To);
                // Move visually
                _container.MoveFigure(action.From, action.To);
            }
        }
        
    }
}