using System;
using System.Collections;
using System.Collections.Generic;
using src.core;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonRules;

    private void Awake()
    {
        _buttonPlay.onClick.AddListener(OnButtonStartClick);
        _buttonRules.onClick.AddListener(OnButtonStartClick);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    private void OnButtonStartClick()
    {
        GameManager.Instance.StartGame();
    }

    private void OnButtonRulesClick()
    {
        
    }
}
