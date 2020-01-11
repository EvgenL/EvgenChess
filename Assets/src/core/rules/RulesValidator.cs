using System.Collections.Generic;
using src.core.figures;
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
            turn.TurnValid = ActionsValid(turn);

            // check king
            var tempBoard = turn.board.Copy();
            tempBoard.ApplyTurn(turn);
            var attacker = KingUnderAttack(tempBoard);
            if (attacker != null)
            {
                turn.KingAttackedBy = attacker;
                turn.TurnValid = false;
            }
            
            
            return turn;
        }
        
        

        private Figure KingUnderAttack(Board board)
        {
            var enemies = board.GetEnemies(WhoseTurn);
            var king = board.GetKing(WhoseTurn);
            
            foreach (var enemy in enemies)
            {
                Turn possibleLethalTurn = Turn.NoValidate(board, enemy.CurrentPos, king.CurrentPos);
                if (ActionsValid(possibleLethalTurn))
                {
                    return enemy;
                }
            }

            return null;
        }

        private bool ActionsValid(Turn turn)
        {
            foreach (var rule in _rules)
            {
                if (rule.CanDoTurn(turn))
                {
                    turn.Actions.AddRange(rule.GetActions(turn));
                    return true;
                }
            }

            return false;
        }
    }
}