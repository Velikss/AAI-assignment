﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.FuzzyLogic.FuzzySets
{
    class FuzzyTriangle : FuzzySet
    {
        private double PeakPoint, LeftOffset, RightOffset;
        public FuzzyTriangle(double mid, double left, double right) : base(mid)
        {
            this.PeakPoint = mid;
            this.LeftOffset = left;
            this.RightOffset = right;
        }

        public override double CalculateDOM(double val)
        {
            //if ((RightOffset == 0.0 && PeakPoint == val) || (LeftOffset == 0.0 && PeakPoint == val))
            //    return 1.0;
            //if ((val <= PeakPoint) && (val >= (PeakPoint - LeftOffset)))
            //    return (1.0 / LeftOffset) * (val - (PeakPoint - LeftOffset));
            //else if ((val > PeakPoint) && (val < (PeakPoint + RightOffset)) && val != RightOffset)
            //{
            //    double grad = 1.0 / -RightOffset;
            //    return grad * (val - PeakPoint) + 1.0;
            //}
            //else
            //    return 0.0;

            if (PeakPoint == val)
                return 1.0;
            if (val < PeakPoint && val > LeftOffset && LeftOffset == 0.0)
                return 1.0 / (PeakPoint) * (val - LeftOffset);
            if (val < PeakPoint && val > LeftOffset)
                return 1.0 / (PeakPoint - LeftOffset) * (val - LeftOffset);
            if (val > PeakPoint && val < RightOffset)
                return 1.0 / (RightOffset - PeakPoint) * (RightOffset - val);
            else
                return 0.0;
        }
    }
}
