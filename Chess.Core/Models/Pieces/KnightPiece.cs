using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;

namespace Chess.Core.Models.Pieces
{
    public class KnightPiece : Piece
    {
        public KnightPiece(PieceType pieceType, ILogger logger, bool isWhitePiece)
            : base(pieceType, logger, isWhitePiece)
        {
        }
    }
}
