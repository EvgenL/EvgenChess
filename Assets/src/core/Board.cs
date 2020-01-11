using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Xml;
using src.core.figures;
using src.core.grid;
using src.core.rules;

namespace src.core
{
    public class Board
    {
        public FiguresSetup CurrentSetup;

        private FiguresContainer _container;

        public Board(FiguresContainer container)
        {
            CurrentSetup = FiguresSetup.GetBasicSetup();
            _container = container;
            _container?.SetBoard(this);
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

        public List<Figure> GetEnemies(ChessSide side)
        {
            return side == ChessSide.Whites ? CurrentSetup.FiguresBlacks : CurrentSetup.FiguresWhites;
        }

        public List<Figure> GetAllies(ChessSide side)
        {
            return side == ChessSide.Whites ? CurrentSetup.FiguresWhites : CurrentSetup.FiguresBlacks;
        }

        public Figure GetFigureByName(ChessSide side, FigureName name)
        {
            var allies = GetAllies(side);
            return allies.First(f => f.Name == name);
        }

        public Figure GetKing(ChessSide side)
        {
            return GetFigureByName(side, FigureName.King);
        }
        
        private void ApplyAction(ChessAction action)
        {
            if (action is MoveAction move)
            {
                // Move in "model"
                CurrentSetup.MoveFigure(move.From, move.To);
                // Move visually
                _container?.MoveFigure(move.From, move.To);
            }
            else if (action is TakeAction take)
            {
                CurrentSetup.TakeFigure(take.TakenPos);
                _container?.TakeFigure(take.TakenPos);
            }
        }

        public Board Copy()
        {
            var newB = new Board(null);
            newB.CurrentSetup = CurrentSetup.Copy();
            return newB;
        }
        
    }
}