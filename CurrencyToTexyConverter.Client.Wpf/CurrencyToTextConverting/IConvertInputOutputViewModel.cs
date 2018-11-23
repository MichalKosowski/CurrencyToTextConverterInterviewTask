using CurrencyToTexyConverter.Client.Wpf.Common;

namespace CurrencyToTexyConverter.Client.Wpf.CurrencyToTextConverting
{
    public interface IConvertInputOutputViewModel
    {
        RelayCommand ConvertCommand { get; set; }
        string CurrentConverterOutput { get; set; }
        string CurrentCurrencyInput { get; set; }
    }
}