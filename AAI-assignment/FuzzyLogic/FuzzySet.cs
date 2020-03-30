using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.FuzzyLogic
{
    class FuzzySet
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
