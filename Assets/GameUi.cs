using System;
using System.Collections;
using System.Collections.Generic;
using src.core;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] private Text _whoseTurn;

    [SerializeField] private Button _buttonGiveUp;
    [SerializeField] private Button _buttonDraw;
    
    [SerializeField] private Transform _dialog;
    [SerializeField] private Text _dialogText;

    private void Awake()
    {
        _buttonGiveUp.onClick.AddListener(GiveUp);
        _buttonDraw.onClick.AddListener(Draw);
    }

    public void SetTurn(ChessSide side)
    {
        _whoseTurn.text = side.ToString() + "\n<size=15>are doing their turn</size>";
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void GiveUp()
    {
        
    }
    
    private void Draw()
    {
        
    }
}
