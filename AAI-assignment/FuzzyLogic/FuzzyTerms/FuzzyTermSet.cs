using System;

namespace AAI_assignment.FuzzyLogic.FuzzyTerms
{
    public class FuzzyTermSet : FuzzyTerm
    {
        public FuzzySet FuzzyTerm;
        public string Name;
        public FuzzyTermSet(ref FuzzySet fs, string name) : base()
        {
            FuzzyTerm = fs;
            Name = name;
        }

        public override double GetDom()
        {
            return FuzzyTerm.GetDOM();
        }

        public override void ClearDom()
        {
            FuzzyTerm.ClearDOM();
        }

        public override void SetDom(double val)
        {
            Console.WriteLine(Name);
            Console.WriteLine(FuzzyTerm.GetDOM() + " < " + val);
            if (FuzzyTerm.GetDOM() < val)
                FuzzyTerm.SetDOM(val);
        }

        public string GetName()
        {
            return Name;
        }
    }
}
