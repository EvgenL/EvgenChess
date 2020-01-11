using src.core.figures;

namespace src.core.rules
{
    public interface Rule
    {
        bool CanDoTurn(Turn turn);
        ChessAction[] GetActions(Turn turn);
    }
}