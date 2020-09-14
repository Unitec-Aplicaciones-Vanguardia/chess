using Chess.Core.Models;

namespace Chess.Core.Interfaces
{
    public interface IMovementSerializer
    {
        Movement SerializeMovement(string data);
    }
}
