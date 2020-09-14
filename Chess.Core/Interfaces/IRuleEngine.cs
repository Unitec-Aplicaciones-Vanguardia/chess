using Chess.Core.Models;
using Chess.Core.Models.Pieces;

namespace Chess.Core.Interfaces
{
    public interface IRuleEngine
    {
        void ApplyRules(int [,] board, Piece piece, Movement movement);
    }
}