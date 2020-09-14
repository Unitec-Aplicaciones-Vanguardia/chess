using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Pieces;
using Chess.Core.Models.Rules;
using Chess.Core.Rules;
using Chess.Core.Rules.Builder;
using Moq;

namespace Chess.Tests.Builders
{
    public class RuleEngineTestBuilder
    {
        private IEnumerable<RuleBase> _rules;
        private ILogger _logger;
        public int[,] Board;
        public Piece Piece;
        public Movement Movement;

        public RuleEngineTestBuilder()
        {
            _rules = new List<RuleBase>();
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

        public RuleEngineTestBuilder WithInvalidMovement()
        {
            CreateLogger();
            CreateRules(false);
            return this;
        }

        public RuleEngineTestBuilder WithValidMovement()
        {
            CreateLogger();
            CreateRules(true);
            return this;
        }

        public RuleEngineTestBuilder WithValidPiece()
        {
            CreateLogger();
            Piece = new PawnPiece(PieceType.P, _logger, true);
            return this;
        }

        public IRuleEngine Build()
        {
            return new MovementsRuleEngine(_rules);
        }

        private void CreateRules(bool expectedValidationResult)
        {
            Movement = new Movement();
            var ruleMock = new Mock<PawnMovementRule>(_logger);
            ruleMock.Setup(r => r.ValidateMovement(It.IsAny<int[,]>(), It.IsAny<Piece>(), It.IsAny<Movement>()))
                .Returns(expectedValidationResult);
            ruleMock.Setup(r => r.IsMatch(It.IsAny<Piece>()))
                .Returns(true);
            _rules = new[] { ruleMock.Object };
        }

        private void CreateLogger()
        {
            var logMock = new Mock<ILogger>();
            logMock.Setup(l => l.Log(It.IsAny<string>()));
            _logger ??= logMock.Object;
        }
    }
}
