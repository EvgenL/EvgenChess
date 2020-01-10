using System;
using System.Collections;
using System.Collections.Generic;
using src.core;
using UnityEngine;

public class CellRenderer : MonoBehaviour
{
    public CellPosition Pos;
    
    public delegate void CellMouseEvent(CellRenderer cellRenderer);
    
    public event CellMouseEvent OnMouseEntered;
    public event CellMouseEvent OnMouseExited;
    public event CellMouseEvent OnMouseDowned;
    public event CellMouseEvent OnMouseUpped;

    private Sprite _normalSprite;
    public SpriteRenderer spriteRenderer { get; private set; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _normalSprite = spriteRenderer.sprite;
    }

    public void SetNormalSprite()
    {
        spriteRenderer.sprite = _normalSprite;
    }
    
    public void SetSprite(Sprite spr)
    {
        spriteRenderer.sprite = spr;
    }

    private void OnMouseEnter()
    {
        OnMouseEntered?.Invoke(this);
    }

    private void OnMouseExit()
    {
        OnMouseExited?.Invoke(this);
    }

    private void OnMouseDown()
    {
        OnMouseDowned?.Invoke(this);
    }
    
    private void OnMouseUp()
    {
        OnMouseUpped?.Invoke(this);
    }
}
