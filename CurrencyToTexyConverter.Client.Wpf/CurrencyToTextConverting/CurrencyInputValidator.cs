using System;
using System.Collections.Generic;
using System.Globalization;
using System.Configuration;

namespace CurrencyToTexyConverter.Client.Wpf.CurrencyToTextConverting
{
    public class CurrencyInputValidator : ICurrencyInputValidator
    {
        public List<string> Errors { get; } = new List<string>();

        public bool Validate(string input)
        {
            Errors.Clear();

            if(string.IsNullOrEmpty(input))
            {
                Errors.Add("Currency value cannot be empty");
                return false;
            }
            if(input.Contains("."))
            {
                Errors.Add("Please use ',' as a decimal separator");
                return false;
            }
            double dValue;
            if(!Double.TryParse(input, System.Globalization.NumberStyles.Currency, CultureInfo.InvariantCulture, out dValue))
            {
                Errors.Add("Please provide a valid currency value without currency symbol.");
                return false;
            }
            var maxValue = int.Parse(ConfigurationManager.AppSettings["maxValueOfDollars"]);
            if((int)dValue > maxValue)
            {
                Errors.Add($"Maximal allowed value is {ConfigurationManager.AppSettings["maxValueOfDollars"]}");
                return false;
            }
            return true;
        }
    }
}
