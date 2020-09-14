using Chess.Core.Interfaces;

namespace Chess.Core.Models.Pieces
{
    public abstract class Piece
    {
        public readonly PieceType PieceType;
        private readonly ILogger _logger;
        public bool IsWhitePiece;

        protected Piece(PieceType pieceType, ILogger logger, bool isWhitePiece)
        {
            PieceType = pieceType;
            _logger = logger;
            IsWhitePiece = isWhitePiece;
        }

        public virtual void Move(int[,] board, Movement movement)
        {
            _logger.Log(
                $"Moving piece {PieceType} from {movement.OriginalXPosition}{movement.OriginalYPosition + 1} to {movement.NewXPosition}{movement.NewYPosition + 1}");
            board[(int) movement.NewXPosition, movement.NewYPosition] = 1;
        }
    }
}
