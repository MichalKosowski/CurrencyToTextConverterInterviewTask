using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CurrencyToTexyConverter.Client.Wpf.Common
{
    public abstract class ValidatableViewModelBase : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];

            return null;
        }

        protected void RaiseErrorsChanged(string propertyName)
        {
            var handler = this.ErrorsChanged;
            if (handler != null)
            {
                handler(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public void UpdateErrors(string propertyName, List<string> errors)
        {
            _errors.Remove(propertyName);
            if (errors.Any())
            {
                _errors.Add(propertyName, errors);
            }
        }
    }
}
