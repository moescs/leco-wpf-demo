namespace WpfFirmwareDemo.Controls
{
    using System;
    using System.Linq.Expressions;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using WpfFirmwareDemo.WpfHelpers;

    class FancyToggleButton: ToggleButton
    {
        #region fields

        #endregion

        #region constructors

        static FancyToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FancyToggleButton),
                new FrameworkPropertyMetadata(typeof(FancyToggleButton)));
        }

        #endregion

        #region properties

        #endregion

        #region dependency properties

        public static readonly DependencyProperty UncheckedContentProperty = Register(
            x => x.UncheckedContent,
            new PropertyMetadata(default(object)));

        public object UncheckedContent
        {
            get => (object) GetValue(UncheckedContentProperty);
            set => SetValue(UncheckedContentProperty, value);
        }

        public static readonly DependencyProperty CheckedContentProperty = Register(
            x => x.CheckedContent,
            new PropertyMetadata(default(object)));

        public object CheckedContent
        {
            get => (object) GetValue(CheckedContentProperty);
            set => SetValue(CheckedContentProperty, value);
        }

        public static readonly DependencyProperty UncheckedPaddingProperty = Register(
            x => x.UncheckedPadding,
            new PropertyMetadata(default(Thickness)));

        public Thickness UncheckedPadding
        {
            get => (Thickness) GetValue(UncheckedPaddingProperty);
            set => SetValue(UncheckedPaddingProperty, value);
        }

        public static readonly DependencyProperty CheckedPaddingProperty = Register(
            x => x.CheckedPadding,
            new PropertyMetadata(default(Thickness)));

        public Thickness CheckedPadding
        {
            get => (Thickness) GetValue(CheckedPaddingProperty);
            set => SetValue(CheckedPaddingProperty, value);
        }

        public static readonly DependencyProperty UncheckedBackgroundProperty = Register(
            x => x.UncheckedBackground,
            new PropertyMetadata(default(Brush)));

        public Brush UncheckedBackground
        {
            get => (Brush) GetValue(UncheckedBackgroundProperty);
            set => SetValue(UncheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty CheckedBackgroundProperty = Register(
            x => x.CheckedBackground,
            new PropertyMetadata(default(Brush)));

        public Brush CheckedBackground
        {
            get => (Brush) GetValue(CheckedBackgroundProperty);
            set => SetValue(CheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty = Register(
            x => x.CornerRadius,
            new PropertyMetadata(default(CornerRadius)));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius) GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        //public static readonly DependencyProperty OldFashionedPropertyProperty = DependencyProperty.Register(
        //    "OldFashionedProperty",
        //    typeof(string),
        //    typeof(FancyToggleButton),
        //    new PropertyMetadata(default(string)));

        //public string OldFashionedProperty
        //{
        //    get { return (string) GetValue(OldFashionedPropertyProperty); }
        //    set { SetValue(OldFashionedPropertyProperty, value); }
        //}

        #endregion

        #region methods

        static DependencyProperty Register<TProperty>(
            Expression<Func<FancyToggleButton, TProperty>> propertyExpression,
            PropertyMetadata propertyMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            return DependencyPropertyHelpers.Register(
                propertyExpression,
                propertyMetadata,
                validateValueCallback);
        }

        #endregion
    }
}
