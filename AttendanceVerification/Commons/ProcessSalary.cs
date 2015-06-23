using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AttendanceVerification
{
    class ProcessSalary
    {
        ArrayList benefit;
        ArrayList deduction;
        double basicSalary;

        public ProcessSalary(ArrayList benefit, ArrayList deduction, double basicSalary)
        {
            this.benefit = benefit;
            this.deduction = deduction;
            this.basicSalary = basicSalary;
        }

        public double getTaxableIncome()
        {
            double taxableIncome = 0;
            taxableIncome += basicSalary;

            for (int i = 0; i < this.benefit.Count; i++)
            {
                taxableIncome += Convert.ToDouble(this.benefit[i]);
            }

            return taxableIncome;
        }

        public double getDeductionOnIncome()
        {
            double deduction = 0;
            
            for (int i = 0; i < this.deduction.Count; i++)
            {
                deduction += Convert.ToDouble(this.deduction[i]);
            }

            return deduction;
        }

        public double getTax(double taxableIncome, double taxrelief)
        {
            double tax = 0,taxable = 0;

            if (taxableIncome > 10165) {
            taxable = 10164;
            tax = tax + (taxable * 0.1);
            taxableIncome = taxableIncome - taxable;
            Console.Write("Tax 1: "+(taxable * 0.1));
        } else {
            taxable = taxableIncome;
            tax = tax + (taxable / 10);
             Console.Write("Tax 2: "+(taxable * 0.1));
            taxableIncome = taxableIncome - taxableIncome;
        }

        if (taxableIncome > 9576) {
            taxable = 9576;
            tax = tax + (taxable * 0.15);
            taxableIncome = taxableIncome - taxable;
             Console.Write("Tax 3: "+(taxable * 0.15));
        } else {
            taxable = taxableIncome;
            tax = tax + (taxable * 0.15);
             Console.Write("Tax 4: "+(taxable * 0.15));
            taxableIncome = taxableIncome - taxableIncome;
        }

        if (taxableIncome > 9576) {
            taxable = 9576;
            tax = tax + (taxable* 0.2);
             Console.Write("Tax 5: "+(taxable * 0.2));
            taxableIncome = taxableIncome - taxable;
        } else {
            taxable = taxableIncome;
            tax = tax + (taxable * 0.2);
             Console.Write("Tax 6: "+(taxable * 0.2));
            taxableIncome = taxableIncome - taxableIncome;
        }

        if (taxableIncome > 9576) {
            taxable = 9576;
            tax = tax + (taxable* 0.25);
             Console.Write("Tax 7: "+(taxable* 0.25));
            taxableIncome = taxableIncome - taxable;
        } else {
            taxable = taxableIncome;
            tax = tax + (taxable * 0.25);
             Console.Write("Tax 8: "+(taxable* 0.25));
            taxableIncome = taxableIncome - taxableIncome;
        }

        if (taxableIncome > 0) {
            tax = tax + (taxableIncome * 0.30);
            Console.Write("Tax 9: " + tax);
        }

        return (tax - taxrelief);
        }
    }
}
