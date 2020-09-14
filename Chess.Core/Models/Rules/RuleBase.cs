using Chess.Core.Interfaces;
using Chess.Core.Models.Pieces;

namespace Chess.Core.Models.Rules
{
    public abstract class RuleBase
    {
        public ILogger Logger { get; set; }

        protected RuleBase(ILogger logger)
        {
            Logger = logger;
        }
        public abstract bool IsMatch(Piece piece);

        public abstract bool ValidateMovement(int[,] board, Piece piece, Movement movement);
    }
}
