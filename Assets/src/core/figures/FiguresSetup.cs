using System.Collections.Generic;
using System.Linq;
using src.core.grid;

namespace src.core.figures
{
    public class FiguresSetup
    {
        public List<Figure> FiguresOnBoard = new List<Figure>();        
        
        private Dictionary<CellPosition, Figure>_figuresByPos
            = new Dictionary<CellPosition, Figure>();
        
        
        public List<Figure> FiguresWhites = new List<Figure>();  
        public List<Figure> FiguresBlacks = new List<Figure>();  
        
        public List<Figure> FiguresWhitesTaken = new List<Figure>();  
        public List<Figure> FiguresBlacksTaken = new List<Figure>();  
        
        public static FiguresSetup GetBasicSetup()
        {
            FiguresSetup setup = new FiguresSetup();
            
            // whites
            setup.PutFigure(new CellPosition(2, 'A'), new Figure(ChessSide.Whites, FigureName.Pawn));
            setup.PutFigure(new CellPosition(2, 'B'), new Figure(ChessSide.Whites, FigureName.Pawn));
            setup.PutFigure(new CellPosition(2, 'C'), new Figure(ChessSide.Whites, FigureName.Pawn));
            setup.PutFigure(new CellPosition(2, 'D'), new Figure(ChessSide.Whites, FigureName.Pawn));
            setup.PutFigure(new CellPosition(2, 'E'), new Figure(ChessSide.Whites, FigureName.Pawn));
            setup.PutFigure(new CellPosition(2, 'F'), new Figure(ChessSide.Whites, FigureName.Pawn));
            setup.PutFigure(new CellPosition(2, 'G'), new Figure(ChessSide.Whites, FigureName.Pawn));
            setup.PutFigure(new CellPosition(2, 'H'), new Figure(ChessSide.Whites, FigureName.Pawn));
            setup.PutFigure(new CellPosition(1, 'A'), new Figure(ChessSide.Whites, FigureName.Rook));
            setup.PutFigure(new CellPosition(1, 'H'), new Figure(ChessSide.Whites, FigureName.Rook));
            setup.PutFigure(new CellPosition(1, 'B'), new Figure(ChessSide.Whites, FigureName.Knight));
            setup.PutFigure(new CellPosition(1, 'G'), new Figure(ChessSide.Whites, FigureName.Knight));
            setup.PutFigure(new CellPosition(1, 'C'), new Figure(ChessSide.Whites, FigureName.Bishop));
            setup.PutFigure(new CellPosition(1, 'F'), new Figure(ChessSide.Whites, FigureName.Bishop));
            setup.PutFigure(new CellPosition(1, 'E'), new Figure(ChessSide.Whites, FigureName.King));
            setup.PutFigure(new CellPosition(1, 'D'), new Figure(ChessSide.Whites, FigureName.Queen));
            
            // blacks
            setup.PutFigure(new CellPosition(7, 'A'), new Figure(ChessSide.Blacks, FigureName.Pawn));
            setup.PutFigure(new CellPosition(7, 'B'), new Figure(ChessSide.Blacks, FigureName.Pawn));
            setup.PutFigure(new CellPosition(7, 'C'), new Figure(ChessSide.Blacks, FigureName.Pawn));
            setup.PutFigure(new CellPosition(7, 'D'), new Figure(ChessSide.Blacks, FigureName.Pawn));
            setup.PutFigure(new CellPosition(7, 'E'), new Figure(ChessSide.Blacks, FigureName.Pawn));
            setup.PutFigure(new CellPosition(7, 'F'), new Figure(ChessSide.Blacks, FigureName.Pawn));
            setup.PutFigure(new CellPosition(7, 'G'), new Figure(ChessSide.Blacks, FigureName.Pawn));
            setup.PutFigure(new CellPosition(7, 'H'), new Figure(ChessSide.Blacks, FigureName.Pawn));
            setup.PutFigure(new CellPosition(8, 'A'), new Figure(ChessSide.Blacks, FigureName.Rook));
            setup.PutFigure(new CellPosition(8, 'H'), new Figure(ChessSide.Blacks, FigureName.Rook));
            setup.PutFigure(new CellPosition(8, 'B'), new Figure(ChessSide.Blacks, FigureName.Knight));
            setup.PutFigure(new CellPosition(8, 'G'), new Figure(ChessSide.Blacks, FigureName.Knight));
            setup.PutFigure(new CellPosition(8, 'C'), new Figure(ChessSide.Blacks, FigureName.Bishop));
            setup.PutFigure(new CellPosition(8, 'F'), new Figure(ChessSide.Blacks, FigureName.Bishop));
            setup.PutFigure(new CellPosition(8, 'E'), new Figure(ChessSide.Blacks, FigureName.King));
            setup.PutFigure(new CellPosition(8, 'D'), new Figure(ChessSide.Blacks, FigureName.Queen));

            return setup;
        }

        public void Clear()
        {
            FiguresOnBoard = new List<Figure>(); 
            FiguresWhites = new List<Figure>();  
            FiguresBlacks = new List<Figure>();  
            FiguresWhitesTaken = new List<Figure>();  
            FiguresBlacksTaken = new List<Figure>();  
        }
            
        public void PutFigure(CellPosition pos, Figure figure)
        {
            figure.CurrentPos = pos;
            
            if (figure.Side == ChessSide.Whites)
            {
                if (FiguresWhitesTaken.Contains(figure))
                    FiguresWhitesTaken.Remove(figure);
                
                FiguresWhites.Add(figure);
            }
            else // Blacks
            {
                if (FiguresBlacksTaken.Contains(figure))
                    FiguresBlacksTaken.Remove(figure);
                
                FiguresBlacks.Add(figure);
            }
            
            FiguresOnBoard.Add(figure);
        }
        
        public void TakeFigure(CellPosition pos)
        {
            var figure = GetFigureByPos(pos);
            figure.IsTaken = true;
            
            if (figure.Side == ChessSide.Whites)
            {
                if (FiguresWhites.Contains(figure))
                    FiguresWhites.Remove(figure);
                
                FiguresWhitesTaken.Add(figure);
            }
            else // Blacks
            {
                if (FiguresBlacks.Contains(figure))
                    FiguresBlacks.Remove(figure);
                
                FiguresBlacksTaken.Add(figure);
            }
            
            FiguresOnBoard.Remove(figure);
        }
        
        public void MoveFigure(CellPosition from, CellPosition to)
        {
            var fig = GetFigureByPos(from);
            fig.PrevPos = from;
            fig.CurrentPos = to;
        }

        public Figure GetFigureByPos(CellPosition pos)
        {
            return FiguresOnBoard.FirstOrDefault(figure => figure.CurrentPos == pos);
        }
    }
}