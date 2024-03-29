﻿using System;
using System.Windows.Input;


namespace MateuszDobrowolski.UI
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public RelayCommand(Action<object> action)
        {
            _execute = action;
        }

        public RelayCommand(Action<object> action, Predicate<object> predicate)
        {
            _execute = action;
            _canExecute = predicate;
        }

        #region ICommand
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute(parameter);
            }
        }
        #endregion
    }
}
