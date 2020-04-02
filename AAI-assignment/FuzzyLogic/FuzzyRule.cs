namespace AAI_assignment
{
    public class FuzzyRule
    {
        public FuzzyTerm Antecedent, Consequence;
        public FuzzyRule(FuzzyTerm antecedent, FuzzyTerm consequence)
        {
            this.Antecedent = antecedent;
            this.Consequence = consequence;
        }

        public void Calculate()
        {
            double d = Antecedent.GetDom();
            Consequence.SetDom(d);
        }
    }
}
