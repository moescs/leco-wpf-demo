
namespace WpfFirmwareDemo
{
    using System.Windows;
    using WpfFirmwareDemo.View;
    using WpfFirmwareDemo.ViewModel;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    partial class App
    {
        protected override void OnStartup(
            StartupEventArgs e)
        {
            base.OnStartup(e);

            new MainWindow
            {
                UserControl = { DataContext = new OverViewModel() },
                ItemsView = { DataContext = new ItemsViewModel() }
            }.Show();
        }
    }
}
