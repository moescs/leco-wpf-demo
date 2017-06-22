namespace WpfFirmwareDemo.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    class CornerRadiusMaskingConverter: MarkupExtension, IValueConverter
    {
        #region fields

        #endregion

        #region constructors

        #endregion

        #region properties

        public Side Sides { private get; set; }

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
            var radius = (CornerRadius) value;
            var sides = Sides;
            if ((sides & Side.TopLeft) == Side.TopLeft)
                radius.TopLeft = 0;
            if ((sides & Side.TopRight) == Side.TopRight)
                radius.TopRight = 0;
            if ((sides & Side.BottomRight) == Side.BottomRight)
                radius.BottomRight = 0;
            if ((sides & Side.BottomLeft) == Side.BottomLeft)
                radius.BottomLeft = 0;
            return radius;
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

        #region nested types

        [Flags]
        public enum Side
        {
            TopLeft = 1,
            TopRight = 2,
            BottomRight = 4,
            BottomLeft = 8
        }

        #endregion
    }
}
