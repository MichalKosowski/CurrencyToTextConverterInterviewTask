using CurrencyToTexyConverter.Client.Wpf.Utils;
using FluentAssertions;
using NUnit.Framework;

namespace CurrencyToTextConverter.Domain.Tests
{
    [TestFixture]
    public class NumberToCurrencyConverterTests
    {
        [TestCase(23.456, 23, 45)]
        [TestCase(3.00, 3, 0)]
        [TestCase(99876, 99876, 0)]
        [TestCase(.45996, 0, 45)]
        public void Split_CalledForDouble_Will_CorrectlySplit(double input, int @decimal, int fractional)
        {
            var splitter = new NumberToCurrencyConverter();
            var output = splitter.Convert(input);

            output.Dollars.Should().Be(@decimal);
            output.Cents.Should().Be(fractional);
        }

        [TestCase(23, 23, 0)]
        [TestCase(3, 3, 0)]
        public void Split_CalledForInt_Will_CorrectlySplit(int input, int @decimal, int fractional)
        {
            var splitter = new NumberToCurrencyConverter();
            var output = splitter.Convert(input);

            output.Dollars.Should().Be(@decimal);
            output.Cents.Should().Be(fractional);
        }

        [TestCase(23.456d, 23, 45)]
        [TestCase(3.00d, 3, 0)]
        [TestCase(99876d, 99876, 0)]
        [TestCase(.45996d, 0, 45)]
        public void Split_CalledForDecimal_Will_CorrectlySplit(decimal input, int @decimal, int fractional)
        {
            var splitter = new NumberToCurrencyConverter();
            var output = splitter.Convert(input);

            output.Dollars.Should().Be(@decimal);
            output.Cents.Should().Be(fractional);
        }
    }
}
