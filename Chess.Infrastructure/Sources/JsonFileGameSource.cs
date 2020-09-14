using System.IO;
using Chess.Core.Interfaces;

namespace Chess.Infrastructure.Sources
{
    public class JsonFileGameSource : IGameSource
    {
        public string GetData()
        {
            return File.ReadAllText("game.json");
        }
    }
}