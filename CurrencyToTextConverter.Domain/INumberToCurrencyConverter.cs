using CurrencyToTextConverter.Domain;

namespace CurrencyToTexyConverter.Client.Wpf.Utils
{
    public interface INumberToCurrencyConverter
    {
        Currency Convert(decimal value);
        Currency Convert(double value);
        Currency Convert(int value);
    }
}