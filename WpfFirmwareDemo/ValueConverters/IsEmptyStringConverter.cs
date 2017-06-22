namespace WpfFirmwareDemo.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    class IsEmptyStringConverter: MarkupExtension, IValueConverter
    {
        #region fields

        #endregion

        #region constructors

        #endregion

        #region properties

        public object TrueValue { private get; set; }
        public object FalseValue { private get; set; }

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
            return string.IsNullOrEmpty(text)
                ? TrueValue
                : FalseValue;
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
