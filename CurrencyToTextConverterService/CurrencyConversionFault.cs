using System.Runtime.Serialization;

namespace CurrencyToTextConverterService
{
    [DataContract]
    public class CurrencyConversionFault
    {
        public CurrencyConversionFault(string message)
        {
            Message = message;
        }

        [DataMember]
        public string Message { get; set; }
    }
}
