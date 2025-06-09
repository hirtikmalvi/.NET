using System;

namespace Practice_5
{
    abstract class Loan
    {
        public decimal LoanAmount {  get; set; }
        public float InterestRate {  get; set; }

        abstract public decimal CalculateEMI();
    }
    class HomeLoan : Loan
    {
        public override decimal CalculateEMI()
        {
            return LoanAmount * (decimal)InterestRate / 100;
        }
    }
    class CarLoan : Loan
    {
        public override decimal CalculateEMI()
        {
            return LoanAmount * (decimal)InterestRate / 100;
        }
    }
}