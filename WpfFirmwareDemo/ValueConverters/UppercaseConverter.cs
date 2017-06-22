namespace WpfFirmwareDemo.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(UppercaseConverter))]
    [ValueConversion(typeof(string), typeof(string))]
    class UppercaseConverter: MarkupExtension, IValueConverter
    {
        #region fields

        #endregion

        #region constructors

        #endregion

        #region properties

        #endregion

        #region methods

        public override object ProvideValue(
            IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            var text = (string) value;
            return text?.ToUpper(culture);
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        #endregion
    }
}
