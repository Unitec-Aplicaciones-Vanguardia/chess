using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Pieces;

namespace Chess.Core
{
    public class GameEngine : IGameEngine
    {
        private readonly ILogger _logger;
        private readonly PieceFactory _pieceFactory;
        private readonly IRuleEngine _ruleEngine;
        private readonly int[,] _board;

        public GameEngine(
            ILogger logger,
            PieceFactory pieceFactory,
            IRuleEngine ruleEngine)
        {
            _logger = logger;
            _pieceFactory = pieceFactory;
            _ruleEngine = ruleEngine;
            _board = new [,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 }
            };
        }

        public void Start()
        {
            _logger.Log("Starting simulation");
        }

        public void ExecuteMovement(Movement movement)
        {
            try
            {
                _logger.Log("Executing movement on board");
                var piece = _pieceFactory.Create(movement);
                _ruleEngine.ApplyRules(_board, piece, movement);
                piece.Move(_board, movement);
            }
            catch (Exception e)
            {
                _logger.Log(e.Message);
                throw;
            }
        }

        public void Stop()
        {
            _logger.Log("Stopping simulation");
        }
    }
}
