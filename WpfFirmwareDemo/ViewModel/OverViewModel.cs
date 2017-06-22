namespace WpfFirmwareDemo.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Microsoft.Expression.Interactivity.Core;
    using WpfFirmwareDemo.Annotations;

    class OverViewModel: INotifyPropertyChanged
    {
        #region fields

        string _input;

        #endregion

        #region constructors

        public OverViewModel()
        {
            ClearCommand = new ActionCommand(Clear);
        }

        #endregion

        #region properties

        public ICommand ClearCommand { get; }

        public string Input
        {
            get => _input;
            set
            {
                if (_input == value)
                    return;
                _input = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region methods

        void Clear()
        {
            Input = null;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
