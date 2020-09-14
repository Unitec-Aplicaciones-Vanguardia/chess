using System;
using Chess.Core;
using Chess.Core.Models.Pieces;
using Chess.Core.Models.Rules;
using Chess.Infrastructure.Loggers;
using Chess.Infrastructure.Serializers;
using Chess.Infrastructure.Sources;
using Newtonsoft.Json.Linq;
using RulesBuilder = Chess.Core.Rules.Builder.RulesBuilder;

namespace Chess.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContent = new JsonFileGameSource().GetData();
            var arrayOfMovements = JArray.Parse(fileContent);
            var gameSerializer = new JsonFileGameSerializer();
            var logger = new FileLogger();
            var ruleEngine = new RulesBuilder(logger).WithKnightRules().WithRookRules().Build();
            var gameEngine = new GameEngine(logger, new PieceFactory(logger), ruleEngine);
            gameEngine.Start();
            foreach (var movementData in arrayOfMovements)
            {
                var movement = gameSerializer.SerializeMovement(movementData.ToString());
                gameEngine.ExecuteMovement(movement);
            }
            gameEngine.Stop();
        }
    }
}
