using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellRenderer : MonoBehaviour
{
    public delegate void CellMouseEvent(CellRenderer cellRenderer);
    
    public event CellMouseEvent OnMouseEntered;
    public event CellMouseEvent OnMouseExited;
    public event CellMouseEvent OnMouseDowned;

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
        OnMouseEntered(this);
    }

    private void OnMouseExit()
    {
        OnMouseExited(this);
    }

    private void OnMouseDown()
    {
        OnMouseDowned(this);
    }
}
