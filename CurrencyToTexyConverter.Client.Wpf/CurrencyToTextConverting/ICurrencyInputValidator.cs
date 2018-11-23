using System.Collections.Generic;

namespace CurrencyToTexyConverter.Client.Wpf.CurrencyToTextConverting
{
    public interface ICurrencyInputValidator
    {
        List<string> Errors { get; }

        bool Validate(string input);
    }
}