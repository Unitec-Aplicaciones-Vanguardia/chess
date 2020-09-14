using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Pieces;
using Chess.Core.Models.Rules;

[assembly: InternalsVisibleTo("Chess.Tests")]
namespace Chess.Core.Rules
{
    internal class MovementsRuleEngine : IRuleEngine
    {
        private readonly IEnumerable<RuleBase> _rules;

        public MovementsRuleEngine(IEnumerable<RuleBase> rules)
        {
            _rules = rules;
        }

        public void ApplyRules(int[,] board, Piece piece, Movement movement)
        {
            if (_rules.Where(rule => rule.IsMatch(piece)).Any(rule => !rule.ValidateMovement(board, piece, movement)))
            {
                throw new ApplicationException(
                    $"Invalid movement {piece.PieceType}{movement.OriginalXPosition}{movement.OriginalYPosition}-{movement.NewXPosition}{movement.NewYPosition}");
            }
        }
    }
}
