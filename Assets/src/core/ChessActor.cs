using System;

namespace src.core
{
    public abstract class ChessActorBase
    {
        public readonly ChessSide Side;
        
        public event Action OnTurn;
        public event Action OnGiveUp;
        public event Action OnOfferDraw;
        public event Action OnAcceptDraw;

        public ChessActorBase(ChessSide side)
        {
            this.Side = side;
        }

        public void OnMyTurn()
        {
            
        }

        /// <summary>
        /// Turn ends if
        /// 1. player made their turn
        /// 2. player's turn expired
        /// </summary>
        public void OnEndTurn()
        {
            
        }
        
        public void MakeTurn(string cellFrom, string cellTo)
        {
            
        }

        public void GiveUp()
        {
            
        }

        public void OfferDraw()
        {
            
        }

        public void AcceptDraw()
        {
            
        }
    }
}