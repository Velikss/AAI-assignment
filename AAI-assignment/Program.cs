﻿using System;
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
            // Fuzzy Module
            FuzzyModule fm = new FuzzyModule();

            // Distance to target
            FuzzyVariable DistToTarget = fm.CreateFLV("DistToTarget");

            FuzzySet Target_Close = DistToTarget.AddLeftShoulderSet("Target_Close", 0, 25, 150);
            FuzzySet Target_Medium = DistToTarget.AddTriangularSet("Target_Medium", 25, 150, 300);
            FuzzySet Target_Far = DistToTarget.AddRightShoulderSet("Target_Far", 150, 300, 500);

            // Ammo Status
            FuzzyVariable AmmoStatus = fm.CreateFLV("AmmoStatus");

            FuzzySet Ammo_Low = AmmoStatus.AddLeftShoulderSet("Ammo_Low", 0, 0, 10);
            FuzzySet Ammo_Medium = AmmoStatus.AddTriangularSet("Ammo_Medium", 0, 10, 30);
            FuzzySet Ammo_High = AmmoStatus.AddRightShoulderSet("Ammo_High", 10, 30, 40);

            // Desirability
            FuzzyVariable Desirablility = fm.CreateFLV("Desirability");

            FuzzySet unDesirable = Desirablility.AddLeftShoulderSet("unDesirable", 0, 25, 50);
            FuzzySet desirable = Desirablility.AddTriangularSet("desirable", 25, 50, 75);
            FuzzySet veryDesirable = Desirablility.AddRightShoulderSet("veryDesirable", 50, 75, 100);

            // Rules
            fm.AddRule(new FuzzyTermAND(ref Target_Medium, ref Ammo_Medium), new FuzzyTermSet( ref veryDesirable, "veryD") );//
            fm.AddRule(new FuzzyTermAND(ref Target_Medium, ref Ammo_Low), new FuzzyTermSet( ref desirable, "D"));//
            //fm.AddRule(new FuzzyTermAND(ref Target_Far, ref Ammo_High), new FuzzyTermSet(ref desirable));
            fm.AddRule(new FuzzyTermAND(ref Target_Far, ref Ammo_Medium), new FuzzyTermSet(ref unDesirable, "unD"));//
            fm.AddRule(new FuzzyTermAND(ref Target_Far, ref Ammo_Low), new FuzzyTermSet(ref unDesirable, "unD"));//


            // Crisp value calculation
            double crisp = fm.CalculateDesirability(200, 8);
            Console.WriteLine(crisp);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
