using CurrencyToTexyConverter.Client.Wpf.Common;
using CurrencyToTexyConverter.Client.Wpf.CurrencyConversionService;
using CurrencyToTexyConverter.Client.Wpf.Utils;
using System;
using System.ServiceModel;
using System.Windows;

namespace CurrencyToTexyConverter.Client.Wpf.CurrencyToTextConverting
{
    public class ConvertInputOutputViewModel : ValidatableViewModelBase, IConvertInputOutputViewModel
    {
        private readonly CurrencyConversionService.ICurrencyConversionService  _conversionService;
        private readonly INumberToCurrencyConverter _numberToCurrencyConverter;
        private readonly ICurrencyInputValidator _validator;

        private string _currentInput;
        private string _currentOutput;

        public ConvertInputOutputViewModel(
            CurrencyConversionService.ICurrencyConversionService conversionService, 
            INumberToCurrencyConverter numberToCurrencyConverter,
            ICurrencyInputValidator currencyInputValidator)
        {
            _conversionService = conversionService;
            _numberToCurrencyConverter = numberToCurrencyConverter;
            _validator = currencyInputValidator;
            ConvertCommand = new RelayCommand(CanConvertCurrency, Convert);
        }

        public RelayCommand ConvertCommand { get; set; }

        public string CurrentCurrencyInput
        {
            get
            {
                return _currentInput;
            }
            set
            {
                if (_currentInput != value)
                {
                    var cleanVal = CleanInputFromSpaces(value);
                    _validator.Validate(cleanVal);
                    UpdateErrors(nameof(CurrentCurrencyInput), _validator.Errors);
                    _currentInput = cleanVal;
                    RaisePropertyChanged(nameof(CurrentCurrencyInput));
                }
            }
        }

        public string CurrentConverterOutput
        {
            get
            {
                return this._currentOutput;
            }
            set
            {
                if (_currentOutput != value)
                {
                    _currentOutput = value;
                    RaisePropertyChanged(nameof(CurrentConverterOutput));
                }
            }
        }

        private bool CanConvertCurrency(object input)
        {
            return true;
        }

        private void Convert(object value)
        {
            if (this.HasErrors)
                return;

            try
            {
                var ccy = _numberToCurrencyConverter.Convert(Math.Abs(double.Parse(CurrentCurrencyInput)));
                this.CurrentConverterOutput = _conversionService.ConvertToText(new CurrencyConversionService.CurrencyDto { Dollars = ccy.Dollars, Cents = ccy.Cents });
            }
            catch(FaultException<CurrencyConversionFault> ex)
            {
                MessageBox.Show(ex.Detail.Message, "Error while converting currency value.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Other processing error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private string CleanInputFromSpaces(string input)
        {
            return input.Replace(" ", "");
        }
    }
}
