using System.Collections.Generic;
using System.Linq;

namespace CommerceProject.Model.Refactored
{
    /* This class is implamenting main part of the strategy pattern
    Plase take a look to this video https://www.youtube.com/watch?v=-NCgRD9-C6o */
    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<IPriceRule> _pricingRules;

        public PricingCalculator()
        {
            _pricingRules = new List<IPriceRule>();
            _pricingRules.Add(new EachPriceRule());
            _pricingRules.Add(new PerGramPriceRule());
            _pricingRules.Add(new SpecialPriceRule());
            _pricingRules.Add(new Buy4GetOneFree());
        }

        public decimal CalculatePrice(OrderItem item)
        {
            return _pricingRules.First(r => r.IsMatch(item)).CalculatePrice(item);
        }
    }
}