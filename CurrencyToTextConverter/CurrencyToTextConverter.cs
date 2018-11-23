using CurrencyToTextConverter.Domain;
using System;

namespace CurrencyToTextConverter
{
    public class CurrencyToTextConverter
    {
        private readonly NumberToTextTranslator _translator = new NumberToTextTranslator();
        private const double MaxValue = 999999999.99;

        public string Convert(Currency currencyValue)
        {
            Validate(currencyValue);

            var dollarsAsText = _translator.Convert(currencyValue.Dollars);
            var centsAsText = _translator.Convert(currencyValue.Cents);

            var dollar = IsPluralFormNeeded(currencyValue.Dollars) ? "dollars" : "dollar";
            var cent = IsPluralFormNeeded(currencyValue.Cents) ? "cents" : "cent";

            string result = $"{dollarsAsText} {dollar}";

            if(currencyValue.Cents > 0)
            {
                result = $"{result} and {centsAsText} {cent}";
            }

            return result;
        }

        private bool IsPluralFormNeeded(int value)
        {
            return value != 1;
        }

        private void Validate(Currency input)
        {
            if (input.Dollars > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(input), "Currency value too large. Maximum currency value is 999 999 999,99 dollars.");
        }
    }
}
