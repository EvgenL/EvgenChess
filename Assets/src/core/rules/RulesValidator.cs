using System.Collections.Generic;
using src.core.rules.ruleList;

namespace src.core.rules
{
    public class RulesValidator
    {
        private List<Rule> _rules = new List<Rule>();
        
        public RulesValidator()
        {
            // add new Castelling
            _rules.Add(new Pawn());
            _rules.Add(new King());
            _rules.Add(new Rook());
            _rules.Add(new Knight());
        }
        
        public Turn ValidateTurn(Turn turn)
        {
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