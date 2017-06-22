namespace WpfFirmwareDemo.MarkupExtensions
{
    using System;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(long))]
    public class Int64LiteralExtension: MarkupExtension
    {
        public Int64LiteralExtension() {}

        public Int64LiteralExtension(long value)
        {
            Value = value;
        }

        [ConstructorArgument("value")]
        public long Value { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) => Value;
    }
}
