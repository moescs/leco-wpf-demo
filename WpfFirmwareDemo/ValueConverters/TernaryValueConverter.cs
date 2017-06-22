// <copyright>Copyright © 2015 LECO® Corporation. All rights reserved.</copyright>

namespace WpfFirmwareDemo.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(TernaryValueConverter))]
    [ValueConversion(typeof(bool), typeof(object))]
    public class TernaryValueConverter: MarkupExtension, IValueConverter, IMultiValueConverter
    {
        public object TrueValue { get; set; }
        public object FalseValue { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, true)
                ? TrueValue
                : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, TrueValue);
        }

        public object Convert(
            object[] values,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            if (values.Any(v => v == DependencyProperty.UnsetValue))
                return DependencyProperty.UnsetValue;

            return Equals(values[0], true)
                ? values[1]
                : values[2];
        }

        public object[] ConvertBack(
            object value,
            Type[] targetTypes,
            object parameter,
            CultureInfo culture)
        {
            return targetTypes.Select(_ => DependencyProperty.UnsetValue).ToArray();
        }
    }
}
