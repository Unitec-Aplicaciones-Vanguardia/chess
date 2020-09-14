using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models.Pieces;

namespace Chess.Core.Models.Rules
{
    public class KnightMovementRule : RuleBase
    {
        public override bool IsMatch(Piece piece)
        {
            return piece.PieceType == PieceType.C;
        }

        public override bool ValidateMovement(int[,] board, Piece piece, Movement movement)
        {
            if (board[(int)movement.NewXPosition, movement.NewYPosition] != 0)
            {
                Logger.Log($"Invalid movement, there is a piece in {movement.NewXPosition}{movement.NewYPosition}");
            }
            var validMovements = new List<(int, int)>
            {
                (1, 2),
                (1, -2),
                (2, 1),
                (2, -1),
                (-1, -2),
                (-1, 2),
                (-2, -1),
                (-2, 1)
            };

            return validMovements.Any(c =>
                (int) movement.OriginalXPosition + c.Item1 == (int) movement.NewXPosition &&
                movement.OriginalYPosition + c.Item2 == movement.NewYPosition);
        }

        public KnightMovementRule(ILogger logger) 
            : base(logger)
        {
        }
    }
}
