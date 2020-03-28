using System;

namespace AAI_assignment.FuzzyLogic.FuzzyTerms
{
    class FuzzyTermAND : FuzzyTerm
    {
        public FuzzySet t1, t2;

        public FuzzyTermAND( ref FuzzySet t1, ref FuzzySet t2)
        {
            this.t1 = t1;
            this.t2 = t2;
        }

        public override FuzzyTerm Clone()
        {
            throw new NotImplementedException();
        }

        public override double GetDom()
        {
            double minDOM = t1.GetDOM();
            if (t2.GetDOM() < minDOM)
                minDOM = t2.GetDOM();
            return minDOM;
        }

        public override void ClearDom()
        {
            t1.ClearDOM();
            t2.ClearDOM();
        }

        public override void OrWithDom(double val)
        {
            t1.ORWithDOM(val);
            t2.ORWithDOM(val);
        }

        public override void SetDom(double val)
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
