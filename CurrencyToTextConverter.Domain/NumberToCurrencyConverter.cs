using CurrencyToTextConverter.Domain;

namespace CurrencyToTexyConverter.Client.Wpf.Utils
{
    public class NumberToCurrencyConverter : INumberToCurrencyConverter
    {
        public Currency Convert(double value)
        {
            return Convert((decimal)value);
        }

        public Currency Convert(decimal value)
        {
            var first2DecimalPlaces = (int)((value % 1) * 100);
            return new Currency((int)value,first2DecimalPlaces);
        }

        public Currency Convert(int value)
        {
            return new Currency(value, 0);
        }
    }
}
