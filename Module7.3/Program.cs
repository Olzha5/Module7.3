using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7._3
{
    public class CurrencyConverter
    {
        public static decimal Convert(decimal amount, decimal exchangeRate)
        {
            return amount * exchangeRate;
        }
    }

    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money m1, Money m2)
        {
            if (m1.Currency == m2.Currency)
            {
                return new Money(m1.Amount + m2.Amount, m1.Currency);
            }
            else
            {
                
                decimal convertedAmount = CurrencyConverter.Convert(m2.Amount, 0.9m); 
                return new Money(m1.Amount + convertedAmount, m1.Currency);
            }
        }

        public static bool operator ==(Money m1, Money m2)
        {
            return m1.Amount == m2.Amount && m1.Currency == m2.Currency;
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return !(m1 == m2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Money))
                return false;

            Money moneyObj = (Money)obj;
            return Amount == moneyObj.Amount && Currency == moneyObj.Currency;
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() ^ Currency.GetHashCode();
        }
    }

}
