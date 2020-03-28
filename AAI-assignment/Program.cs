using System;
using System.Windows.Forms;
using AAI_assignment.FuzzyLogic;
using AAI_assignment.FuzzyLogic.FuzzyTerms;

namespace AAI_assignment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FuzzyModule fm = new FuzzyModule();
            FuzzyVariable DistToTarget = fm.CreateFLV("DistToTarget");

            FuzzySet Target_Close = DistToTarget.AddLeftShoulderSet("Target_Close", 0, 25, 150);
            FuzzySet Target_Medium = DistToTarget.AddTriangularSet("Target_Medium", 25, 150, 300);
            FuzzySet Target_Far = DistToTarget.AddRightShoulderSet("Target_Far", 150, 300, 500);


            FuzzyVariable AmmoStatus = fm.CreateFLV("AmmoStatus");

            FuzzySet Ammo_Low = AmmoStatus.AddLeftShoulderSet("Ammo_Low", 0, 0, 10);
            FuzzySet Ammo_Medium = AmmoStatus.AddTriangularSet("Ammo_Medium", 0, 10, 30);
            FuzzySet Ammo_High = AmmoStatus.AddRightShoulderSet("Ammo_High", 10, 30, 40);

            //FuzzyVariable Desirablility = fm.CreateFLV("Desirability");

            FuzzyTermSet veryDesirable = new FuzzyTermSet();
            FuzzyTermSet desirable = new FuzzyTermSet();
            FuzzyTermSet undesirable = new FuzzyTermSet();


            fm.AddRule(new FuzzyTermAND(Target_Medium, Ammo_Medium), veryDesirable );
            fm.AddRule(new FuzzyTermAND(Target_Medium, Ammo_Low), desirable );
            fm.AddRule(new FuzzyTermAND(Target_Far, Ammo_High), desirable );
            fm.AddRule(new FuzzyTermAND(Target_Far, Ammo_Medium), desirable );
            fm.AddRule(new FuzzyTermAND(Target_Far, Ammo_Low), undesirable );

            fm.CalculateDesirability(50, 5);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
