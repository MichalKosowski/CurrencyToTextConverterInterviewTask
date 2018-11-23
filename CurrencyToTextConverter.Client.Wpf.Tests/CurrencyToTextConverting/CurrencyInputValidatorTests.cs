using CurrencyToTexyConverter.Client.Wpf.CurrencyToTextConverting;
using FluentAssertions;
using NUnit.Framework;
using System.Configuration;
using System.Linq;

namespace CurrencyToTextConverter.Client.Wpf.Tests.CurrencyToTextConverting
{
    [TestFixture]
    public class CurrencyInputValidatorTests
    {
        [Test]
        public void Validate_Will_TreatEmptyAndNullValue_As_Invalid()
        {
            string empty = string.Empty;
            string nullString = null;

            var validator = new CurrencyInputValidator();

            var result = validator.Validate(empty);

            result.Should().BeFalse();
            validator.Errors.Should().NotBeEmpty();
            validator.Errors.Count.Should().Be(1);

            result = validator.Validate(nullString);

            result.Should().BeFalse();
            validator.Errors.Should().NotBeEmpty();
            validator.Errors.Count.Should().Be(1);
        }

        [Test]
        public void Validate_Will_PassOnlyCommaAsDecimalSeparator()
        {
            var value = "23.4";

            var validator = new CurrencyInputValidator();

            var result = validator.Validate(value);
            result.Should().BeFalse();
            validator.Errors.Should().NotBeEmpty();
            validator.Errors.Count.Should().Be(1);
        }

        [TestCase("abs")]
        [TestCase("ten")]
        [TestCase("$123")]
        [TestCase("1,34zł")]
        public void Validate_Will_NotPassNonNumericValues(string input)
        {
            var validator = new CurrencyInputValidator();

            var result = validator.Validate(input);
            result.Should().BeFalse();
            validator.Errors.Should().NotBeEmpty();
            validator.Errors.Count.Should().Be(1);
        }

        [TestCase("999999999,99", true)]
        [TestCase("1000000000", false)]
        public void Validate_Will_CheckForMaximumAllowedValue(string input, bool expected)
        {
            var validator = new CurrencyInputValidator();

            var result = validator.Validate(input);
            result.Should().Be(expected);
            if (!expected)
            {
                validator.Errors.Should().NotBeEmpty();
                validator.Errors.Count.Should().Be(1);
            }
        }

        [TestCase("1")]
        [TestCase("1,23")]
        [TestCase("0,87")]
        [TestCase("10000034")]
        [TestCase("145453,23")]
        public void Validate_Will_CorrectlyValidateCorrectInput(string input)
        {

            var validator = new CurrencyInputValidator();

            var result = validator.Validate(input);
            result.Should().BeTrue();
            validator.Errors.Should().BeEmpty();
        }

        [Test]
        public void Validate_WhenCalled_WillClearPreviousErrorCollection()
        {
            var validator = new CurrencyInputValidator();
            validator.Errors.Should().BeEmpty();

            validator.Validate("invalid");

            validator.Errors.Count.Should().Be(1);
            var error1 = validator.Errors.First();

            validator.Validate("");

            validator.Errors.Count.Should().Be(1);
            var error2 = validator.Errors.First();

            error1.Should().NotBe(error2);

            validator.Validate("1");
            validator.Errors.Should().BeEmpty();
        }
    }
}
