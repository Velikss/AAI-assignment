namespace AAI_assignment
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
            if (val >= LeftOffset && val <= PeakPoint)
                return 1.0;
            if (val > PeakPoint && val < RightOffset)
                return (1.0 / (RightOffset - PeakPoint)) * (RightOffset - val);
            else
                return 0.0;
        }
    }
}
