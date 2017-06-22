namespace WpfFirmwareDemo.WpfHelpers
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    public class RelayCommand<T> : ICommand
    {
        #region Fields

        readonly Action<T> _execute;
        readonly Predicate<T> _canExecute;
        static readonly Predicate<T> ReturnTrue = x => true;

        #endregion // Fields

        #region constructors

        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action<T> execute)
            : this(execute, ReturnTrue)
        {
        }

        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null || canExecute == null)
                throw new ArgumentNullException();

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        #endregion // ICommand Members
    }

    public class RelayCommand : RelayCommand<object>
    {
        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action execute)
            : base(execute == null ? null as Action<object> : o => execute())
        {
        }

        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action execute, Func<bool> canExecute)
            : base(execute == null ? null as Action<object> : o => execute(), canExecute == null ? null as Predicate<object> : o => canExecute())
        {
        }
    }

}
