using System;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Pieces;
using Chess.Core.Rules.Builder;
using Chess.Tests.Builders;
using Moq;
using Xunit;

namespace Chess.Tests
{
    public class RuleEngineTests
    {
        [Fact]
        public void ApplyRules_InvalidMovement_Fails()
        {
            var testBuilder = new RuleEngineTestBuilder();
            var engine = testBuilder
                .WithInvalidMovement()
                .WithValidPiece()
                .Build();

            Assert.Throws<ApplicationException>(() => engine.ApplyRules(testBuilder.Board, testBuilder.Piece, testBuilder.Movement));
        }

        [Fact]
        public void ApplyRules_ValidMovement_Fails()
        {
            var testBuilder = new RuleEngineTestBuilder();
            var engine = testBuilder
                .WithValidMovement()
                .WithValidPiece()
                .Build();

            var exception = Record.Exception(() =>
                engine.ApplyRules(testBuilder.Board, testBuilder.Piece, testBuilder.Movement));
            Assert.Null(exception);
        }
    }
}
