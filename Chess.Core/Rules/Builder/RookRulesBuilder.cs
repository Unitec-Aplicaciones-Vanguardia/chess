using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Models.Rules;

namespace Chess.Core.Rules.Builder
{
    public partial class RulesBuilder
    {
        public RulesBuilder WithRookRules()
        {
            _rules.Add(new RookMovementRule(_logger));
            return this;
        }
    }
}
