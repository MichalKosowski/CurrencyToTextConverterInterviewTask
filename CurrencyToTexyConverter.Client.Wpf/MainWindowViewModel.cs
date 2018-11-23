using CurrencyToTexyConverter.Client.Wpf.CurrencyToTextConverting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyToTexyConverter.Client.Wpf
{
    public class MainWindowViewModel
    {
        public IConvertInputOutputViewModel ConvertingViewModel { get; private set; }

        public MainWindowViewModel(IConvertInputOutputViewModel convertInputOutputViewModel)
        {
            ConvertingViewModel = convertInputOutputViewModel;
        }
    }
}
