using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.FuzzyLogic.FuzzySets
{
    class FuzzyLeftShoulder : FuzzySet
    {
        private double PeakPoint, LeftOffset, RightOffset;
        public FuzzyLeftShoulder(double peak, double left, double right) : base(((peak + left) / 2))
        {
            this.PeakPoint = peak;
            this.LeftOffset = left;
            this.RightOffset = right;
        }

        public override double CalculateDOM(double val)
        {
            //if (LeftOffset == 0.0 && val == PeakPoint)
            //    return 1.0;
            //if ((val <= PeakPoint) && (val > (PeakPoint - LeftOffset)))
            //    return (1.0 - LeftOffset) * (val - (PeakPoint - LeftOffset));
            //else if (val < PeakPoint)
            //    return 1.0;
            //else
            //    return 0.0;

            //if (LeftOffset == 0.0 && val == PeakPoint)
            //    return 1.0;
            //if (val > PeakPoint && val < LeftOffset)
            //    return (1.0 / (LeftOffset - PeakPoint)) * (1);
            //else if (val < PeakPoint)
            //    return 1.0;
            //else
            //    return 0.0;

            if (val >= LeftOffset && val <= PeakPoint)
                return 1.0;
            if (val > PeakPoint && val < RightOffset)
                return (1.0 / (RightOffset - PeakPoint)) * (RightOffset - val);
            else
                return 0.0;
        }
    }
}
