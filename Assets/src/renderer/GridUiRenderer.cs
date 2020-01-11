using src.core.grid;
using src.core.managers;
using UnityEngine;

namespace src.renderer
{
    public class GridUiRenderer : MonoBehaviour
    {
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
        
            _gridContainer.ClearCellPaint();
        }
        public void Disable()
        {
            _im.OnMouseEnteredCell -= OnCellEntered;
            _im.OnMouseExitedCell -= OnCellExited;
        
            _gridContainer.ClearCellPaint();
        }

        private void OnCellEntered(CellPosition pos)
        {
            _gridContainer.PaintCell(GridContainer.CellState.Hovered, pos);
        }
        
        private void OnCellExited(CellPosition pos)
        {
            _gridContainer.PaintCell(GridContainer.CellState.None, pos);
        }
    }
}
