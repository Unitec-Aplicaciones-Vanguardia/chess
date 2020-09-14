using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models.Pieces;

namespace Chess.Core.Models.Rules
{
    public class PawnMovementRule : RuleBase
    {
        public override bool IsMatch(Piece piece)
        {
            return piece.PieceType == PieceType.P;
        }

        public override bool ValidateMovement(int[,] board, Piece piece, Movement movement)
        {
            if (board[(int)movement.NewXPosition, movement.NewYPosition] != 0)
            {
                Logger.Log($"Invalid movement, there is a piece in {movement.NewXPosition}{movement.NewYPosition}");
                return false;
            }
            var validXPositionAfterMove = (int)movement.OriginalXPosition;
            var validYPositionsAfterMove =
                GetWhiteValidResults(piece, movement).Union(GetBlackValidResults(piece, movement));
            return validXPositionAfterMove == (int) movement.NewXPosition &&
                   validYPositionsAfterMove.Contains(movement.NewYPosition);

        }

        private static IEnumerable<int> GetBlackValidResults(Piece piece, Movement movement)
        {
            var validResults = new List<int>();
            if (piece.IsWhitePiece)
            {
                return Enumerable.Empty<int>();
            }

            if (movement.OriginalYPosition == 6)
            {
                validResults.Add(5);
                validResults.Add(4);
            }
            validResults.Add(++movement.OriginalYPosition);
            return validResults;
        }

        private static IEnumerable<int> GetWhiteValidResults(Piece piece, Movement movement)
        {
            var validResults = new List<int>();
            if (!piece.IsWhitePiece)
            {
                return Enumerable.Empty<int>();
            }

            if (movement.OriginalYPosition == 1)
            {
                validResults.Add(2);
                validResults.Add(3);
            }
            validResults.Add(++movement.OriginalYPosition);
            return validResults;
        }

        public PawnMovementRule(ILogger logger) 
            : base(logger)
        {
        }
    }
}
