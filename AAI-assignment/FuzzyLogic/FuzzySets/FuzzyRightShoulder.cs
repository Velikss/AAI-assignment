namespace AAI_assignment
{
    class FuzzyRightShoulder : FuzzySet
    {
        private double PeakPoint, LeftOffset, RightOffset;
        public FuzzyRightShoulder(double peak, double left, double right) : base(((peak + right) / 2))
        {
            this.PeakPoint = peak;
            this.LeftOffset = left;
            this.RightOffset = right;
        }

        public override double CalculateDOM(double val)
        {
            if (val >= PeakPoint && val <= RightOffset)
                return 1.0;
            if (val <= PeakPoint && val > LeftOffset)
                return (1.0 / (PeakPoint - LeftOffset)) * (val - LeftOffset);
            else
                return 0.0;
        }
    }
}
