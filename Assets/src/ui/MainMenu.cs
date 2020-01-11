using src.core.managers;
using UnityEngine;
using UnityEngine.UI;

namespace src.ui
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _buttonPlay;
        [SerializeField] private Button _buttonRules;
        [SerializeField] private GameObject _menu;
        [SerializeField] private GameObject _help;
        [SerializeField] private Button _helpButton;

        

        private void Awake()
        {
            _buttonPlay.onClick.AddListener(OnButtonStartClick);
            _buttonRules.onClick.AddListener(OnHelpClick);
            _helpButton.onClick.AddListener(HideHelp);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _menu.SetActive(true);
            _help.SetActive(false);
        }


        public void Hide()
        {
            gameObject.SetActive(false);
        }
    
        private void OnButtonStartClick()
        {
            GameManager.Instance.StartGame();
        }

        private void OnHelpClick()
        {
            _menu.SetActive(false);
            _help.SetActive(true);
        }
        private void HideHelp()
        {
            _menu.SetActive(true);
            _help.SetActive(false);
        }
    }
}
