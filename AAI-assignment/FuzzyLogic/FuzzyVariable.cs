using System;
using System.Collections.Generic;
using AAI_assignment.FuzzyLogic.FuzzySets;

namespace AAI_assignment.FuzzyLogic
{
    using MemberSets = System.Collections.Generic.Dictionary<string, FuzzySet>;
    public class FuzzyVariable
    {
        public MemberSets _memberSets = new MemberSets();
        public double MinRange, MaxRange;

        public FuzzyVariable(double minRange, double maxRange)
        {
            this.MinRange = minRange;
            this.MaxRange = maxRange;
        }

        public FuzzySet AddLeftShoulderSet(string name, double minBound, double peak, double maxBound)
        {
            if(!InRange(minBound, maxBound))
                throw new FuzzySetOutOfRangeException("FuzzySet min or max value is out of range");
            FuzzyLeftShoulder fls = new FuzzyLeftShoulder(peak, minBound, maxBound);
            _memberSets.Add(name, fls);
            return fls;
        }

        public FuzzySet AddRightShoulderSet(string name, double minBound, double peak, double maxBound)
        {
            if (!InRange(minBound, maxBound))
                throw new FuzzySetOutOfRangeException("FuzzySet min or max value is out of range");
            FuzzyRightShoulder frs = new FuzzyRightShoulder(peak, minBound, maxBound);
            _memberSets.Add(name, frs);
            return frs;
        }

        public FuzzySet AddTriangularSet(string name, double minBound, double peak, double maxBound)
        {
            if (!InRange(minBound, maxBound))
                throw new FuzzySetOutOfRangeException("FuzzySet min or max value is out of range");
            FuzzyTriangle ft = new FuzzyTriangle(peak, minBound, maxBound);
            _memberSets.Add(name, ft);
            return ft;
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

            if (divider == 0.0 || value == 0.0)
                return 0.0;

            return value / divider;
        }

        public double DeFuzzifyCentroid(int numSamples)
        {
            throw new NotImplementedException();
        }

        public bool InRange(double min, double max)
        {
            if (min >= MinRange && max <= MaxRange)
                return true;
            return false;
        }

    }

    public class FuzzySetOutOfRangeException : Exception
    {
        public FuzzySetOutOfRangeException() { }

        public FuzzySetOutOfRangeException(string message)
            : base(message) { }
    }
}
