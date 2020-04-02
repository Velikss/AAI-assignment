using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Tests
{
    [TestClass]
    public class FuzzyLogicTests
    {
        [TestMethod]
        public void LectureExampleCrispValue()
        {
            // Fuzzy Module
            FuzzyModule fm = new FuzzyModule();

            // Distance to Target
            FuzzyVariable DistToTarget = fm.CreateFLV("DistToTarget", 0, 500);

            FuzzySet Target_Close = DistToTarget.AddLeftShoulderSet("Target_Close", 0, 25, 150);
            FuzzySet Target_Medium = DistToTarget.AddTriangularSet("Target_Medium", 25, 150, 300);
            FuzzySet Target_Far = DistToTarget.AddRightShoulderSet("Target_Far", 150, 300, 500);

            // Ammo Status
            FuzzyVariable AmmoStatus = fm.CreateFLV("AmmoStatus", 0, 40);

            FuzzySet Ammo_Low = AmmoStatus.AddLeftShoulderSet("Ammo_Low", 0, 0, 10);
            FuzzySet Ammo_Medium = AmmoStatus.AddTriangularSet("Ammo_Medium", 0, 10, 30);
            FuzzySet Ammo_High = AmmoStatus.AddRightShoulderSet("Ammo_High", 10, 30, 40);

            // Desirability
            FuzzyVariable Desirablility = fm.CreateFLV("Desirability", 0, 100);

            FuzzySet unDesirable = Desirablility.AddLeftShoulderSet("unDesirable", 0, 25, 50);
            FuzzySet desirable = Desirablility.AddTriangularSet("desirable", 25, 50, 75);
            FuzzySet veryDesirable = Desirablility.AddRightShoulderSet("veryDesirable", 50, 75, 100);

            // Rules
            fm.AddRule(new FuzzyTermAND(ref Target_Medium, ref Ammo_Medium), new FuzzyTermSet(ref veryDesirable, "veryDesirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Medium, ref Ammo_Low), new FuzzyTermSet(ref desirable, "desirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Far, ref Ammo_Medium), new FuzzyTermSet(ref unDesirable, "unDesirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Far, ref Ammo_Low), new FuzzyTermSet(ref unDesirable, "unDesirable"));

            // Crisp value calculation
            double crisp = fm.CalculateDesirabilityTest(200, 8);

            Assert.AreEqual(Math.Round(crisp, 2), 60.42);
        }
    }
}
