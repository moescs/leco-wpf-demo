// <copyright>Copyright © 2013 LECO® Corporation. All rights reserved.</copyright>

namespace WpfFirmwareDemo.ValueConverters
{
    using System;
    using System.Windows.Data;
    using System.Windows.Markup;
    using System.Windows.Media;

    [MarkupExtensionReturnType(typeof(ColorToSolidColorBrushConverter))]
    [ValueConversion(typeof(Color), typeof(SolidColorBrush))]
    public class ColorToSolidColorBrushConverter : MarkupExtension, IValueConverter
    {
        float _opacity = float.NaN;

        public float Opacity
        {
            set => _opacity = Math.Min(1, Math.Max(0, value));
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null == value)
                return null;

            var color = (Color)value;
            if (!float.IsNaN(_opacity))
                color.ScA = _opacity;
            var brush = new SolidColorBrush(color);
            if (brush.CanFreeze) brush.Freeze();
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var brush = (SolidColorBrush) value;
            return brush?.Color;
        }
    }
}
