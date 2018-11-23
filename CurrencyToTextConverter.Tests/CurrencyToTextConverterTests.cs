using CurrencyToTexyConverter.Client.Wpf.Utils;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace CurrencyToTextConverter.Tests
{
    [TestFixture]
    public class CurrencyToTextConverterTests
    {
        [TestCase(0, "zero dollars")]
        [TestCase(1, "one dollar")]
        [TestCase(25.1, "twenty-five dollars and ten cents")]
        [TestCase(0.01, "zero dollars and one cent")]
        [TestCase(45100, "forty-five thousand one hundred dollars")]
        [TestCase(999999999.99, "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents")]
        public void Convert_WillPassTaskDescriptionSamplesTest(double value, string expected)
        {
            var converter = new CurrencyToTextConverter();
            var numberParser = new NumberToCurrencyConverter();

            var result = converter.Convert(numberParser.Convert(value));

            result.Should().Be(expected);
        }

        [TestCase(1000000000)]
        public void Convert_Will_ThrowExceptionIfValueOfDollarsTooLarge(int dollars)
        {
            var converter = new CurrencyToTextConverter();

            Action conversion = () => converter.Convert(new Domain.Currency(dollars, 0));

            conversion.Should().Throw<ArgumentOutOfRangeException>().Where(e => e.Message.Contains("Maximum currency value is 999 999 999,99 dollars"));
        }
    }
}
