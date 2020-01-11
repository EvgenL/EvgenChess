using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private GameUi _gameUi;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private FiguresContainer _figuresContainer;
        [SerializeField] private AudionManager _audionManager;

        public ChessSide WhoseTurn { get; private set; }
        public ChessSide OtherPlayer => (ChessSide)((int)(WhoseTurn + 1) % 2);

        private Board _board;
        private RulesValidator _validator;
        
        private Queue<Turn> _turnsHistory = new Queue<Turn>();
        
        private void Awake()
        {
            Init();
            Instance = this;
            OpenMenu();
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
            _gameUi.Hide();
        }

        public void StartGame()
        {
            _mainMenu.Hide();
            _gameUi.Show();
            SetTurn(ChessSide.Whites);
            
            _inputManager.EnableInput();
            _cameraController.EnablePlayerControl();
            
            _turnsHistory = new Queue<Turn>();
            
            _board = new Board(_figuresContainer);
        }

        public void EndGame()
        {
            _inputManager.DisableInput();
            OpenMenu();
        }

        public void GiveUp()
        {
            _gameUi.ShowWinMessage(OtherPlayer);
        }

        public void Draw()
        {
            _gameUi.ShowFullscreenText("Draw!");
        }

        public bool CellCanBeSelected(CellPosition pos)
        {
            Figure fig = _board.GetFigure(pos);
            return fig == null || fig.Side == WhoseTurn;
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
                SetTurn(OtherPlayer);
                PlaySounds(turn);
            }
            else
            {
                // todo ui cancel turn
                _audionManager.PlayNo();
            }
        }

        private void SetTurn(ChessSide whoseTurn)
        {
            WhoseTurn = whoseTurn;
            _validator.WhoseTurn = WhoseTurn;
            _gameUi.SetTurn(WhoseTurn);
        }

        private void PlaySounds(Turn turn)
        {
            var actions = turn.Actions;
            if (actions.Count > 0)
            {
                var action = actions.OrderByDescending(i => i.SortingPower).First();

                if (action is TakeAction)
                {
                    _audionManager.PlayTake();
                }
                else 
                {
                    _audionManager.PlayBonk();
                }
            }

        }
        
    }
}