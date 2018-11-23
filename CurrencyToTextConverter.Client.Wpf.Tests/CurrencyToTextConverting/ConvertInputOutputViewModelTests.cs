using CurrencyToTexyConverter.Client.Wpf.CurrencyConversionService;
using CurrencyToTexyConverter.Client.Wpf.CurrencyToTextConverting;
using CurrencyToTexyConverter.Client.Wpf.Utils;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyToTextConverter.Client.Wpf.Tests.CurrencyToTextConverting
{
    // just few simple test for behavior, should be extended
    [TestFixture]
    public class ConvertInputOutputViewModelTests
    {
        [Test]
        public void CurrentCurrencyInput_Setter_Will_CallValidator()
        {
            var validator = Mock.Of<ICurrencyInputValidator>(v => v.Errors == new List<string>());
            var sut = new ConvertInputOutputViewModel(
                Mock.Of<ICurrencyConversionService>(), 
                Mock.Of<INumberToCurrencyConverter>(), 
                validator);

            var testInput = "12";
            sut.CurrentCurrencyInput = testInput;

            Mock.Get(validator).Verify(v => v.Validate(It.Is<string>(s => string.Equals(s, testInput))), Times.Once);
        }

        [Test]
        public void CurrentCurrencyInput_Setter_WhenInputNotValid_Will_UpdatePropertyErrorslist_And_InvalidateViewModel()
        {
            var fakeError = "test error";
            var validator = Mock.Of<ICurrencyInputValidator>(v => 
                v.Errors == new List<string> { fakeError } &&
                v.Validate(It.IsAny<string>()) == false);

            var sut = new ConvertInputOutputViewModel(
                Mock.Of<ICurrencyConversionService>(),
                Mock.Of<INumberToCurrencyConverter>(),
                validator);

            var testInput = "12";
            sut.CurrentCurrencyInput = testInput;

            sut.GetErrors(nameof(sut.CurrentCurrencyInput)).Should().NotBeEmpty();
            sut.GetErrors(nameof(sut.CurrentCurrencyInput)).As<IEnumerable<string>>().First().Should().Be(fakeError);
            sut.HasErrors.Should().BeTrue();
        }

        [Test]
        public void CurrentCurrencyInput_Setter_Will_CleanInputFromSpaces()
        {
            var validator = Mock.Of<ICurrencyInputValidator>(v => v.Errors == new List<string>());
            var sut = new ConvertInputOutputViewModel(
                Mock.Of<ICurrencyConversionService>(),
                Mock.Of<INumberToCurrencyConverter>(),
                validator);

            var testInput = "12 234,45";
            sut.CurrentCurrencyInput = testInput;

            var testInputWithoutSpaces = "12234,45";

            Mock.Get(validator).Verify(v => v.Validate(It.Is<string>(s => string.Equals(s, testInputWithoutSpaces))), Times.Once);
        }

        [Test]
        public void ConvertCommand_Will_CallConversionService()
        {
            var validator = Mock.Of<ICurrencyInputValidator>(v => v.Errors == new List<string>());
            var service = Mock.Of<ICurrencyConversionService>();
            var sut = new ConvertInputOutputViewModel(
                service,
                Mock.Of<INumberToCurrencyConverter>(c => c.Convert(It.IsAny<double>()) == new Domain.Currency(12,3)), // any dummy value
                validator);

            var testInput = "12";
            sut.CurrentCurrencyInput = testInput;

            sut.ConvertCommand.Execute(null);

            Mock.Get(service).Verify(s => s.ConvertToText(It.IsAny<CurrencyDto>()), Times.Once);
        }
    }
}
