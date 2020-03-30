using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAI_assignment.FuzzyLogic.FuzzyTerms;

namespace AAI_assignment.FuzzyLogic
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
            double d =  Antecedent.GetDom();
            Consequence.SetDom(d);
        }
    }
}
