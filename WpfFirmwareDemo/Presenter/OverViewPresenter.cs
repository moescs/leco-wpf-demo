namespace WpfFirmwareDemo.Presenter
{
    using WpfFirmwareDemo.View;
    using WpfFirmwareDemo.ViewModel;

    class OverViewPresenter
    {
        #region fields

        #endregion

        #region constructors

        #endregion

        #region properties

        #endregion

        #region methods

        public static OverView Show()
        {
            return new OverView {DataContext = new OverViewModel()};
        }

        #endregion
    }
}
