namespace WpfFirmwareDemo.MarkupExtensions
{
    using System;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(double))]
    public class DoubleLiteralExtension: MarkupExtension
    {
        public DoubleLiteralExtension() {}

        public DoubleLiteralExtension(double value)
        {
            Value = value;
        }

        [ConstructorArgument("value")]
        public double Value { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) => Value;
    }
}
