using src.core.grid;
using src.core.managers;
using UnityEngine;

namespace src.renderer
{
    public class GridUiRenderer : MonoBehaviour
    {
        [Header("Sprites")]
        [SerializeField] private Sprite _spriteCellActive;
        [SerializeField] private Sprite _spriteCellSelected;
        [SerializeField] private Sprite _spriteCellInactive;
        
        [Header("Container")]
        [SerializeField] private GridContainer _gridContainer;
        private InputManager _im;
    
        private void Start()
        {
            _im = InputManager.Instance;
            Enable();
        }

        public void Enable()
        {
            _im.OnMouseEnteredCell += OnCellEntered;
            _im.OnMouseExitedCell += OnCellExited;
            _im.OnMouseStartDrag += OnStartDrag;
            _im.OnMouseClickedCell += OnCellClick;
            _im.OnMouseClickedTwoCells += OnTwoCellClick;
            _im.OnDeselectCell += OnDeselectCell;
        
            ClearCellPaint();
        }
        public void Disable()
        {
            _im.OnMouseEnteredCell -= OnCellEntered;
            _im.OnMouseExitedCell -= OnCellExited;
        
            ClearCellPaint();
        }

        private void OnCellEntered(CellPosition pos)
        {
            if (_im.DragStartCell != pos)
                PaintCell(CellState.Hovered, pos);
            if (_im.IsMouseDragging)
            {
                ClearCellPaint();
                PaintCell(CellState.Hovered, _im.HoveredCell);
                PaintCell(CellState.Selected, _im.DragStartCell);
            }
        }
        
        private void OnCellExited(CellPosition pos)
        {
            if (_im.DragStartCell != pos)
                PaintCell(CellState.None, pos);
        }

        private void OnStartDrag(CellPosition pos)
        {
//            PaintCell(CellState.Selected, pos);
        }

        private void OnCellClick(CellPosition pos)
        {
            PaintCell(CellState.Selected, pos);
        }
        private void OnTwoCellClick(CellPosition a, CellPosition b)
        {
            PaintCell(CellState.None, a);
            PaintCell(CellState.None, b);
        }

        public void PaintCell(CellState state, CellPosition cellPos)
        {
            var cell = _gridContainer.GetCellByPos(cellPos);
        
            switch (state)
            {
                case CellState.Hovered:
                    cell.SetSprite(_spriteCellSelected);
                    break;
                case CellState.Selected:
                    cell.SetSprite(_spriteCellActive);
                    break;
                case CellState.None:
                    cell.SetSprite(_spriteCellInactive);
                    break;
            }
        }

        private void OnDeselectCell(CellPosition pos)
        {
            ClearCellPaint();
        }
        private void OnDragUpdate(CellPosition pos)
        {
            PaintCell(CellState.None, pos);
        }

        public void ClearCellPaint()
        {
            foreach (var cellRender in _gridContainer.GetCells())
            {
                cellRender.SetSprite(_spriteCellInactive);
            }
        }
    }
}
