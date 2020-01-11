using System.Collections.Generic;
using src.core.rules.ruleList;

namespace src.core.rules
{
    public class RulesValidator
    {
        private List<Rule> _rules = new List<Rule>();
        public ChessSide WhoseTurn;
        public RulesValidator()
        {
            _rules.Add(new Castelling());
//            _rules.Add(new Promotion());
//            _rules.Add(new TakeByPass());
            _rules.Add(new Pawn());
            _rules.Add(new King());
            _rules.Add(new Rook());
            _rules.Add(new Knight());
            _rules.Add(new Queen());
            _rules.Add(new Bishop());
        }
        
        public Turn ValidateTurn(Turn turn)
        {
            if (turn.board.HasFigure(turn.MovingFrom) 
                && turn.board.GetFigure(turn.MovingFrom).Side != WhoseTurn) return null;
            
            foreach (var rule in _rules)
            {
                if (rule.CanDoTurn(turn))
                {
                    turn.Actions.AddRange(rule.GetActions(turn));
                    return turn;
                }
            }
            return null;
        }
    }
}