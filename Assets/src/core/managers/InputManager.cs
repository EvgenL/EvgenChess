using src.core.grid;
using UnityEngine;

namespace src.core.managers
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        [SerializeField] private GridContainer gridContainer;

        public CellPosition HoveredCell { get; private set; }
        public CellPosition SelectedCell { get; private set; }
        public CellPosition DragStartCell { get; private set; }
        public bool IsCellSelected { get; private set; }
        public bool IsMouseHeld { get; private set; }
        public bool IsMouseDragging { get; private set; }

        public delegate void GridMouseEvent(CellPosition position);

        public delegate void GridTurnEvent(CellPosition from, CellPosition to);

        public event GridMouseEvent OnMouseEnteredCell;
        public event GridMouseEvent OnMouseExitedCell;
        public event GridMouseEvent OnMouseClickedCell;
        public event GridTurnEvent OnMouseClickedTwoCells;
        public event GridMouseEvent OnMouseStartDrag;
        public event GridMouseEvent OnDeselectCell;
        public event GridTurnEvent OnMouseEndDrag;

        private bool inputEnabled = false;
        private void Awake()
        {
            Instance = this;
        }

        public void EnableInput()
        {
            inputEnabled = true;
        }

        public void DisableInput()
        {
            inputEnabled = false;
        }


        public void OnCellHovered(CellPosition pos)
        {
            if (!inputEnabled) return;
            HoveredCell = pos;
            OnMouseEnteredCell?.Invoke(pos);
        }

        public void OnCellMouseExited(CellPosition pos)
        {
            if (!inputEnabled) return;
            if (IsMouseHeld)
            {
                IsMouseDragging = true;
                OnMouseStartDrag?.Invoke(pos);
            }
            else
            {
                OnMouseExitedCell?.Invoke(pos);
            }
        }

        public void OnCellMouseDown(CellPosition pos)
        {
            if (!inputEnabled) return;
            IsMouseHeld = true;

            DragStartCell = pos;
            OnMouseEnteredCell?.Invoke(pos);
        }

        public void OnCellMouseUp(CellPosition pos) // pos is not used
        {
            if (!inputEnabled) return;
            if (IsMouseDragging)
            {
                if (DragStartCell != HoveredCell)
                    OnMouseEndDrag?.Invoke(DragStartCell, HoveredCell);
                DeselectCell();
            }
            else
            {
                // if doing second click
                if (IsCellSelected)
                {
                    OnMouseClickedCell?.Invoke(HoveredCell);
                    if (SelectedCell != HoveredCell)
                        OnMouseClickedTwoCells?.Invoke(SelectedCell, HoveredCell);
                    DeselectCell();
                }
                else if (!IsCellSelected) // selecting first cell
                {
                    if (SelectedCell == HoveredCell) // clicking same again
                    {
                        DeselectCell();
                    }
                    else
                    {
                        print("Selected cell " + HoveredCell);
                        SelectedCell = HoveredCell;
                        IsCellSelected = true;
                        OnMouseClickedCell?.Invoke(HoveredCell);
                    }
                }
            }

            IsMouseHeld = false;
            IsMouseDragging = false;
        }

        private void DeselectCell()
        {
            if (!inputEnabled) return;
            print("Deselected cell " + HoveredCell);
            IsCellSelected = false;
            SelectedCell = new CellPosition();
            DragStartCell = new CellPosition();
            OnDeselectCell?.Invoke(HoveredCell);
        }
    }
}