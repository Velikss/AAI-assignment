using System;

namespace AAI_assignment.FuzzyLogic
{
    public class FuzzySet
    {
        protected double DOM;
        protected double RepresentativeValue;

        public FuzzySet(double RepVal)
        {
            this.DOM = 0.0;
            this.RepresentativeValue = RepVal;
        }

        public virtual double CalculateDOM(double val)
        {
            throw new NotImplementedException();
        }

        public double GetRepresentativeVal()
        {
            return RepresentativeValue;
        }

        public void ClearDOM() => this.DOM = 0.0;

        public double GetDOM() => this.DOM;

        public void SetDOM(double val) => this.DOM = val;

    }
}
