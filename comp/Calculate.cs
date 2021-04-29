using System;
using static System.Math;
using System.Collections.Generic;

namespace comp
{
    public class Calculate
    {
        private double amount = 0.0;
        private double amount_of_fees = 0.0;
        private double annual_interest = 0;
        private double monthly_interest = 0.0;
        private double total_fee = 0.0;

        public Calculate(double amount, double amount_of_fees, double annual_interest = 1)
        {
            this.amount = amount;
            this.annual_interest = (double)annual_interest / 100;
            this.amount_of_fees = amount_of_fees;
            this.monthly_interest = montlhyInterestCalculation();
            this.total_fee = totalFeeCalculation();
            
        }

        private double montlhyInterestCalculation()
        {
            return Pow(((double)1 + (double)this.annual_interest), ((double)1 / (double)12)) - 1;
        }

        private double totalFeeCalculation()
        {
            double total = 0.0;

            total = this.amount * this.monthly_interest;

            return (double)total / (1 - Pow((1 + (double)this.monthly_interest), this.amount_of_fees*-1));
        }

        public List<Amortization> createTable()
        {
            List<Amortization> list_amort = new List<Amortization>();

            double balance = 0;

            for (int i = 0; i <= this.amount_of_fees; i++)
            {   
                if (i == 0)
                {   
                    list_amort.Add(new Amortization(i, this.amount));
                }
                else
                {
                    double month_int = this.amount * this.monthly_interest;
                    double capital = this.total_fee - month_int;
                    balance = this.amount - capital;

                    list_amort.Add(new Amortization(i, this.amount, this.total_fee, month_int, capital, balance));

                    this.amount = balance;
                }

            }

            return list_amort;
        }

        //Getters and Setters

        public void setAmount(double x) => this.amount = x;
        public void setAmountFees(double x) => this.amount_of_fees = x; 
        public void setAnualInterest(double x) => this.annual_interest = x; 

        public double GetAmount() => this.amount;
        public double GetAmountFees() => this.amount_of_fees; 
        public double GetAnualInterest() => this.annual_interest; 
        public double GetMonthlyInterest() => this.monthly_interest; 
        public double GetTotalFee() => this.total_fee; 
        
    }
}