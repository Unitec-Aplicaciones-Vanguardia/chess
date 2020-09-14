using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;

namespace Chess.Core.Models.Pieces
{
    public class RookPiece : Piece
    {
        public RookPiece(PieceType pieceType, ILogger logger, bool isWhitePiece) 
            : base(pieceType, logger, isWhitePiece)
        {
        }
    }
}
