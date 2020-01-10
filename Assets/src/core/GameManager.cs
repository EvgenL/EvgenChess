using UnityEngine;

namespace src.core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private CameraController _cameraController;
        
        private Player WhitesPlayer;
        private Player BlacksPlayer;
        
        private void Awake()
        {
            Instance = this;
            OpenMenu();
        }

        public void OpenMenu()
        {
            _mainMenu.Show(); 
        }

        public void StartGame()
        {
            _cameraController.EnablePlayerControl();
            
            WhitesPlayer = new Player(ChessSide.Whites);
            BlacksPlayer = new Player(ChessSide.Blacks);
        }

        public void OnCellClicked(CellPosition pos)
        {
            
        }

    }
}