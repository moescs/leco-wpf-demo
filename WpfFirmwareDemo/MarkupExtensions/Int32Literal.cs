namespace WpfFirmwareDemo.MarkupExtensions
{
    using System;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(int))]
    public class Int32LiteralExtension: MarkupExtension
    {
        public Int32LiteralExtension() {}

        public Int32LiteralExtension(int value)
        {
            Value = value;
        }

        [ConstructorArgument("value")]
        public int Value { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) => Value;
    }
}
