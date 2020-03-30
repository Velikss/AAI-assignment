
using System;
using System.CodeDom;
using System.Collections.Generic;
using AAI_assignment.FuzzyLogic.FuzzyTerms;

namespace AAI_assignment.FuzzyLogic
{
    using VarMap = System.Collections.Generic.Dictionary<string, FuzzyVariable>;
    public class FuzzyModule
    {
        public enum DefuzzifyType
        {
            max_av, centroid
        }

        public const int NumSampleToUseForCentroid = 15;

        private VarMap map = new VarMap();
        private List<FuzzyRule> _rule;

        public FuzzyModule()
        {
            map = new VarMap();
            _rule = new List<FuzzyRule>();
        }

        public FuzzyVariable CreateFLV(string varName, double minRange, double maxRange)
        {
            FuzzyVariable v = new FuzzyVariable(minRange, maxRange);
            map.Add(varName, v);
            return v;
        }

        public void AddRule(FuzzyTerm antecedent, FuzzyTerm consequent)
        {
            _rule.Add(new FuzzyRule(antecedent, consequent));
        }

        public void Fuzzify(string key, double val)
        {
            map[key].Fuzzify(val);
        }

        public double DeFuzzify(string key, DefuzzifyType method)
        {
            // clear the DOMs of all consequents
            map[key].ClearAllDOMValues();

            // process the rules
            foreach (FuzzyRule rule in _rule)
            {
                rule.Calculate();
            }

            switch (method)
            {
                case DefuzzifyType.max_av:
                    return map[key].DeFuzzifyMaxAv();
                case DefuzzifyType.centroid:
                    return map[key].DeFuzzifyCentroid(10);
                default:
                    return 0.0; // NotImplementedException();
            }
        }

        public double CalculateDesirabilityTest(double dist, double ammo)
        {
            //fuzzify the inputs
            this.Fuzzify("DistToTarget", dist);
            this.Fuzzify("AmmoStatus", ammo);


            //this method automatically processes the rules and defuzzifies the inferred conclusion
            return this.DeFuzzify("Desirability", DefuzzifyType.max_av);
        }

        public double CalculateDesirability(double dist, double health)
        {
            //fuzzify the inputs
            this.Fuzzify("DistToTarget", dist);
            this.Fuzzify("HealthStatus", health);


            //this method automatically processes the rules and defuzzifies the inferred conclusion
            return this.DeFuzzify("Desirability", DefuzzifyType.max_av);
        }
    }
}
