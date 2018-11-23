using System.Runtime.Serialization;

namespace CurrencyToTextConverter.Domain
{
    public class Currency
    {
        public int Dollars { get; }
        public int Cents { get; }

        public Currency(int dollars, int cents)
        {
            Dollars = dollars;
            Cents = cents;
        }
    }
}
