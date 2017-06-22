namespace WpfFirmwareDemo.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using WpfFirmwareDemo.Annotations;

    class ViewModelBase: INotifyPropertyChanged
    {
        #region fields

        #endregion

        #region constructors

        #endregion

        #region properties

        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region methods

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
