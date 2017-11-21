using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public CreditCard() { }

        public CreditCard(DateTime expirattionDate, decimal limit, decimal moneyOwed)
        {
            this.ExpirationDate = expirattionDate;
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
        }

        public int CreditCardId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal Limit { get; private set; }

        public decimal MoneyOwed { get; private set; }

        public PaymentMethod PaymentMethod { get; set; }

        public decimal LimitLeft
        {
            get
            {
                return this.Limit - this.MoneyOwed;
            }
        }

        public void Deposit (decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid operation");
            }

            this.MoneyOwed -= amount;
        }

        public void Withdraw(decimal amount)
        {
            if(this.LimitLeft < amount || amount <= 0)
            {
                throw new Exception("Invalid operation");
            }

            this.MoneyOwed += amount;
        }

        public override string ToString()
        {
            return $"-- ID: {this.CreditCardId}" + Environment.NewLine +
                $"--- Limit: {this.Limit:f2}" + Environment.NewLine +
                $"--- Money Owed: {this.MoneyOwed:f2}" + Environment.NewLine +
                $"--- Limit Left: {this.LimitLeft:f2}" + Environment.NewLine +
                $"--- Expiration Date: {this.ExpirationDate.ToString("yyyy/MM")}";
        }
    }
}
