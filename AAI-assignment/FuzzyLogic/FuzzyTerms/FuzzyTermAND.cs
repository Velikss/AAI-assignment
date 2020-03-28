using System;

namespace AAI_assignment.FuzzyLogic.FuzzyTerms
{
    class FuzzyTermAND : FuzzyTerm
    {
        public FuzzySet t1, t2;

        public FuzzyTermAND(FuzzySet t1, FuzzySet t2)
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
            double minDOM = 0.0;
            if (t1.GetDOM() < minDOM)
                minDOM = t1.GetDOM();
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
    }
}
