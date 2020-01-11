using src.core.figures;
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
        [SerializeField] private FiguresContainer _figuresContainer;
        
        private Player _whitesPlayer;
        private Player _blacksPlayer;

        private Board _board;
        
        private void Awake()
        {
            Init();
            Instance = this;
            OpenMenu();
        }

        private void Start()
        {
            Debug.LogError("Quickstart");
            StartGame();
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
            _mainMenu.Hide();
            
            _inputManager.EnableInput();
            _cameraController.EnablePlayerControl();
            
            _whitesPlayer = new Player(ChessSide.Whites);
            _blacksPlayer = new Player(ChessSide.Blacks);
            
            _board = new Board(_whitesPlayer, _blacksPlayer);
            _figuresContainer.SetBoard(_board);
        }

        private void DoTurn(CellPosition from, CellPosition to)
        {
            Debug.Log("Doing turn from " + from + " to " + to);
            //validate();
        }
        
    }
}