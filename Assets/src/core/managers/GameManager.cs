using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace src.core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private GridContainer _gridContainer;
        [SerializeField] private InputManager _inputManager;
        
        private Player WhitesPlayer;
        private Player BlacksPlayer;
        
        private void Awake()
        {
            Init();
            Instance = this;
            OpenMenu();
        }

        private void Init()
        {
            _inputManager.DisableInput();

            _inputManager.OnMouseEndDrag += DoTurn;
            _inputManager.OnMouseClickedTwoCells += DoTurn;
        }
        
        public void OpenMenu()
        {
            _mainMenu.Show(); 
        }

        public void StartGame()
        {
            _inputManager.EnableInput();
            _cameraController.EnablePlayerControl();
            
            WhitesPlayer = new Player(ChessSide.Whites);
            BlacksPlayer = new Player(ChessSide.Blacks);
        }

        private void DoTurn(CellPosition from, CellPosition to)
        {
            Debug.Log("Doing turn from " + from + " to " + to);
            //validate();
        }
        
    }
}