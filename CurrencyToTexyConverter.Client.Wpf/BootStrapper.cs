using CurrencyToTexyConverter.Client.Wpf.CurrencyToTextConverting;
using CurrencyToTexyConverter.Client.Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace CurrencyToTexyConverter.Client.Wpf
{
    public class BootStrapper
    {
        private UnityContainer _container;

        public BootStrapper()
        {
            _container = new UnityContainer();
            _container.RegisterType<CurrencyConversionService.ICurrencyConversionService, CurrencyConversionService.CurrencyConversionServiceClient>(new InjectionConstructor("BasicHttpBinding_ICurrencyConversionService"));
            _container.RegisterType<INumberToCurrencyConverter, NumberToCurrencyConverter>();
            _container.RegisterType<ICurrencyInputValidator, CurrencyInputValidator>();
            _container.RegisterType<IConvertInputOutputViewModel, ConvertInputOutputViewModel>();
            _container.RegisterType<MainWindowViewModel>();
            _container.RegisterType<MainWindow>();
        }

        public UnityContainer Container
        {
            get { return _container; }
        }
    }
}
