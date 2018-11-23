using System.Runtime.Serialization;

namespace CurrencyToTextConverterService
{
    [DataContract]
    public class CurrencyDto
    {
        [DataMember]
        public int Dollars { get; set; }
        [DataMember]
        public int Cents { get; set; }
    }
}
