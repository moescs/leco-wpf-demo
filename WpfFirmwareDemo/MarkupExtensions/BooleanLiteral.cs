namespace WpfFirmwareDemo.MarkupExtensions
{
    using System;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(bool))]
    public class BooleanLiteralExtension: MarkupExtension
    {
        public BooleanLiteralExtension() {}

        public BooleanLiteralExtension(bool value)
        {
            Value = value;
        }

        [ConstructorArgument("value")]
        public bool Value { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) => Value;
    }
}
