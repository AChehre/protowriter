namespace ProtoWriter
{
    public class ProtoStringConverter : ProtoTypeConverterBase
    {
        public const string BaseType = "string";
        public string[] SupportedTypes = {nameof(String)};

        public ProtoStringConverter(ProtoTypeConverterBase nextConvertor) : base(nextConvertor)
        {
        }

        protected override string ConvertFrom(string type)
        {
            return BaseType;
        }

        protected override bool CanHandle(string type)
        {
            return SupportedTypes.Contains(type);
        }
    }
}