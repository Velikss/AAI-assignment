using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.FuzzyLogic.FuzzySets
{
    class FuzzyRightShoulder : FuzzySet
    {
        private double PeakPoint, LeftOffset, RightOffset;
        public FuzzyRightShoulder(double peak, double left, double right) : base(((peak + right) + peak) / 2)
        {
            this.PeakPoint = peak;
            this.LeftOffset = left;
            this.RightOffset = right;
        }

        public override double CalculateDOM(double val)
        {
            double midpoint = (PeakPoint + RightOffset) / 2;
            //double midpoint = (((PeakPoint + RightOffset) + PeakPoint) / 2);
            //double midpoint = (LeftOffset + RightOffset) / 2;
            //if (LeftOffset == 0.0 && val == midpoint)
            //    return 1.0;
            //if (val <= midpoint && (val > (midpoint - LeftOffset)))
            //    return (1.0 / LeftOffset) * (val - (midpoint - LeftOffset));
            //else if (val > midpoint)
            //    return 1.0;
            //else
            //    return 0.0;

            if (val >= PeakPoint && val <= RightOffset)
                return 1.0;
            if (val <= PeakPoint && val > LeftOffset)
                return (1.0 / (PeakPoint - LeftOffset)) * (val - LeftOffset);
            else
                return 0.0;
        }
    }
}
