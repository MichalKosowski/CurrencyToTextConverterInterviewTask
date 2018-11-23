using System.ServiceModel;

namespace CurrencyToTextConverterService
{
    [ServiceContract]
    public interface ICurrencyConversionService
    {
        [OperationContract]
        [FaultContract(typeof(CurrencyConversionFault))]
        string ConvertToText(CurrencyDto value);
    }
}
