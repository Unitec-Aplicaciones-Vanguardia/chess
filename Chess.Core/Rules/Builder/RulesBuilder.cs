using System.Collections.Generic;
using Chess.Core.Interfaces;
using Chess.Core.Models.Rules;

namespace Chess.Core.Rules.Builder
{
    public partial class RulesBuilder
    {
        private readonly ILogger _logger;
        private readonly List<RuleBase> _rules = new List<RuleBase>();

        public RulesBuilder(ILogger logger)
        {
            _logger = logger;
        }

        public IRuleEngine Build()
        {
            _rules.Add(new PawnMovementRule(_logger));
            return new MovementsRuleEngine(_rules);
        }
    }
}
