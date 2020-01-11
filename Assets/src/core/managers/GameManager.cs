using System.Collections.Generic;
using src.core.figures;
using src.core.grid;
using src.core.rules;
using src.input;
using src.ui;
using UnityEngine;

namespace src.core.managers
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
        private RulesValidator _validator;
        
        private Queue<Turn> _turnsHistory = new Queue<Turn>();
        
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
            _validator = new RulesValidator();
            _inputManager.DisableInput();

            _inputManager.OnMouseEndDrag += TryDoTurn;
            _inputManager.OnMouseClickedTwoCells += TryDoTurn;
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
            
            _turnsHistory = new Queue<Turn>();
            
            _whitesPlayer = new Player(ChessSide.Whites);
            _blacksPlayer = new Player(ChessSide.Blacks);
            
            _board = new Board(_whitesPlayer, _blacksPlayer, _figuresContainer);
            _figuresContainer.SetBoard(_board);
        }

        private void TryDoTurn(CellPosition from, CellPosition to)
        {
            Debug.Log("TryDoTurn from " + from + " to " + to);
            Turn turn = Turn.CreateIfPossible(_validator, _board, from, to);
            
            if (turn != null)
            {
                Debug.Log("Doing turn from " + from + " to " + to);
                _turnsHistory.Enqueue(turn);
                _board.ApplyTurn(turn);
            }
            else
            {
                // ui cancel turn
            }
        }
        
    }
}