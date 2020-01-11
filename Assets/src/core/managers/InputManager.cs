using src.core.grid;
using UnityEngine;

namespace src.core.managers
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;
        
        [SerializeField] private GridContainer _gridContainer;

        private CellPosition _hoveredCell;
        private CellPosition _selectedCell;
        private CellPosition _dragStartCell;
        private bool _isCellSelected = false;
        private bool _isMouseHeld = false;
        private bool _isMouseDragging = false;

        public delegate void GridMouseEvent(CellPosition position);
        public delegate void GridTurnEvent(CellPosition from, CellPosition to);
        public event GridMouseEvent OnMouseEnteredCell;
        public event GridMouseEvent OnMouseExitedCell;
        public event GridMouseEvent OnMouseClickedCell;
        public event GridTurnEvent OnMouseClickedTwoCells;
        public event GridMouseEvent OnMouseStartDrag;
        public event GridMouseEvent OnMouseUpdateDrag;
        public event GridTurnEvent OnMouseEndDrag;
        
        public bool InputEnabled = false;

        private void Awake()
        {
            Instance = this;
        }

        public void EnableInput()
        {
            InputEnabled = true;
        }

        public void DisableInput()
        {
            InputEnabled = false;
        }


        public void OnCellHovered(CellPosition pos)
        {
            _hoveredCell = pos;
            OnMouseEnteredCell?.Invoke(pos);
        }

        public void OnCellMouseExited(CellPosition pos)
        {
            if (_isMouseHeld)
            {
                _isMouseDragging = true;
                OnMouseStartDrag?.Invoke(pos);
            }
            else
            {
                OnMouseExitedCell?.Invoke(pos);
            }
        }
        public void OnCellMouseDown(CellPosition pos)
        {
            _isMouseHeld = true;
            
            _dragStartCell = pos;
            OnMouseEnteredCell?.Invoke(pos);
        }
        public void OnCellMouseUp(CellPosition pos) // pos is not used
        {
             
            if (_isMouseDragging)
            {
                OnMouseEndDrag?.Invoke(_dragStartCell, _hoveredCell);
                DeselectCell();
            }
            else if (_hoveredCell == _dragStartCell)
            {
                // if doing second click
                if (_isCellSelected && _selectedCell != _hoveredCell)
                {
                    OnMouseClickedCell?.Invoke(_hoveredCell);
                    OnMouseClickedTwoCells?.Invoke(_selectedCell, _hoveredCell);
                    DeselectCell();
                }
                else // selecting first cell
                {
                    if (_selectedCell == _hoveredCell) // clicking same again
                    {
                        DeselectCell();
                    }
                    else
                    {
                        print("Selected cell " + _hoveredCell);
                        OnMouseClickedCell?.Invoke(_hoveredCell);
                        _selectedCell = _hoveredCell;
                        _isCellSelected = true;
                    }
                }
            }
            _isMouseHeld = false;
            _isMouseDragging = false;
        }

        private void DeselectCell()
        {
            print("Deselected cell " + _hoveredCell);
            _isCellSelected = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && _hoveredCell == null)
            {
                DeselectCell();
            }
        }
    }
}