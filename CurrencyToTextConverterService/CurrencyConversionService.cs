using CurrencyToTextConverter.Domain;
using System.ServiceModel;

namespace CurrencyToTextConverterService
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly CurrencyToTextConverter.CurrencyToTextConverter _currencyToTextConverter = new CurrencyToTextConverter.CurrencyToTextConverter();

        public string ConvertToText(CurrencyDto currencyDto)
        {
            try
            {
                return _currencyToTextConverter.Convert(new Currency(currencyDto.Dollars, currencyDto.Cents));
            }
            catch(System.Exception ex)
            {
                throw new FaultException<CurrencyConversionFault>(new CurrencyConversionFault(ex.Message));
            }
        }
    }
}
