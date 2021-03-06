﻿using System.Collections.Generic;
using src.core.managers;
using src.renderer;
using UnityEngine;

namespace src.core.grid
{
    public class GridContainer : MonoBehaviour
    {
        private CellRenderer[] _cellRenders;
        private Dictionary<CellPosition, CellRenderer> _cellRendersByPos
            = new Dictionary<CellPosition, CellRenderer>();

        public Vector3 CellPosToWord(CellPosition pos)
        {
            return _cellRendersByPos[pos].transform.position;
        }

        public CellRenderer GetCellByPos(CellPosition pos)
        {
            return _cellRendersByPos[pos];
        }
        public CellRenderer[] GetCells()
        {
            return _cellRenders;
        }

        private void Awake()
        {
            _cellRenders = new CellRenderer[StaticParameters.BOARD_SIZE * StaticParameters.BOARD_SIZE];
        
            for (int row = 0; row < StaticParameters.BOARD_SIZE; row++)
            {
                var rowContainer = transform.GetChild(row);
                for (int col = 0; col < StaticParameters.BOARD_SIZE; col++)
                {
                    var cell = rowContainer.GetChild(col).GetComponent<CellRenderer>();
                    cell.Pos = new CellPosition(row+1, col+1);
                    cell.OnMouseEntered += OnCellHovered;
                    cell.OnMouseExited += OnCellMouseExited;
                    cell.OnMouseDowned += OnCellMouseDown;
                    cell.OnMouseUpped += OnCellMouseUp;
                    _cellRenders[(row * StaticParameters.BOARD_SIZE) + col] = cell;
                    _cellRendersByPos[cell.Pos] = cell;
                }
            }
        
        }

        private void OnCellHovered(CellRenderer cellRenderer)
        {
            InputManager.Instance.OnCellHovered(cellRenderer.Pos);
        }

        private void OnCellMouseExited(CellRenderer cellRenderer)
        {
            InputManager.Instance.OnCellMouseExited(cellRenderer.Pos);
        }
        private void OnCellMouseDown(CellRenderer cellRenderer)
        {
            InputManager.Instance.OnCellMouseDown(cellRenderer.Pos);
        }
        private void OnCellMouseUp(CellRenderer cellRenderer)
        {
            InputManager.Instance.OnCellMouseUp(cellRenderer.Pos);
        }
    }
}
