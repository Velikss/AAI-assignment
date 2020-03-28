using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAI_assignment.FuzzyLogic.FuzzySets;
using AAI_assignment.FuzzyLogic.FuzzyTerms;

namespace AAI_assignment.FuzzyLogic
{
    using MemberSets = System.Collections.Generic.Dictionary<string, FuzzySet>;
    class FuzzyVariable
    {
        public MemberSets _memberSets = new MemberSets();
        public double MinRange, MaxRange;

        public FuzzyVariable()
        {
            this.MinRange = 0.0;
            this.MaxRange = 0.0;
        }

        public FuzzySet AddLeftShoulderSet(string name, double minBound, double peak, double maxBound)
        {
            //throw new NotImplementedException();
            FuzzyLeftShoulder fls = new FuzzyLeftShoulder(peak, minBound, maxBound);
            _memberSets.Add(name, fls);
            return fls;
        }

        public FuzzySet AddRightShoulderSet(string name, double minBound, double peak, double maxBound)
        {
            //throw new NotImplementedException();
            FuzzyRightShoulder frs = new FuzzyRightShoulder(peak, minBound, maxBound);
            _memberSets.Add(name, frs);
            return frs;
        }

        public FuzzySet AddTriangularSet(string name, double minBound, double peak, double maxBound)
        {
            //throw new NotImplementedException();
            FuzzyTriangle ft = new FuzzyTriangle(peak, minBound, maxBound);
            _memberSets.Add(name, ft);
            return ft;
        }

        public FuzzySet AddSingletonSet(string name, double minBound, double peak, double maxBound)
        {
            throw new NotImplementedException();
        }

        public void Fuzzify(double val)
        {
            foreach (KeyValuePair<string, FuzzySet> entry in _memberSets)
            {
                entry.Value.SetDOM(entry.Value.CalculateDOM(val));
                Console.WriteLine(entry.Key + ": " + entry.Value.CalculateDOM(val));
            }
        }

        public void ClearAllDOMValues()
        {
            foreach (KeyValuePair<string, FuzzySet> entry in _memberSets)
                entry.Value.ClearDOM();
        }

        public double DeFuzzifyMaxAv()
        {
            double value = 0.0;
            double divider = 0.0;
            foreach (KeyValuePair<string, FuzzySet> entry in _memberSets)
            {
                Console.WriteLine("value = " + entry.Value.GetDOM() + "*" + entry.Value.GetRepresentativeVal());
                Console.WriteLine("divider = " + entry.Value.GetDOM());
                value += entry.Value.GetDOM() * entry.Value.GetRepresentativeVal();
                divider += entry.Value.GetDOM();
            }

            return value / divider;
        }

        public double DeFuzzifyCentroid(int numSamples)
        {
            throw new NotImplementedException();
        }

        public void AdjustRangeToFit(double min, double max)
        {
            throw new NotImplementedException();
        }


    }
}
