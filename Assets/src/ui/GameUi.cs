using System;
using System.Collections;
using System.Collections.Generic;
using src.core;
using src.core.grid;
using src.core.managers;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] private Text _whoseTurn;

    [SerializeField] private Button _buttonGiveUp;
    [SerializeField] private Button _buttonDraw;
    
    [SerializeField] private GameObject _dialog;
    [SerializeField] private Text _dialogText;
    [SerializeField] private Button _buttonYes;
    [SerializeField] private Button _buttonNo;
    
    [SerializeField] private GameObject _sidebar;
    [SerializeField] private GameObject _fullScreenTextContainer;
    [SerializeField] private Text _fullScreenText;
    [SerializeField] private Button _buttonFullScreenText;
    
    [SerializeField] private Text _smallText;


    private void Start()
    {
        _buttonGiveUp.onClick.AddListener(GiveUp);
        _buttonDraw.onClick.AddListener(Draw);
        
        _buttonNo.onClick.AddListener(() => {
            InputManager.Instance.EnableInput();
            _dialog.SetActive(false);
            _sidebar.SetActive(true);
        });
        _buttonFullScreenText.onClick.AddListener(GameManager.Instance.EndGame);
        _buttonFullScreenText.onClick.AddListener(() => _fullScreenTextContainer.SetActive(false));
        _dialog.SetActive(false);
    }

    public void SetTurn(ChessSide side)
    {
        _whoseTurn.text = side.ToString() + "\n<size=15>are doing their turn</size>";
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
        _dialog.SetActive(false);
        _fullScreenTextContainer.SetActive(false);
        _smallText.gameObject.SetActive(false);
        _sidebar.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void GiveUp()
    {
        _buttonYes.onClick.RemoveAllListeners();
        
        ShowDialog(GameManager.Instance.WhoseTurn + " <size=22>wants to give up!</size>\n" +
                   GameManager.Instance.OtherPlayer + ", <size=22>do you accept their defeat?</size>");
        
        _buttonYes.onClick.AddListener(GameManager.Instance.GiveUp);
    }
    
    private void Draw()
    {
        _buttonYes.onClick.RemoveAllListeners();
        
        ShowDialog(GameManager.Instance.WhoseTurn + " <size=22>think it's draw!</size>\n" +
                   GameManager.Instance.OtherPlayer + ", <size=22>do you accept draw?</size>");
        
        _buttonYes.onClick.AddListener(GameManager.Instance.Draw);
    }

    public void ShowWinMessage(ChessSide side)
    {       
        _sidebar.SetActive(false);
        ShowFullscreenText(side + "\n<size=52>won the game!</size>");
    }
    
    public void ShowFullscreenText(string text)
    {
        _fullScreenText.text = text;
        _fullScreenTextContainer.SetActive(true);
        InputManager.Instance.DisableInput();
        _dialog.SetActive(false);
        _sidebar.SetActive(false);
    }

    public void ShowSmallText(string text)
    {
        
    }

    private void ShowDialog(string message)
    {
        _dialogText.text = message;
        _dialog.SetActive(true);
        _sidebar.SetActive(false);
        InputManager.Instance.DisableInput();
    }
}
