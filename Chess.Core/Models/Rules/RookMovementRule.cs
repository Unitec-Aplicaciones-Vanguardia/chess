using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models.Pieces;

namespace Chess.Core.Models.Rules
{
    public class RookMovementRule : RuleBase
    {
        public RookMovementRule(ILogger logger) : base(logger)
        {
        }

        public override bool IsMatch(Piece piece)
        {
            return piece.PieceType == PieceType.T;
        }

        public override bool ValidateMovement(int[,] board, Piece piece, Movement movement)
        {
            return true;
        }
    }
}
