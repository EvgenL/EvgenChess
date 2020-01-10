using System;
using System.Collections;
using System.Collections.Generic;
using src.core;
using UnityEngine;

public class CellsContainer : MonoBehaviour
{
    [SerializeField] private Sprite _spriteCellActive;
    [SerializeField] private Sprite _spriteCellHovered;
    
    private CellRenderer[,] _cellRenders;

    private CellRenderer _hoveredCell;
    private CellRenderer _selectedCell;
    private bool _isCellSelected = false;

    private void Awake()
    {
        _cellRenders = new CellRenderer[StaticParameters.BOARD_SIZE, StaticParameters.BOARD_SIZE];
        
        for (int row = 0; row < StaticParameters.BOARD_SIZE; row++)
        {
            var rowContainer = transform.GetChild(row);
            
            for (int col = 0; col < StaticParameters.BOARD_SIZE; col++)
            {
                var cell = rowContainer.GetChild(col).GetComponent<CellRenderer>();
                cell.OnMouseEntered += OnCellHovered;
                cell.OnMouseExited += OnCellMouseExited;
                cell.OnMouseDowned += OnCellClicked;
                _cellRenders[row, col] = cell;
            }
        }
        
    }

    public void OnCellHovered(CellRenderer cellRenderer)
    {
        cellRenderer.SetSprite(_spriteCellHovered);
        _hoveredCell = cellRenderer;
    }

    public void OnCellMouseExited(CellRenderer cellRenderer)
    {
        cellRenderer.SetNormalSprite();
    }
    public void OnCellClicked(CellRenderer cellRenderer)
    {
        cellRenderer.SetSprite(_spriteCellActive);
    }

    private CellPosition getCellPositionByRenderer(CellRenderer cellRenderer)
    {
        for (int row = 0; row < StaticParameters.BOARD_SIZE; row++)
        {
            for (int col = 0; col < StaticParameters.BOARD_SIZE; col++)
            {
                if (_cellRenders[row, col] == cellRenderer)
                {
                    throw new NotImplementedException();
                }
            }
        }
        throw new NotImplementedException();
    }
}
