using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace src.core.figures
{
    public class FiguresContainer : MonoBehaviour
    {
        [SerializeField] private GridContainer _grid;

        [Header("White figures")] 
        [SerializeField] private GameObject _pawnW;
        [SerializeField] private GameObject _rookW;
        [SerializeField] private GameObject _knightW;
        [SerializeField] private GameObject _bishopW;
        [SerializeField] private GameObject _kingW;
        [SerializeField] private GameObject _queenW;
        
        [Header("Black figures")]
        [SerializeField] private GameObject _pawnB;
        [SerializeField] private GameObject _rookB;
        [SerializeField] private GameObject _knightB;
        [SerializeField] private GameObject _bishopB;
        [SerializeField] private GameObject _kingB;
        [SerializeField] private GameObject _queenB;

        private Board _board;
        
        private Dictionary<Figure, GameObject> _figuresObjects = new Dictionary<Figure, GameObject>();
        private Dictionary<CellPosition, GameObject> _figuresObjectsByPos = new Dictionary<CellPosition, GameObject>();

        public void SetBoard(Board b)
        {
            ClearBoard();
            
            _board = b;

            foreach (var fig in b.CurrentSetup.FiguresOnBoard)
            {
                PutFigure(fig.CurrentPos, fig);
            }
        }

        public void ClearBoard()
        {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            
            _figuresObjects = new Dictionary<Figure, GameObject>();
            _figuresObjectsByPos = new Dictionary<CellPosition, GameObject>();
        }
        
        public void PutFigure(CellPosition pos, Figure figure)
        {
            var prefab = GetPrefab(figure);
            var worldPos = _grid.CellPosToWord(pos);

            var go = Instantiate(prefab, this.transform);
            go.transform.position = worldPos;
            _figuresObjects[figure] = go;
            _figuresObjectsByPos[pos] = go;
        }
        
        public void TakeFigure(CellPosition pos)
        {
            var go = _figuresObjectsByPos[pos];
            var fig = _figuresObjects.First(f => f.Value == go).Key;

            _figuresObjectsByPos.Remove(pos);
            _figuresObjects.Remove(fig);
            
            Destroy(go);
        }
        
        public void MoveFigure(CellPosition from, CellPosition to)
        {
            var figure = _figuresObjectsByPos[from];
            _figuresObjectsByPos.Remove(from);
            _figuresObjectsByPos[to] = figure;

            figure.transform.position = _grid.CellPosToWord(to);
        }

        private GameObject GetPrefab(Figure fig)
        {
            if (fig.Side == ChessSide.Whites)
            {
                switch (fig.Name)
                {
                    case FigureName.Pawn:
                        return _pawnW;
                    case FigureName.Rook:
                        return _rookW;
                    case FigureName.Knight:
                        return _knightW;
                    case FigureName.Bishop:
                        return _bishopW;
                    case FigureName.King:
                        return _kingW;
                    case FigureName.Queen:
                        return _queenW;
                }
            }
            else // blacks
            {
                switch (fig.Name)
                {
                    case FigureName.Pawn:
                        return _pawnB;
                    case FigureName.Rook:
                        return _rookB;
                    case FigureName.Knight:
                        return _knightB;
                    case FigureName.Bishop:
                        return _bishopB;
                    case FigureName.King:
                        return _kingB;
                    case FigureName.Queen:
                        return _queenB;
                }
            }
            throw new Exception("Bad figure: " + fig);
        }
    }
}