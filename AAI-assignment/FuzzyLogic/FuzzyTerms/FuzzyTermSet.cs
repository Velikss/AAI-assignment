using System;

namespace AAI_assignment.FuzzyLogic.FuzzyTerms
{
    class FuzzyTermSet : FuzzyTerm
    {
        public FuzzySet Fts;
        public string Name;
        public FuzzyTermSet(ref FuzzySet fs, string name) : base()
        {
            Fts = fs;
            Name = name;
        }

        public override FuzzyTerm Clone()
        {
            throw new System.NotImplementedException();
        }

        public override double GetDom()
        {
            return Fts.GetDOM();
        }

        public override void ClearDom()
        {
            throw new System.NotImplementedException();
        }

        public override void OrWithDom(double val)
        {
            throw new System.NotImplementedException();
        }

        public override void SetDom(double val)
        {
            Console.WriteLine(Name);
            Console.WriteLine(Fts.GetDOM() + " < " + val);
            if (Fts.GetDOM() < val)
                Fts.SetDOM(val);
        }

        public override string GetName()
        {
            return Name;
        }
    }
}
