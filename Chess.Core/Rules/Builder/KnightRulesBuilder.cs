using Chess.Core.Models.Rules;

namespace Chess.Core.Rules.Builder
{
    public partial class RulesBuilder
    {
        public RulesBuilder WithKnightRules()
        {
            _rules.Add(new KnightMovementRule(_logger));
            return this;
        }
    }
}
