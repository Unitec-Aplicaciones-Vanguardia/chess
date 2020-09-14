using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Pieces;
using Chess.Core.Models.Rules;
using Moq;

namespace Chess.Tests.Builders
{
    public class RulesTestBuilder
    {
        private ILogger _logger;
        private RuleBase _rule;
        public int[,] Board;
        public Piece Piece;
        public Movement Movement;

        public RulesTestBuilder()
        {
            Board = new[,]
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

        public RulesTestBuilder WithPawnRule()
        {
            CreateLogger();
            _rule = new PawnMovementRule(_logger);
            return this;
        }

        public RulesTestBuilder WithPawnPiece()
        {
            CreateLogger();
            Piece = new PawnPiece(PieceType.P, _logger, true);
            return this;
        }

        public RulesTestBuilder WithMovement(Movement movement)
        {
            CreateLogger();
            Movement = movement;
            return this;
        }

        public RuleBase Build()
        {
            return _rule;
        }

        private void CreateLogger()
        {
            var logMock = new Mock<ILogger>();
            logMock.Setup(l => l.Log(It.IsAny<string>()));
            _logger ??= logMock.Object;
        }
    }
}
