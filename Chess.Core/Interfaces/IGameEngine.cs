using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Models;

namespace Chess.Core.Interfaces
{
    public interface IGameEngine
    {
        void Start();

        void ExecuteMovement(Movement movement);

        void Stop();
    }
}
