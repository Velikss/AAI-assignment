namespace AAI_assignment.FuzzyLogic.FuzzyTerms
{
    public abstract class FuzzyTerm
    {
        public abstract FuzzyTerm Clone();
        public abstract double GetDom();
        public abstract void ClearDom();
        public abstract void OrWithDom(double val);
    }
}
